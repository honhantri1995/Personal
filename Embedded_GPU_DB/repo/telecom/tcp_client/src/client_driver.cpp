#include <iostream>
#include <signal.h>
using namespace std;

#include "tcp_client.h"
#include "commif.h"
#include "msg_handler.h"

#ifdef USE_OMNISCI
    // Omnisci
    #include "omniDbWrapper.h"

    unsigned int g_executeMode;
#endif

TcpClient g_client;

#define ARGUMENT_MAX_NUM    1

// on sig_exit, close client
void sig_exit(int s)
{
    cout << "Closing client..." << endl;
    pipe_ret_t finishRet = g_client.finish();
    if (finishRet.success) {
        cout << "Client closed." << endl;
    } else {
        cout << "Failed to close client." << endl;
    }
    exit(0);
}

// observer callback. will be called for every new message received by the server
void onIncomingMsg(const char* msg, size_t size)
{
    char* byteSnd = (char*)malloc(size);
    memset(byteSnd, 0, size);

    analyzeRspMsg(msg, byteSnd);
    
    pipe_ret_t sendRet = g_client.sendMsg(byteSnd, ((CommonHeader*)msg)->msgLen);
    if (!sendRet.success) {
        cout << "Failed to send msg: " << sendRet.msg << endl;
        return;
    }
    
    free(byteSnd);
}

// observer callback. will be called when server disconnects
void onDisconnection(const pipe_ret_t & ret)
{
    cout << "Server disconnected: " << ret.msg << endl;
    cout << "Closing client..." << endl;
    pipe_ret_t finishRet = g_client.finish();
    if (finishRet.success) {
        cout << "Client closed." << endl;
    } else {
        cout << "Failed to close client: " << finishRet.msg << endl;
    }
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

#ifdef USE_OMNISCI
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
#endif
    
    return D_OK;
}

void sendReq_1()
{
    // Send data for request msg to server
    DataReq_1 dataReq;
    dataReq.header.msgId = OPT_DATA_REQ_1;
    dataReq.header.msgLen = sizeof(DataReq_1);
    dataReq.msg.funcID = rand() % 100000000;
    dataReq.msg.seqNo = 0;

    char sndMsg[D_MSG_MAX_LENGTH];
    memcpy(sndMsg, &dataReq, sizeof(DataReq_1));

    pipe_ret_t sendRet = g_client.sendMsg(sndMsg, sizeof(DataReq_1));
    if (!sendRet.success) {
        cout << "Failed to send msg: " << sendRet.msg << endl;
        return;
    }
}

int main(int argc, char *argv[])
{
    // Use for attach debug
    // sleep(10);

    if (validateArgs(argc, argv) != D_OK) {
        return D_ERR;
    }

    // Connect to Db
    if (!connectDb()) {
        return D_ERR;
    }

#ifdef USE_OMNISCI
    // Set execute mode
    setExecuteMode();
#endif

    // Register to SIGINT to close client when user press ctrl+c
    signal(SIGINT, sig_exit);

    // Configure and register observer
    client_observer_t observer;
    observer.wantedIp = D_TCP_HOST_IP;
    observer.incoming_packet_func = onIncomingMsg;
    observer.disconnected_func = onDisconnection;
    g_client.subscribe(observer);

    // Connect client to an open server
    pipe_ret_t connectRet = g_client.connectTo(D_TCP_HOST_IP, D_TCP_PORT_NO);
    if (connectRet.success) {
        cout << "Client connected successfully" << endl;
    } else {
        cout << "Client failed to connect: " << connectRet.msg << endl;
        return D_TCP_OK;
    }

    sendReq_1();

    while(1)
    {
        sleep(D_SENDING_CYCLE);
    }

    // Disconnect from Db
    disconnectDb();

    return 0;
}