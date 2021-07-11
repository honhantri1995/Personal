#pragma once
#include <ctime>
#include <string>
#include <fstream>
#include <chrono>

class Benchmark
{
private:
    std::chrono::time_point<std::chrono::high_resolution_clock> m_startTime;
    std::chrono::time_point<std::chrono::high_resolution_clock> m_endTime;
    
    std::fstream m_file;
    std::string m_filePath;

public:
    Benchmark();
    ~Benchmark();
    void startClock();
    double stopClock();
    void print(std::string operationType, double duration, std::string msg);

    void setFilePath(std::string path);
    std::string getFilePath();
    bool openFile(std::ios_base::openmode openMode);
    void closeFile();
    bool writeToFile(std::string operation, double exeTime);
};