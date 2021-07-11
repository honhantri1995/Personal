#pragma once
#include "dbWrapper.h"

#define DB_INVENTORY_PATH       "../database/inventory.db"
#define CSV_INVENTORY_PATH      "../database/inventory.csv"

// typedef struct _Inventory {
//     // char m_key;
//     char m_name[50];
//     double m_price;
//     int m_quantity;
//     char m_category[50];
//     char m_vendor[50];
// } Inventory;


class Db_Inventory : public DbWrapper
{
private:

public:
    Db_Inventory(string dbName);
    ~Db_Inventory();

    void getKey(Dbt& key) override;
    vector<string> getValues(Dbt& value) override;
};
