#include <string>
#include <fstream>
#include <vector>
using namespace std;

#define	TMP_CSV_PATH		"Database\\Tmp.csv"

class CSV
{
private:
	string path;
	fstream file;

public:
	CSV(string filePath);
	bool open(std::ios_base::openmode openMode);
	void close();

	void readLine(string line, vector<string> &items);
	bool readAll(vector<vector<string>> &records);

	bool addRecord(vector<string> record);
	bool updateRecord(string id, vector<string> newRecord);
	bool removeRecord(string id);

	bool isExistRecord(string id);
	bool getRecordValues(string id, vector<string>& items);

	static bool is_integer(string input);
	static string trim(string input);
};
