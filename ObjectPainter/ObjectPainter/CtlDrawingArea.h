#pragma once
#include "CtlBase.h"

class CtlDrawingArea : public CtlBase
{
public:
	CtlDrawingArea();
	~CtlDrawingArea();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);

	static HWND GetWindowHandler();

private:
	bool OnRegister();
	static LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);

	static HWND m_hThis;
	static HDC m_hdc;
};

