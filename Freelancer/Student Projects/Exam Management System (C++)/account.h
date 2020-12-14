#pragma once
#include <string>
#include <vector>
using namespace std;

#define	ACCOUNT_ADMIN_CSV_PATH		"Database\\Account_Admin.csv"
#define	ACCOUNT_STUDENT_CSV_PATH	"Database\\Account_Student.csv"

// Enum để quản lý loại account
enum ACCOUNT_TYPE {
	ADMIN,		// Account cho admin
	STUDENT		// Account cho student
};

// Class để quản lý thông tin account
class Account
{
private:
	ACCOUNT_TYPE accountType;	// Loại account
	string username;			// Tên đăng nhập
	string password;			// Mật mã
	string fullname;			// Tên đầy đủ

public:
	ACCOUNT_TYPE getAccountType() { return accountType; }
	void setAccountType(ACCOUNT_TYPE input) { accountType = input; }
	string getUsername() { return username; }
	void setUsername(string input) { username = input; }
	string getPassword() { return password; }
	void setPassword(string input) { password = input; }
	string getFullname() { return fullname; }
	void setFullname(string input) { fullname = input; }

	bool signin(Account account);
	void input_signin(Account &account);
	bool validate_signin(Account account);

	bool login(Account &account);
	void input_login(Account &account);
	bool validate_login(Account account);
};

// Class để quản lý thông tin account dành cho Admin
// Kế thừa từ class Account
class Admin : public Account
{
private:

public:
};

// Class để quản lý thông tin account dành cho Student
// Kế thừa từ class Account
class Student : public Account
{
private:

public:
};

// Class để quản lý account
class AccountManager
{
private:
	Account account;
public:
	bool loadAccounts(vector<Account> &accounts);
	void displayTitle();
	void displayAccount(Account account);
	void displayAllAccounts();
	void removeAccount();
	void _removeAccount(string username);
};