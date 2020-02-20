#pragma once
#include "CtlBase.h"
#include <string>
#include <vector>
#include <map>

class DataModel;

class CtlApplyBtn : public CtlBase
{
public:
	CtlApplyBtn();
	~CtlApplyBtn();

	bool OnCreate();
	void OnResize(LPRECT inRectParent);
	void OnCommand(UINT inMsg, WPARAM inWParam, LPARAM inLParam);

	static bool IsDrawn();

private:
	HWND m_hThis;
	std::vector<std::map<std::string, std::string>> mShapeAttributes;
	static bool m_isDrawn;
};

