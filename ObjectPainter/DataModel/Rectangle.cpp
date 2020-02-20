#include "Rectangle.h"

CRectangle::CRectangle(POINT inOriginPoint,
					   unsigned long inHeight,
					   unsigned long inWidth,
					   COLORREF inFillColor,
					   COLORREF inPenColor,
					   unsigned long inPenWidth)
	: m_originPoint(inOriginPoint),
	  m_height(inHeight),
	  m_width(inWidth)
{
	m_fillColor = inFillColor;
	m_penColor = inPenColor;
	m_penWidth = inPenWidth;
}

CRectangle::~CRectangle()
{
}

bool CRectangle::Validate()
{
	if (m_height <= 0) {
		MessageBox(NULL, _T("Height of a rectangle must be greater than 0"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}
	if (m_width <= 0) {
		MessageBox(NULL, _T("Width of a rectangle must be greater than 0"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}
	if (m_penWidth <= 0) {
		MessageBox(NULL, _T("Pen width must be greater than 0"), _T("ERROR"), MB_ICONERROR | MB_OK);
		return false;
	}

	return true;
}

void CRectangle::Draw()
{
	SetColor();
	::Rectangle(m_hdc, m_originPoint.x, m_originPoint.y, m_originPoint.x + m_width, m_originPoint.y + m_height);
}