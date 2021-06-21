#include <sstream>
#include <cstring>
#include <iostream>

#include "importDbFromCsv.h"
#include "logManager.h"
#include "benchmark.h"

using namespace std;

ImportDbFromCsv::ImportDbFromCsv(string csvPath, unsigned int keyIndex, char delimeter)
    : m_csvPath(csvPath),
      m_keyIndex(keyIndex),
      m_delimeter(delimeter)
{
}

ImportDbFromCsv::~ImportDbFromCsv()
{
}

bool ImportDbFromCsv::openCsv(std::ios_base::openmode openMode)
{
    m_csvFile.open(m_csvPath, openMode);

    if(!m_csvFile) {
        LogManager::print("ERROR", __FILE__, __LINE__, "Cannot open CSV file: " + m_csvPath);
        return false;
    }

    return true;
}

void ImportDbFromCsv::closeCsv()
{
    m_csvFile.close();
}

vector<string> ImportDbFromCsv::fetchRecord(string line)
{
    vector<string> record;
    string item;

    if (line.empty()) {
        return record;
    }

    // If line is a comment, skip it
    if (line[0] == '#') {
        return record;
    }

    stringstream ss(line);
    while(getline(ss, item, m_delimeter)) {
        record.push_back(item); 
    }

    return record;
}

bool ImportDbFromCsv::import(DbWrapper& db)
{ 
#if BENCHMARK
    Benchmark benchmark;
    benchmark.setFilePath("./../../log/benchmark_berkeley.csv");
    benchmark.startClock();
#endif

    if (!openCsv()) {
        return 0;
    }

    string line;
    vector<string> record;

    LogManager::print("INFO", __FILE__, __LINE__, "Start importing CSV record... to DB.");
    while (getline(m_csvFile, line)) {
        record = fetchRecord(line);
        if (record.size() > 0) {
            try {
                Dbt key;
                Dbt value;

                // Set key
                key.set_data((void*)record[m_keyIndex].c_str());
                key.set_size(record[m_keyIndex].length() + 1);

#if DEBUG
                LogManager::print("INFO", __FILE__, __LINE__, "Importing record of key: " + string((char*)key.get_data()));
#endif

                // Make buffer for value
                char* valueBuf = (char*)malloc(1024);
                memset(valueBuf, 0, 1024);

                size_t bufferSize = 0;
                for (size_t i = 0; i < record.size(); i++) {
                    // Values are other items, except the key
                    if (i == m_keyIndex) {
                        continue;
                    }
                    if (!makeBuffer(i, (char*)record[i].c_str(), valueBuf, bufferSize)) {
                        LogManager::print("ERROR", __FILE__, __LINE__, "Fail to make buffer for values of key: " + string((char*)key.get_data()));
                        return false;
                    }
                }

                // Set value
                value.set_data((void*)valueBuf);
                value.set_size(bufferSize);

                // Put key and values to the DB
                db.getDb()->put(nullptr, &key, &value, 0);

                free(valueBuf);
            }
            catch (const DbException &e) {
                LogManager::print("ERROR", __FILE__, __LINE__, "Fail to import key: " +  record[m_keyIndex] + "\n" + e.what());
                db.closeDb();
                return false;
            }
            catch (const std::exception &e) {
                LogManager::print("ERROR", __FILE__, __LINE__, "Fail to import key: " +  record[m_keyIndex] + "\n" + e.what());
                db.closeDb();
                return false;
            }
        }
    }

    closeCsv();

#if BENCHMARK
    double duration = benchmark.stopClock();
    benchmark.print("IMPORT", duration, "Import CSV to DB");
#endif

    LogManager::print("INFO", __FILE__, __LINE__, "Finish importing all CSV records to DB.");

    return true;
}

bool ImportDbFromCsv::makeBuffer(size_t itemIndex, char* in, char* buffer, size_t& bufferSize)
{
#if DEBUG
    size_t size_tmp = bufferSize;
#endif

    memcpy(buffer + bufferSize, in, strlen(in));        // Note: strlen, not sizeof
    bufferSize += strlen(in) + 1;

#if DEBUG
    printf("  Item of type 'char': %s. Current buffer size: %lu\n", buffer + size_tmp, bufferSize);
#endif
    return true;
}