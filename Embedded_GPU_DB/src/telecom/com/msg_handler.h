#pragma once

// Omnisci
#include "constants.h"
#include "logManager.h"

bool connectDb();
void disconnectDb();
void setExecuteMode();

void analyzeReqMsg(const char* recvMsg, char* sndByte);
void analyzeRspMsg(const char* recvMsg, char* sndByte);

void msgHandler_req_1(const char* recvMsg, char* sndByte);
void msgHandler_rsp_1(const char* recvMsg, char* sndByte);