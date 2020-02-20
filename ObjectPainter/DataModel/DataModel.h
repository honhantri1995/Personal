#pragma once
#include <string>
#include <vector>
#include <map>
#include "Shape.h"

#define DllExport		__declspec(dllexport)

class DataModel
{
public:
	DllExport static DataModel* GetInstance();
	DllExport static void ReleaseInstance();
	DllExport void Draw(const std::string& inScript, HDC inHdc);
	DllExport void ReDrawOnPAINTEvent();

private:
	DataModel();
	~DataModel();
	void Factory();
	bool IsFullAttribute(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs);
	bool IsValidNumber(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs);
	bool IsColorSupported(const std::map<std::string, std::string>& inShapeAttributeMap, const std::vector<std::string>& inAttrs);
	COLORREF ConvertStringColorToHex(const std::string& inColor);

	static DataModel* m_pInstance;
	std::vector<std::map<std::string, std::string>> m_shapeAttributes;
	HDC m_hdc;
	std::vector<Shape*> m_shapes;
};

