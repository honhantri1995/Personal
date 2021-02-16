#pragma once

#include <string>
#include <fstream>
#include <vector>
using namespace std;

#define	PRODUCT_CSV_PATH	"Database/Product.csv"

// Class để định nghĩa tất cả thuộc tính của một sản phẩm
class Product
{
private:
	string id;				// Mã sản phẩm
	string name;			// Tên sản phẩm
	int quantity;			// Số lượng sản phẩm
	long double price;		// Giá của sản phẩm

public:
	string getId() { return id; }
	void setId(string input) { id = input; }
	string getName() { return name; }
	void setName(string input) { name = input; }
	int getQuantity() { return quantity; }
	void setQuantity(int input) { quantity = input; }
	long double getPrice() { return price; }
	void setPrice(long double input) { price = input; }
};

// Class để quản lý sản phẩm
class ProductManager
{
private:
	Product product;

public:
	Product getProduct() { return product; }
	void setProduct(Product input) { product = input; }

	void input();
	bool loadProduct(vector<Product> &products);

	void displayTitle();
	void displayValue(Product product);
	void displayAllProducts();

	void addProduct();

	void searchProduct();
	bool searchProduct(string productId, Product &out_product);

	void updateProduct(Product product);

	void removeProduct();
	bool removeProduct(string productId);
};