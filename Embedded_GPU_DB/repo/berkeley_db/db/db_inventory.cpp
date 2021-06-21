#include <vector>
#include <cstring>
#include "db_inventory.h"

using namespace std;

Db_Inventory::Db_Inventory(string dbName) : DbWrapper(dbName)
{
}

Db_Inventory::~Db_Inventory()
{
}

void Db_Inventory::getKey(Dbt& key)
{
    char* keyBuf = (char*)key.get_data();
#if DEBUG
    printf("Key\t: %s\n", keyBuf);
#endif
}

vector<string> Db_Inventory::getValues(Dbt& value)
{
    char* valueBuf = (char*)value.get_data();
    size_t pos = 0;
    vector<string> valueList;

    char* name = valueBuf + pos;
    pos += strlen(name) + 1;
    valueList.emplace_back(string(name));
    // printf("pos: %d\n", pos);

    char* price = valueBuf + pos;
    pos += strlen(price) + 1;
    valueList.emplace_back(string(price));
    // printf("pos: %d\n", pos);

    char* quantity = valueBuf + pos;
    pos += strlen(quantity) + 1;
    valueList.emplace_back(string(quantity));
    // printf("pos: %d\n", pos);

    char* category = valueBuf + pos;
    pos += strlen(category) + 1;
    valueList.emplace_back(string(category));
    // printf("pos: %d\n", pos);

    char* vendor = valueBuf + pos;
    pos += strlen(vendor) + 1;
    valueList.emplace_back(string(vendor));
    // printf("pos: %d\n", pos);

    // Print all values respectively
#if DEBUG
    printf("Values\t: ");
    printf("name: %s, ", name);
    printf("price: %s, ", price);
    printf("quantity: %s, ", quantity);
    printf("category: %s, ", category);
    printf("vendor: %s\n", vendor);
#endif

    return valueList;
}