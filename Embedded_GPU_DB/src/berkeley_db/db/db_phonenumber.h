#pragma once
#include "dbWrapper.h"

#define DB_PHONENUMBER_PATH     "/home/omnisci/gpuDb/phonenumber_100M.db"
#define CSV_PHONENUMBER_PATH    "/home/omnisci/gpuDb/phonenumber_100M.csv"

class Db_PhoneNumber : public DbWrapper
{
private:

public:
    Db_PhoneNumber(string dbName);
    ~Db_PhoneNumber();

    void getKey(Dbt& key) override;
    vector<string> getValues(Dbt& value) override;
};
