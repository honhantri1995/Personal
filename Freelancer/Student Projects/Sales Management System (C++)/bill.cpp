#include "bill.h"
#include "csv.h"
#include <iostream>
#include <iomanip>
#include <sstream>

// Lấy input về thông tin thanh toán từ người quản lý
bool BillManager::input(Product &product)
{
	cout << "----------------------------------" << endl
			<< "Nhap thong tin hoa don, bao gom: " << endl;

	////////////////////////////////////////////////////////////////////////////////
	// Lấy mã hóa đơn
	string id;
	CSV csv(BILL_CSV_PATH);
	// Kiểm tra thử mã hóa đơn mới có bị trùng với các hóa đơn đang có hay không
	// Nếu có trùng lặp, thông báo lỗi
	while (true) {
		cout << "Ma hoa don: ";
		cin >> id;
		if ( csv.isExistRecord(id) ) {
			cout << "LOI: Ma hoa don da ton tai. Vui long chon ma moi." << endl;
		}
		else {
			break;
		}
	}
	bill.setBillId(id);

	////////////////////////////////////////////////////////////////////////////////
	// Lấy tên SP muốn tạo hóa đơn
	string productId;
	while (true) {
		cout << "Ma san pham: ";
		cin >> productId;
		// Nếu nhập lệnh 'huy', thoát khỏi việc tạo hóa đơn
		if (productId.compare("huy") == 0) {
			cout << "Da huy tao hoa don." << endl;
			return false;
		}

		// Nếu không tìm thấy sản phẩm, yêu cầu nhập lại
		if (productManager.searchProduct(productId, product) == false) {
			cout << "Vui long nhap lai. ";
			cout << "Hoac huy bo viec tao hoa don bang cach nhap lenh 'huy'." << endl;
			continue;
		}
		// Nếu tìm thấy, thoát khỏi vòng lặp để thực hiện những xử lý tiếp theo
		else {
			bill.setProduct(product);
			break;
		}
	};

	////////////////////////////////////////////////////////////////////////////////
	// Lấy số lượng SP muốn bán
	string quantity_str;
	while (true) {
		cout << "So luong san pham muon ban: ";
		cin >> quantity_str;
		if (csv.is_integer(quantity_str) == false) {
			cout << "LOI: So luong san pham phai la mot so nguyen duong. Vui long nhap lai." << endl;
			continue;
		}
		sellProductQuantity = stoi(quantity_str);
		break;
	}

	return true;
}

// Load tất cả hóa đơn từ file CVS và lưu vào tham số đầu ra 'bills'
bool BillManager::loadBills(vector<Bill> &bills)
{
	// Đọc tất cả record từ file Bill.csv
	// Nếu trong quá trình đọc có lỗi gì, thì dừng hàm
	CSV file(BILL_CSV_PATH);
	vector<vector<string>> records;
	if (!file.readAll(records)) {
		return false;
	}

	// Trong từng record, lấy từng item và set thông tin hóa đơn tương ứng
	// Ví dụ: Mã, Tên SP, Số lượng SP đã bán, Tổng giá
	for (vector<string> record : records) {
		// Set mã hóa đơn
		Bill bill;
		bill.setBillId(record[0]);

		// Set thông tin sản phẩm
		Product product;
		product.setId(record[1]);
		product.setName(record[2]);
		product.setQuantity(stoi(record[3]));
		product.setPrice(stold(record[4]));
		bill.setProduct(product);

		// Sau khi có được thông tin SP, lưu vào vector 'bills'
		bills.push_back(bill);
	}

	return true;
}

// Hiển thị title cho thông tin hóa đơn
void BillManager::displayTitle()
{
	cout << endl
		 << setw(20) << left << "Ma hoa don"
		 << setw(20) << left << "Ma san pham"
		 << setw(30) << left << "Ten san pham"
		 << setw(30) << left << "So luong san pham da ban"
		 << setw(20) << left << "Gia san pham (vnd)" << endl;
}

// Hiển thị thông tin hóa đơn
void BillManager::displayValue(Bill bill)
{
	cout << setw(20) << left << bill.getBillId() 
		 << setw(20) << left << bill.getProduct().getId()
		 << setw(30) << left << bill.getProduct().getName()
		 << setw(30) << left << bill.getProduct().getQuantity()
		 << setw(20) << left << std::fixed << std::setprecision(3) << bill.getProduct().getPrice() << endl;
}

