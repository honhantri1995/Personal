The whole project include following modules:
- telecom:
  + It includes a TCP server and a TCP client. Messages are sent between each other.
  + This is the main part of the project. It uses the berkeley_db and omnisci_db as dynamic libraries
  
- berkeley_db:
  + It is a wrapper for BerkeleyDB. It contains basic APIs (connect, disconnect, get, set, delete, etc.) to work with the BerkeleyDB.
  + It is used in the "telecom" module as dynamic library.

- omnisci_db:
  + It is a wrapper for OmnisciDB. It contains basic APIs (connect, disconnect, select, update, delete, etc.) to work with the OmnisciDB.
  + It is used in the "telecom" module as dynamic library.


Environment:
Linux