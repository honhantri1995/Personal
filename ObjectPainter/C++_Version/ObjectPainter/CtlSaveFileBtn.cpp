#include "CtlSaveFileBtn.h"
#include "../FileHandling/FileHandling.h"
#include "CtlEdittingArea.h"

#define BUTTON_WIDTH	45
#define BUTTON_HEIGHT	25

CtlSaveFileBtn::CtlSaveFileBtn()
	: m_hThis(nullptr)
{
}

CtlSaveFileBtn::~CtlSaveFileBtn()
{
}

bool CtlSaveFileBtn::OnCreate()
{
	m_hThis = CreateWindow(_T("Button"), _T("Save"),
		WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | BS_CENTER,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlSaveFileBtn::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis,
		(inRectParent->right - BUTTON_WIDTH - 10) - BUTTON_WIDTH - 20,
		inRectParent->bottom - 35,
		BUTTON_WIDTH,
		BUTTON_HEIGHT,
		TRUE);
}

void CtlSaveFileBtn::OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	// Get file content from window
	CtlEdittingArea ctlEdittingArea;
	HWND edittingAreaHandler = ctlEdittingArea.GetWindowHandler();
	int len = GetWindowTextLength(edittingAreaHandler) + 1;
	TCHAR* text = new TCHAR[len];
	GetWindowText(edittingAreaHandler, text, len);

	this->SaveFile(text, len);
	delete[] text;
}

void CtlSaveFileBtn::SaveFile(TCHAR* inText, int inLength)
{
	OPENFILENAME ofn;
	TCHAR szFile[MAX_PATH];

	// Must free the memory region of OPENFILENAMEW first. Else, cannot start the dialog box
	ZeroMemory(&ofn, sizeof(OPENFILENAME));

	ofn.lStructSize = sizeof(OPENFILENAME);
	ofn.lpstrFile = szFile;			// File name used to initialize the File Name edit control
	ofn.lpstrFile[0] = '\0';		// The first character of lpstrFile buffer must be NULL if initialization is not necessary
	ofn.hwndOwner = m_hParent;		// The parent window of this dialog
	ofn.nMaxFile = sizeof(szFile);
	ofn.lpstrFilter = TEXT("Configuration(*.ini)\0*.ini\0*.*\0");
	ofn.nFilterIndex = 1;			// The File Types control initially displays 'All files(*.*)'
	ofn.lpstrInitialDir = NULL;
	ofn.lpstrFileTitle = NULL;
	ofn.lpstrDefExt = _T("ini");	// Automatically pick ini file if users forget to type the file extension
	ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST | OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT;

	if (GetSaveFileName(&ofn) == TRUE) {
		FileHandling* pFileHandling = new FileHandling();
		pFileHandling->WriteFile(ofn.lpstrFile, inText, inLength);
		delete pFileHandling;
	}
}