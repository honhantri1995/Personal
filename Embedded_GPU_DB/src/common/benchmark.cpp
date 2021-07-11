#include <iostream>
#include <vector>
#include <time.h> 
#include "benchmark.h"
using namespace std;

Benchmark::Benchmark()
{
}

Benchmark::~Benchmark()
{
}

void Benchmark::startClock()
{
    m_startTime = chrono::high_resolution_clock::now();
}

double Benchmark::stopClock()
{
    m_endTime = chrono::high_resolution_clock::now();

    double duration = chrono::duration_cast<chrono::nanoseconds>(m_endTime - m_startTime).count();
    // duration *= 1e-9;     // Second
    // duration *= 1e-6;     // Milli-second
    duration *= 1e-3;        // Micro-second
    return duration;
}

void Benchmark::print(string operationType, double duration, string msg)
{
    char log[1024] = {0};
    sprintf(log, "[BENCHMARK] [%s] \t %s:\t%lf (us)", operationType.c_str(),  msg.c_str(), duration);
    cout << log << endl;
}

void Benchmark::setFilePath(string path)
{
    m_filePath = path;
}

string Benchmark::getFilePath()
{
    return m_filePath;
}

bool Benchmark::openFile(std::ios_base::openmode openMode)
{
    m_file.open(m_filePath, openMode);
    if(!m_file) {
        cout << "ERROR: Cannot open performance log file: " << m_filePath << "." << endl;
        return false;
    }
    return true;
}

void Benchmark::closeFile()
{
    m_file.close();
}

bool Benchmark::writeToFile(string operation, double exeTime)
{
    if (!openFile(ios::in | ios::out | ios::app)) {
        return false;
    }

    // Get current time
    time_t now = time(0);
    struct tm tstruct = *localtime(&now);
    char time[80];
    strftime(time, sizeof(time), "%Y-%m-%d %X", &tstruct);

    // Items in line. Write by order.
    vector<string> line = {string(time), operation, to_string(exeTime)};

    m_file << "\n";
    for (size_t i = 0; i < line.size(); i++) {
        if (i > 0) {
            m_file << ",";
        }
        m_file << line[i];
    }

    closeFile();

    return true;
}