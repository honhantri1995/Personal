#include "exam.h"
#include "csv.h"
#include "subject.h"
#include "grade.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <sstream>
#include <windows.h>

// Constructor
ExamManager::ExamManager()
{
	subjectManager = new SubjectManager();
}

// Destructor
ExamManager::~ExamManager()
{
	if (subjectManager) {
		delete subjectManager;
	}
}

// Lấy thông tin đề thi (admin thực hiện)
bool ExamManager::input_byAdmin(Exam &exam)
{
	// Lấy mã môn học
	// Nếu mã môn học không tồn tại, yêu cầu nhập lại
	string subjectId;
	Subject subject;
	while(true) {
		cout << "Nhap ma mon hoc. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma mon hoc: ";
		cin >> subjectId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (subjectId.compare("huy") == 0) {
			return false;
		}
		// Nếu tìm thấy môn học, thoát khỏi hàm
		if ( subjectManager->_searchSubject(subjectId, subject) ) {
			break;
		}
		// Nếu không tìm thấy, hiện thông báo lỗi
		cout << "LOI: Mon hoc khong ton tai. Vui long nhap lai. ";
	}

	// Lấy mã đề thi
	// Lấy mã đề thi đã tồn tại, yêu cầu nhập lại mã đề thi khác
	string examId;
	while(true) {
		cout << "Nhap ma de thi. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma de thi: ";
		cin >> examId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (examId.compare("huy") == 0) {
			return false;
		}
		// Nếu không tìm thấy đề thi, yêu cầu nhập mã khác
		if ( !_searchExam(examId, exam) ) {
			break;
		}
		// Nếu tìm thấy, hiện thông báo lỗi
		cout << "LOI: De thi da ton tai. Vui long nhap lai. ";
	}

	// Lấy đường dẫn đến file đề thi
	string path;
	cout << "Dong dan den file de thi: ";
	cin.ignore(1);
	getline(cin, path);		// Vì đường dẫn có thể chứa dấu space, nên phải dùng getline thay vì >>

	// Lấy trạng thái exam
	string status;
	while (true) {
		cout << "Trang thai de thi (nhap 'open' hoac 'close'): ";
		cin >> status;
		// Nếu trạng thái là 1 trong 2 trạng thái "open" hoặc "close"
		if ( status.compare("open") == 0 || status.compare("close") == 0 ) {
			break;
		}
		// Nếu không đúng, yêu cầu nhập lại
		cout << "LOI: Trang thai khong hop ly. Vui long nhap lai. ";
	}

	// Lưu tất cả thông tin đề thi vào param 'exam'
	exam.setId(examId);
	exam.setSubjectId(subjectId);
	exam.setStatus(status);
	exam.setPath(path);

	return true;
}

// Lấy thông tin đề thi (sinh viên thực hiện)
bool ExamManager::input_byStudent(Exam &exam)
{
	// Lấy mã môn học
	// Nếu mã môn học không tồn tại, yêu cầu nhập lại
	string subjectId;
	Subject subject;
	while(true) {
		cout << "Nhap ma mon hoc. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma mon hoc: ";
		cin >> subjectId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (subjectId.compare("huy") == 0) {
			return false;
		}
		// Nếu tìm thấy môn học, thoát khỏi hàm
		if ( subjectManager->_searchSubject(subjectId, subject) ) {
			break;
		}
		// Nếu không tìm thấy, hiện thông báo lỗi
		cout << "LOI: Mon hoc khong ton tai. Vui long nhap lai. ";
	}

	// Lấy mã đề thi
	// Lấy mã đề thi không tồn tại, yêu cầu nhập mã khác
	string examId;
	while(true) {
		cout << "Nhap ma de thi. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma de thi: ";
		cin >> examId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (examId.compare("huy") == 0) {
			return false;
		}
		// Nếu tìm thấy đề thi, thoát khỏi hàm
		if ( _searchExam(examId, exam) ) {
			break;
		}
		// Nếu không tìm thấy, hiện thông báo lỗi
		cout << "LOI: De thi khong ton tai. Vui long nhap lai. ";
	}

	// Lưu thông tin cần thiết của đề thi vào param 'exam'
	exam.setSubjectId(subjectId);
	exam.setId(examId);

	return true;
}

