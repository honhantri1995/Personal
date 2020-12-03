#include "menu.h"
#include "account.h"
#include "subject.h"
#include "exam.h"
#include "grade.h"
#include "feedback.h"
#include <iostream>
using namespace std;

// Hàm main (entry point) của chương trình
int main()
{
	int choice;						// Sự lựa chọn
	char yesOrNo;					// Có tiếp tục chương trình không. VD: 'y' là tiếp tục, 'n' là không tiếp tục
	Menu menu;						// Menu chương trình
	MenuAdmin menuAdmin;			// Menu dành cho admin (người quản lý)
	MenuStudent menuStudent;		// Menu dành cho student (sinh viên)

	Account account;				// Account chung
	Admin admin;					// Account cho admin
	Student student;				// Account cho student

	SubjectManager subjectManager;	// Quản lý môn học
	ExamManager examManager;		// Quản lý đề thi
	GradeManager gradeManager;		// Quản lý điểm thi
	Feedback feedback;				// Quản lý phản hồi của SV
	AccountManager accountManager;
	
	// Hiển thị menu và lấy sự lựa chọn từ người dùng
	menu.displayMainMenu();
	choice = menu.getChoice();

	// Tùy vào sự lựa chọn, sẽ thực hiện 1 xử lý tương ứng
	switch (choice) {
		// Nếu là Admin
		case 1:
			// Set loại tài khoản là Admin
			account.setAccountType(ADMIN);
			// Login vào hệ thống. Nếu hủy bỏ login, thoát khỏi chương trình
			if ( !account.login(account) ) {
				return 0;
			}

			do {
				AdminMenu:
				// Hiển thị menu chính dành cho Admin
				menuAdmin.displayAdminMenu();
				choice = menu.getChoice();
				switch (choice) {
				// Nếu quản lý MÔN THI
				case 1:
					menuAdmin.displaySubjectManagementMenu();
					choice = menu.getChoice();
					switch (choice)	{
					case 1:
						subjectManager.displayAllSubjects();
						break;
					case 2:
						subjectManager.searchSubject();
						break;
					case 3:
						subjectManager.addSubject();
						break;
					case 4:
						subjectManager.updateSubject();
						break;
					case 5:
						subjectManager.removeSubject();
						break;
					case 6:
						// Quay lại menu chính dành cho Admin
						goto AdminMenu;
						break;

					default:
						cout << "LOI: Tinh nang khong ton tai. Vui long nhap lai." << endl;
						continue;
					}
					break;

				// Nếu quản lý ĐỀ THI
				case 2:
					menuAdmin.displayExamManagementMenu();
					choice = menu.getChoice();
					switch (choice) {
					case 1:
						examManager.displayAllExams();
						break;
					case 2:
						examManager.searchExam();
						break;
					case 3:
						examManager.addExam();
						break;
					case 4:
						examManager.updateExam();
						break;
					case 5:
						examManager.removeExam();
						break;
					case 6:
						// Quay lại menu chính dành cho Admin
						goto AdminMenu;
						break;
					default:
						cout << "LOI: Tinh nang khong ton tai. Vui long nhap lai." << endl;
						continue;
					}
					break;

				// Nếu quản lý ĐIỂM THI
				case 3:
					menuAdmin.displayGradeManagementMenu();
					choice = menu.getChoice();
					switch (choice) {
					case 1: {
						Exam exam;
						examManager.searchExam(exam);
						gradeManager.displayGrade_ByExam(exam);
						break;
						
					}
					case 2:
						// Quay lại menu chính dành cho Admin
						goto AdminMenu;
						break;
					default:
						cout << "LOI: Tinh nang khong ton tai. Vui long nhap lai." << endl;
						continue;
					}
					break;

				// Quan ly tai khoan
				case 4:
					menuAdmin.displayAccountManagementMenu();
					choice = menu.getChoice();
					switch (choice)
					{
					case 1:
						accountManager.displayAllAccounts();
						break;
					case 2:
						accountManager.removeAccount();
						break;
					default:
						cout << "LOI: Tinh nang khong ton tai. Vui long nhap lai." << endl;
						continue;
					}
					break;

				// Nếu quản lý phản hồi của sinh viên
				case 5:
					feedback.displayAll();
					break;

				// Nếu thoát khỏi chương trình
				case 6:
					return 0;
				}

				// Hỏi xem người dùng có muốn tiếp tục chương trình hay không
				cout << endl << "Ban co muon tiep tuc chuong trinh (nhap 'y' de tiep tuc): ";
				cin >> yesOrNo;
			} while (yesOrNo == 'y');	// Nếu muốn tiếp tục ==> Lặp lại vòng lặp

		// Nếu là Student
		case 2:
			SigninLoginMenu:
				// Set loại tài khoản là Student
				account.setAccountType(STUDENT);

				// Hiển thị menu để SV đăng nhập hoặc đăng ký
				menuStudent.displaySigninLoginMenu();
				choice = menu.getChoice();
				switch (choice)	{
				// Nếu đăng nhập
				case 1:
					// Đăng nhập vào hệ thống. Nếu hủy bỏ đăng nhập, thoát khỏi chương trình
					if ( !account.login(account) ) {
						return 0;
					}
					student.setUsername(account.getUsername());
					break;
				// Nếu đăng ký
				case 2:
					// Đăng ký vào hệ thống. Nếu hủy bỏ đăng ký, thoát khỏi chương trình
					if ( !account.signin(account) ) {
						return 0;
					}
					// Nếu đăng ký thành công, quay lại menu đăng nhập hoặc đăng ký
					goto SigninLoginMenu;
					break;
				// Nếu thoát khỏi chương trình
				case 3:
					return 0;
				default:
						cout << "LOI: Tinh nang khong ton tai." << endl;
					break;
				}

				do {
					StudentMenu:
						menuStudent.displayStudentMenu();
						choice = menu.getChoice();
						switch (choice) {
						case 1:
							examManager.joinExam(student);
							break;
						case 2:
							gradeManager.displayGrade_ByStudent(student);
							break;
						case 3:
							feedback.feedback(student);
							break;
						// Thoat khoi chuong trinh
						case 4:
							return 0;

						default:
							cout << "LOI: Tinh nang khong ton tai. Vui long nhap lai." << endl;
							continue;
						}

					// Hỏi xem người dùng có muốn tiếp tục chương trình hay không
					cout << endl << "Ban co muon tiep tuc chuong trinh (nhap 'y' de tiep tuc): ";
					cin >> yesOrNo;
				} while (yesOrNo == 'y');	// Nếu muốn tiếp tục ==> Lặp lại vòng lặp

		// Thoát chương trình
		case 3:
			return 0;
	}

	return 0;
}