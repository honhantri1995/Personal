#pragma once

typedef enum EM_COMM_MSG_TYPE{
	OPT_DATA_REQ_1		= 0x3001,
	OPT_DATA_RSP_1		= 0x3002,
}EM_COMM_MSG_TYPE;

typedef struct CommonHeader
{
	uint msgId;
	uint msgLen;
} CommonHeader;

//////////////////////////////////////////
// Request 1
typedef struct BodyDataReq_1 {
	uint funcID;
	uint seqNo;
} BodyDataReq_1;

typedef struct DataReq_1{
	CommonHeader header;
	BodyDataReq_1 msg;
} DataReq_1;

// Response 1
typedef struct BodyDataRsp_1 {
	uint ok_ng;
	uint ngCode;
    uint data1;
    uint data2;
} BodyDataRsp_1;

typedef struct DataRsp_1 {
	CommonHeader header;
	BodyDataRsp_1 msg;
} DataRsp_1;
//////////////////////////////////////////

extern unsigned int g_executeMode;
