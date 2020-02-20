#include "Parser.h"
#include "DefScriptFormat.h"
#include <regex>
#include <Windows.h>
#include <tchar.h>

#define MAX_MSG			512

Parser::Parser(const std::string& inScript)
	: m_script(inScript)
{

}

Parser::~Parser()
{
}

bool Parser::Parse(std::vector<std::map<std::string, std::string>> &outShapeAttributes)
{
	// Trim all spaces and tabs at both end of each line
	std::string modifiedScript = TrimLeft(m_script);
	modifiedScript = TrimRight(modifiedScript);

	// Split the script into each line (stored in a vector)
	std::vector<std::string> lines = SplitStringToLines(modifiedScript);

	// Show error if two or more objects have the same ID
	if (AreDuplicateObjectIDs(lines)) {
		return false;
	}

	// Parse each script line to get all shape attributes
	outShapeAttributes = StoreShapeAttributes(lines);

	return true;
}

bool Parser::AreDuplicateObjectIDs(const std::vector<std::string>& inScriptLines)
{
	// Search all object IDs in the script
	const std::regex pattern(R"(\[.+\])");
	std::vector<std::string> matches;
	std::smatch match;
	for (std::string line : inScriptLines) {
		if (std::regex_search(line, match, pattern)) {
			matches.push_back(match._At(0));
		}
	}

	// Check if duplicate object IDs
	std::string duplicateStr;
	if (AreDuplicateStrings(matches, duplicateStr)) {
		TCHAR msg[MAX_MSG] = { 0 };
		sprintf_s(msg, sizeof(msg), "Duplicate object IDs: %s.\nObject ID must be unique.", duplicateStr.c_str());
		MessageBox(NULL, msg, _T("ERROR"), MB_ICONERROR | MB_OK);
		return true;
	}

	return false;
}

bool Parser::AreDuplicateStrings(const std::vector<std::string>& inVec, std::string& outDuplicateStr)
{
	int i = 0;

	for (auto str1 : inVec) {
		str1 = inVec.at(i);
		int j = i + 1;
		for (size_t index = 0; index < inVec.size() - j; index++) {
			std::string str2 = inVec.at(j);
			if (str1.compare(str2) == 0) {
				outDuplicateStr = str1;
				return true;
			}
			j += 1;
		}
		i += 1;
	}

	return false;
}

std::string Parser::TrimLeft(const std::string& inStr)
{
	std::regex pattern(R"(^\s+)");
	std::vector<std::string> matches;
	std::smatch match;
	std::string beforeStr = inStr;
	std::string afterStr = inStr;
	while (std::regex_search(beforeStr, match, pattern)) {
		for (size_t i = 0; i < match.size(); i++) {
			afterStr = std::regex_replace(afterStr, pattern, "");
		}
		beforeStr = match.suffix();
	}

	return afterStr;
}

std::string Parser::TrimRight(const std::string& inStr)
{
	std::regex pattern(R"(\s+$)");
	std::vector<std::string> matches;
	std::smatch match;
	std::string beforeStr = inStr;
	std::string afterStr = inStr;
	while (std::regex_search(beforeStr, match, pattern)) {
		for (size_t i = 0; i < match.size(); i++) {
			afterStr = std::regex_replace(afterStr, pattern, "");
		}
		beforeStr = match.suffix();
	}

	return afterStr;
}

std::vector<std::string> Parser::SplitStringToLines(const std::string& inStr)
{
	const char* delimiter = "\n";
	size_t start = 0;
	size_t end = 0;
	std::vector<std::string> lines;
	
	while ((start = inStr.find_first_not_of(delimiter, end)) != std::string::npos)
	{
		end = inStr.find(delimiter, start);

		// Ignore all comments
		if (IsComment(start, inStr)) {
			continue;
		}

		lines.push_back(inStr.substr(start, end - start));
	}

	return lines;
}

bool Parser::IsComment(size_t inStart, const std::string& inStr)
{
	if (inStr.at(inStart) == ';') {
		return true;
	}
	return false;
}

std::vector<std::map<std::string, std::string>> Parser::StoreShapeAttributes(const std::vector<std::string>& inLines)
{
	std::vector<std::map<std::string, std::string>> shapeAttributes;

	const std::regex LHSPattern(R"(^\w+)");		// eg: lhs = rhs	// note: LHS and RHS strings must have no space
	const std::regex RHSPattern(R"((|-|- +|\+|\+ +|)\w+$)");
	std::smatch match;

	std::map<std::string, std::string> shapeAttributeMap;
	std::string key;
	std::string value;

	const std::regex objectIDPattern(R"(\[.+\])");
	bool isFirstObjectID = true;

	for (auto line : inLines)
	{
		bool isInsertToMap[2] = { false };
		if (std::regex_search(line, match, LHSPattern)) {
			key = match._At(0);
			isInsertToMap[0] = true;
		}
		if (std::regex_search(line, match, RHSPattern)) {
			value = match._At(0);
			isInsertToMap[1] = true;
		}

		// Only insert to map when both LHS (key) and RHS (value) of each shape property are not empty
		if (isInsertToMap[0] && isInsertToMap[1]) {
			shapeAttributeMap.insert(std::pair<std::string, std::string>(key, value));
		}

		// If finding the next oject ID, push all collected shape attributes to a vector of maps
		// That mean each map (in this vector) stores attributes of only one shape
		if (std::regex_search(line, match, objectIDPattern)) {
			if (isFirstObjectID) {
				shapeAttributeMap.insert(std::pair<std::string, std::string>(OBJECT_ID, match._At(0)));
				isFirstObjectID = false;
				continue;
			}
			shapeAttributes.push_back(shapeAttributeMap);
			shapeAttributeMap.clear();

			shapeAttributeMap.insert(std::pair<std::string, std::string>(OBJECT_ID, match._At(0)));
		}
	}

	// Because there is no next object ID if reaching the last object, make sure we push this last one to the vector of maps
	shapeAttributes.push_back(shapeAttributeMap);

	return shapeAttributes;
}