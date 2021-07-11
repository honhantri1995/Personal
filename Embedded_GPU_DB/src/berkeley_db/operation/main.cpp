#include <iostream>
#include "db_inventory.h"
#include "db_country.h"
#include "db_phonenumber.h"
using namespace std;

int main(int argc, char *argv[])
{
    // {
        // DbWrapper* dbWrapper = new Db_Inventory(DB_INVENTORY_PATH);
        // dbWrapper->openDb();

        // // dbWrapper->getAllRecords();
        // // dbWrapper->getRecord("OranfruiRu6Ghr");
        // // dbWrapper->deleteRecord("OranfruiRu6Ghr");
        // // dbWrapper->getRecord("OranfruiRu6Ghr");

        // // dbWrapper->getRecordByValue(2, "770");
        // // dbWrapper->getRecord("Baelfruidjne4e");
        // // cout << endl << endl;
        // dbWrapper->updateRecord("AlmofruidMyKmp", 0, "AbC");
        // cout << endl << endl;
        // dbWrapper->getRecord("AlmofruidMyKmp");
        // cout << endl << endl;

        // dbWrapper->closeDb();

        // delete dbWrapper;
    // }

    // {
    //     DbWrapper* dbWrapper = new Db_Country(DB_COUNTRY_PATH);
    //     dbWrapper->openDb();

    //     // Test benchmark n times
    //     // int n = 10;
    //     // sleep(5);
    //     // for (int i = 0; i < n; i++) {

    //         // dbWrapper->getAllRecords();
    //         dbWrapper->getRecord("Bulgaria");
    //         // dbWrapper->deleteRecord("OranfruiRu6Ghr");
    //         // dbWrapper->getRecord("OranfruiRu6Ghr");

    //         // dbWrapper->getRecordByValue(2, "770");
    //         // dbWrapper->getRecord("Baelfruidjne4e");
    //         // cout << endl << endl;
    //         // dbWrapper->updateRecord("AlmofruidMyKmp", 0, "AbC");
    //         // cout << endl << endl;
    //         // dbWrapper->getRecord("AlmofruidMyKmp");
    //         // cout << endl << endl;


    //         // dbWrapper->getRecord("Comoros");
    //         // dbWrapper->getRecord("Malawi");
    //         // dbWrapper->getRecord("Portugal");
    //         // dbWrapper->getRecord("Svalbard and Jan Mayen");
    //         // dbWrapper->getRecord("Ukraine");
    //         // dbWrapper->getRecord("Yemen");
    //         // dbWrapper->getRecord("Saint Martin");
    //         // dbWrapper->getRecord("Virgin Islands British");
    //         // dbWrapper->getRecord("Chad");

    //         // dbWrapper->getRecordByValue(1, "Asia&Pacific");

    //         // dbWrapper->updateRecord("Comoros", 0, "AbC");
    //         // dbWrapper->deleteRecord("Comoros");

    //         sleep(5);

    //     // }

    //     dbWrapper->closeDb();
    //     delete dbWrapper;

    // }
    
    {
        DbWrapper* dbWrapper = new Db_PhoneNumber(DB_PHONENUMBER_PATH);
        dbWrapper->openDb();

        // dbWrapper->getAllRecords();
        dbWrapper->getRecord("1");
        // dbWrapper->deleteRecord("OranfruiRu6Ghr");
        // dbWrapper->getRecordByValue(2, "770");
        // dbWrapper->updateRecord("AlmofruidMyKmp", 0, "AbC");

        dbWrapper->closeDb();
        delete dbWrapper;

    }

    return 0;
}