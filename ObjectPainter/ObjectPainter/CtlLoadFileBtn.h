#pragma once
#include "CtlBase.h"

class CtlLoadFileBtn : public CtlBase
{
public:
	CtlLoadFileBtn();
	~CtlLoadFileBtn();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);
	void OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

private:
	void LoadFileAndSetText(HWND inHTarget);
	HWND m_hThis;
};

