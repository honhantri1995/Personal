#pragma once
#include "CtlBase.h"

class CtlEdittingArea : CtlBase
{
public:
	CtlEdittingArea();
	~CtlEdittingArea();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);

	static HWND GetWindowHandler();

private:
	static HWND m_hThis;
};

