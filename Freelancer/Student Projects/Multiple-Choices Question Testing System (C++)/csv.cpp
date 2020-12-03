#include "csv.h"
#include <iostream>
#include <sstream>
#include <cstdio>
#include <errno.h>
#include <cstring>
#include <cctype>
#include <algorithm>

// Constructor có tham số
CSV::CSV(string filePath)
{
	path = filePath;
}

// Mở file CSV
bool CSV::open(std::ios_base::openmode openMode)
{
	// Mở file
	file.open(path, openMode);

	// Nếu quá trình mở file gặp lỗi, in ra dòng thông báo lỗi và thoát khỏi hàm
	if(!file) {
		cout << "LOI: Khong the mo file " << path << ". Vui long kiem tra lai." << endl;
		return false;
	}

	return true;
}

// Đóng file CSV
void CSV::close()
{
	file.close();
}

// Đọc line và tách ra các items, lưu tất cả vào vector
void CSV::readLine(string line, vector<string> &items)
{
	string item;			// Từng item trong mỗi dòng. Các item cách nhau bằng dấu ','

	// Đảm bảo vector 'items' rỗng bằng cách xóa hết phần tử của nó
	if (items.size() > 0) {
		items.clear();
	}

	// Nếu line rỗng, thì bỏ qua không đọc line này
	if (line.empty()) {
		return;
	}
	// Nếu line bắt đầu bằng ký tư '#' thì đây là một comment
	// nên không cần lưu thông tin của line này, mà bỏ qua để dọc các line tiếp theo
	if (line[0] == '#') {
		return;
	}

	// Tách các phần tử trong một line
	// Mỗi phần tử tương ứng với một thuộc tính của record
	// Sau đó, lưu tất cả thuộc tính của một record vào vector 'items'
	stringstream ss(line);
	while( getline(ss, item, ',') ) {
		items.push_back(item); 
	}
}

// Đọc tất cả record (cùng với thuộc tính của chúng) từ file CSV
// và lưu tất cả vào tham số đầu ra là vector 'records'
bool CSV::readAll(vector<vector<string>> &records)
{ 
	// Mở file CSV trong chế độ ĐỌC
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in)) {
		return false;
	}

	string line;			// Từng dòng trong file CSV
	vector<string> items;	// Vector lưu tất cả item của mỗi dòng

	// Đảm bảo vector 'records' rỗng bằng cách xóa hết phần tử của nó
	if (records.size() > 0) {
		records.clear(); 
	}
	// Trong từng line của file CSV, đọc và lưu thông tin
	while (getline(file, line)) {
		// Tách từng item trong line và lưu vào vector 'items'
		readLine(line, items);

		// Nếu line chứa item (k phải comment, ...), lưu tất cả item vào vector 'records'
		if (items.size() > 0) {
			records.push_back(items);
			items.clear();
		}
	}

	// Đóng file CSV
	close();
	return true;
}

// Thêm record mới vào file CSV
bool CSV::addRecord(vector<string> record)
{
	// Mở file CSV trong chế độ ĐỌC, GHI, APPEND
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in | ios::out | ios::app)) {
		return false;
	}

	// Ghi record vào file
	file << "\n";
	for (int i = 0; i < record.size(); i++) {
		if (i > 0) {
			file << ",";
		}
		file << record[i];
	}

	// Đóng file
	close();
	return true;
}

// Cập nhật record theo ID
// Hàm trả về false nếu xử lý file CSV bị lỗi, hoặc ID không tồn tại
bool CSV::updateRecord(string id, vector<string> newRecord)
{
	// Mở file CSV trong chế độ ĐỌC, GHI, APPEND
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in | ios::out | ios::app)) {
		return false;
	}

	string line;					// Từng dòng trong file CSV
	vector<string> items;			// Vector lưu tất cả item của mỗi dòng
	bool isFoundRecord = false;		// Có tìm thấy record (theo ID) muốn update không

	// Tạo và mở một file tạm
	// Thông tin sẽ được ghi lại vào file tạm này trước khi nó được đổi tên
	fstream tmpFile;	
	// Ghi từng record vào file tạm, cho đến khi hết file
	tmpFile.open(TMP_CSV_PATH, ios::in | ios::out | ios::app);

	// Trong từng line của file CSV, đọc và lưu thông tin
	while (getline(file, line)) {
		// Tách từng item trong line và lưu vào vector 'items'
		readLine(line, items);

		// Nếu line chứa item (k phải comment, ...), lưu tất cả item vào vector 'records'
		if (items.size() > 0) {
			// Nếu tìm thấy record muốn update, ghi nội dung của record mới vào file CSV tạm
			if (items[0].compare(id) == 0) {
				isFoundRecord = true;

				// Từ line, tạo vector 'oldRecord' chứa tất cả item của record cũ
				vector<string> oldRecord;
				size_t last = 0; size_t next = 0;
				while ((next = line.find(',', last)) != string::npos) {
					oldRecord.push_back(line.substr(last, next - last));
					last = next + 1; 
				}

				tmpFile << "\n";
				for (int i = 0; i < newRecord.size(); i++) {
					if (i > 0) {
						tmpFile << ",";
					}
					// Nếu item của 'newRecord' rỗng, ghi item (cùng index) của 'oldRecord' vào file CSV tạm
					if (newRecord[i].empty()) {
						tmpFile << oldRecord[i];
					}
					// Nếu không, ghi item của 'newRecord' vào file CSV tạm
					else {
						tmpFile << newRecord[i];
					}
				}
			}
			// Nếu không, ghi lại line của file CSV chính và CSV tạm
			else {
				tmpFile << "\n" << line;
			}
		}
		// Nếu line là phải comment, ghi lại line của file CSV chính và CSV tạm
		else {
			tmpFile << line;
		}
	}

	// Đóng cả 2 file CSV
	close();
	tmpFile.close();

	// Xóa file CSV chính
	if (remove(path.c_str()) != 0) {
		cout << "LOI: Loi khi xoa file " << path << ": " << strerror(errno) << endl;
		return false;
	}

	// Đổi tên file tạm thành file CSV chính
	if (rename(TMP_CSV_PATH, path.c_str()) != 0) {
		cout << "LOI: Loi khi doi ten file tu " << TMP_CSV_PATH << " sang " << path << ": " << strerror(errno) << endl;
		return false;
	}

	// Nếu không tìm thấy record, return false
	if ( !isFoundRecord ) {
		return false;
	}

	return true;
}

