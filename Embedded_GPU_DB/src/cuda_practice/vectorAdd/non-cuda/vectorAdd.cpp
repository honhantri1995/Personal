#include <iostream>
using namespace std;

#include "benchmark.h"

#define ITEM_NUM   100000000    // 100 million

void _vector_add(uint *result, uint *a, uint *b, int size)
{
    for(int i = 0; i < size; i ++) {
        result[i] = a[i] + b[i];
    }
}

void addVector(uint first, uint second)
{
    uint *a, *b, *result; 

    // Allocate memory
    a       = (uint*)malloc(sizeof(uint) * ITEM_NUM);
    b       = (uint*)malloc(sizeof(uint) * ITEM_NUM);
    result  = (uint*)malloc(sizeof(uint) * ITEM_NUM);

    // Initialize array
    for(int i = 0; i < ITEM_NUM; i++){
        a[i] = first;
        b[i] = second;
    }

    // Main function
    _vector_add(result, a, b, ITEM_NUM);

    // Print result
    cout << "Sum is: " << result[0] << endl;
}

int main()
{
    Benchmark benchmark;
    benchmark.startClock();

    addVector(123456789, 987654321);

    benchmark.print("Addition on CPU", benchmark.stopClock(), "");
}