// Bắt đầu làm bài thi
bool ExamManager::joinExam(Student student)
{
	// Hiển thị tất cả môn học
	cout << "Chon mot trong so cac mon hoc duoi day:";
	subjectManager->displayAllSubjects();

	// Yêu cầu sinh viên chọn đề thi
	Exam exam;
	if ( !input_byStudent(exam) ) {
		return false;
	}

	// Nếu trạng thái của đề thi không phải là "open", thông báo cho SV và dừng hàm
	if ( exam.getStatus().compare("open") != 0 ) {
		cout << endl << "LOI: De thi duoc dong. Ban khong the thuc hien no." << endl;
		return false;
	}
	
	// Bắt đầu làm bài thi
	string examFileOfStudent;
	openExam(exam, student, examFileOfStudent);

	// Lưu tổng số câu hỏi trong bài thi
	exam.setQuestionNumber(getQuestionNumber(exam.getPath()));

	// Lấy tất cả câu trả lời của sinh viên 
#if DO_EXAM_ON_CMD
	// Từ input trên CMD
	vector<string> studentAnswers = getStudentAnswers_FromCmd();
#else
	// Từ file bài làm cua SV
	vector<string> studentAnswers = getStudentAnswers_FromFile(examFileOfStudent);
#endif

	// Lấy đường dẫn của file đáp án dựa theo file đề bài
	// Quy định: File đề bài và đáp án phải được đặt cùng tên, chỉ khác nhau chữ "Exam" hay "Solution"
	// Ví dụ: Nếu file đề thi là "xstk1-Exam.txt", thì file đáp án phải đặt tên là "xstk1-Solution.txt"
	string textToReplace("-Exam");
	string solutionPath = exam.getPath().replace(exam.getPath().find(textToReplace), textToReplace.length(), "-Solution");
	// Lấy tất cả đáp án từ file đáp án
	vector<string> correctAnswers = getCorrectAnswers(solutionPath);

	// Tính điểm và lưu vào database
	int correctAnswerNum;
	GradeManager gradeManager;
	float grade = gradeManager.caculateExamGrade(exam.getPath(), exam.getQuestionNumber(), studentAnswers, correctAnswers, correctAnswerNum);
	gradeManager.saveGrade(exam, student, grade);

	// Hỏi sinh viên có muốn xem điểm không. Nếu có, in ra điểm
	char isCheckResult;
	cout << "Ban co muon xem diem khong (nhap 'y' de xem): ";
	cin >> isCheckResult;
	if (isCheckResult == 'y') {
		cout << "Diem so cua ban la: " << grade << " (Dung " << correctAnswerNum << "/" << exam.getQuestionNumber() << ")" << endl;
	}

	return true;
}

// Mở file đề thi
// Quy định: Đề thi là một file TXT
void ExamManager::openExam(Exam &exam, Student student, string &examFileOfStudent)
{
#if DO_EXAM_ON_CMD
	// In toàn bộ đề thi ra CMD. SV nhập câu trả lời từ CMD
	printExamFile(exam.getPath());
#else
	/////////////////////////////////////////////////////////////////////////////////////////////////////
	// Từ file đề thi gốc, tạo tên mới cho file đề thi tương ứng cho sinh viên
	// VD: Nếu file gốc là "Database\Exam\hh1-Midterm\hh1-Midterm-Exam.txt"
	// thì file mới tương ứng với sinh viên "anguyen" là "Database\Exam\hh1-Midterm\hh1-Midterm-Exam-anguyen.txt"
	// Đầu tiên, tạo ra tên file mới
	string textToReplace(".txt");
	examFileOfStudent = exam.getPath();
	examFileOfStudent.replace(examFileOfStudent.find(textToReplace), textToReplace.length(), "-" + student.getUsername() + ".txt");
	// Sau đó, copy file gốc ra file mới
	CopyFileA(exam.getPath().c_str(), examFileOfStudent.c_str(), true);

	// Mở đề thi. SV làm bài trực tiếp lên đề thi
	openExamFile(examFileOfStudent);
#endif
}

void ExamManager::openExamFile(string filePath)
{
	// Bây giờ, mở file mới để SV làm bài
	system(filePath.c_str());
}

