#pragma once
#include "account.h"
#include <string>
using namespace std;

// Đường dẫn đến file CSV lưu thông tin phản hồi của SV
#define	FEEDBACK_CSV_PATH	"Database\\Feedback.csv"

// Class để quản lý thông tin phản hồi của SV
class Feedback
{
private:
	string message = R"()";		// Phản hồi. Lưu ý: Sử dụng raw string, để khi lưu vào file CSV, item message chỉ nằm trên 1 line dù SV có nhập nhiều line trong CMD
	string feedbackId;			// Mã phản hồi	
	string datetime;			// Ngày giờ tạo phản hồi

public:
	string getMessage() { return message; }
	void setMessage(string input) { message = input; }

	void feedback(Account student);
	void input();
	bool save(Account student);
	void displayAll();
	void printRawStringWithNewline(string rawString);
};
