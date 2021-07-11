#pragma once
#include <string>
#include <fstream>
#include <vector>

#include "dbWrapper.h"

class ImportDbFromCsv
{
private:
    fstream m_csvFile;
    std::string m_csvPath;
    unsigned int m_keyIndex;
    char m_delimeter;
    
    bool openCsv(std::ios_base::openmode openMode = std::ios::in);
    void closeCsv();
    std::vector<std::string> fetchRecord(std::string line);
public:
    ImportDbFromCsv(std::string csvPath, unsigned int keyIndex = 0, char delimeter = '#');
    ~ImportDbFromCsv();

    bool import(DbWrapper& db);
    bool makeBuffer(size_t itemIndex, char* str, char* buffer, size_t& bufferSize);
};
