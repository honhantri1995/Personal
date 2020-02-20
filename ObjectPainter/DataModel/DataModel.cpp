#include "DataModel.h"
#include "Parser.h"
#include "Rectangle.h"
#include "Triangle.h"
#include "Ellipse.h"
#include "Line.h"
#include <exception>
#include <regex>

#define MAX_MSG			512

DataModel* DataModel::m_pInstance = nullptr;

DataModel::DataModel()
	: m_hdc(nullptr)
{
}

DataModel::~DataModel()
{
}

DataModel* DataModel::GetInstance()
{
	if (m_pInstance == nullptr) {
		m_pInstance = new DataModel;
		return m_pInstance;
	}
	return m_pInstance;
}

void DataModel::ReleaseInstance()
{
	if (m_pInstance) {
		delete m_pInstance;
		m_pInstance = nullptr;
	}
}

void DataModel::Factory()
{
	Shape* pShape = nullptr;
	try
	{
		for (auto shapeAttributeMap : m_shapeAttributes) {
			if (shapeAttributeMap[TYPE] == RECTANGLE) {
				std::vector<std::string> musthaveAttrs = { X0, Y0, HEIGHT, WIDTH };
				if (!IsFullAttribute(shapeAttributeMap, musthaveAttrs)) {
					return;
				}
				std::vector<std::string> mustbenumAttrs = { X0, Y0, HEIGHT, WIDTH, PENWIDTH };
				if (!IsValidNumber(shapeAttributeMap, mustbenumAttrs)) {
					return;
				}
				std::vector<std::string> mustbecolorAttrs = { PENCOLOR, FILLCOLOR };
				if (!IsColorSupported(shapeAttributeMap, mustbecolorAttrs)) {
					return;
				}
				pShape = new CRectangle({ std::stol(shapeAttributeMap[X0].c_str()), std::stol(shapeAttributeMap[Y0].c_str()) },
										std::stol(shapeAttributeMap[HEIGHT].c_str()),
										std::stol(shapeAttributeMap[WIDTH].c_str()),
										ConvertStringColorToHex(shapeAttributeMap[FILLCOLOR]),
										ConvertStringColorToHex(shapeAttributeMap[PENCOLOR]),
										std::stol(shapeAttributeMap[PENWIDTH].c_str()));
			}
			else if (shapeAttributeMap[TYPE] == TRIANGLE) {
				std::vector<std::string> musthaveAttrs = { X0, Y0, X1, Y1, X2, Y2 };
				if (!IsFullAttribute(shapeAttributeMap, musthaveAttrs)) {
					return;
				}
				std::vector<std::string> mustbenumAttrs = { X0, Y0, X1, Y1, X2, Y2, PENWIDTH };
				if (!IsValidNumber(shapeAttributeMap, mustbenumAttrs)) {
					return;
				}
				std::vector<std::string> mustbecolorAttrs = { PENCOLOR, FILLCOLOR };
				if (!IsColorSupported(shapeAttributeMap, mustbecolorAttrs)) {
					return;
				}
				pShape = new CTriangle({ std::stol(shapeAttributeMap[X0].c_str()), std::stol(shapeAttributeMap[Y0].c_str()) },
									   { std::stol(shapeAttributeMap[X1].c_str()), std::stol(shapeAttributeMap[Y1].c_str()) },
									   { std::stol(shapeAttributeMap[X2].c_str()), std::stol(shapeAttributeMap[Y2].c_str()) },
									   ConvertStringColorToHex(shapeAttributeMap[FILLCOLOR]),
									   ConvertStringColorToHex(shapeAttributeMap[PENCOLOR]),
									   std::stol(shapeAttributeMap[PENWIDTH].c_str()));
			}
			else if (shapeAttributeMap[TYPE] == LINE) {
				std::vector<std::string> musthaveAttrs = { X0, Y0, X1, Y1 };
				if (!IsFullAttribute(shapeAttributeMap, musthaveAttrs)) {
					return;
				}
				std::vector<std::string> mustbenumAttrs = { X0, Y0, X1, Y1, PENWIDTH };
				if (!IsValidNumber(shapeAttributeMap, mustbenumAttrs)) {
					return;
				}
				std::vector<std::string> mustbecolorAttrs = { PENCOLOR, FILLCOLOR };
				if (!IsColorSupported(shapeAttributeMap, mustbecolorAttrs)) {
					return;
				}
				pShape = new CLine({ std::stol(shapeAttributeMap[X0].c_str()), std::stol(shapeAttributeMap[Y0].c_str()) },
								   { std::stol(shapeAttributeMap[X1].c_str()), std::stol(shapeAttributeMap[Y1].c_str()) },
								   ConvertStringColorToHex(shapeAttributeMap[FILLCOLOR]),
								   ConvertStringColorToHex(shapeAttributeMap[PENCOLOR]),
								   std::stol(shapeAttributeMap[PENWIDTH].c_str()));
			}
			else if (shapeAttributeMap[TYPE] == ELLIPSE) {
				std::vector<std::string> musthaveAttrs = { X0, Y0, HEIGHT, WIDTH };
				if (!IsFullAttribute(shapeAttributeMap, musthaveAttrs)) {
					return;
				}
				std::vector<std::string> mustbenumAttrs = { X0, Y0, HEIGHT, WIDTH, PENWIDTH };
				if (!IsValidNumber(shapeAttributeMap, mustbenumAttrs)) {
					return;
				}
				std::vector<std::string> mustbecolorAttrs = { PENCOLOR, FILLCOLOR };
				if (!IsColorSupported(shapeAttributeMap, mustbecolorAttrs)) {
					return;
				}
				pShape = new CEllipse({ std::stol(shapeAttributeMap[X0].c_str()), std::stol(shapeAttributeMap[Y0].c_str()) },
										std::stol(shapeAttributeMap[HEIGHT].c_str()),
										std::stol(shapeAttributeMap[WIDTH].c_str()),
										ConvertStringColorToHex(shapeAttributeMap[FILLCOLOR]),
										ConvertStringColorToHex(shapeAttributeMap[PENCOLOR]),
										std::stol(shapeAttributeMap[PENWIDTH].c_str()));
			}
			else {
				// If shape is unavailable
				TCHAR msg[MAX_MSG] = { 0 };
				sprintf_s(msg, sizeof(msg), _T("In %s, shape %s is unsupported."), shapeAttributeMap[OBJECT_ID].c_str(), shapeAttributeMap[TYPE].c_str());
				MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
				return;
			}

			pShape->SetHDC(m_hdc);
			m_shapes.push_back(pShape);
		}
	}
	catch (std::exception &e) {
		MessageBox(NULL, e.what(), _T("ERROR"), MB_ICONERROR | MB_OK);
	};
}

