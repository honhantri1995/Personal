#include <Windows.h>
#include <tchar.h>
#include "CtlBase.h"
#include "MainWindow.h"

HWND hwnd;
CtlBase* pCtlBase;

int WINAPI wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR pCmdLine, _In_ int nCmdShow);
LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);
BOOL CALLBACK EnumChildProc(HWND hwndChild, LPARAM lParam);

int WINAPI wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR pCmdLine, _In_ int nCmdShow)
{
	// Step 1: Registering the Window Class
	WNDCLASSEX wc = { 0 };
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = CS_HREDRAW | CS_VREDRAW;				// Redraw if size changes
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);	// Default color value for main application window
	wc.lpszMenuName = NULL;							// No menu for this app
	wc.lpszClassName = _T("ObjectPainter_Class");
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	// If registering class fails
	if (!RegisterClassEx(&wc)) {
		MessageBox(NULL, _T("Register window class failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return 0;
	}

	// Step 2: Creating the window
	hwnd = CreateWindowEx(
		WS_EX_CLIENTEDGE,			// The window has a border with a sunken edge
		_T("ObjectPainter_Class"),
		_T("Object Painter"),		// Window title
		WS_VISIBLE
		| WS_OVERLAPPEDWINDOW		// Top-level window with a title bar, border, and client area (meant to serve as an application's main window)
		| WS_MAXIMIZE | WS_CLIPCHILDREN,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		NULL,				// No owner window
		NULL,				// No menu
		hInstance,
		NULL);				// No window-creation data

	// If window creation fails
	if (!hwnd) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return 0;
	}
	ShowWindow(hwnd, SW_SHOW);
	UpdateWindow(hwnd);

	// Step 3: The message loop
	MSG Msg;
	while (GetMessage(&Msg, NULL, 0, 0)) {
		TranslateMessage(&Msg);
		DispatchMessageW(&Msg);
	}

	return Msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	MainWindow* pMainWindow = MainWindow::GetInstance(hwnd);

	switch (msg)
	{
	case WM_CLOSE:
		DestroyWindow(hwnd);
		pMainWindow->ReleaseInstance();
		break;

	case WM_DESTROY:
		PostQuitMessage(0);
		break;

	case WM_CREATE:
		pMainWindow->CreateControls();
		break;

	case WM_SIZE:
		// Retrieve coordinates of window's client area
		RECT rectClient;
		GetClientRect(hwnd, &rectClient);
		// Enumerate child windows that belong to the specified parent window by passing the handle to each child window
		EnumChildWindows(hwnd, EnumChildProc, (LPARAM)& rectClient);
		break;

	case WM_COMMAND:
		pMainWindow->CommandControls(msg, wParam, lParam);
		break;

	default:
		return DefWindowProc(hwnd, msg, wParam, lParam);
	}

	return 0;
}

BOOL CALLBACK EnumChildProc(HWND hwndChild, LPARAM lParam)
{
	MainWindow* pPageMain = MainWindow::GetInstance(hwnd);

	// Get coordinates of parent window
	LPRECT rectParent = (LPRECT)lParam;

	pPageMain->ResizeControls(rectParent);

	ShowWindow(hwndChild, SW_SHOW);

	return TRUE;
}