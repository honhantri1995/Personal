#pragma once
#include <Windows.h>
#include <tchar.h>

#define DllExport		__declspec(dllexport)

class FileHandling
{
public:
	DllExport FileHandling();
	DllExport ~FileHandling();

	DllExport TBYTE* ReadFile(TCHAR* inFile, DWORD* outTextSize);
	DllExport bool WriteFile(TCHAR* inFile, TCHAR* inText, int inLength);

private:

};

