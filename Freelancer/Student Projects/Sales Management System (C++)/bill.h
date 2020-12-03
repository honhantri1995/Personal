#pragma once

#include <string>
#include <fstream>
#include <vector>
#include "Product.h"
using namespace std;

#define	BILL_CSV_PATH		"Database\\Bill.csv"

// Class để quản lý hóa đơn thanh toán
class Bill
{
private:
	string id;					// Mã hóa đơn
	Product product;			// Sản phẩm

public:
	string getBillId()	{ return id; }
	void setBillId(string input) { id = input; }
	Product getProduct() { return product; }
	void setProduct(Product input) { product = input; }
};

class BillManager
{
private:
	Bill bill;						// Hóa đơn
	ProductManager productManager;	// Quản lý sản phẩm
	int sellProductQuantity;		// Số lượng sản phẩm muốn bán

public:
	bool input(Product &product);
	bool loadBills(vector<Bill> &bills);

	void displayTitle();
	void displayValue(Bill bill);

	void createBill();

	void searchBill();
	bool searchBill(string billId);

	void removeBill();
	bool removeBill(string billId);
};