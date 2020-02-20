#include "CtlExitMainWin.h"
#include "MainWindow.h"

#define BUTTON_WIDTH	45
#define BUTTON_HEIGHT	25

CtlExitMainWin::CtlExitMainWin()
	: m_hThis(nullptr)
{

}

CtlExitMainWin::~CtlExitMainWin()
{
}

bool CtlExitMainWin::OnCreate()
{
	m_hThis = CreateWindow(_T("Button"), _T("Exit"),
		WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | BS_CENTER,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlExitMainWin::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis, inRectParent->right - BUTTON_WIDTH - 10, inRectParent->bottom - 35, BUTTON_WIDTH, BUTTON_HEIGHT, TRUE);
}

void CtlExitMainWin::OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	DestroyWindow(m_hParent);
	PostQuitMessage(0);
	MainWindow::GetInstance(m_hParent)->ReleaseInstance();
}