#pragma once

// Class định nghĩa phần menu chính của chương trình
class Menu
{
public:
	void displayMainMenu();
	int getChoice();
};

class MenuAdmin
{
public:
	void displayAdminMenu();
	void displaySubjectManagementMenu();
	void displayExamManagementMenu();
	void displayGradeManagementMenu();
	void displayAccountManagementMenu();
};

class MenuStudent
{
public:
	void displaySigninLoginMenu();
	void displayStudentMenu();

};