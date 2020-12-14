#include "menu.h"
#include <iostream>
using namespace std;

/////////////////////////////////////////////////////////////////////
// Menu chính
void Menu::displayMainMenu()
{
	cout << endl << "=======================================" << endl
		<< "Ban la ai?" << endl
		<< "1. Nguoi quan ly" << endl
		<< "2. Sinh vien" << endl
		<< "3. Thoat khoi chuong trinh" << endl;
}

// Lấy lựa chọn từ người dùng
int Menu::getChoice()
{
	int choice;
	cout << "Nhap su lua chon cua ban: ";
	cin >> choice;
	cout << endl;
	return choice;
}


/////////////////////////////////////////////////////////////////////
// Menu dành cho admin (người quản lý)
void MenuAdmin::displayAdminMenu()
{
	cout << endl << "=======================================" << endl
			<< "Chon mot trong so cac tinh nang sau: " << endl
			<< "1. Quan ly mon hoc" << endl
			<< "2. Quan ly de thi" << endl
			<< "3. Quan ly diem thi" << endl
			<< "4. Quan ly tai khoan" << endl
			<< "5. Xem phan hoi" << endl
			<< "6. Thoat khoi chuong trinh" << endl;
}

// Menu dành cho admin để quản lý MÔN THI
void MenuAdmin::displaySubjectManagementMenu()
{
	cout << endl << "-----------------------------" << endl
		<< "Tiep tuc chon tinh nang: " << endl
		<< "1. Xem tat ca mon hoc" << endl
		<< "2. Tim mon hoc" << endl
		<< "3. Them mon hoc" << endl
		<< "4. Sua mon hoc" << endl
		<< "5. Xoa mon hoc" << endl
		<< "6. Quay lai menu chinh" << endl;
}

// Menu dành cho admin để quản lý ĐỀ THI
void MenuAdmin::displayExamManagementMenu()
{
	cout << endl << "-----------------------------" << endl
		<< "Tiep tuc chon tinh nang: " << endl
		<< "1. Xem tat ca de thi" << endl
		<< "2. Tim de thi" << endl
		<< "3. Them de thi" << endl
		<< "4. Sua de thi" << endl
		<< "5. Xoa de thi" << endl
		<< "6. Quay lai menu chinh" << endl;
}

// Menu dành cho admin để quản lý ĐIỂM THI
void MenuAdmin::displayGradeManagementMenu()
{
	cout << endl << "-----------------------------" << endl
		<< "Tiep tuc chon tinh nang: " << endl
		<< "1. Xem diem thi" << endl
		<< "2. Quay lai menu chinh" << endl;
}

// Menu dành cho admin để quản lý ĐIỂM THI
void MenuAdmin::displayAccountManagementMenu()
{
	cout << endl << "-----------------------------" << endl
		<< "Tiep tuc chon tinh nang: " << endl
		<< "1. Xem tat ca tai khoan SV" << endl
		<< "2. Xoa tai khoan SV" << endl
		<< "3. Quay lai menu chinh" << endl;
}


/////////////////////////////////////////////////////////////////////
// Menu dành cho student (sinh viên)
void MenuStudent::displayStudentMenu()
{
	cout << endl << "=======================================" << endl
		<< "Chon mot trong so cac tinh nang sau: " << endl
		<< "1. Bat dau thi" << endl
		<< "2. Xem diem thi" << endl
		<< "3. Gop y" << endl
		<< "4. Thoat khoi chuong trinh" << endl;
}

// Menu dành cho student để đăng ký hoặc đăng nhập vào hệ thống
void MenuStudent::displaySigninLoginMenu()
{
	cout << endl << "=======================================" << endl
		<< "Ban muon: " << endl
		<< "1. Dang nhap" << endl
		<< "2. Dang ky" << endl
		<< "3. Thoat khoi chuong trinh" << endl;
}