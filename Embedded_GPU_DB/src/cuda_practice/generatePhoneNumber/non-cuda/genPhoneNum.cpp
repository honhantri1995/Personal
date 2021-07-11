#include <stdlib.h>
#include <stdio.h>
#include <iostream>
using namespace std;

#include "benchmark.h"

#define ITEM_NUM   10000000

void createListOfRandomNumbers(int* nums, uint size, uint range)
{
    for(int count = 0; count < size; count++) {
        nums[count] = rand() % range;
    }
}

int main()
{
    printf("Sum is: \n", __LINE__, __FILE__);
    
    Benchmark benchmark;
    benchmark.startClock();
    
    srand(time(NULL));
    printf("Sum is: \n", __LINE__, __FILE__);

    // Create a list of random numbers. Range: 0 - 10
    int randomNums[ITEM_NUM];
    printf("Sum is: \n", __LINE__, __FILE__);
    createListOfRandomNumbers(randomNums, ITEM_NUM, 10);
    printf("Sum is: \n", __LINE__, __FILE__);
    
    for (int i = 0; i < ITEM_NUM; i++) {
        randomNums[i] += rand() % 10;
    }
    printf("Sum is: \n", __LINE__, __FILE__);

    
    // int num;
    // for (int i = 0; i < ITEM_NUM; i++) {
    //     num += randomNums[i];
    // }
    
    // printf("\n\nnum = %d", num);
    
    string phone = "0123456789";
    
    // // Get the last two digits from the phone number
    // char lastTwoDigits_arr[2] = { phone[phone.length()-2], phone[phone.length()-1] };
    // uint lastTwoDigits = stoi(string(lastTwoDigits_arr));
    // // Generate a random index
    // uint randomIndex = rand() % ITEM_NUM;
    // // The new last two digits = the one last two digits + random item in the list of random numbers
    // lastTwoDigits = lastTwoDigits + randomNums[randomIndex];
    // // Replace the last two digits in the original phone number by the last two digits which we just modified
    // phone = phone.substr(0, phone.size()-2);
    // phone = phone.append(to_string(lastTwoDigits));


    cout << phone << endl;


    // for(int count = 0; count < 50; count++) {
    //     printf("nums[count] = %d", nums[count]);
    // }
    // phoneNum
    // float *a, *b, *out; 
    // uint 

    // // Allocate memory
    // a   = (float*)malloc(sizeof(float) * ITEM_NUM);
    // out = (float*)malloc(sizeof(float) * ITEM_NUM);

    // // Initialize array
    // for(int i = 0; i < N; i++){
    //     a[i] = 1.0f;
    //     b[i] = 2.0f;
    // }

    // // Main function
    // vector_add(out, a, b, N);

    // // Print values
    // printf("Sum is: %f\n", out[0]);
    // printf("Number of retry is: %d\n", N);
    
    benchmark.print("Addition on CPU", benchmark.stopClock(), "");
}