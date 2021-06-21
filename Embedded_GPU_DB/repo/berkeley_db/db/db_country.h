#pragma once
#include "dbWrapper.h"

#define DB_COUNTRY_PATH     "../database/country.db"
#define CSV_COUNTRY_PATH    "../database/country.csv"

class Db_Country : public DbWrapper
{
private:

public:
    Db_Country(string dbName);
    ~Db_Country();

    void getKey(Dbt& key) override;
    vector<string> getValues(Dbt& value) override;
};
