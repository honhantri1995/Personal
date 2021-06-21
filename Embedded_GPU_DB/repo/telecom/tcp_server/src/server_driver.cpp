#include <iostream>
#include <signal.h>
using namespace std;

#include "tcp_server.h"
#include "commif.h"
#include "msg_handler.h"

// OmnisciDb
#include "omniDbWrapper.h"

// Common
#include "logManager.h"

#define ARGUMENT_MAX_NUM    1

// Declare the server
TcpServer g_server;
// Declare a server observer which will receive incoming messages. This server supports multiple observers
server_observer_t g_observer;

unsigned int g_executeMode;

// Observer callback. will be called for every new message received by clients
// with the requested IP address
void onIncomingMsg(const Client& client, const char* msg, size_t size)
{
    char* byteSnd = (char*)malloc(size);
    memset(byteSnd, 0, size);

    analyzeReqMsg(msg, byteSnd);
    g_server.sendToAllClients(byteSnd, size);
    
    free(byteSnd);
}

// observer callback. will be called when client disconnects
void onClientDisconnected(const Client & client)
{
    cout << "Client: " << client.getIp() << " disconnected: " << client.getInfoMessage() << endl;
}

void help()
{
    cout << "Usage: omni [execute mode]" << endl;
    cout << "  - Execute mode:" << endl;
    cout << "    --gpu: Execute DB operations using GPU (default option)" << endl;
    cout << "    --cpu: Execute DB operations using CPU" << endl;
}

int validateArgs(int argc, char **argv)
{
    // Check number of argument
    if (argc < ARGUMENT_MAX_NUM+1) {
        cout << "Error: Invalid arguments" << endl;
        help();
        return D_ERR;
    }

    // Check argument 1: Execute mode
    string mode_str = string(argv[1]);
    if (mode_str.empty()) {
        g_executeMode = TExecuteMode::GPU;     // GPU by default
    }
    else if (mode_str.compare("--gpu") == 0) {
        g_executeMode = TExecuteMode::GPU;
    }
    else if (mode_str.compare("--cpu") == 0) {
        g_executeMode = TExecuteMode::CPU;
    }
    else {
        cout << "Error: Invalid argument 1" << endl;
        help();
        return D_ERR;
    }
    
    return D_OK;
}

int main(int argc, char *argv[])
{
    // Use for attach debug
    // sleep(10);

    if (validateArgs(argc, argv) != D_OK) {
        return D_ERR;
    }

    // Start TCP server
    pipe_ret_t startRet = g_server.start(D_TCP_PORT_NO);
    if (startRet.success) {
        cout << "Server setup succeeded" << endl;
    } else {
        cout << "Server setup failed: " << startRet.msg << endl;
        return D_ERR;
    }
    
    // Connect to Omni DB
    if (!connectDb()) {
        return D_ERR;
    }
    
    // Set execute mode
    setExecuteMode();

    // Configure and register observer
    g_observer.incoming_packet_func = onIncomingMsg;
    g_observer.disconnected_func = onClientDisconnected;
    g_observer.wantedIp = "";
    g_server.subscribe(g_observer);

    // Receive clients
    while(1) {
        Client client = g_server.acceptClient(0);
        if (client.isConnected()) {
            cout << "Got client with IP: " << client.getIp() << endl;
            g_server.printClients();
        } else {
            cout << "Accepting client failed: " << client.getInfoMessage() << endl;
        }
        sleep(D_SENDING_CYCLE);
    }

    // Disconnect from Omni DB
    disconnectDb();

    return 0;
}