#include "CtlDrawingArea.h"
#include "CtlApplyBtn.h"
#include "../DataModel/DataModel.h"

HWND CtlDrawingArea::m_hThis = nullptr;

CtlDrawingArea::CtlDrawingArea()
{
}

CtlDrawingArea::~CtlDrawingArea()
{
}

bool CtlDrawingArea::OnRegister()
{
	WNDCLASS wc = { 0 };

	wc.lpszClassName = _T("DrawingArea_Class");
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wc.lpfnWndProc = WndProc;
	wc.hCursor = LoadCursor(0, IDC_ARROW);

	if (!RegisterClass(&wc)) {
		MessageBox(NULL, _T("Register window class failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

bool CtlDrawingArea::OnCreate()
{
	this->OnRegister();

	m_hThis = CreateWindow(_T("DrawingArea_Class"), NULL,
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlDrawingArea::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis,
			  (inRectParent->right / 3) + 20,
			  5,
			  (inRectParent->right) - (inRectParent->right / 3) - 30,
			  inRectParent->bottom - 50,
			  TRUE);
}

HWND CtlDrawingArea::GetWindowHandler()
{
	return m_hThis;
}

LRESULT CALLBACK CtlDrawingArea::WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	CtlDrawingArea* pThis = (CtlDrawingArea*)GetWindowLongPtr(hwnd, GWLP_USERDATA);

	if (msg == WM_CREATE)
	{
		pThis = new CtlDrawingArea();
		SetWindowLongPtr(hwnd, GWLP_USERDATA, (LONG)pThis);
	}
	else if (msg == WM_DESTROY)
	{
		pThis = (CtlDrawingArea*)GetWindowLongPtr(hwnd, GWLP_USERDATA);
		SetWindowLongPtr(hwnd, GWLP_USERDATA, NULL);
		delete pThis;
		pThis = NULL;
	}
	else {
		pThis = (CtlDrawingArea*)(GetWindowLongPtr(hwnd, GWLP_USERDATA));
	}

	if (pThis) {
		switch (msg)
		{
			case WM_PAINT:
			{
				PAINTSTRUCT ps;
				BeginPaint(hwnd, &ps);
				BeginPaint(pThis->m_hThis, &ps);

				if (CtlApplyBtn::IsDrawn()) {
					DataModel* pDataModel = DataModel::GetInstance();
					pDataModel->ReDrawOnPAINTEvent();
				}

				EndPaint(pThis->m_hThis, &ps);
				EndPaint(hwnd, &ps);

				break;
			}
		}
	}

	return DefWindowProcW(hwnd, msg, wParam, lParam);
}