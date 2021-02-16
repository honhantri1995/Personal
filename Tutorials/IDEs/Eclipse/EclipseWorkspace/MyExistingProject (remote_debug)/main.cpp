#include "product.h"
#include "bill.h"
#include <iostream>
using namespace std;

// Class định nghĩa phần menu của chương trình
// Ví dụ:
// =======================================
// Chon mot trong so cac tinh nang sau:
// 1. Quan ly san pham
// 2. Thanh toan
// Nhap su lua chon cua ban:
class Menu
{
public:
	// Menu chính
	void displayMainMenu()
	{
		cout << "=======================================" << endl
			 << "Chon mot trong so cac tinh nang sau: " << endl
			 << "1. Quan ly san pham" << endl
			 << "2. Thanh toan" << endl
			 << "3. Thoat khoi chuong trinh" << endl;
	}

	// Menu về Product Management (quản lý sản phẩm)
	void displayProductManagementMenu()
	{
		cout << "-----------------------------" << endl
				<< "Tiep tuc chon tinh nang: " << endl
				<< "1. Xem tat ca san pham" << endl
				<< "2. Them san pham" << endl
				<< "3. Tim san pham" << endl
				<< "4. Xoa san pham" << endl
				<< "5. Quay lai menu chinh" << endl;
	}

	// Menu về Bill (quản lý thanh toán)
	void displayBillMenu()
	{
		cout << "-----------------------------" << endl
				<< "Tiep tuc chon tinh nang: " << endl
				<< "1. Tao hoa don" << endl
				<< "2. Tim hoa don" << endl
				<< "3. Xoa hoa don" << endl
				<< "4. Quay lai menu chinh" << endl;
	}

	// Lấy lựa chọn từ người dùng
	int getChoice()
	{
		int choice;
		cout << "Nhap su lua chon cua ban: ";
		cin >> choice;
		cout << endl;
		return choice;
	}
};


// Hàm main (entry point) của chương trình
int main()
{
	int choice;						// Sự lựa chọn
	char yesOrNo;					// Có tiếp tục chương trình không. VD: 'y' là tiếp tục, 'n' là không tiếp tục
	Menu menu;						// Menu chương trình
	ProductManager productManager;	// Quản lý sản phẩm
	BillManager billManager;		// Quản lý hóa đơn

	do {
		// Hiển thị menu và lấy sự lựa chọn từ người dùng
		menu.displayMainMenu();
		choice = menu.getChoice();

		// Tùy vào sự lựa chọn, sẽ thực hiện 1 xử lý tương ứng
		switch (choice) {
		// Nếu lựa chọn là "Quản lý sản phẩm"
		case 1:
			menu.displayProductManagementMenu();
			choice = menu.getChoice();

			switch (choice) {
				// Nếu lựa chọn là "Xem tất cả sản phẩm"
				case 1:
					productManager.displayAllProducts();
					break;

				// Nếu lựa chọn là "Thêm sản phẩm"
				case 2:
					productManager.addProduct();
					break;

				// Nếu lựa chọn là "Tìm sản phẩm"
				case 3:
				{
					productManager.searchProduct();
					break;
				}

				// Nếu lựa chọn là "Xóa sản phẩm"
				case 4:
				{
					productManager.removeProduct();
					break;
				}

				// Nếu lựa chọn là "Quay lại menu chính"
				case 5:
					menu.displayMainMenu();
					break;

				default:
					break;
				}
			break;
		
		// Nếu lựa chọn là "Quản lý hóa đơn"
		case 2:
			menu.displayBillMenu();
			choice = menu.getChoice();

			switch (choice) {
				// Nếu lựa chọn là "Tạo hóa đơn"
				case 1:
					billManager.createBill();
					break;

				// Nếu lựa chọn là "Tìm hóa đơn"
				case 2:
				{
					billManager.searchBill();
					break;
				}

				// Nếu lựa chọn là "Xóa hóa đơn"
				case 3:
				{
					billManager.removeBill();
					break;
				}

				// Nếu lựa chọn là "Quay lại menu chính"
				case 4:
					menu.displayMainMenu();
					break;

				default:
					break;
			}
			break;

		// Thoát chương trình
		case 3:
			return 0;

		default:
			break;
		}

		// Hỏi xem người dùng có muốn tiếp tục chương trình hay không
		cout << endl << "Ban co muon tiep tuc (nhap 'y' de tiep tuc): ";
		cin >> yesOrNo;

	} while (yesOrNo == 'y');		// Nếu 'y' là muốn tiếp tục ==> Vòng lặp sẽ tiếp tục

	return 0;
}