bool DataModel::IsFullAttribute(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs)
{
	// If lack of other shape attribute
	for (std::string attr : inAttrs) {
		if (inShapeAttributeMap.at(attr).empty()) {
			TCHAR msg[MAX_MSG] = { 0 };
			sprintf_s(msg, sizeof(msg), _T("In %s, %s has no attribute %s."), inShapeAttributeMap.at(OBJECT_ID).c_str(), inShapeAttributeMap.at(TYPE).c_str(), attr.c_str());
			MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
			return false;
		}
	}

	return true;
}

bool DataModel::IsValidNumber(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs)
{
	TCHAR msg[MAX_MSG] = { 0 };

	for (std::string attr : inAttrs) {
		// Error when number is negative. Note: "-100" is considered as a match.
		std::regex negativeNumPattern(R"((-|- +)\b[0-9]+\b)");
		if (std::regex_match(inShapeAttributeMap.at(attr), negativeNumPattern)) {
			sprintf_s(msg, sizeof(msg), _T("In %s, %s of %s must be a positive number."), inShapeAttributeMap.at(OBJECT_ID).c_str(), attr.c_str(), inShapeAttributeMap.at(TYPE).c_str());
			MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
			return false;
		}

		// Error when number with wrong "-" or "+". Eg: "-100" is correct, but "- 100" or "+ 100" is wrong.
		std::regex wrongNumPattern(R"((\+ +|- +)\b[0-9]+\b)");
		if (std::regex_match(inShapeAttributeMap.at(attr), wrongNumPattern)) {
			sprintf_s(msg, sizeof(msg), _T("In %s, %s of %s must be a number."), inShapeAttributeMap.at(OBJECT_ID).c_str(), attr.c_str(), inShapeAttributeMap.at(TYPE).c_str());
			MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
			return false;
		}

		// Error when not a number.
		std::regex numPattern(R"((|\+)[0-9]+)");
		if (!std::regex_match(inShapeAttributeMap.at(attr), numPattern)) {
			sprintf_s(msg, sizeof(msg), _T("In %s, %s of %s must be a number."), inShapeAttributeMap.at(OBJECT_ID).c_str(), attr.c_str(), inShapeAttributeMap.at(TYPE).c_str());
			MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
			return false;
		}
	}

	return true;
}

bool DataModel::IsColorSupported(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs)
{
	std::string colors[] = { BLACK, RED, GREEN, BLUE, BROWN };
	TCHAR msg[MAX_MSG] = { 0 };

	for (std::string attr : inAttrs) {
		bool isSupported = false;
		for (std::string color : colors) {
			if (inShapeAttributeMap.at(attr).compare(color) == 0) {
				isSupported = true;
				break;
			}
			else {
				continue;
			}
		}

		if (!isSupported) {
			sprintf_s(msg, sizeof(msg), _T("In %s, pen color %s is not supported."), inShapeAttributeMap.at(OBJECT_ID).c_str(), inShapeAttributeMap.at(attr).c_str());
			MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
			return false;
		}
	}

	return true;
}

COLORREF DataModel::ConvertStringColorToHex(const std::string& inColor)
{
	if (inColor == BLACK)		return 0x000000;
	else if (inColor == GREEN)	return 0x00FF00;
	else if (inColor == BLUE)	return 0xFF0000;
	else if (inColor == RED)	return 0x0000FF;
	else if (inColor == BROWN)	return 0x45138B;

	return 0x000000;		// black
}

void DataModel::Draw(const std::string& inScript, HDC inHdc)
{
	m_hdc = inHdc;

	// 1. First parse script
	if (inScript.empty()) {
		return;
	}
	Parser parser(inScript);
	if (!parser.Parse(m_shapeAttributes)) {
		return;
	}

	// 2. Then create objects of shapes
	Factory();

	// 3. Finally draw shapes
	for (auto shape : m_shapes) {
		// Only draw shapes with correct attributes
		if (shape->Validate()) {
			shape->Draw();
		}
	}
}

void DataModel::ReDrawOnPAINTEvent()
{
	// Only draw. Don't need to parse script and validate shapes again.
	for (auto shape : m_shapes) {
		shape->Draw();
	}
}