#pragma once
#include <string>
#include <vector>
#include <map>

#define DllExport		__declspec(dllexport)

class Parser
{
public:
	DllExport Parser(const std::string& inScript);
	DllExport ~Parser();

	DllExport bool Parse(std::vector<std::map<std::string, std::string>> &outShapeAttributes);

private:
	bool AreDuplicateObjectIDs(const std::vector<std::string>& inScriptLines);
	bool AreDuplicateStrings(const std::vector<std::string>& inVec, std::string& outDuplicateStr);
	std::string TrimLeft(const std::string& inStr);
	std::string TrimRight(const std::string& inStr);
	std::vector<std::string> SplitStringToLines(const std::string& inStr);
	bool IsComment(size_t inStart, const std::string& inStr);
	std::vector<std::map<std::string, std::string>> StoreShapeAttributes(const std::vector<std::string>& inLines);

	std::string m_script;
};

