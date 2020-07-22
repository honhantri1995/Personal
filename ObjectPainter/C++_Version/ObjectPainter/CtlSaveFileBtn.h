#pragma once
#include "CtlBase.h"

class CtlSaveFileBtn : public CtlBase
{
public:
	CtlSaveFileBtn();
	~CtlSaveFileBtn();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);
	void OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

private:
	void SaveFile(TCHAR* inText, int inLength);

	HWND m_hThis;
};

