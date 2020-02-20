#pragma once
#include "Shape.h"

class CRectangle : public Shape
{
public:
	CRectangle(POINT inOriginPoint,
			   unsigned long inHeight,
			   unsigned long inWidth,
			   COLORREF inFillColor,
			   COLORREF inPenColor,
			   unsigned long inPenWidth);
	~CRectangle();

	bool Validate() override;
	void Draw() override;

private:
	POINT m_originPoint;
	unsigned long m_height;
	unsigned long m_width;
};

