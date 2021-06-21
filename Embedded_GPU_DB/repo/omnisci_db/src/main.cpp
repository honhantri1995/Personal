#include "logManager.h"
#include "omniDbWrapper.h"
#include "constants.h"
#include "types.h"
#include "benchmark.h"

#include <iostream>
using namespace std;

// Arguments
#define ARGUMENT_MAX_NUM    1
uint g_mode;

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
        g_mode = TExecuteMode::GPU;     // GPU by default
    }
    else if (mode_str.compare("--gpu") == 0) {
        g_mode = TExecuteMode::GPU;
    }
    else if (mode_str.compare("--cpu") == 0) {
        g_mode = TExecuteMode::CPU;
    }
    else {
        cout << "Error: Invalid argument 1" << endl;
        help();
        return D_ERR;
    }
    
    return D_OK;
}

int main(int argc, char **argv)
{
    // For attach debug
    // sleep(10);
    
    if (validateArgs(argc, argv) != D_OK) {
        return D_ERR;
    }

    string serverHost(D_OMNI_HOST);
    unsigned int portNo = D_OMNI_PORT_NO;
    OmniDbWrapper dbWrapper(serverHost, portNo);

    string username = "admin";
    string password = "HyperInteractive";
    string dbName = "omnisci";

    TSessionId session;
    string query;
    TQueryResult queryResult;

    try
    {
        dbWrapper.connectDb(session, username, password, dbName);
        dbWrapper.getClient()->set_execution_mode(session, (TExecuteMode::type)g_mode);

        query = "SELECT * FROM phonenumber_100M where id = 80000000;";
        
        // char buf[1024];
        // string phone = "123456789";
        // sprintf(buf, "UPDATE phonenumber_100M SET phone = '%s' WHERE id = %d;", phone.c_str(), 81000000);
        // query = buf;

#if BENCHMARK
        Benchmark benchmark;
        benchmark.setFilePath("./../log/benchmark_omnisci.csv");
        benchmark.startClock();
#endif

        dbWrapper.run_sql(queryResult, session, query);

#if BENCHMARK
        benchmark.writeToFile("SELECT - Mode " + to_string(g_mode), benchmark.stopClock());
#endif

        map<string, vector<string>> columnResults;
        columnResults = dbWrapper.getRecord_str(queryResult, "phone");
        for (auto it = columnResults.begin(); it != columnResults.end(); ++it) {
            cout << "Column: " << it->first << '\n';
            cout << "Record: ";
            for (string item : it->second) {
                cout << "\t" << item << ", ";
            }
            cout << endl;
        }

        // dbWrapper.printSelectedRecords(queryResult);
        cout << "Execution time: " << queryResult.execution_time_ms << " (ms)" << endl;
    }
    catch (TOmniSciException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to query.\nError msg: " + e.error_msg);
        dbWrapper.disconnectDb(session);
        return D_ERR;
    }
    catch (TException &te) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to query.\nError msg: " + string(te.what()));
        dbWrapper.disconnectDb(session);
        return D_ERR;
    }

    return D_OK;
}
