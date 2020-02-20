#pragma once
#include "Shape.h"

class CTriangle : public Shape
{
public:
	CTriangle(POINT inPoint1,
			  POINT inPoint2,
			  POINT inPoint3,
			  COLORREF inFillColor,
			  COLORREF inPenColor,
			  unsigned long inPenWidth);
	~CTriangle();

	bool Validate() override;
	void Draw() override;

private:
	POINT m_Point1;
	POINT m_Point2;
	POINT m_Point3;
};

