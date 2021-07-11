#include <vector>
#include <cstring>
#include "db_phonenumber.h"

using namespace std;

Db_PhoneNumber::Db_PhoneNumber(string dbName) : DbWrapper(dbName)
{
}

Db_PhoneNumber::~Db_PhoneNumber()
{
}

void Db_PhoneNumber::getKey(Dbt& key)
{
    char* keyBuf = (char*)key.get_data();
#if DEBUG
    printf("Key\t: %s\n", keyBuf);
#endif
}

vector<string> Db_PhoneNumber::getValues(Dbt& value)
{
    char* valueBuf = (char*)value.get_data();
    size_t pos = 0;
    vector<string> valueList;

    char* name = valueBuf + pos;
    pos += strlen(name) +1;
    valueList.emplace_back(string(name));

    char* phone = valueBuf + pos;
    pos += strlen(phone) +1;
    valueList.emplace_back(string(phone));

#if DEBUG
    // Print all values respectively
    printf("Values: ");
    printf("  Name = %s, ", name);
    printf("  Phone = %s", phone);
    printf("\n");
#endif

    return valueList;
}