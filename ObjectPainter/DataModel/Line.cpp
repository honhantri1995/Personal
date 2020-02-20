#include "Line.h"

CLine::CLine(POINT inPoint1,
			 POINT inPoint2,
			 COLORREF inFillColor,
			 COLORREF inPenColor,
			 unsigned long inPenWidth)
	: m_Point1(inPoint1),
	  m_Point2(inPoint2)
{
	m_fillColor = inFillColor;
	m_penColor = inPenColor;
	m_penWidth = inPenWidth;
}

CLine::~CLine()
{
}

bool CLine::Validate()
{
	if (m_Point1.x <= 0 || m_Point1.y <= 0
		|| m_Point2.x <= 0 || m_Point2.y <= 0) {
		MessageBox(NULL, _T("All points of a line must be greater than 0"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CLine::Draw()
{
	SetColor();
	::MoveToEx(m_hdc, m_Point1.x, m_Point1.y, nullptr);
	::LineTo(m_hdc, m_Point2.x, m_Point2.y);
}