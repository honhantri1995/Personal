#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <assert.h>

// Cuda
#include <cuda.h>
#include <cuda_runtime.h>

#include "benchmark.h"

#define N       1000000000      // 1 billion

__global__ void vector_add(float *out, float *a, float *b, int n)
{
    for(int i = 0; i < n; i ++) {
        out[i] = a[i] + b[i];
    }
}

int main()
{
    Benchmark::startClock();

    float *a, *b, *out;
    float *d_a, *d_b, *d_out; 

    // Allocate host memory
    a   = (float*)malloc(sizeof(float) * N);
    b   = (float*)malloc(sizeof(float) * N);
    out = (float*)malloc(sizeof(float) * N);

    // Initialize host arrays
    for(int i = 0; i < N; i++) {
        a[i] = 1.0f;
        b[i] = 2.0f;
    }

    // Allocate device memory
    cudaMalloc((void**)&d_a, sizeof(float) * N);
    cudaMalloc((void**)&d_b, sizeof(float) * N);
    cudaMalloc((void**)&d_out, sizeof(float) * N);

    // Transfer data from host to device memory
    cudaMemcpy(d_a, a, sizeof(float) * N, cudaMemcpyHostToDevice);
    cudaMemcpy(d_b, b, sizeof(float) * N, cudaMemcpyHostToDevice);

    // Executing kernel
    // Using 1 block, 1 thread
    // vector_add<<<1,1>>>(d_out, d_a, d_b, N);

    // Executing kernel
    // Using multiple blocks, multiple thread
    int block_size = 256;
    int grid_size = ((N + block_size) / block_size);
    vector_add<<<grid_size,block_size>>>(d_out, d_a, d_b, N);

    // FIXME: Why the same performance?

    // Transfer data back to host memory
    cudaMemcpy(out, d_out, sizeof(float) * N, cudaMemcpyDeviceToHost);

    // Print values
    printf("Sum is: %f\n", out[0]);
    printf("Number of retry is: %d\n", N);

    // Deallocate device memory
    cudaFree(d_a);
    cudaFree(d_b);
    cudaFree(d_out);

    // Deallocate host memory
    free(a); 
    free(b); 
    free(out);
    
    double duration = Benchmark::stopClock();
    Benchmark::print("Addition on GPU", duration, "");
}
