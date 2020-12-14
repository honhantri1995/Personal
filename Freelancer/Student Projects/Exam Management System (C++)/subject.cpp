#include "subject.h"
#include "csv.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <sstream>

// Lấy input về thông tin môn học từ admin
void SubjectManager::input(Subject &subject)
{
	cout << "----------------------------------" << endl
		 << "Nhap thong tin mon hoc, bao gom: " << endl;

	////////////////////////////////////////////////////////////////////
	// Lấy mã môn học
	string id;
	CSV csv(SUBJECT_CSV_PATH);
	// Kiểm tra thử mã môn học mới có bị trùng với các môn học đang có hay không
	// Nếu có trùng lặp, thông báo lỗi
	while (true) {
		cout << "Ma mon hoc: ";
		cin >> id;
		if ( csv.isExistRecord(id) ) {
			cout << "LOI: Ma mon hoc da ton tai. Vui long chon ma moi." << endl;
		}
		else {
			break;
		}
	}
	subject.setId(id);

	////////////////////////////////////////////////////////////////////
	// Lấy tên môn học
	string name;
	cout << "Ten mon hoc: ";
	cin.ignore(1);
	getline(cin, name);		// Vì tên môn học có thể chứa dấu space, nên phải dùng getline thay vì >>
	subject.setName(name);
}

// Load tất cả môn học từ file CVS
bool SubjectManager::loadSubject(vector<Subject> &subjects)
{
	// Đọc tất cả record từ file CSV
	// Nếu trong quá trình đọc có lỗi gì, thì dừng hàm
	CSV file(SUBJECT_CSV_PATH);
	vector<vector<string>> records;
	if (!file.readAll(records)) {
		return false;
	}

	// Trong từng record, lấy từng item và set thông tin môn học tương ứng
	// CSV format: Subject ID, subject name
	for (vector<string> record : records) {
		Subject subject;
		subject.setId(record[0]);
		subject.setName(record[1]);

		// Sau khi có được thông tin môn học, lưu vào param 'subjects'
		subjects.push_back(subject);
	}

	return true;
}

// Hiển thị tiêu đề
void SubjectManager::displayTitle()
{
	cout << endl << setw(20) << left << "Ma mon hoc" << setw(30) << left << "Ten mon hoc" << endl;
}

// Hiển thị thông tin môn học
void SubjectManager::displaySubject(Subject subject)
{
	cout << setw(20) << left << subject.getId() << setw(30) << left << subject.getName() << endl;
}

void SubjectManager::displayAllSubjects()
{
	// Load tất cả record từ file CSV
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Subject> subjects;
	if (!loadSubject(subjects)) {
		return;
	}

	displayTitle();
	// Cho từng môn học, print ra thông tin
	for (Subject subject : subjects) {
		displaySubject(subject);
	}
	cout << endl;
}

void SubjectManager::addSubject()
{
	// Lấy thông tin môn học từ admin
	Subject subject;
	input(subject);

	// Lưu thông tin môn học vào vector
	vector<string> newRecord;
	newRecord.push_back(subject.getId());
	newRecord.push_back(subject.getName());

	// Sau khi có đầy đủ thông tin, ghi tất cả vào file CSV
	CSV file(SUBJECT_CSV_PATH);
	if ( !file.addRecord(newRecord) ) {
		cout << "LOI: Them mon hoc that bai." << endl;
		return;
	}
	cout << "Them mon hoc thanh cong." << endl;
}

void SubjectManager::searchSubject()
{
	// Lấy mã môn học
	// Nếu môn học không tòn tại, yêu cầu nhập lại
	Subject subject;
	string subjectId;
	while(true) {
		cout << "Nhap ma mon hoc. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma mon hoc: ";
		cin >> subjectId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (subjectId.compare("huy") == 0) {
			return;
		}
		// Nếu tìm thấy môn học, thoát khỏi hàm
		if (_searchSubject(subjectId, subject)) {
			return;
		}
		// Nếu không tìm thấy, hiện thông báo lỗi
		cout << "LOI: Mon hoc khong ton tai. Vui long nhap lai. ";
	}
}

bool SubjectManager::_searchSubject(string subjectId, Subject &out_subject)
{
	// Load tất cả record từ file CSV
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Subject> subjects;
	if (!loadSubject(subjects)) {
		return false;
	}

	// Trong từng môn học, so sánh mã môn học muốn tìm với danh sách môn học
	for (Subject &subject : subjects) {
		// Nếu tìm thấy môn học, print ra thông tin về môn học
		if ( subjectId.compare(subject.getId()) == 0 ) {
			displayTitle();
			displaySubject(subject);
			out_subject = subject;
			return true;
		}
	}

	// Nếu KHÔNG tìm thấy môn học, return false
	return false;
}

// Cập nhật môn học
void SubjectManager::updateSubject()
{
	///////////////////////////////////////////////////////////////////
	// Lấy mã môn học
	// Nếu nhập mã không tồn tại, báo lỗi và yêu cầu nhập lại
	string id;
	Subject subject;
	while (true) {
		cout << "Ma mon hoc: ";
		cin >> id;
		if ( !_searchSubject(id, subject) ) {
			cout << "LOI: Mon hoc khong ton tai. Vui long nhap lai." << endl;
		}
		else {
			break;
		}
	}

	///////////////////////////////////////////////////////////////////
	// Lấy tên môn học moi
	string name;
	cout << "Doi thanh mon hoc: ";
	cin.ignore(1);
	getline(cin, name);		// Vì tên môn học có thể chứa dấu space, nên phải dùng getline thay vì >>
	subject.setName(name);
	
	// Lưu thông tin về mã và tên môn học vào record mới
	vector<string> new_record;
	new_record.push_back(id);
	new_record.push_back(name);

	// Sau khi có được tất cả thông tin môn học, cập nhật vào file Subject.csv
	CSV file(SUBJECT_CSV_PATH);
	if ( !file.updateRecord(id, new_record) ) {
		cout << "LOI: Cap nhat mon hoc that bai." << endl;
		return;
	}
	cout << "Cap nhat mon hoc thanh cong." << endl;
}

// Xóa môn học
void SubjectManager::removeSubject()
{
	// Lấy mã môn học muốn xóa
	string subjectId;
	cout << "Nhap ma mon hoc ";
	cin >> subjectId;

	// Xóa môn học
	_removeSubject(subjectId);
}

// Xóa môn học dựa vào mã môn học
void SubjectManager::_removeSubject(string subjectId)
{
	// Xóa môn học tương ứng với mã môn học
	CSV file(SUBJECT_CSV_PATH);
	if ( !file.removeRecord(subjectId) ) {
		cout << "LOI: Xoa mon hoc that bai. Dam bao ma mon hoc co ton tai." << endl;
		return;
	}
	cout << "Xoa mon hoc thanh cong." << endl;
}