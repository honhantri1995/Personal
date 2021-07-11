#include <iostream>
#include "logManager.h"
using namespace std;

LogManager::LogManager()
{
}

LogManager::~LogManager()
{
}

void LogManager::print(string level, string file, int line, string msg)
{
    char log[1024] = {0};
    sprintf(log, "[%s] [%s:%d] %s", level.c_str(), file.c_str(), line, msg.c_str());
    cout << log << endl;
}