// Lấy tổng số câu hỏi trong bài thi
int ExamManager::getQuestionNumber(string examFilePath)
{
	int totalQuestionNum = 0;
	fstream examFile;
	string line;
	size_t pos;
	string textToFind;

	// Mở file bài làm trong chế độ ĐỌC
	examFile.open(examFilePath, ios::in);
	// Dò từng line trong bài làm để lấy 2 thông tin: Tổng số câu hỏi và Đáp án của mỗi câu
	while (getline(examFile, line)) {
		// Tổng số câu hỏi
		if ( pos = (line.find(QUESTION_NUM) != string::npos) ) {
			textToFind = line.substr(pos - 1 + strlen(QUESTION_NUM));
			textToFind = CSV::trim(textToFind);
			totalQuestionNum = stoi(textToFind);
			break;
		}
	}

	// Cuối cùng, đóng file bài làm
	examFile.close();

	return totalQuestionNum;
}

// Lấy tất cả câu trả lời từ bài làm (từ file bài làm)
vector<string> ExamManager::getStudentAnswers_FromFile(string examFilePath)
{
	vector<string> answers;
	fstream examFile;
	string line;
	size_t pos;
	string textToFind;

	// Mở file bài làm trong chế độ ĐỌC
	examFile.open(examFilePath, ios::in);
	// Dò từng line trong bài làm để lấy 2 thông tin: Tổng số câu hỏi và Đáp án của mỗi câu
	while (getline(examFile, line)) {
		// Đáp án của mỗi câu
		if (pos = (line.find(ANSWER) != string::npos) ) {
			textToFind = line.substr(pos - 1 + strlen(ANSWER));
			textToFind = CSV::trim(textToFind);
			answers.push_back(textToFind);
		}
	}

	// Cuối cùng, đóng file bài làm
	examFile.close();

	return answers;
}

#if DO_EXAM_ON_CMD
void ExamManager::printExamFile(string examFile)
{
	// Set page code (encoder) cho CMD để hiển thị được tiếng Việt có dấu
	SetConsoleOutputCP(65001);

	// In toàn bộ đề bài thi
	fstream file;
	file.open(examFile, ios::in | ios::out | ios::app);
	string line;
	while (getline(file, line)) {
		cout << line << endl;
	}
	file.close();
}

vector<string> ExamManager::getStudentAnswers_FromCmd()
{
	// Lấy nội dung phản hồi và lưu nào class member 'message'
	cout << endl << "***************************** PHAN TRA LOI ******************************" << endl;
	cout << "Lan luot nhap tung cau tra loi cua ban cho tung cau hoi o tren theo thu tu." << endl;
	cout << "Moi cau tra loi tren mot dong. Vi du, de tra loi 4 cau hoi theo thu tu trong de thi, nhap:" << endl;
	cout << "\tA\n\tB\n\tC\n\tD" << endl;
	cout << "Sau khi nhap tat ca cau tra loi cho tat ca cau hoi, nhap lenh 'hoan thanh' tren mot dong rieng de ket thuc bai thi." << endl;
	cout << "Cac cau tra loi cua ban:" << endl;
	cin.ignore(1);

	vector<string> answers;
	string line;
	char isDone;
	while (true) {
		getline(cin, line);
		// Nếu line rỗng hoặc chỉ chứa toàn dấu space, bỏ qua
		if (CSV::trim(line).empty()) {
			continue;
		}
		// Nếu nhập lệnh 'hoan thanh'
		if (line.compare("hoan thanh") == 0) {
			cout << "Ban co chac chan muon ket thuc bai thi khong ('y' la dong y): ";
			cin >> isDone;
			if (isDone == 'y') {
				// Nếu số câu trả lời nhiều hơn số câu hỏi, yêu cầu nhập lại toàn bộ câu trả lời
				if (answers.size() > exam.getQuestionNumber()) {
					answers.clear();
					cout << "LOI: So luong cau tra loi ma ban nhap vuot qua so luong cau hoi. Vui long kiem tra lai!" << endl;
					cout << "Cac cau tra loi cua ban:" << endl;
					cin.ignore(1);
					continue;
				}

				cout << "Chuc mung ban da hoan thanh bai thi!" << endl << endl;
				break;
			}
			else {
				answers.clear();
				cout << "Vui long nhap lai cau tra loi cho toan bo cau hoi. Hoc nhap lenh 'hoan thanh' tren mot dong rieng de ket thuc bai thi." << endl;
				cout << "Cac cau tra loi cua ban:" << endl;
				cin.ignore(1);
				continue;
			}
		}
		answers.push_back(line);
	}

	return answers;
}
#endif 		// DO_EXAM_ON_CMD

