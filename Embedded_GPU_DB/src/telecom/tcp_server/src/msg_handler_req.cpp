#include "msg_handler.h"
#include "commif.h"

#include "benchmark.h"

#include <iostream>
#include <string.h>
using namespace std;

// OmnisciDb
#include "omniDbWrapper.h"

// Cuda
// #include "vectorAdd.h"

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
    delete g_dbWrapper;
}

void setExecuteMode()
{
    g_dbWrapper->getClient()->set_execution_mode(g_session, (TExecuteMode::type)g_executeMode);
}

void analyzeReqMsg(const char* recvMsg, char* sndByte)
{
    CommonHeader* pHeader = (CommonHeader*)recvMsg;
    switch(pHeader->msgId)
    {
        case OPT_DATA_REQ_1:
#ifdef DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Received request: OPT_DATA_REQ_1");
#endif
            msgHandler_req_1(recvMsg, sndByte);
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
// Hanlder when receiving request message 1 from client
void msgHandler_req_1(const char* recvMsg, char* sndByte)
{
    Benchmark benchmark;
    benchmark.setFilePath("./../../log/benchmark_tcpserver.csv");
    benchmark.startClock();

    ////////////////////////////////////////////////
    // Get record from DB
    TQueryResult queryResult;
    char buf[1024];
    sprintf(buf, "SELECT * FROM phonenumber_100M WHERE id = %d;", ((DataReq_1*)recvMsg)->msg.funcID);
    string query = buf;
    g_dbWrapper->getClient()->sql_execute(queryResult, g_session, query, true, "", -1, -1);

    string phone;
    map<string, vector<string>> columnResults = g_dbWrapper->getRecord_str(queryResult, "phone");    
    for (auto it = columnResults.begin(); it != columnResults.end(); ++it) {
        phone = it->second[0];
        break;
    }
    
    cnt++;
    sum += benchmark.stopClock();
    if(cnt == 1) {
        benchmark.writeToFile("Omnisci DB - SELECT", sum/cnt);
        cout << "Average execution time (us) - SELECT: " << sum/cnt << endl;
        sum = 0;
        cnt = 0;
    }

    /////////////////////////////////////////////////
    // Write new data to DB
    benchmark.startClock();
    sprintf(buf, "UPDATE phonenumber_100M SET phone = \'%s\' WHERE id = %d;", phone.c_str(), ((DataReq_1*)recvMsg)->msg.funcID);
    char buf1[1024];
    sprintf(buf1, "UPDATE phonenumber_100M SET phone = '%s' WHERE id = %d;", phone.c_str(), ((DataReq_1*)recvMsg)->msg.funcID);
    cout << string(buf1) << endl;
    query = buf;
    cout << query << endl;
    g_dbWrapper->getClient()->sql_execute(queryResult, g_session, query, true, "", -1, -1);

    cnt_update++;
    sum_update += benchmark.stopClock();
    if(cnt_update == 1) {
        benchmark.writeToFile("Omnisci DB - UPDATE", sum_update/cnt_update);
        cout << "Average execution time (us) - UPDATE: " << sum_update/cnt_update << endl;
        sum_update = 0;
        cnt_update = 0;
    }

    ////////////////////////////////////////////////
    // Set data for response messsage to client
    DataRsp_1 dataRsp;
    dataRsp.header.msgId = OPT_DATA_RSP_1;
    dataRsp.header.msgLen = sizeof(DataRsp_1);
    dataRsp.msg.data1 = ((DataReq_1*)recvMsg)->msg.funcID;
    dataRsp.msg.data2 = 0;

    // addVector(rand() % 100, stoi(phone));

    memcpy(sndByte, (char*)&dataRsp, sizeof(DataRsp_1));
}