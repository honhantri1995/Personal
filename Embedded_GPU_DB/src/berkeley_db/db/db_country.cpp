#include <vector>
#include <cstring>
#include "db_country.h"

using namespace std;

Db_Country::Db_Country(string dbName) : DbWrapper(dbName)
{
}

Db_Country::~Db_Country()
{
}

void Db_Country::getKey(Dbt& key)
{
    char* keyBuf = (char*)key.get_data();
#if DEBUG
    printf("Key\t: %s\n", keyBuf);
#endif
}

vector<string> Db_Country::getValues(Dbt& value)
{
    char* valueBuf = (char*)value.get_data();
    size_t pos = 0;
    vector<string> valueList;

    char* tag1 = valueBuf + pos;
    pos += strlen(tag1) +1;
    valueList.emplace_back(string(tag1));
    // printf("pos: %d\n", pos);

    char* tag2 = valueBuf + pos;
    pos += strlen(tag2) +1;
    valueList.emplace_back(string(tag2));
    // printf("pos: %d\n", pos);

#if DEBUG
    // Print all values respectively
    printf("Values\t: ");
    printf("tag1 = %s, ", tag1);
    printf("tag2 = %s", tag2);
    printf("\n");
#endif

    return valueList;
}