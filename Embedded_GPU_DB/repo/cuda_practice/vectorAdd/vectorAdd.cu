#include <stdlib.h>
#include <iostream>
using namespace std;

// Cuda
#include <cuda.h>
#include <cuda_runtime.h>

#include "benchmark.h"

#define ITEM_NUM       100000000      // 100 million

__global__ void _addVector(uint *result, uint *a, uint *b, int size)
{
    for(int i = 0; i < size; i ++) {
        result[i] = a[i] + b[i];
    }
}

void addVector(uint first, uint second)
{
    uint *a, *b, *result;
    uint *cd_a, *cd_b, *cd_result; 

    // Allocate host memory
    a       = (uint*)malloc(sizeof(uint) * ITEM_NUM);
    b       = (uint*)malloc(sizeof(uint) * ITEM_NUM);
    result  = (uint*)malloc(sizeof(uint) * ITEM_NUM);

    // Initialize host arrays
    for(int i = 0; i < ITEM_NUM; i++) {
        a[i] = first;
        b[i] = second;
    }

    // Allocate device memory
    cudaMalloc((void**)&cd_a, sizeof(uint) * ITEM_NUM);
    cudaMalloc((void**)&cd_b, sizeof(uint) * ITEM_NUM);
    cudaMalloc((void**)&cd_result, sizeof(uint) * ITEM_NUM);

    // Transfer data from host to device memory
    cudaMemcpy(cd_a, a, sizeof(uint) * ITEM_NUM, cudaMemcpyHostToDevice);
    cudaMemcpy(cd_b, b, sizeof(uint) * ITEM_NUM, cudaMemcpyHostToDevice);

    // Executing kernel
    // Using 1 block, 1 thread
    // _addVector<<<1,1>>>(cd_result, cd_a, cd_b, ITEM_NUM);

    // Executing kernel
    // Using multiple blocks, multiple thread
    int block_size = 256;
    int grid_size = ((ITEM_NUM + block_size) / block_size);
    _addVector<<<grid_size,block_size>>>(cd_result, cd_a, cd_b, ITEM_NUM);
    cudaDeviceSynchronize();

    // Transfer data back to host memory
    cudaMemcpy(result, cd_result, sizeof(uint) * ITEM_NUM, cudaMemcpyDeviceToHost);

    // Print result
    cout << "Sum is: " << result[0] << endl;

    // Deallocate device memory
    cudaFree(cd_a);
    cudaFree(cd_b);
    cudaFree(cd_result);

    // Deallocate host memory
    free(a); 
    free(b); 
    free(result);
}

int main()
{
    Benchmark benchmark;
    benchmark.startClock();

    addVector(123456789, 987654321);

    benchmark.print("Addition on GPU", benchmark.stopClock(), "");
}
