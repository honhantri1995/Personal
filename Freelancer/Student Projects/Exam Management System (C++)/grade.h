#pragma once

#include "exam.h"
#include "account.h"
#include <string>
#include <vector>
using namespace std;

// Đường dẫn đến file CSV lưu thông tin điểm thi
#define	GRADE_CSV_PATH	"Database\\Grade.csv"

// Class để quản lý điểm thi
class GradeManager
{
private:

public:
	float caculateExamGrade(string examFilePath, int totalQuestionNum, vector<string> studentAnswers, vector<string> correctAnswers, int &correctAnswerNum);
	void saveGrade(Exam exam, Student student, float grade);
	void displayGrade_ByExam(Exam exam);
	void displayGrade_ByStudent(Student student);
	bool isStudentDoExamBefore(Exam exam, Student student, string& gradeId);
};
