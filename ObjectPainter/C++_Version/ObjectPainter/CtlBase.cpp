#include "CtlBase.h"

CtlBase::CtlBase()
	: m_hParent(nullptr),
	  m_ctlID(0)
{
}

CtlBase::~CtlBase()
{
}

void CtlBase::SetParent(HWND inParent)
{
	m_hParent = inParent;
}

void CtlBase::SetControlID(int inCtlID)
{
	m_ctlID = inCtlID;
}

bool CtlBase::OnCreate()
{
	return true;
}

void CtlBase::OnResize(LPRECT inRectParent)
{
	return;
}

bool CtlBase::OnRegister()
{
	return true;
}

void CtlBase::OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam)
{
	return;
}
