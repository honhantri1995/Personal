#include "Triangle.h"

CTriangle::CTriangle(POINT inPoint1,
					 POINT inPoint2,
					 POINT inPoint3,
					 COLORREF inFillColor,
					 COLORREF inPenColor,
					 unsigned long inPenWidth)
	: m_Point1(inPoint1),
	  m_Point2(inPoint2),
	  m_Point3(inPoint3)
{
	m_fillColor = inFillColor;
	m_penColor = inPenColor;
	m_penWidth = inPenWidth;
}

CTriangle::~CTriangle()
{
}

bool CTriangle::Validate()
{
	if (m_Point1.x <= 0 || m_Point1.y <= 0
		|| m_Point2.x <= 0 || m_Point2.y <= 0
		|| m_Point3.x <= 0 || m_Point3.y <= 0) {
		MessageBox(NULL, _T("All points of a triangle must be greater than 0"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CTriangle::Draw()
{
	SetColor();
	POINT point[] = { m_Point1.x, m_Point1.y, m_Point2.x, m_Point2.y, m_Point3.x, m_Point3.y };
	::Polygon(m_hdc, point, 3);
}