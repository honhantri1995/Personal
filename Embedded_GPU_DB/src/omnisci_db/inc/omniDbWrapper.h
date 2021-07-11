#pragma once

// C++ standard libraries
#include <cstdint>
#include <cstdlib>
#include <string>
#include <map>
#include <vector>
using namespace std;

// OmnisciDb
#include "OmniSci.h"    // In folder 'gen-cpp'

// Thrift
#include <thrift/protocol/TBinaryProtocol.h>
#include <thrift/transport/TBufferTransports.h>
#include <thrift/transport/TSocket.h>
using namespace ::apache::thrift;
using namespace ::apache::thrift::protocol;
using namespace ::apache::thrift::transport;

class OmniDbWrapper
{
private:
    shared_ptr<TSocket> m_socket;
    shared_ptr<TTransport> m_transport;
    shared_ptr<TProtocol> m_protocol;
    shared_ptr<OmniSciClient> m_client;

public:
    OmniDbWrapper(string serverHost, unsigned int portNo);
    ~OmniDbWrapper();
    
    // Getter
    shared_ptr<OmniSciClient> getClient();
    
    bool connectDb(TSessionId& session, string username, string password, string dbName);
    bool disconnectDb(const TSessionId& session);
    
    void run_sql(TQueryResult& queryResult, const TSessionId& session, string query);
    map<string, vector<string>> getRecord_str(const TQueryResult& queryResult, string columnName);
    void printSelectedRecords(const TQueryResult& queryResult);
//  void run_sql(TDataFrame& dataFrame, const TSessionId& session, string query);

};