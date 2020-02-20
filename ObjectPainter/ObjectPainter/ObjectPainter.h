#include <windows.h>
#include <tchar.h>
#include <SDKDDKVer.h>

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);
void RegisterClass_DrawingArea(void);
LRESULT CALLBACK WndProc_DrawingArea(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);
BOOL CALLBACK EnumChildProc(HWND hwndChild, LPARAM lParam);
