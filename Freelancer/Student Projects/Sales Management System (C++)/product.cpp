#include "product.h"
#include "csv.h"
#include <iostream>
#include <iomanip>
#include <sstream>

// Lấy input về thông tin sản phẩm từ người quản lý
void ProductManager::input()
{
	cout << "----------------------------------" << endl
		 << "Nhap thong tin san pham, bao gom: " << endl;

	////////////////////////////////////////////////////////////////////
	// Lấy mã SP
	string id;
	CSV csv(PRODUCT_CSV_PATH);
	// Kiểm tra thử mã SP mới có bị trùng với các SP đang có hay không
	// Nếu có trùng lặp, thông báo lỗi
	while (true) {
		cout << "Ma san pham: ";
		cin >> id;
		if ( csv.isExistRecord(id) ) {
			cout << "LOI: Ma san pham da ton tai. Vui long chon ma moi." << endl;
		}
		else {
			break;
		}
	}
	product.setId(id);

	////////////////////////////////////////////////////////////////////
	// Lấy tên SP
	string name;
	cout << "Ten san pham: ";
	cin.ignore(1);
	getline(cin, name);		// Vì tên sản phẩm có thể chứa dấu space, nên phải dùng getline thay vì >>
	product.setName(name);

	////////////////////////////////////////////////////////////////////
	// Lấy số lượng SP
	string quantity_str;
	while (true) {
		cout << "So luong san pham: ";
		cin >> quantity_str;
		if (csv.is_integer(quantity_str) == false) {
			cout << "LOI: So luong san pham phai la mot so nguyen duong. Vui long nhap lai." << endl;
			continue;
		}
		product.setQuantity(stoi(quantity_str));		// Convert kiểu dữ liệu từ string sang int trước khi lưu vào object Product
		break;
	}

	////////////////////////////////////////////////////////////////////
	// Lấy giá SP
	string price_str;
	while (true) {
		cout << "Gia san pham (vnd): ";
		cin >> price_str;
		if (csv.is_integer(price_str) == false) {
			cout << "LOI: Gia san pham phai la mot so duong. Vui long nhap lai." << endl;
			continue;
		}
		product.setPrice(stoi(price_str));		// Convert kiểu dữ liệu từ string sang int trước khi lưu vào object Product
		break;
	}
}

// Load tất cả sản phẩm từ file CVS và lưu vào tham số đầu ra 'products'
bool ProductManager::loadProduct(vector<Product> &products)
{
	// Đọc tất cả record từ file Product.csv
	// Nếu trong quá trình đọc có lỗi gì, thì dừng hàm
	CSV file(PRODUCT_CSV_PATH);
	vector<vector<string>> records;
	if (!file.readAll(records)) {
		return false;
	}

	// Trong từng record, lấy từng item và set thông tin sản phẩm tương ứng
	// Ví dụ: Mã, Tên, Số lượng, Giá
	for (vector<string> record : records) {
		Product product;
		product.setId(record[0]);
		product.setName(record[1]);
		product.setQuantity(stoi(record[2]));
		product.setPrice(stold(record[3]));

		// Sau khi có được thông tin SP, lưu vào vector 'products'
		products.push_back(product);
	}

	return true;
}

// Hiển thị title cho thông tin sản phẩm
void ProductManager::displayTitle()
{
	cout << endl
		 << setw(20) << left << "Ma san pham"
		 << setw(40) << left << "Ten san pham"
		 << setw(30) << left << "So luong san pham"
		 << setw(30) << left << "Gia san pham (vnd)" << endl;
}

// Hiển thị thông tin sản phẩm
void ProductManager::displayValue(Product product)
{
	cout << setw(20) << left << product.getId()
		 << setw(40) << left << product.getName()
		 << setw(30) << left << product.getQuantity()
		 << setw(30) << left << std::fixed << std::setprecision(3) << product.getPrice() << endl;
}

void ProductManager::displayAllProducts()
{
	// Load tất cả record từ file csv
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Product> products;
	if (!loadProduct(products)) {
		return;
	}

	// Cho từng SP, print ra thông tin
	displayTitle();
	for (Product product : products) {
		displayValue(product);
	}
}

