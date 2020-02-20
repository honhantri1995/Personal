#include "FileHandling.h"
#include "commdlg.h"

FileHandling::FileHandling()
{
}

FileHandling::~FileHandling()
{

}

TBYTE* FileHandling::ReadFile(TCHAR* inFile, DWORD* outTextSize)
{
	HANDLE hFile = CreateFile(inFile, GENERIC_READ, 0, NULL, OPEN_EXISTING, 0, NULL);
	if (hFile == INVALID_HANDLE_VALUE) {
		return 0;
	}
	DWORD textSize = GetFileSize(hFile, NULL);
	TBYTE* buf = (TBYTE*)HeapAlloc(GetProcessHeap(), HEAP_GENERATE_EXCEPTIONS, textSize + 1);
	DWORD dw;
	if (::ReadFile(hFile, (TCHAR*)buf, textSize, &dw, NULL) == FALSE) {
		CloseHandle(hFile);
		return 0;
	}

	CloseHandle(hFile);
	*outTextSize = textSize;

	return buf;
}

bool FileHandling::WriteFile(TCHAR* inFile, TCHAR* inText, int inLength)
{
	HANDLE hFile = CreateFile(inFile, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE) {
		return false;
	}

	DWORD dwWritten;
	if (::WriteFile(hFile, inText, inLength, &dwWritten, NULL) == FALSE) {
		CloseHandle(hFile);
		return false;
	}

	CloseHandle(hFile);

	return true;
}