#include "account.h"
#include "csv.h"
#include <iostream>
#include <iomanip>
using namespace std;

// Đăng ký vào hệ thống
bool Account::signin(Account account)
{
	char yesOrNo;	// Có tiếp tục chương trình không
	while (true) {
		// Lấy thông tin đăng nhập từ người dùng và lưu vào param 'account'
		account.input_signin(account);
		// Kiểm tra account. Nếu không hợp lý, yêu cầu nhập lại
		if ( !account.validate_signin(account) ) {
			cout << "Ban co muon dang ky lai (nhap 'y' de tiep tuc): ";
			cin >> yesOrNo;
			if (yesOrNo == 'y') {
				continue;
			}
			return false;
		}
		return true;
	}
}

// Lấy thông tin đăng ký từ người dùng
void Account::input_signin(Account &account)
{
	// Lấy tên đăng nhập
	string username;
	cout << "Nhap thong tin dang ky." << endl;
	cout << "Username: ";
	cin >> username;

	// Lấy tên đầy đủ
	string fullname;
	cout << "Full name: ";
	cin.ignore(1);
	getline(cin, fullname);		// Vì full name có thể chứa dấu space, nên phải dùng getline thay vì >>

	// Lấy mật mã
	string password;
	cout << "Password: ";
	cin >> password;

	// Lưu tất cả thông tin vào param 'account'
	account.setUsername(username);
	account.setFullname(fullname);
	account.setPassword(password);
}

// Kiểm tra account có hợp lệ hay không (đã có ai đăng ký với cùng username không?)
bool Account::validate_signin(Account account)
{
	// Admin không có quyền đăng ký (chỉ có quyền đăng nhập)
	if (account.getAccountType() == ADMIN) {
		cout << "LOI: Khong ho tro chuc nang dang ky doi voi nguoi quan ly." << endl;
		return false;
	}

	// Kiểm tra thử có username và password có đúng không
	CSV csv(ACCOUNT_STUDENT_CSV_PATH);
	if ( csv.isExistRecord(account.getUsername()) ) {
		cout << "LOI: Username da ton tai. Vui long chon Username khac." << endl;
		return false;
	}

	// Nếu account hợp lý, lưu vào vector 'newRecord'
	vector<string> newRecord;
	newRecord.push_back(account.getUsername());
	newRecord.push_back(account.getPassword());
	newRecord.push_back(account.getFullname());

	// Và thêm 'newRecord' vào file CSV
	// Nếu quá trình ghi file có vấn đề, thông báo lỗi và dừng hàm
	if ( !csv.addRecord(newRecord) ) {
		cout << "LOI: Dang ky that bai." << endl;
		return false;
	}

	// Nếu ghi file thành công, thông báo thành công
	cout << "Dang ky thanh cong." << endl;
	return true;
}

// Đăng nhập vào hệ thống
bool Account::login(Account &account)
{
	char yesOrNo;	// Có tiếp tục chương trình không
	while (true) {
		// Lấy thông tin đăng nhập từ người dùng và lưu vào param 'account'
		account.input_login(account);
		// Kiểm tra account. Nếu không hợp lý, yêu cầu nhập lại
		if ( !account.validate_login(account) ) {
			cout << "Ban co muon dang nhap lai (nhap 'y' de tiep tuc): ";
			cin >> yesOrNo;
			if (yesOrNo == 'y') {
				continue;
			}
			return false;
		}
		return true;
	}
}

// Lấy thông tin đăng nhập từ người dùng
void Account::input_login(Account &account)
{
	// Lấy tên đăng nhập
	string username;
	cout << "Nhap thong tin dang nhap." << endl;
	cout << "Username: ";
	cin >> username;

	// Lấy mật mã
	string password;
	cout << "Password: ";
	cin >> password;

	// Lưu tất cả thông tin vào param 'account'
	account.setUsername(username);
	account.setPassword(password);
}

// Kiểm tra account có hợp lệ hay không (account có tồn tại không? username và password có đúng không?)
bool Account::validate_login(Account account)
{
	// Kiểm tra loại tài khoản.
	string path;
	// Nếu là admin thì chọn file CSV cho admin
	if (account.accountType == ADMIN) {
		path = ACCOUNT_ADMIN_CSV_PATH;
	}
	// Nếu là student thì chọn file CSV cho student
	else {
		path = ACCOUNT_STUDENT_CSV_PATH;
	}

	// Kiểm tra thử password có đúng không
	vector<string> record;
	CSV csv(path);
	if ( csv.getRecordValues(account.getUsername(), record) ) {
		// Nếu đúng password, thông báo đăng nhập thành công
		if ( account.getPassword().compare(record[1]) == 0 ) {
			cout << "Dang nhap thanh cong." << endl;
			return true;
		}
	}

	// Nếu không, thông báo đăng nhập thất bại
	cout << "LOI: Username hoac Password khong dung." << endl;
	return false;
}

// Load tất cả môn học từ file CVS
bool AccountManager::loadAccounts(vector<Account> &accounts)
{
	// Đọc tất cả record từ file CSV
	// Nếu trong quá trình đọc có lỗi gì, thì dừng hàm
	CSV file(ACCOUNT_STUDENT_CSV_PATH);
	vector<vector<string>> records;
	if (!file.readAll(records)) {
		return false;
	}

	// Trong từng record, lấy từng item và set thông tin môn học tương ứng
	// CSV format: Username, Password, Full Name
	for (vector<string> record : records) {
		Account account;
		account.setUsername(record[0]);
		account.setPassword("******");
		account.setFullname(record[2]);

		// Sau khi có được thông tin môn học, lưu vào param 'accounts'
		accounts.push_back(account);
	}

	return true;
}

// Hiển thị tiêu đề
void AccountManager::displayTitle()
{
	cout << endl 
		 << setw(30) << left << "Username"
		 << setw(30) << left << "Full name" << endl;
}

// Hiển thị thông tin môn học
void AccountManager::displayAccount(Account account)
{
	cout << setw(30) << left << account.getUsername()
		 << setw(30) << left << account.getFullname() << endl;
}

void AccountManager::displayAllAccounts()
{
	// Load tất cả record từ file CSV
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Account> accounts;
	if (!loadAccounts(accounts)) {
		return;
	}

	displayTitle();
	// Cho từng môn học, print ra thông tin
	for (Account account : accounts) {
		displayAccount(account);
	}
	cout << endl;
}

// Xóa môn học
void AccountManager::removeAccount()
{
	// Lấy mã môn học muốn xóa
	string username;
	cout << "Nhap username: ";
	cin >> username;

	// Xóa môn học
	_removeAccount(username);
}

// Xóa môn học dựa vào mã môn học
void AccountManager::_removeAccount(string username)
{
	// Xóa môn học tương ứng với mã môn học
	CSV file(ACCOUNT_STUDENT_CSV_PATH);
	if ( !file.removeRecord(username) ) {
		cout << "LOI: Xoa tai khoan that bai. Dam bao ma tai khoan co ton tai." << endl;
		return;
	}
	cout << "Xoa tai khoan thanh cong." << endl;
}