#include "feedback.h"
#include "csv.h"
#include <iostream>
#include <vector>
#include <ctime>
#include <sstream>

// Lấy và lưu nội dung phẩn hồi
void Feedback::feedback(Account account)
{
	// Lấy nội dung phản hồi
	input();

	// Lưu nội dung phản hồi
	if ( !save(account) ) {
		cout << "LOI: Phan hoi that bai." << endl;
		return;
	}

	cout << "Phan hoi thanh cong." << endl;
}

// Lấy nội dung phản hồi và lưu nào class member 'message'
void Feedback::input()
{
	cout << "De lai loi nhan cua ban ben duoi:" << endl;
	cin.ignore(1);
	
	// Vì người dùng có thể nhập lời nhắn trải dài trên nhiều line của CMD
	// nên cần phải lấy tất cả các line
	string line;
	while (true) {
		getline(cin, line);				// Vì message có thể chứa dấu space, nên phải dùng getline thay vì >>
		if (line.empty()) {
			break;
		}
		message += line + R"(\n)";
	}
}

// Lưu thông tin phản hồi vào file CSV
bool Feedback::save(Account account)
{
	// Lấy time hiện tại
	// Ref: https://en.cppreference.com/w/cpp/chrono/c/tm
	time_t t = time(0);
	tm* now = localtime(&t);

	// Lưu mã phản hồi
	// Lưu ý: Mã phản hồi được lấy tự động theo thông tin ngày giờ (theo format: năm-tháng-ngày-giờ-phút-giây)
	ostringstream os_feedbackId;
	os_feedbackId << now->tm_year + 1900 << now->tm_mon + 1 << now->tm_mday << now->tm_hour << now->tm_min + 1 << now->tm_sec;
	feedbackId = os_feedbackId.str();

	// Lưu thông tin ngày giờ tạo phản hồi
	ostringstream os_datetime;
	os_datetime << now->tm_year + 1900 << "-" << now->tm_mon + 1 << "-" << now->tm_mday << " " << now->tm_hour << ":" << now->tm_min + 1 << ":" << now->tm_sec;
	datetime = os_datetime.str();

	// Lưu tất cả thông tin về phản hồi vào vector 'record'
	// CSV format: Feedback ID, Username, Datetime, Message
	vector<string> record;
	record.push_back(feedbackId);
	record.push_back(account.getUsername());
	record.push_back(datetime);
	record.push_back(message);

	// Thêm vector 'record' vào file CSV
	CSV csv(FEEDBACK_CSV_PATH);
	if ( !csv.addRecord(record) ) {
		return false;
	}

	return true;
}

// Hiển thị tất cả phản hồi của tất cả sinh viên
void Feedback::displayAll()
{
	// Đọc tất cả phản hồi từ file CSV
	vector<vector<string>> records;
	CSV csv(FEEDBACK_CSV_PATH);
	if ( !csv.readAll(records) ) {
		return;
	}

	// Hiển thị tất cả phản hồi
	// CSV format: Feedback ID, Username, Datetime, Message
	for (vector<string> record : records) {
		cout << "Vao ngay " << record[2] << ", sinh vien co ma so '" << record[1] << "' phan hoi nhu sau: " << endl;
		printRawStringWithNewline(record[3]);
	}
}

// Print raw string ra màn hình, nhưng trên nhiều line
void Feedback::printRawStringWithNewline(string rawString)
{
	string textToFind = "\\n";
	string textToPrint;
	string remainingText = rawString;
	int pos = 0;
	while (true) {
		pos = remainingText.find(textToFind);
		if ( pos != string::npos ) {
			textToPrint = remainingText.substr(0, pos);
			remainingText = remainingText.substr(pos + textToFind.length(), remainingText.length());
			cout << textToPrint << endl;
		}
		else {
			cout << remainingText << endl;
			break;
		}
	}
	cout << endl;
}