#pragma once

#include <string>
#include <stdio.h>

class LogManager
{
private:
    
public:
    LogManager();
    ~LogManager();
    static void print(std::string level, std::string file, int line, std::string msg);

};