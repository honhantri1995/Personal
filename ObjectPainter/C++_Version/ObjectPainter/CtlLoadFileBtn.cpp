#include "CtlLoadFileBtn.h"
#include "../FileHandling/FileHandling.h"
#include "CtlEdittingArea.h"

#define BUTTON_WIDTH	45
#define BUTTON_HEIGHT	25

CtlLoadFileBtn::CtlLoadFileBtn()
	: m_hThis(nullptr)
{
}

CtlLoadFileBtn::~CtlLoadFileBtn()
{
}

bool CtlLoadFileBtn::OnCreate()
{
	m_hThis = CreateWindow(_T("Button"), _T("Load from file"),
		WS_CHILD | WS_VISIBLE | BS_DEFPUSHBUTTON | BS_CENTER,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		m_hParent, (HMENU)m_ctlID, NULL, NULL);

	if (!m_hThis) {
		MessageBox(NULL, _T("Window creation failed!"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CtlLoadFileBtn::OnResize(LPRECT inRectParent)
{
	MoveWindow(m_hThis,
			  (inRectParent->right / 3) - BUTTON_WIDTH - (BUTTON_WIDTH + 55) - 20,
			   inRectParent->bottom - 35,
			   BUTTON_WIDTH + 55,
			   BUTTON_HEIGHT,
			   TRUE);
}

void CtlLoadFileBtn::OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	CtlEdittingArea ctlEdittingArea;
	HWND hEdittingArea = ctlEdittingArea.GetWindowHandler();

	// If editing area is empty, display dialog for opening file
	if ((GetWindowTextLength(hEdittingArea) == 0)) {
		this->LoadFileAndSetText(hEdittingArea);
	}
	// Else, display message box to warm the user before reloading the script
	else {
		if (MessageBox(NULL, _T("Do you want to reload your script?"), _T("WARNING"),
			MB_ICONQUESTION | MB_OKCANCEL) == IDOK) {
			this->LoadFileAndSetText(hEdittingArea);
		}
	}
}

void CtlLoadFileBtn::LoadFileAndSetText(HWND inHTarget)
{
	OPENFILENAME ofn;
	TCHAR szFile[MAX_PATH];

	// Must free the memory region of OPENFILENAME first. Else, cannot start the dialog box
	ZeroMemory(&ofn, sizeof(OPENFILENAME));

	ofn.lStructSize = sizeof(OPENFILENAME);
	ofn.lpstrFile = szFile;			// File name used to initialize the File Name edit control
	ofn.lpstrFile[0] = '\0';
	ofn.hwndOwner = m_hParent;
	ofn.nMaxFile = sizeof(szFile);
	ofn.lpstrFilter = TEXT("Configuraton file(*.ini)\0*.ini\0*.art\0All files(*.*)\0*.*\0");	// Filter to different file formats
	ofn.nFilterIndex = 0;			// The File Types control initially displays ini files
	ofn.lpstrInitialDir = NULL;
	ofn.lpstrFileTitle = NULL;
	ofn.lpstrDefExt = _T("ini");	// Automatically pick ini file if users forget to type the file extension
	ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST | OFN_NODEREFERENCELINKS;

	if (GetOpenFileName(&ofn) == TRUE) {
		FileHandling* pFileHandling = new FileHandling();
		DWORD textSize = 0;
		TBYTE* text = pFileHandling->ReadFile(ofn.lpstrFile, &textSize);

		text[textSize] = 0;
		SetWindowText(inHTarget, (TCHAR*)text);

		HeapFree(GetProcessHeap(), 0, text);
		delete pFileHandling;
	}
	else {
		MessageBox(NULL, _T("Cannot open file!"), _T("ERROR"), MB_ICONERROR | MB_OK);
	}
}