// Tạo hóa đơn
void BillManager::createBill()
{
	//////////////////////////////////////////////////////////////////
	// Lấy thông tin sảm phầm từ người dùng
	// Nếu có yêu cầu hủy - không tạo hóa đơn nữa, thoát khỏi hàm
	Product product;
	if (!input(product)) {
		return;
	}

	//////////////////////////////////////////////////////////////////
	// Cập nhập lại số lượng SP sau khi tạo hóa đơn
	int newQuantity = 0;
	// Nếu số lượng muốn mua nhiều hơn số lượng mà cửa hàng đang có,
	// yêu cầu người dùng nhập lại con số nhỏ hơn
	while (true) {
		newQuantity = product.getQuantity() - sellProductQuantity;
		if (newQuantity >= 0) {
			break;
		}
		cout << "LOI: Hien tai cua hang chi co " << product.getQuantity() << " san pham nay." << endl;
		cout << "Vui long nhap lai so luong: ";
		cin >> sellProductQuantity;
	}
	product.setQuantity(newQuantity);
	productManager.updateProduct(product);

	//////////////////////////////////////////////////////////////////
	// Tạo vector chứa tất cả thông tin hóa đơn sau khi tạo
	vector<string> record;
	record.push_back(bill.getBillId());
	record.push_back(product.getId());
	// record.push_back(product.getName());

	stringstream sellProductQuantity_ss;
	sellProductQuantity_ss << sellProductQuantity;
	record.push_back(sellProductQuantity_ss.str());

	stringstream totalPrice_ss;
	totalPrice_ss << std::fixed << std::setprecision(3) << product.getPrice()*sellProductQuantity;
	record.push_back(totalPrice_ss.str());

	//////////////////////////////////////////////////////////////////
	// Ghi thông tin hóa đơn vào file csv
	CSV file(BILL_CSV_PATH);
	file.addRecord(record);

	cout << "Tao hoa don thanh cong." << endl;
}

// Tìm kiếm hóa đơn
void BillManager::searchBill()
{
	string id;
	Bill bill;
	while (true) {
		cout << "Nhap ma hoa don ma ban muon tim.";
		cout << "Hoac huy bo viec tim kiem bang cach nhap lenh 'huy'." << endl;
		cout << "Ma hoa don: ";
		cin >> id;

		// Nếu nhập lệnh 'huy', thoát khỏi việc tạo hóa đơn
		if (id.compare("huy") == 0) {
			return;
		}

		if (searchBill(id)) {
			return;
		}
	}
}

// Tìm kiếm hóa đơn (dựa vào mã hóa đơn)
bool BillManager::searchBill(string billId)
{
	// Load tất cả record từ file csv
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Bill> bills;
	if (!loadBills(bills)) {
		return false;
	}

	// Trong từng SP, so sánh mã SP muốn tìm với danh sách SP
	for (Bill &bill : bills) {
		// Nếu tìm thấy SP, print ra thông tin về SP
		if ( billId.compare(bill.getBillId()) == 0 ) {
			displayTitle();
			displayValue(bill);
			return true;
		}
	}

	// Nếu KHÔNG tìm thấy SP, print ra thông báo
	cout << "LOI: Khong tim thay hoa don." << endl;
	return false;
}

// Xóa sản phẩm
void BillManager::removeBill()
{
	string id;
	while (true) {
		cout << "Nhap ma hoa don ma ban muon xoa.";
		cout << "Hoac huy bo viec xoa bang cach nhap lenh 'huy'." << endl;
		cout << "Ma hoa don: ";
		cin >> id;

		// Nếu nhập lệnh 'huy', thoát khỏi việc tạo hóa đơn
		if (id.compare("huy") == 0) {
			return;
		}

		if (removeBill(id)) {
			return;
		}
	}
}

// Xóa sản phẩm (dựa vào Id)
bool BillManager::removeBill(string billId)
{
	// Xóa sản phẩm tương ứng với mã SP
	CSV file(BILL_CSV_PATH);
	if ( !file.removeRecord(billId) ) {
		cout << "LOI: Xoa hoa don that bai. Dam bao ma hoa don co ton tai." << endl;
		return false;
	}
	
	cout << "Xoa hoa don thanh cong." << endl;
	return true;
}