// Lấy đáp án đúng của đề thi (từ file đáp án)
vector<string> ExamManager::getCorrectAnswers(string solutionPath)
{
	vector<string> answers;
	fstream solutionFile;
	string line;

	// Mở file đáp áp
	solutionFile.open(solutionPath, ios::in);
	// Mỗi line của file tương ứng với 1 đáp án của 1 câu hỏi
	while (getline(solutionFile, line)) {
		// Nếu line bắt đầu bằng ký tư '#' thì đây là một comment
		// nên không cần lưu thông tin của line này, mà bỏ qua để dọc các line tiếp theo
		if (line[0] == '#') {
			continue;
		}

		// Nếu line rỗng, thì bỏ qua không đọc line này
		if (line.empty()) {
			continue;
		}

		// Lưu tất cả đáp án vào vector 'answers'
		answers.push_back( CSV::trim(line) );
	}

	// Cuối cùng, đóng file đáp án
	solutionFile.close();

	return answers;
}

// Load thông tin của tất cả đề thi từ file CSV
bool ExamManager::loadExams(vector<Exam> &exams)
{
	// Đọc thông tin của tất cả đề thi từ file CSV
	CSV file(EXAMINFO_CSV_PATH);
	vector<vector<string>> records;
	if (!file.readAll(records)) {
		return false;
	}

	// Trong từng đề thi, lấy tất cả thông tin cần thiết
	// CSV format: ExamID, SubjectID, Status, Path to exam
	for (vector<string> record : records) {
		Exam exam;
		exam.setId(record[0]);
		exam.setSubjectId(record[1]);
		exam.setStatus(record[2]);
		exam.setPath(record[3]);

		// Sau khi có được thông tin đề thi, lưu vào tham số 'exams'
		exams.push_back(exam);
	}

	return true;
}

// Hiển thị tiêu đề
void ExamManager::displayTitle()
{
	cout << endl 
		 << setw(20) << left << "Ma mon hoc"
		 << setw(20) << left << "Ma de thi"
		 << setw(20) << left << "Trang thai"
		 << setw(80) << left << "Duong dan den de thi" << endl;
}

// Hiển thị thông tin đề thi
void ExamManager::displayExam(Exam exam)
{
	cout << setw(20) << left << exam.getSubjectId()
		 << setw(20) << left << exam.getId()
		 << setw(20) << left << exam.getStatus()
		 << setw(80) << left << exam.getPath() << endl;
}

// Hiển thị thông tin của tất cả đề thi
void ExamManager::displayAllExams()
{
	// Load tất cả record từ file CSV
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Exam> exams;
	if (!loadExams(exams)) {
		return;
	}

	displayTitle();
	// Cho từng đề thi, print ra thông tin
	for (Exam exam : exams) {
		displayExam(exam);
	}
}

// Thêm đề thi mới vào file CSV
void ExamManager::addExam()
{
	// Hiển thị tất cả môn học
	cout << "Chon mot trong so cac mon hoc duoi day:";
	subjectManager->displayAllSubjects();

	// Lấy thông tin đề thi từ admin
	Exam exam;
	if ( !input_byAdmin(exam) ) {
		return;
	}

	// Lưu thông tin đề thi
	vector<string> newRecord;
	newRecord.push_back(exam.getId());
	newRecord.push_back(exam.getSubjectId());
	newRecord.push_back(exam.getStatus());
	newRecord.push_back(exam.getPath());

	// Sau khi có đầy đủ thông tin, ghi tất cả vào file CSV
	CSV file(EXAMINFO_CSV_PATH);
	if ( !file.addRecord(newRecord) ) {
		cout << "LOI: Them de thi that bai." << endl;
		return;
	}
	cout << "Them de thi thanh cong." << endl;
}

// Tìm kiếm đề thi
void ExamManager::searchExam()
{
	// Lấy mã đề thi
	// Nếu đề thi không tòn tại, yêu cầu nhập lại
	Exam exam;
	string examId;
	while(true) {
		cout << "Nhap ma de thi. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma de thi: ";
		cin >> examId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (examId.compare("huy") == 0) {
			return;
		}
		// Nếu tìm thấy đề thi, thoát khỏi hàm
		if (_searchExam(examId, exam)) {
			return;
		}
		// Nếu không tìm thấy, thông báo lỗi
		cout << "LOI: De thi khong ton tai. Vui long nhap lai." << endl;
	}
}

