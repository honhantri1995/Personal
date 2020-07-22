#pragma once
#include "CtlBase.h"

class CtlExitMainWin : CtlBase
{
public:
	CtlExitMainWin();
	~CtlExitMainWin();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);
	void OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

private:
	HWND m_hThis;
};

