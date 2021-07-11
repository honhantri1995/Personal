#include <cstring>

#include "dbWrapper.h"
#include "logManager.h"
#include "constants.h"
#include "benchmark.h"

using namespace std;

DbWrapper::DbWrapper(string dbName)
    : m_db(nullptr),
      m_dbName(dbName)
{
    m_db = new Db(nullptr, 0);
}

DbWrapper::~DbWrapper()
{
    if (m_db) {
        delete m_db;
        m_db = nullptr;
    }
}

bool DbWrapper::openDb(DBTYPE accessMethod, unsigned int openFlag)
{
    try
    {
        m_db->open(nullptr,          // Transaction pointer
                   m_dbName.c_str(), // Database file name
                   nullptr,          // Optional logical database name
                   accessMethod,     // Database access method
                   openFlag,         // Open flags
                   0);               // File mode (using defaults)
    }
    catch (const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to open database: " + m_dbName + "\n" + e.what());
        return false;
    }
    catch (const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to open database: " + m_dbName + "\n" + e.what());
        return false;
    }

    return true;
}

bool DbWrapper::closeDb()
{
    try
    {
        m_db->close(0);
        return true;
    }
    catch (const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to close database: " + m_dbName + "\n" + e.what());
        return false;
    }
    catch (const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to close database: " + m_dbName + "\n" + e.what());
        return false;
    }
}

bool DbWrapper::getAllRecords()
{
    Dbc *cursor;
    try
    {
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif
        m_db->cursor(nullptr, &cursor, 0);

        Dbt key, value;
        int ret;

        // Initialize Dbt
        memset((void*)&key, 0, sizeof(Dbt));
        memset((void*)&value, 0, sizeof(Dbt));

        while ((ret = cursor->get(&key, &value, DB_NEXT)) == 0)
        {
            getKey(key);
            getValues(value);
        }
#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("GET", duration, "Get all records from DB");
#endif
    }
    catch (const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get all records from DB: " + m_dbName + "\n" + e.what());
        cursor->close();
        return false;
    }
    catch (const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get all records from DB: " + m_dbName + "\n" + e.what());
        cursor->close();
        return false;
    }

    cursor->close();
    return true;
}

bool DbWrapper::getRecord(string keyName)
{
    try {
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif
        Dbt key;
        memset((void*)&key, 0, sizeof(Dbt));
        Dbt value;
        memset((void*)&value, 0, sizeof(Dbt));

        key.set_data((void*)keyName.c_str());
        key.set_size(keyName.length() + 1);

        int ret = m_db->get(nullptr, &key, &value, 0);
        if (ret == D_OK) {
            getValues(value);
#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("GET", duration, "Get record of key '" + keyName + "'");
#endif
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Found '" + keyName + "'");
#endif
        }
        else {
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Not found '" + keyName + "'");
#endif
        }
    }
    catch(const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get values of key " + keyName + " from DB: " + m_dbName + "\n" + e.what());
        return false;
    }
    catch(const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get values of key " + keyName + " from DB: " + m_dbName + "\n" + e.what());
        return false;
    }

    return true;
}


bool DbWrapper::getRecordByValue(unsigned int valueIndex, string valueValue)
{
    Dbc *cursor;

    try
    {
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif
        m_db->cursor(nullptr, &cursor, 0);

        Dbt key, value;
        int ret;

        memset((void*)&key, 0, sizeof(Dbt));
        memset((void*)&value, 0, sizeof(Dbt));

        while ((ret = cursor->get(&key, &value, DB_NEXT)) == 0)
        {
            vector<string> valueList = getValues(value);
            if (valueList.at(valueIndex).compare(valueValue) == 0) {
                getKey(key);
            }
        }
#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("GET", duration, "Get key and values when item of index " + to_string(valueIndex) + " is " + valueValue);
#endif
    }
    catch (const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get record by value '" + valueValue + "' of DB: " + m_dbName + "\n" + e.what());
        cursor->close();
        return false;
    }
    catch (const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to get record by value '" + valueValue + "' of DB: " + m_dbName + "\n" + e.what());
        cursor->close();
        return false;
    }

    cursor->close();
    return true;
}

bool DbWrapper::deleteRecord(string keyName)
{
    try {
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif
        Dbt key;
        memset((void*)&key, 0, sizeof(Dbt));
        key.set_data((void*)keyName.c_str());
        key.set_size(keyName.length() + 1);

        int ret = m_db->del(nullptr, &key, 0);
        if (ret == D_OK) {
#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("DELETE", duration, "Deleted record with key '" + keyName + "'");
#endif
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Deleted '" + keyName + "'");
#endif
        }
        else {
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Not found '" + keyName + "'");
#endif
        }
    }
    catch(const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to delete record of key " + keyName + " from DB: " + m_dbName + "\n" + e.what());
        return false;
    }
    catch(const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to delete record of key " + keyName + " from DB: " + m_dbName + "\n" + e.what());
        return false;
    }

    return true;
}

// FIXME: BUG
bool DbWrapper::updateRecord(string keyName, unsigned int valueIndex, string valueValue)
{
    try {
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif
        Dbt key;
        memset((void*)&key, 0, sizeof(Dbt));
        key.set_data((void*)keyName.c_str());
        key.set_size(keyName.length() + 1);

        Dbt value;
        memset((void*)&value, 0, sizeof(Dbt));

        char* buffer = (char*)malloc(1024);
        memset(buffer, 0, 1024);
        size_t bufferSize = 0;

        int ret = m_db->get(nullptr, &key, &value, 0);
        if (ret == D_OK) {
            vector<string> valueList = getValues(value);

            // If new value and old value are the same, don't need to update
            if (valueList[valueIndex].compare(valueValue) == 0) {
                return true;
            }
            else {
                for (size_t i = 0; i < valueList.size(); i++) {
                    memcpy(buffer + bufferSize, valueList[i].c_str(), valueList[i].length());
                    bufferSize += valueList[i].length();
                }

                value.set_data((void*)buffer);
                value.set_size(bufferSize);

                m_db->put(nullptr, &key, &value, 0);
            }
#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("UPDATE", duration, "Updated record of key '" + keyName + "'");
#endif
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Updated record of key '" + keyName + "'");
#endif
        }
        else {
#if DEBUG
            LogManager::print("INFO", __FILE__, __LINE__, "Not found '" + keyName + "'");
#endif
        }

        free(buffer);

    }
    catch(const DbException &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to update record of key " + keyName + " in DB: " + m_dbName + "\n" + e.what());
        return false;
    }
    catch(const std::exception &e) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to update record of key " + keyName + " in DB: " + m_dbName + "\n" + e.what());
        return false;
    }

    return true;
}
