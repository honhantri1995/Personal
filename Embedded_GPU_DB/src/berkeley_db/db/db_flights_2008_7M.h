#pragma once
#include "dbWrapper.h"
using namespace std;

#define DB_FLIGHTS_2008_7M_PATH    "../database/flights_2008_7M.db"
#define CSV_FLIGHTS_2008_7M_PATH    "/opt/omnisci/data/mapd_import/sample_datasets/flights_2008_7M/flights_2008_7M.csv"

// typedef struct _Country {
//     int flight_year;
//     int flight_month;
//     int flight_dayofmonth;
//     int flight_dayofweek;
//     int deptime;
//     int crsdeptime;
//     int arrtime;
//     int crsarrtime;
//     string uniquecarrier;
//     int flightnum;
//     string tailnum;
//     int actualelapsedtime;
//     int crselapsedtime;
//     int airtime;
//     int arrdelay;
//     int depdelay;
//     string origin;
//     string dest;
//     int distance;
//     int taxiin;
//     int taxiout;
//     int cancelled;
//     string cancellationcode;
//     int diverted;
//     int carrierdelay;
//     int weatherdelay;
//     int nasdelay;
//     int securitydelay;
//     int lateaircraftdelay;
//     time_t dep_timestamp;
//     time_t arr_timestamp;
//     string carrier_name;
//     string plane_type;
//     string plane_manufacturer;
//     time_t plane_issue_date;
//     string plane_model;
//     string plane_status;
//     string plane_aircraft_type;
//     string plane_engine_type;
//     int plane_year;
//     string origin_name;
//     string origin_city;
//     string origin_state;
//     string origin_country;
//     double origin_lat;
//     double origin_lon;
//     string dest_name;
//     string dest_city;
//     string dest_state;
//     string dest_country;
//     double dest_lat;
//     double dest_lon;
//     double origin_merc_x;
//     double origin_merc_y;
//     double dest_merc_x;
//     double dest_merc_y;
// } Country;


class Db_Flights_2008_7M : public DbWrapper
{
private:

public:
    Db_Flights_2008_7M(string dbName);
    ~Db_Flights_2008_7M();

    void getKey(Dbt& key) override;
    vector<string> getValues(Dbt& value) override;
};
