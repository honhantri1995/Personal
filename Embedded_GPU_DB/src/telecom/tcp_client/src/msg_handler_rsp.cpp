// TCP
#include "msg_handler.h"
#include "commif.h"

#include <iostream>
#include <string.h>
using namespace std;

// Common
#include "benchmark.h"

// Cuda
// #include "vectorAdd.h"

#ifdef USE_OMNISCI

    // Omnisci
    #include "omniDbWrapper.h"

    // OmnisciDb wrapper
    OmniDbWrapper* g_dbWrapper = new OmniDbWrapper(D_OMNI_HOST, D_OMNI_PORT_NO);
    TSessionId g_session;

    // Connect to OmnisciDb
    bool connectDb()
    {
        string query;
        if (g_dbWrapper->connectDb(g_session, D_USERNAME, D_PASSWORD, D_DBNAME)) {
            return true;
        }
        return false;
    }

    // Disconnect from OmnisciDb
    void disconnectDb()
    {
        g_dbWrapper->disconnectDb(g_session);
    }

    void setExecuteMode()
    {
        g_dbWrapper->getClient()->set_execution_mode(g_session, (TExecuteMode::type)g_executeMode);
    }

#else

    // Berkeley
    #include "db_phonenumber.h"

    // Berkeley wrapper
    DbWrapper* g_dbWrapper = new Db_PhoneNumber(DB_PHONENUMBER_PATH);

    // Connect to Berkeley
    bool connectDb()
    {
        if (g_dbWrapper->openDb()) {
            return true;
        }
        return false;
    }

    // Disconnect from Berkeley
    void disconnectDb()
    {
        g_dbWrapper->closeDb();
        delete g_dbWrapper;
    }

#endif

void analyzeRspMsg(const char* recvMsg, char* sndByte)
{
    CommonHeader* pHeader = (CommonHeader*)recvMsg;
    switch(pHeader->msgId)
    {
        case OPT_DATA_RSP_1:
#ifdef DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Received response: OPT_DATA_RSP_1");
#endif
            msgHandler_rsp_1(recvMsg, sndByte);
            break;

        default:
            LogManager::print("ERROR", __FILE__, __LINE__, "Received response: Inavalid ID");
            break;
    }
}

unsigned int cnt = 0;
unsigned int cnt_update = 0;
unsigned int sum = 0;
unsigned int sum_update = 0;
// Hanlder when receiving response message 1 from server
void msgHandler_rsp_1(const char* recvMsg, char* sndByte)
{
    ////////////////////////////////////////////////
    // Get record from DB
    Benchmark benchmark;
    benchmark.setFilePath("./../../log/benchmark_tcpclient.csv");
    benchmark.startClock();

#ifdef USE_OMNISCI
    TQueryResult queryResult;

    srand(time(NULL));
    uint key = rand() % 100000000;
    char buf[1024];
    sprintf(buf, "SELECT * FROM phonenumber_100M WHERE id = %d;", key);
    string query = buf;
    g_dbWrapper->getClient()->sql_execute(queryResult, g_session, query, true, "", -1, -1);
    // g_dbWrapper->printSelectedRecords(queryResult);
    
    string phone;
    map<string, vector<string>> columnResults = g_dbWrapper->getRecord_str(queryResult, "phone");    
    for (auto it = columnResults.begin(); it != columnResults.end(); ++it) {
        phone = it->second[0];
        break;
    }

#else
    char keyStr[1024];
    sprintf(keyStr, "%d", key);
    g_dbWrapper->getRecord(keyStr);
#endif

    cnt++;
    sum += benchmark.stopClock();
    if(cnt == 1) {
#ifdef USE_OMNISCI
    benchmark.writeToFile("Omnisci DB - SELECT", sum/cnt);
#else
    benchmark.writeToFile("Berkeley DB - SELECT", sum/cnt);
#endif
        cout << "Average execution time (us) - SELECT: " << sum/cnt << endl;
        sum = 0;
        cnt = 0;
    }

    ////////////////////////////////////////////////
    // Set data for request message to server
    DataReq_1 dataReq;
    dataReq.header.msgId = OPT_DATA_REQ_1;
    dataReq.header.msgLen = sizeof(DataReq_1);
    dataReq.msg.funcID = key;
    dataReq.msg.seqNo = 0;

    // addVector(rand() % 100, stoi(phone));

    /////////////////////////////////////////////////
    // Write new data to DB
    benchmark.startClock();

#ifdef USE_OMNISCI
    sprintf(buf, "UPDATE phonenumber_100M SET phone = '%s' WHERE id = %d;", phone.c_str(), key);
    query = buf;
    g_dbWrapper->getClient()->sql_execute(queryResult, g_session, query, true, "", -1, -1);
#else
#endif

    cnt_update++;
    sum_update += benchmark.stopClock();
    if(cnt_update == 1) {
#ifdef USE_OMNISCI
    benchmark.writeToFile("Omnisci DB - UPDATE", sum_update/cnt_update);
#else
    benchmark.writeToFile("Berkeley DB - UPDATE", sum_update/cnt_update);
#endif
        cout << "Average execution time (us) - UPDATE: " << sum_update/cnt_update << endl;
        sum_update = 0;
        cnt_update = 0;
    }

    memcpy(sndByte, (char*)&dataReq, sizeof(DataReq_1));
}