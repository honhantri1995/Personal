#include "CtlApplyBtn.h"
#include "CtlEdittingArea.h"
#include "CtlDrawingArea.h"
#include "../DataModel/DataModel.h"

#define BUTTON_WIDTH	45
#define BUTTON_HEIGHT	25

bool CtlApplyBtn::m_isDrawn = false;

CtlApplyBtn::CtlApplyBtn()
	: m_hThis(nullptr)
{
}

CtlApplyBtn::~CtlApplyBtn()
{
}

bool CtlApplyBtn::OnCreate()
{
	m_hThis = CreateWindow(_T("Button"), _T("Apply"),
		WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | BS_CENTER,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlApplyBtn::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis,
		(inRectParent->right / 3) - BUTTON_WIDTH,
		inRectParent->bottom - 35,
		BUTTON_WIDTH,
		BUTTON_HEIGHT,
		TRUE);
}

void CtlApplyBtn::OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	// 1. Get text from Editing Area
	HWND hEdittingArea = CtlEdittingArea::GetWindowHandler();
	int len = GetWindowTextLength(hEdittingArea) + 1;	// +1 for null terminator
	if (len == 1) {
		MessageBox(NULL, _T("Please input the script!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return;
	}
	char* text = new char[len];
	GetWindowText(hEdittingArea, text, len);

	// 2. Draw shapes
	HWND hDrawingArea = CtlDrawingArea::GetWindowHandler();
	HDC hdc = GetDC(hDrawingArea);
	if (m_isDrawn) {
		// Release old script before getting new script
		DataModel::ReleaseInstance();

		// Erase all drawn shapes before drawing new shapes
		InvalidateRect(hDrawingArea, 0, TRUE);

		// Only release DC when pressing "apply" button.
		// If we release DC right after calling "Draw", PAINT event will erase all drawn shapes
		ReleaseDC(hDrawingArea, hdc);
	}
	DataModel* pDataModel = DataModel::GetInstance();
	pDataModel->Draw(text, hdc);
	delete[] text;

	m_isDrawn = true;
}

bool CtlApplyBtn::IsDrawn()
{
	return m_isDrawn;
}