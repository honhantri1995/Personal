#include <experimental/filesystem>

#include "constants.h"
#include "logManager.h"
#include "importDbFromCsv.h"
#include "db_inventory.h"
#include "db_country.h"
#include "db_flights_2008_7M.h"

using namespace std;

#define ARGUMENT_MAX_NUM    3
string g_csvFilePath;
string g_dbFilePath;
char g_delimeter;

void help()
{
    cout << "Usage: db_importer [CSV file path] [Berkeley DB file path] [Delimeter] " << endl;
    cout << "  - CSV file path [input]: Specify the path to your CSV file which holding your DB." << endl;
    cout << "  - Berkeley file path [output]: Specify the path to your Berkeley DB file." << endl;
    cout << "  - Delimeter: Specify the delimeter used in the CSV file." << endl;
    cout << "    Can be: 'comma' or 'pipe'. By default, use 'comma'" << endl;
}

int validateArgs(int argc, char **argv)
{
    // Check number of argument
    if (argc < ARGUMENT_MAX_NUM+1) {
        cout << "Error: Invalid arguments" << endl;
        help();
        return D_ERR;
    }

    // Set CSV file path
    if (argv[1] == nullptr) {
        cout << "Error: Invalid argument #1" << endl;
        help();
        return D_ERR;
    }
    g_csvFilePath = string(argv[1]);

    // Set Berkeleyy DB file path
    if (argv[2] == nullptr) {
        cout << "Error: Invalid argument #2" << endl;
        help();
        return D_ERR;
    }
    g_dbFilePath = string(argv[2]);

    // Set delimeter used in CSV file
    if (argv[3] == nullptr) {
        cout << "Error: Invalid argument #3" << endl;
        help();
        return D_ERR;
    }
    else {
        string deli = string(argv[3]);
        if (deli.compare("comma") == 0) {
            g_delimeter = ',';
        }
        else if (deli.compare("pipe") == 0) {
            g_delimeter = '|';
        }
        else {
            cout << "Error: Invalid argument #3: " << deli << endl;
            help();
            return D_ERR;
        }
    }

    return D_OK;
}

int main(int argc, char *argv[])
{
    if (validateArgs(argc, argv) != D_OK) {
        return D_ERR;
    }

    {
        // Check if the .db file exists. If so, delete it before create a new one
        if (std::experimental::filesystem::exists(g_dbFilePath)) {
            unlink(g_dbFilePath.c_str());
            LogManager::print("INFO", __FILE__, __LINE__, string(g_dbFilePath) + " already exists, so deleted it before creating new one.");
        }

        ImportDbFromCsv importer(g_csvFilePath, 0, g_delimeter);
        DbWrapper db(g_dbFilePath);
        if ( db.openDb(DB_BTREE, DB_CREATE) ) {
            if ( !importer.import(db) ) {
                LogManager::print("ERROR", __FILE__, __LINE__, "Fail to import DB " + string(g_dbFilePath));
            }
            db.closeDb();
        }
    }

    return 0;
}