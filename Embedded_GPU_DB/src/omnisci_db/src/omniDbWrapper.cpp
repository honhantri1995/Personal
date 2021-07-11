// C++ standard libraries
#include <iostream>

#include "omniDbWrapper.h"
#include "logManager.h"
#include "constants.h"

OmniDbWrapper::OmniDbWrapper(string serverHost, unsigned int portNo)
{
    m_socket =  make_shared<TSocket>(serverHost, portNo);
    m_transport = make_shared<TBufferedTransport>(m_socket);
    m_protocol = make_shared<TBinaryProtocol>(m_transport);
    m_client = make_shared<OmniSciClient>(m_protocol);
}

OmniDbWrapper::~OmniDbWrapper()
{
}

shared_ptr<OmniSciClient> OmniDbWrapper::getClient()
{
    return m_client;
}

bool OmniDbWrapper::connectDb(TSessionId& session, string username, string password, string dbName)
{
    try {
        m_transport->open();
        m_client->connect(session, username, password, dbName);
        LogManager::print("INFO", __FILE__, __LINE__, "Connected to DB '" + dbName + "'");
    }
    catch (TOmniSciException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to connect to DB '" + dbName + "'.\nError msg: " + e.error_msg);
        return false;
    }
    catch (TException &te) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to connect to DB '" + dbName + "'.\nError msg: " + string(te.what()));
        return false;
    }
    
    return true;
}

bool OmniDbWrapper::disconnectDb(const TSessionId& session)
{
    try {
        m_client->disconnect(session);
        m_transport->close();
        LogManager::print("INFO", __FILE__, __LINE__, "Disconnected from DB");
    }
    catch (TOmniSciException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to disconnect from DB.\nError msg: " + e.error_msg);
        return false;
    }
    catch (TException &te) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to disconnect from DB.\nError msg: " + string(te.what()));
        return false;
    }
    
    return true;
}

void OmniDbWrapper::run_sql(TQueryResult& queryResult, const TSessionId& session, string query)
{
    m_client->sql_execute(queryResult, session, query, true, "", -1, -1);
}

map<string, vector<string>> OmniDbWrapper::getRecord_str(const TQueryResult& queryResult, string columnName)
{
    vector<string> record;
    map<string, vector<string>> columResults;   // One record holds data of multiple columns
    vector<TColumn> columns = queryResult.row_set.columns;

    // Get index of selected columns
    uint colIndex;
    TRowDescriptor rowDesc = queryResult.row_set.row_desc;
    for (size_t i = 0; i < rowDesc.size(); i++) {
        if (rowDesc[i].col_name.compare(columnName) == 0) {
            colIndex = i;
            break;
        }
    }

    // Get number of records
    size_t recordNum = columns[colIndex].data.str_col.size();

    // Push all records to vector
    for (size_t i = 0; i < recordNum; i++) {
        record.push_back(columns[colIndex].data.str_col[i]);
    }
    
    // Insert all records to map
    columResults.insert({columnName, record});
    return columResults;
}

void OmniDbWrapper::printSelectedRecords(const TQueryResult& queryResult) 
{
    vector<TColumn> columns = queryResult.row_set.columns;
    
    // Get number of columns
    size_t columnNum = columns.size();
    cout << "Number of columns: " << columnNum << endl;

    // Get number of records
    // Note: A table can has data of one, or two or three type (we don't know), so we have to get all of it
    size_t dataNum_str = columns[0].data.str_col.size();
    size_t dataNum_int = columns[0].data.int_col.size();
    size_t dataNum_real = columns[0].data.real_col.size();
    size_t dataNum_array[] = { dataNum_str, dataNum_int, dataNum_real };
    size_t recordNum;
    for (auto d : dataNum_array) {
        if (d > 0) {
            recordNum = d;
            break;
        }
    }
    cout << "Number of records: " << recordNum << endl;

    // Print records line by line
    cout << endl;
    for (size_t i = 0; i < recordNum; i++) {
        for (size_t j = 0; j < columnNum; j++) {
            if (dataNum_str > 0) cout << columns[j].data.str_col[i] << ", ";
            if (dataNum_int > 0) cout << columns[j].data.int_col[i] << ", ";
            if (dataNum_real > 0) cout << columns[j].data.real_col[i] << ", ";
        }
        cout << endl;
    }
}

// void OmniDbWrapper::run_sql(TDataFrame& dataFrame, const TSessionId& session, string query)
// {
//     m_client->sql_execute_df(dataFrame, session, query, TDeviceType::GPU, D_GPU_DEVICE_ID, -1, TArrowTransport::type::WIRE);
// }