#pragma once
#include "Shape.h"

class CEllipse : public Shape
{
public:
	CEllipse(POINT inOriginPoint,
		unsigned long inHeight,
		unsigned long inWidth,
		COLORREF inFillColor,
		COLORREF inPenColor,
		unsigned long inPenWidth);
	~CEllipse();

	bool Validate() override;
	void Draw() override;

private:
	POINT m_originPoint;
	unsigned long m_height;
	unsigned long m_width;
};

