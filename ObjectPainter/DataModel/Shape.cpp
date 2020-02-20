#include "Shape.h"

Shape::Shape()
	: m_hdc(nullptr),
	  m_penWidth(0),
	  m_penColor(0x000000),
	  m_fillColor(0xFFFFFF)
{
}

Shape::~Shape()
{
}

void Shape::SetHDC(HDC inHDC)
{
	m_hdc = inHDC;
}

void Shape::SetColor()
{
	// Create pen color and pen width
	HGDIOBJ hPen = CreatePen(PS_SOLID, m_penWidth, m_penColor);
	HGDIOBJ hPenSel = SelectObject(m_hdc, hPen);

	// Create and select a red brush
	HGDIOBJ hSolidBrush = CreateSolidBrush(m_fillColor);
	HGDIOBJ hSolidBrushSel = SelectObject(m_hdc, hSolidBrush);
}