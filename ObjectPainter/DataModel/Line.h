#pragma once
#include "Shape.h"

class CLine : public Shape
{
public:
	CLine(POINT inPoint1,
		  POINT inPoint2,
		  COLORREF inFillColor,
		  COLORREF inPenColor,
		  unsigned long inPenWidth);
	~CLine();

	bool Validate() override;
	void Draw() override;

private:
	POINT m_Point1;
	POINT m_Point2;
};