void ProductManager::addProduct()
{
	// Lấy thông tin sảm phầm từ người dùng
	input();

	// Tạo vector chứa tất cả thông tin hóa đơn sau khi tạo
	vector<string> record;
	record.push_back(product.getId());
	record.push_back(product.getName());

	stringstream quantity_ss;
	quantity_ss << product.getQuantity();
	record.push_back(quantity_ss.str());

	stringstream price_ss;
	price_ss << std::fixed << std::setprecision(3) << product.getPrice();
	record.push_back(price_ss.str());

	// Sau khi có đầy đủ thông tin, ghi tất cả vào file csv
	CSV file(PRODUCT_CSV_PATH);
	if ( !file.addRecord(record) ) {
		cout << "Them san pham that bai." << endl;
		return;
	}
	cout << "LOI: Them san pham thanh cong." << endl;
}

// Tìm kiếm sản phẩm
void ProductManager::searchProduct()
{
	string id;
	Product product;
	while (true) {
		cout << "Nhap ma san pham ma ban muon tim.";
		cout << "Hoac huy bo viec tim kiem bang cach nhap lenh 'huy'." << endl;
		cout << "Ma san pham: ";
		cin >> id;

		// Nếu nhập lệnh 'huy', thoát khỏi việc tạo hóa đơn
		if (id.compare("huy") == 0) {
			return;
		}

		if (searchProduct(id, product)) {
			return;
		}
	}
}

// Tìm kiểm sản phẩm (dựa vào mã sản phẩm)
bool ProductManager::searchProduct(string productId, Product &out_product)
{
	// Load tất cả record từ file csv
	// Nếu quá trình load file có lỗi, dừng hàm
	vector<Product> products;
	if (!loadProduct(products)) {
		return false;
	}

	// Trong từng SP, so sánh mã SP muốn tìm với danh sách SP
	for (Product &product : products) {
		// Nếu tìm thấy SP, print ra thông tin về SP
		if ( productId.compare(product.getId()) == 0 ) {
			displayTitle();
			displayValue(product);
			out_product = product;
			return true;
		}
	}

	// Nếu KHÔNG tìm thấy SP, print ra thông báo
	cout << "LOI: Khong tim thay san pham." << endl;
	return false;
}

// Cập nhật sản phẩm
void ProductManager::updateProduct(Product product)
{
	vector<string> new_record;
	
	// Lấy thông tin về mã SP và tên SP
	new_record.push_back(product.getId());
	new_record.push_back(product.getName());

	// Lấy thông tin về số lượng SP
	stringstream ss_quantity;
	ss_quantity << product.getQuantity();
	new_record.push_back(ss_quantity.str());

	// Lấy thông tin về giá SP
	stringstream ss_price;
	ss_price << std::fixed << std::setprecision(3) << product.getPrice();
	new_record.push_back(ss_price.str());

	// Sau khi có được tất cả thông tin SP, cập nhật vào file Product.csv
	CSV file(PRODUCT_CSV_PATH);
	if ( !file.updateRecord(product.getId(), new_record) ) {
		cout << "LOI: Cap nhat san pham that bai." << endl;
		return;
	}
	cout << "Cap nhat san pham thanh cong." << endl;
}

// Xóa sản phẩm
void ProductManager::removeProduct()
{
	string id;
	while (true) {
		cout << "Nhap ma san pham ma ban muon xoa.";
		cout << "Hoac huy bo viec xoa bang cach nhap lenh 'huy'." << endl;
		cout << "Ma san pham: ";
		cin >> id;

		// Nếu nhập lệnh 'huy', thoát khỏi việc tạo hóa đơn
		if (id.compare("huy") == 0) {
			return;
		}

		if (removeProduct(id)) {
			return;
		}
	}
}

// Xóa sản phẩm (dựa theo Id)
bool ProductManager::removeProduct(string productId)
{
	// Xóa sản phẩm tương ứng với mã SP
	CSV file(PRODUCT_CSV_PATH);
	if ( !file.removeRecord(productId) ) {
		cout << "LOI: Xoa san pham that bai. Dam bao ma san pham co ton tai." << endl;
		return false;
	}
	
	cout << "Xoa san pham thanh cong." << endl;
	return true;
}