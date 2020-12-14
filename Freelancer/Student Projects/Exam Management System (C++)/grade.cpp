#include "grade.h"
#include "csv.h"
#include <iostream>
#include <fstream>
#include <math.h>
#include <cstring>
#include <sstream>
#include <algorithm>
#include <ctime>
#include <iomanip>

#define	GRADE_MAX		10						// Số điểm tối đa (lấy thang 10)

// Tính điểm bài làm 
float GradeManager::caculateExamGrade(string examFilePath, int totalQuestionNum, vector<string> studentAnswers, vector<string> correctAnswers, int &correctAnswerNum)
{
	correctAnswerNum = 0;

	// So sánh câu trả lời và đáp án.
	// Nếu khớp, tức là câu trả lời đúng ==> tăng biến correctAnswerNum lên 1
	for (int i = 0; i < studentAnswers.size(); i++) {
		// Trước khi so sánh, convert mỗi câu trả lời và đáp an qua Uppercase
		// Như vậy: 'A' sẽ tương đương 'a' khi so sánh
		transform(studentAnswers[i].begin(), studentAnswers[i].end(), studentAnswers[i].begin(), ::toupper);
		transform(correctAnswers[i].begin(), correctAnswers[i].end(), correctAnswers[i].begin(), ::toupper);
		if ( studentAnswers[i].compare(correctAnswers[i]) == 0 ) {
			correctAnswerNum += 1;
		}
	}

	// Từ tổng số câu hỏi và tổng số câu trả lời đúng, tính ra điểm thi
	// Lưu ý: Hàm roundf để làm tròn điểm thi
	float grade = roundf(correctAnswerNum * GRADE_MAX / totalQuestionNum);

	return grade;
}

// Lưu điểm thi vào file CSV
void GradeManager::saveGrade(Exam exam, Student student, float grade)
{
	// Lưu thông tin exam vào vector 'newRecord'
	// CSV format: Username, Fullname, Exam ID, Grade
	vector<string> newRecord;

	// Tạo mã điểm  theo thông tin ngày giờ (theo format: năm-tháng-ngày-giờ-phút-giây)
	time_t t = time(0);
	tm* now = localtime(&t);
	ostringstream id_ss;
	id_ss << now->tm_year + 1900 << now->tm_mon + 1 << now->tm_mday << now->tm_hour << now->tm_min + 1 << now->tm_sec;
	string recordId = id_ss.str();

	// Lưu thông tin vào vector
	newRecord.push_back(recordId);
	newRecord.push_back(student.getUsername());
	newRecord.push_back("");		// Item rỗng tức là k update item này (lấy lại giá trị cũ)
	newRecord.push_back(exam.getId());
	ostringstream ss; ss << grade;
	newRecord.push_back(ss.str());
	
	CSV csv(GRADE_CSV_PATH);
	// Nếu sinh viên đã làm bài thi trước, cập nhật lại record cũ
	string gradeId;
	if ( isStudentDoExamBefore(exam, student, gradeId) ) {
		csv.updateRecord(gradeId, newRecord);
	}
	// Nếu đây là lần đầu tiên SV làm đề thi, thêm record mới
	else {
		if ( !csv.addRecord(newRecord) ) {
			cout << "LOI: Them diem thi that bai." << endl;
			return;
		}
	}
	cout << "Them diem thi thanh cong." << endl;
}

// Hiển thị điểm thi theo exam
void GradeManager::displayGrade_ByExam(Exam exam)
{
	// Đọc tất cả điểm thi từ file CSV
	vector<vector<string>> records;
	CSV csv(GRADE_CSV_PATH);
	if ( !csv.readAll(records) ) {
		return;
	}

	// Trong từng điểm thi, chọn để in ra những điểm thi của cùng một exam
	// CSV format: Grade ID, Username, Fullname, Exam ID, Grade
	cout << endl << "Diem so cua cac sinh vien thuc hien bai kiem tra nay:" << endl;
	cout << setw(20) << left << "Ma diem" 
		 << setw(20) << left << "Ma sinh vien"
		 << setw(40) << left << "Ten sinh vien"
		 << setw(20) << left << "Diem" << endl;
	for (vector<string> record : records) {
		if ( exam.getId().compare(record[3]) == 0 ) {
			cout << setw(20) << left << record[0]
				 << setw(20) << left << record[1]
				 << setw(40) << left << record[2]
				 << setw(20) << left << record[4] << endl;
		}
	}
}

// Hiển thị điểm thi theo student
void GradeManager::displayGrade_ByStudent(Student student)
{
	// Đọc tất cả điểm thi từ file CSV
	vector<vector<string>> records;
	CSV csv(GRADE_CSV_PATH);
	if ( !csv.readAll(records) ) {
		return;
	}

	// Trong từng điểm thi, chọn để in ra những điểm thi của cùng một student
	// CSV format: Grade ID, Username, Fullname, Exam ID, Grade
	cout << endl << "Diem so cac bai kiem tra ma ban da thuc hien:" << endl;
	cout << setw(20) << left << "Ma diem" 
		 << setw(20) << left << "Ma de thi"
		 << setw(20) << left << "Diem" << endl;
	for (vector<string> record : records) {
		if ( student.getUsername().compare(record[1]) == 0 ) {
			cout << setw(20) << left << record[0]
				 << setw(20) << left << record[3]
				 << setw(20) << left << record[4] << endl;
		}
	}
}

bool GradeManager::isStudentDoExamBefore(Exam exam, Student student, string& gradeId) 
{
	// Đọc tất cả điểm thi từ file CSV
	vector<vector<string>> records;
	CSV csv(GRADE_CSV_PATH);
	if ( !csv.readAll(records) ) {
		return false;
	}

	// CSV format: Grade Id, Username, Fullname, Exam ID, Grade
	for (vector<string> record : records) {
		if ( student.getUsername().compare(record[1]) == 0 ) {
			if ( exam.getId().compare(record[3]) == 0 ) {
				gradeId = record[0];
				return true;
			}
		}
	}

	return false;
}