#include "MainWindow.h"
#include "CtlEdittingArea.h"
#include "CtlDrawingArea.h"
#include "CtlExitMainWin.h"
#include "CtlLoadFileBtn.h"
#include "CtlSaveFileBtn.h"
#include "CtlApplyBtn.h"

enum class CTLID
{
	EDITTING_AREA,
	DRAWING_AREA,
	APPLY_BTN,
	LOAD_BTN,
	SAVE_BTN,
	EXIT_BTN,

	COUNT
};

MainWindow* MainWindow::m_instance = nullptr;

MainWindow::MainWindow(HWND inParent)
	: m_hMainWin(inParent),
	  m_controls(new CtlBase*[(int)CTLID::COUNT])
{

}

MainWindow::~MainWindow()
{
	this->DestroyControls();
}

MainWindow* MainWindow::GetInstance(HWND inHMainWin)
{
	if (m_instance) {
		return m_instance;
	}
	m_instance = new MainWindow(inHMainWin);
	return m_instance;
}

void MainWindow::ReleaseInstance()
{
	if (m_instance) {
		delete m_instance;
		m_instance = nullptr;
	}
}

void MainWindow::CreateControls()
{
	CtlEdittingArea* pCtlEdittingArea = new CtlEdittingArea();
	m_controls[(int)CTLID::EDITTING_AREA] = (CtlBase*)pCtlEdittingArea;

	CtlExitMainWin* pCtlExitMainWin = new CtlExitMainWin();
	m_controls[(int)CTLID::EXIT_BTN] = (CtlBase*)pCtlExitMainWin;

	CtlDrawingArea* pCtlDrawingArea = new CtlDrawingArea();
	m_controls[(int)CTLID::DRAWING_AREA] = (CtlBase*)pCtlDrawingArea;

	CtlLoadFileBtn* pCtlLoadFileBtn = new CtlLoadFileBtn();
	m_controls[(int)CTLID::LOAD_BTN] = (CtlBase*)pCtlLoadFileBtn;

	CtlSaveFileBtn* pCtlSaveFileBtn = new CtlSaveFileBtn();
	m_controls[(int)CTLID::SAVE_BTN] = (CtlBase*)pCtlSaveFileBtn;

	CtlApplyBtn* pCtlApplyBtn = new CtlApplyBtn();
	m_controls[(int)CTLID::APPLY_BTN] = (CtlBase*)pCtlApplyBtn;

	for (int ctlID = 0; ctlID < (int)CTLID::COUNT; ctlID++) {
		m_controls[ctlID]->SetControlID(ctlID);
		m_controls[ctlID]->SetParent(m_hMainWin);
		m_controls[ctlID]->OnCreate();
	}
}

void MainWindow::DestroyControls()
{
	for (int ctlID = 0; ctlID < (int)CTLID::COUNT; ctlID++) {
		if (m_controls[ctlID]) {
			delete m_controls[ctlID];
			m_controls[ctlID] = nullptr;
		}
	}
	delete m_controls;
	m_controls = NULL;
}

void MainWindow::ResizeControls(LPRECT inRectParent)
{
	for (int ctlID = 0; ctlID < (int)CTLID::COUNT; ctlID++) {
		m_controls[ctlID]->OnResize(inRectParent);
	}
}

void MainWindow::CommandControls(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	for (int ctlID = 0; ctlID < (int)CTLID::COUNT; ctlID++) {
		if (inWParam == (WPARAM)ctlID) {
			m_controls[ctlID]->OnCommand(inMsg, inWParam, inLParam);
		}
	}
}

