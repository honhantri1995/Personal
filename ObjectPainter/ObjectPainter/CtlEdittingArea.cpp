#include "CtlEdittingArea.h"

HWND CtlEdittingArea::m_hThis = nullptr;

CtlEdittingArea::CtlEdittingArea()
{

}

CtlEdittingArea::~CtlEdittingArea()
{
}

bool CtlEdittingArea::OnCreate()
{
	m_hThis = CreateWindow(_T("Edit"), NULL,
		WS_CHILD | WS_VISIBLE | WS_BORDER | WS_VSCROLL | WS_HSCROLL
		| ES_LEFT | ES_MULTILINE | ES_AUTOHSCROLL | ES_AUTOVSCROLL | ES_WANTRETURN,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlEdittingArea::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis, 10, 5, inRectParent->right / 3, inRectParent->bottom - 50, TRUE);
}

HWND CtlEdittingArea::GetWindowHandler()
{
	return m_hThis;
}
