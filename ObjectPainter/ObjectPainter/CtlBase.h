#pragma once
#include <Windows.h>
#include <tchar.h>

class CtlBase
{
public:
	CtlBase();
	virtual ~CtlBase();

	virtual void SetParent(HWND inParent);
	virtual void SetControlID(int inCtlID);
	virtual bool OnCreate();
	virtual void OnResize(LPRECT inRectParent);
	virtual void OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

protected:
	HWND m_hParent;
	int m_ctlID;

private:
	virtual bool OnRegister();
};

