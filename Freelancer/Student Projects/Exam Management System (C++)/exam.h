#pragma once
#include "account.h"
#include <string>
#include <vector>
using namespace std;

// Đường dẫn đến file CSV lưu thông tin đề thi
#define	EXAMINFO_CSV_PATH	"Database\\Info_Exam.csv"
#define	QUESTION_NUM		"Tổng số câu hỏi:"		// Tổng số câu hỏi của đề thi
#define	ANSWER				"Đáp án của bạn:"		// Đáp án của mỗi câu hỏi

// Forward declaration
class SubjectManager;

// Class để lưu thông tin đề thi
class Exam
{
private:
	string subjectId;	// Mã môn học
	string id;			// Mã đề thi
	string path;		// Đường dẫn đến file đề thi
	string status;		// Trạng thái của exam. "Open" là đang mở cửa (SV có thể làm), "Close" là đóng rồi (SV k thể làm nữa)
	int questionNumber;	// Số lượng câu hỏi trong đề thì

public:
	string getSubjectId() { return subjectId; }
	void setSubjectId(string input) { subjectId = input; }
	string getId() { return id; }
	void setId(string input) { id = input; }
	string getPath() { return path; }
	void setPath(string input) { path = input; }
	string getStatus() { return status; }
	void setStatus(string input) { status = input; }
	int getQuestionNumber() { return questionNumber; }
	void setQuestionNumber(int input) { questionNumber = input; }
};

// Class để quản lý đề thi
class ExamManager
{
private:
	Exam exam;							// Thông tin đề thi
	SubjectManager* subjectManager;		// Quản lý môn học

	bool _searchExam(string id, Exam &out_exam);
	void _removeExam(string id);

public:
	ExamManager();
	~ExamManager();

	Exam getExam() { return exam; }
	void setExam(Exam input) { exam = input; }
	SubjectManager* getSubjectManager() { return subjectManager; }
	void setSubjectManager(SubjectManager* input) { subjectManager = input; }

	bool input_byAdmin(Exam &exam);
	bool input_byStudent(Exam &exam);

	bool loadExams(vector<Exam> &exams);
	bool joinExam(Student student);

	void openExam(Exam &exam, Student student, string &examFileOfStudent);

	int getQuestionNumber(string examFilePath);
	vector<string> getCorrectAnswers(string solutionPath);

	void openExamFile(string filePath);
	vector<string> getStudentAnswers_FromFile(string examFilePath);

#if DO_EXAM_ON_CMD
	void printExamFile(string examFile);
	vector<string> getStudentAnswers_FromCmd();
#endif 	// DO_EXAM_ON_CMD

	void displayTitle();
	void displayExam(Exam exam);
	void displayAllExams();
	void addExam();
	void searchExam();
	void searchExam(Exam &exam);
	void updateExam();
	void removeExam();
};