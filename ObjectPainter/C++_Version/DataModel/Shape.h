#pragma once
#include <string>
#include <Windows.h>
#include <Windows.h>
#include <tchar.h>
#include "DefScriptFormat.h"

class Shape
{
public:
	Shape();
	virtual ~Shape();

	virtual void SetHDC(HDC inHDC);
	virtual bool Validate() = 0;
	virtual void Draw() = 0;

protected:
	HDC m_hdc;
	COLORREF m_fillColor;
	COLORREF m_penColor;
	int m_penWidth;

	virtual void SetColor();
};