// Xóa record theo ID
// Hàm trả về false nếu xử lý file CSV bị lỗi, hoặc ID không tồn tại
bool CSV::removeRecord(string id)
{
	// Mở file CSV trong chế độ ĐỌC, GHI, APPEND
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in | ios::out | ios::app)) {
		return false;
	}

	string line;					// Từng dòng trong file CSV
	vector<string> items;			// Vector lưu tất cả item của mỗi dòng
	bool isFoundRecord = false;		// Có tìm thấy record (theo ID) muốn xóa không

	// Tạo và mở một file tạm
	// Thông tin sẽ được ghi lại vào file tạm này trước khi nó được đổi tên
	fstream tmpFile;	
	// Ghi từng record vào file tạm, cho đến khi hết file
	tmpFile.open(TMP_CSV_PATH, ios::in | ios::out | ios::app);

	// Trong từng line của file CSV, đọc và lưu thông tin
	while (getline(file, line)) {
		// Tách từng item trong line và lưu vào vector 'items'
		readLine(line, items);

		// Nếu line chứa item (k phải comment, ...), lưu tất cả item vào vector 'records'
		if (items.size() > 0) {
			// Nếu tìm thấy record muốn xóa, không ghi nội dung của nó vào file CSV tạm
			if (items[0].compare(id) == 0) {
				isFoundRecord = true;
				continue;
			}
			// Nếu không, ghi lại line của file CSV chính và CSV tạm
			else {
				tmpFile << "\n" << line;
			}
		}
		// Nếu line là phải comment, ghi lại line của file CSV chính và CSV tạm
		else {
			tmpFile << line;
		}
	}

	// Đóng cả 2 file CSV
	close();
	tmpFile.close();

	// Xóa file CSV chính
	if (remove(path.c_str()) != 0) {
		cout << "LOI: Loi khi xoa file " << path << ": " << strerror(errno) << endl;
		return false;
	}

	// Đổi tên file tạm thành file CSV chính
	if (rename(TMP_CSV_PATH, path.c_str()) != 0) {
		cout << "LOI: Loi khi doi ten file tu " << TMP_CSV_PATH << " sang " << path << ": " << strerror(errno) << endl;
		return false;
	}

	// Nếu không tìm thấy record, return false
	if ( !isFoundRecord ) {
		return false;
	}

	return true;
}

// Kiểm tra thử record có tồn tại hay không
bool CSV::isExistRecord(string id)
{
	// Mở file CSV trong chế độ ĐỌC
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in)) {
		return false;
	}

	string line;			// Từng dòng trong file CSV
	vector<string> items;	// Vector lưu tất cả item của mỗi dòng

	// Trong từng line của file CSV, đọc và lưu thông tin
	while (getline(file, line)) {
		// Tách từng item trong line và lưu vào vector 'items'
		readLine(line, items);

		// Nếu line chứa item (k phải comment, ...), lưu tất cả item vào vector 'records'
		if (items.size() > 0) {
			// Nếu tìm thấy record, return true
			if ( id.compare(items[0]) == 0 ) {
				return true;
			}
		}
	}

	// Đóng file CSV và return false vì không tìm thấy record
	close();
	return false;
}

// Lấy tất cả values của record
// Logic tương tự "Kiểm tra thử record có tồn tại hay không", nhưng có thêm tham số đầu ra
// Hàm trả về false nếu không tìm thấy record
bool CSV::getRecordValues(string id, vector<string>& items)
{
	// Mở file CSV trong chế độ ĐỌC
	// Nếu quá trình mở file bị lỗi, dừng hàm và return false
	if (!open(ios::in)) {
		return false;
	}

	string line;			// Từng dòng trong file CSV

	// Trong từng line của file CSV, đọc và lưu thông tin
	while (getline(file, line)) {
		// Tách từng item trong line và lưu vào vector 'items'
		readLine(line, items);

		// Nếu line chứa item (k phải comment, ...), lưu tất cả item vào vector 'records'
		if (items.size() > 0) {
			// Nếu tìm thấy record, return true
			if ( id.compare(items[0]) == 0 ) {
				return true;
			}
		}
	}

	// Đóng file CSV và return false vì không tìm thấy record
	close();
	return false;
}

// Kiểm tra string có phải là số nguyên hay không
bool CSV::is_integer(string input)
{
	for (int i = 0; i < input.size(); i++) {
		// Nếu không phải là số, mà là chữ (vd: a, b, c ...)
		if (isdigit(input[i]) == 0) {
			return false;
		}
	}
	return true;
}

// Trim tất cả whitespace và empty string
string CSV::trim(string input)
{
   auto wsfront = find_if_not(input.begin(), input.end(), [](int c) { return isspace(c); });
   auto wsback = find_if_not(input.rbegin(), input.rend(), [](int c) { return isspace(c); }).base();
   return (wsback<=wsfront ? string() : string(wsfront,wsback));
}