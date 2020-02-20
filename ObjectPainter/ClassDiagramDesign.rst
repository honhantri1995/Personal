.. uml::

	@startuml images/Class-Diagram.png",
	TITLE ObjectPainter Class Diagram

	PACKAGE DataModel.dll
	{
		INTERFACE "IShape" AS shape	{
			# m_penColor : COLORREF
			# m_fillColor : COLORREF
			# m_penWidth : unsigned int
			+ {abstract} Draw() : void
			+ {abstract} Validate() : bool
		}

		CLASS "Line" AS line {
			- m_Point1 : Point
			- m_Point2 : Point
			+ Line(POINT inPoint1, \n\tPOINT inPoint2, \n\tCOLORREF inPenColor, \n\tCOLORREF inFillColor, \n\tunsigned int inPenWidth)
			+ Draw() : void
			+ Validate() : bool
		}

		CLASS "Triangle" AS tri {
			- m_Point1 : Point
			- m_Point2 : Point
			- m_Point3 : Point
			+ Triangle(POINT inPoint1, \n\tPOINT inPoint2, \n\tPOINT inPoint3, \n\tCOLORREF inPenColor, \n\tCOLORREF inFillColor, \n\tunsigned int inPenWidth)
			+ Draw() : void
			+ Validate() : bool
		}

		CLASS "Rectangle" AS rec {
			- m_origin : Point
			- m_height : unsigned int
			- m_width : unsigned int
			+ Rectangle(POINT inOrigin, \n\tunsigned int inHeight, \n\tunsigned int inWidth, \n\tCOLORREF inPenColor, \n\tCOLORREF inFillColor, \n\tunsigned int inPenWidth)
			+ Draw() : void
			+ Validate() : bool
		}

		CLASS "Elipse" AS elipse {
			- m_origin : Point
			- m_height : unsigned int
			- m_width : unsigned int
			+ Elipse(POINT inOrigin, \n\tunsigned int inHeight, \n\tunsigned int inWidth, \n\tCOLORREF inPenColor, \n\tCOLORREF inFillColor, \n\tunsigned int inPenWidth)
			+ Draw() : void
			+ Validate() : bool
		}


		CLASS "CDataModel" AS data
		{
			- m_shapeList : vector<IShape>
			+ ParseScript() : bool
			+ GetShapeList() : m_shapeList
		}
	}

	PACKAGE FileHandling.dll
	{
		CLASS "FileHandling" AS file
		{
			+ LoadFile(string inFile) : string
			+ SaveFile(string inFile, string inContent) : void
		}
	}

	PACKAGE ObjectPainter.exe
	{
		hide circle
		hide empty methods
		hide empty fields
		CLASS "WinMain() : int" AS main
	}

	shape <|-- line
	shape <|-- tri
	shape <|-- rec
	shape <|-- elipse

	file <.l. main
	data <.d. main

	data *-- shape

	@enduml