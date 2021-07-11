#pragma once
#include <string>
#include <vector>

#include <db_cxx.h>
using namespace std;

class DbWrapper
{
private:

protected:
    Db* m_db;
    string m_dbName;
    Dbt m_key;
    Dbt m_value;

public:
    DbWrapper(string dbName);
    ~DbWrapper();

    Db* getDb() const { return m_db; };
    string getDbName() const { return m_dbName; }

    bool openDb(DBTYPE accessMethod = DB_BTREE, unsigned int openFlag = DB_CREATE);
    bool closeDb();

    virtual bool getAllRecords();
    virtual bool getRecord(string keyName);
    virtual bool getRecordByValue(unsigned int valueIndex, string valueValue);

    // Note: Must use these methods as PURE VIRTUAL
    virtual void getKey(Dbt& key) {};
    virtual std::vector<std::string> getValues(Dbt& value) {return std::vector<std::string>();};

    virtual bool deleteRecord(string keyName);
    virtual bool updateRecord(string keyName, unsigned int valueIndex, string valueValue);

};