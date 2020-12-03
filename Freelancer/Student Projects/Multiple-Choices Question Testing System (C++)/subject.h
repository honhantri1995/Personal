#pragma once
#include "exam.h"
#include <string>
#include <vector>
using namespace std;

// Đường dẫn đến file CSV lưu thông tin môn học
#define	SUBJECT_CSV_PATH	"Database\\Subject.csv"

// Class để lưu thông tin môn học
class Subject
{
private:
	string id;		// Mã môn học
	string name;	// Tên môn học
	Exam exam;		// Đề thi của môn học

public:
	string getId() { return id; }
	void setId(string input) { id = input; }
	string getName() { return name; }
	void setName(string input) { name = input; }
	Exam getExam() { return exam; }
	void setExam(Exam input) { exam = input; }
};

// Class để quản lý môn học
class SubjectManager
{
private:
	Subject subject;


public:
	Subject getSubject() { return subject; }
	void setSubject(Subject input) { subject = input; }

	void input(Subject &subject);
	bool loadSubject(vector<Subject> &subjects);
	void displayTitle();
	void displaySubject(Subject subject);
	void displayAllSubjects();
	void addSubject();

	bool _searchSubject(string subject, Subject &out_subject);
	void searchSubject();

	void updateSubject();
	
	void _removeSubject(string subjectId);
	void removeSubject();
};