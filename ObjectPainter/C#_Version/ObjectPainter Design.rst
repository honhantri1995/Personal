.. uml::

	@startuml images/1.png",
	TITLE 1. ObjectPainter Class

	PACKAGE Common
	{
		INTERFACE "IShape" AS shape	{
			# m_brushColor : Color
			# m_brushThickness : int
			+ {abstract} Draw() : void
			+ {abstract} IsCorrectFormat() : bool
		}

		CLASS "Line" AS line {
			- m_startPoint : Point
			- m_endPoint : Point
			+ Draw() : void
			+ IsCorrectFormat() : bool
		}

		CLASS "Triangle" AS tri {
			- m_point1 : Point
			- m_point2 : Point
			- m_point3 : Point
			- m_backgroudColor : Color
			+ Draw() : void
			+ IsCorrectFormat() : bool
		}

		CLASS "Rectangle" AS rec {
			- m_origin : Point
			- m_height : long
			- m_width : long
			- m_backgroudColor : Color
			+ Draw() : void
			+ IsCorrectFormat() : bool
		}

		CLASS "Elipse" AS elipse {
			- m_origin : Point
			- m_height : long
			- m_width : long
			- m_backgroudColor : Color
			+ Draw() : void
			+ IsCorrectFormat() : bool
		}
	}

	PACKAGE DataModel.dll
	{
		CLASS "DataModel" AS data
		{
			- m_shapeList : vector<CShape>
			+ ParseScript() : bool
			+ GetShapeList() : m_shapeList
		}
	}

	PACKAGE FileHandling.dll
	{
		CLASS "FileHandling" AS file
		{
			+ LoadFile() : void
			+ SaveToFile(inShapeList : vector<CShape>) : void
		}
	}

	PACKAGE ObjectPainter.exe
	{
		CLASS "App" AS app
		{
			+ Main() : void
		}
		CLASS "MainWindow" AS main
		{
			- <button-click-event-handler>()
		}
	}

	main <.d. app

	shape <|-- line
	shape <|-- tri
	shape <|-- rec
	shape <|-- elipse

	file <.l. ObjectPainter.exe
	data <.r. ObjectPainter.exe

	data *-- shape

	@enduml