=======================================
Chức năng của chương trình, bao gồm:

I - Quan ly san pham
1. Xem san pham
2. Them san pham
3. Tim san pham
4. Xoa san pham

II - Thanh toan
1. Tao hoa don
2. Tim hoa don
3. Xoa hoa don


=================================================================================================================
Mỗi sản phẩm hoặc hóa đơn sẽ có một mã (ID) riêng biệt, không có cái nào giống cái nào.
Nếu người dùng vô tình nhập mã đã tồn tại trong cơ sở dữ liệu, chương trình sẽ thông báo lỗi và yêu cầu nhập lại.


=================================================================================================================
Cơ sở dữ liệu được lưu vào 2 file CSV:
- Product.csv       --> Lưu trữ tất cả sản phẩm
- Bill.csv          --> Lưu trữ tất cả hóa đơn


==================================================================================================================
Để compile source code, trong folder "SaleManagementSystem", chạy lệnh dưới đây trên CMD:
g++ Code\main.cpp Code\product.cpp Code\bill.cpp Code\csv.cpp -o SaleManagementSystem.exe

Để chạy chương trình, trong folder "SaleManagementSystem", chạy lệnh dưới đây từ CMD:
SaleManagementSystem.exe

LƯU Ý:
- Phải cài đặt g++ trước khi chạy lệnh g++.
- Nếu bạn code dự án bằng Visual Studio thì không cần cài g++. Hãy tự tạo project mới bằng Visual Studio sử dụng lại code có sẵn.
Nếu sau khi tạo project bằng Visual Studio mà không compile hoặc chạy code được, liên hệ mình sẽ hướng dẫn