// Tìm kiếm đề thi
void ExamManager::searchExam(Exam &exam)
{
	// Lấy mã đề thi
	// Nếu đề thi không tòn tại, yêu cầu nhập lại
	string examId;
	while(true) {
		cout << "Nhap ma de thi. Hoac huy bo bang cach nhap lenh 'huy'." << endl;
		cout << "Ma de thi: ";
		cin >> examId;
		// Nếu chọn hủy tìm kiếm, thoát khỏi hàm
		if (examId.compare("huy") == 0) {
			return;
		}
		// Nếu tìm thấy đề thi, thoát khỏi hàm
		if (_searchExam(examId, exam)) {
			return;
		}
		// Nếu không tìm thấy, thông báo lỗi
		cout << "LOI: De thi khong ton tai. Vui long nhap lai." << endl;
	}
}

// Tìm kiếm đề thi
bool ExamManager::_searchExam(string examId, Exam &exam)
{
	// Load tất cả record từ file CSV
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Exam> exams;
	if (!loadExams(exams)) {
		return false;
	}

	// Trong từng đề thi, so sánh mã đề thi muốn tìm với danh sách đề thi
	for (Exam &e : exams) {
		// Nếu tìm thấy đề thi, print ra thông tin về đề thi
		if ( examId.compare(e.getId()) == 0 ) {
			displayTitle();
			displayExam(e);
			exam = e;
			return true;
		}
	}

	// Nếu KHÔNG tìm thấy đề thi, print ra thông báo
	return false;
}

// Cập nhật đề thi
void ExamManager::updateExam()
{
	///////////////////////////////////////////////////////////////////
	// Lấy mã đề thi
	// Nếu nhập mã không tồn tại, báo lỗi và yêu cầu nhập lại
	string id;
	Exam exam;
	while (true) {
		cout << "Ma de thi: ";
		cin >> id;
		if ( !_searchExam(id, exam) ) {
			cout << "LOI: De thi khong ton tai. Vui long nhap lai." << endl;
		}
		else {
			break;
		}
	}

	///////////////////////////////////////////////////////////////////
	// Lấy trạng thái exam
	string status;
	while (true) {
		cout << "Doi thanh trang thai (nhap 'open' hoac 'close'): ";
		cin >> status;
		// Nếu trạng thái là 1 trong 2 trạng thái "open" hoặc "close"
		if ( status.compare("open") == 0 || status.compare("close") == 0 ) {
			break;
		}
		// Nếu không đúng, yêu cầu nhập lại
		cout << "LOI: Trang thai khong hop ly. Vui long nhap lai. ";
	}

	// Lấy đường dẫn đến đề thi moi
	string path;
	cout << "Doi thanh duong dan: ";
	cin.ignore(1);
	getline(cin, path);		// Vì tên đề thi có thể chứa dấu space, nên phải dùng getline thay vì >>
	
	// Lưu tất cả thông tin sau khi cập nhật vào record mới
	vector<string> newRecord;
	newRecord.push_back(id);
	newRecord.push_back(exam.getSubjectId());
	newRecord.push_back(status);
	newRecord.push_back(path);

	// Sau khi có được tất cả thông tin đề thi, cập nhật vào file Exam.csv
	CSV file(EXAMINFO_CSV_PATH);
	if ( !file.updateRecord(id, newRecord) ) {
		cout << "LOI: Cap nhat de thi that bai." << endl;
		return;
	}
	cout << "Cap nhat de thi thanh cong." << endl;
}

// Xóa đề thi
void ExamManager::removeExam()
{
	// Lấy mã đề thi muốn xóa
	string examId;
	cout << "Nhap ma mon hoc: ";
	cin >> examId;

	// Xóa đề thi
	_removeExam(examId);
}

// Xóa đề thi dựa vào mã đề thi
void ExamManager::_removeExam(string examId)
{
	// Xóa đề thi tương ứng với mã đề thi
	CSV file(EXAMINFO_CSV_PATH);
	if ( !file.removeRecord(examId) ) {
		cout << "LOI: Xoa de thi that bai. Dam bao ma de thi co ton tai." << endl;
		return;
	}
	cout << "Xoa de thi thanh cong." << endl;
}