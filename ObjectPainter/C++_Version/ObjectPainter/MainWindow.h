#pragma once
#include "CtlBase.h"

class MainWindow
{
public:
	~MainWindow();

	static MainWindow* GetInstance(HWND inParent);
	void ReleaseInstance();

	void CreateControls();
	void DestroyControls();

	void ResizeControls(LPRECT inRectParent);
	void CommandControls(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

private:
	MainWindow(HWND inHMainWin);

	static MainWindow* m_instance;
	HWND m_hMainWin;

	CtlBase** m_controls;
};

