#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <iomanip>
#include <windows.h>

#include <graphics.h>
#include <conio.h>
#include <dos.h>
using namespace std;

// Duong dan den file txt
#define FILE_PATH	"in.txt"

// Thong tin hoa don
typedef struct _HoaDon
{
	string maHoaDon;
	string ngayTao;
	double giaTien;
} HoaDon;

// Toa do cua mot diem tren man hinh
typedef struct _Diem {
	int x;
	int y;
} Diem;

// Kinh thuoc man hinh (chieu rong va chieu cao)
//   Can thong tin nay de tao chart cho khop voi kich thuoc man hinh dang dung
typedef struct _ScreenSize {
	int width;
	int height;
} ScreenSize;
ScreenSize screenSize;

// Tuy chon khoang thoi gian khi tao chart (theo thang hay quy)
enum THOIGIAN {
	THEO_QUY = 1,
	THEO_THANG
};

// Danh sach tat ca hoa don tu file txt
vector<HoaDon> dsHoaDon;

// Doanh thu cua 12 thang
double doanhThuThang[12];
// Doanh thu cua 4 quy
double doanhThuQuy[4];

// 12 mau sac 
int MAU[] = {GREEN, BLUE, YELLOW, RED, BROWN, CYAN, MAGENTA, BROWN, DARKGRAY, LIGHTGREEN, LIGHTBLUE, LIGHTRED};

// Doc file txt va lay thong tin hoa don
bool docFile(string path)
{ 
	fstream file;

	// Mo file txt o che do DOC.
	// Neu qua trinh mo file bi loi (duong dan bi sai, ...), thong bao loi va dung ham.
	file.open(path, ios::in);
	if(!file) {
		cout << "LOI: Khong the mo file " << path << ". Vui long kiem tra lai." << endl;
		return false;
	}

	string line;			// Tung dong trong file txt
	string item;			// Tung phan tu moi dong (ma, ngay tao, tien, ...), moi phan tu cach nhau bang mot dau ','
	vector<string> items;	// Danh sach tat ca phan tu cua moi dong

	// Doc tung line tu file txt cho den het file
	while (getline(file, line)) {
		// Dua vao dau ',', tach cac phan tu cua moi line, va luu tht ca phan tu vao vector 'items'
		stringstream ss(line);
		while( getline(ss, item, ',') ) {
			items.push_back(item);
		}

		// Luu lan luot cac phan tu vao struct 'HoaDon'
		HoaDon hoaDon;
		hoaDon.maHoaDon = items[0];
		hoaDon.ngayTao = items[1];
		hoaDon.giaTien = stod(items[2]);

		// Luu tung hoa hon vao vector 'dsHoaDon'
		dsHoaDon.push_back(hoaDon);

		// Xoa gia tri cua struct 'HoaDon' de chuan bi cho lan lap lai tiep theo
		items.clear();
	}

	// Dong file txt
	file.close();
	
	return true;
}

// Tinh doanh thu theo thang va theo quy
void tinhDoanhThu()
{
	vector<int> ngayThangNam;			// Mang 3 phan tu luu lan luot: ngay, thang va nam
	string item;						// Tung phan tu cua mot dong ngay/thang/nam (18/02/2020) tu file txt
	int i, j;

	// Cong doanh thu cua tung hoa don voi danh thu chung (phan biet theo thang va quy)
	for (i = 0; i < dsHoaDon.size(); i++) {
		stringstream ss(dsHoaDon[i].ngayTao);

		// Dua vao dau '/', tach lan luot ngay/thang/nam
		while( getline(ss, item, '/') ) {
			ngayThangNam.push_back(stoi(item));
		}

		for (j = 0; j < 12; j++) {
			if (ngayThangNam[1] == j + 1) {
				// Cong don doanh thu cua thang nay voi danh thu chung (theo thang)
				doanhThuThang[j] += dsHoaDon[i].giaTien;

				// Neu quy 1
				if (ngayThangNam[1] == 1
					|| ngayThangNam[1] == 2
					|| ngayThangNam[1] == 3) {
					// Cong don doanh thu cua quy nay voi danh thu chung (theo quy)
					doanhThuQuy[0] += dsHoaDon[i].giaTien;
				}
				// Hoac neu quy 2
				else if (ngayThangNam[1] == 4
					|| ngayThangNam[1] == 5
					|| ngayThangNam[1] == 6) {
					// Cong don doanh thu cua quy nay voi danh thu chung (theo quy)
					doanhThuQuy[1] += dsHoaDon[i].giaTien;
				}
				// Hoac neu quy 3
				else if (ngayThangNam[1] == 7
					|| ngayThangNam[1] == 8
					|| ngayThangNam[1] == 9) {
					// Cong don doanh thu cua quy nay voi danh thu chung (theo quy)
					doanhThuQuy[2] += dsHoaDon[i].giaTien;
				}
				// Hoac neu quy 4
				else if (ngayThangNam[1] == 10
					|| ngayThangNam[1] == 11
					|| ngayThangNam[1] == 12) {
					// Cong don doanh thu cua quy nay voi danh thu chung (theo quy)
					doanhThuQuy[3] += dsHoaDon[i].giaTien;
				}

				break;
			}
		}

		// Xoa gia tri cua vector 'ngayThangName' de chuan bi cho lan lap lai tiep theo
		ngayThangNam.clear();
	}

	// In ra doanh thu cua tung thang
	for (i = 0; i < 12; i++) {
		cout << fixed << setprecision(3) << "Danh thu thang " << i + 1 << ": " << doanhThuThang[i] << endl;
	}
	cout << endl;

	// In ra doanh thu cua tung quy
	for (i = 0; i < 4; i++) {
		cout << fixed << setprecision(3) << "Danh thu quy " << i + 1 << ": " << doanhThuQuy[i] << endl;
	}
}

// Tim quy hoac thang co doanh thu lon nhat
//   Ham return doanh thu lon nhat. Thong tin nay se duoc dung de chia ti le cho cac chart khi ve line char va bar chart
double timDoanhThuLonNhat(THOIGIAN thoiGian)
{
	int i;
	double max;

	if (thoiGian == THEO_QUY) {
		max = doanhThuQuy[0];
		for (i = 1; i < 4; i++) {
			if (doanhThuQuy[i] > max) {
				max = doanhThuQuy[i];
			}
		}
	}
	else {
		max = doanhThuThang[0];
		for (i = 1; i < 12; i++) {
			if (doanhThuThang[i] > max) {
				max = doanhThuThang[i];
			}
		}
	}

	return max;
}

// Tinh tong doanh thu cua quy hoac thang
//   Ham return tong doanh thu. Thong tin nay se duoc dung de chia ti le cho cac chart khi ve pie chart
double tinhTongDoanhThu(THOIGIAN thoiGian)
{
	int i;
	double tong = 0;

	if (thoiGian == THEO_QUY) {
		for (i = 0; i < 4; i++) {
			tong += doanhThuQuy[i];
		}
	}
	else {
		for (i = 0; i < 12; i++) {
			tong += doanhThuThang[i];
		}
	}

	return tong;
}

// Khoi tao cua so cho chart. Moi chart se dat trong 1 cua so rieng
// Kich thuoc cua so = kich thuoc man hinh
void khoiTaoGraphWindow()
{
	screenSize.width = GetSystemMetrics(SM_CXSCREEN);
	screenSize.height = GetSystemMetrics(SM_CYSCREEN);
	initwindow(screenSize.width, screenSize.height, "");
}

// Ve line chart
void veLineChart(THOIGIAN thoiGian)
{
	khoiTaoGraphWindow();

	// Ve hoanh do Ox, tung do Oy
	Diem gocToaDo = {200, screenSize.height - 150};
	line(gocToaDo.x, gocToaDo.y, screenSize.width - 100, gocToaDo.y);
	line(gocToaDo.x, gocToaDo.y, gocToaDo.x, 100);

	int soDiem;
	if (thoiGian == THEO_QUY) {
		// So diem tren chart
		soDiem = 4;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Line chart doanh thu theo quy");
		// Dat ten cho hoanh do
		outtextxy(screenSize.width - 100, gocToaDo.y + 10, "Quy");
	}
	else {
		// So diem tren chart
		soDiem = 12;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Line chart doanh thu theo thang");
		// Dat ten cho hoanh do Ox
		outtextxy(screenSize.width - 100, gocToaDo.y + 10, "Thang");
	}
	// Dat ten cho tung do Oy
	outtextxy(gocToaDo.x - 100, 85, "Doanh thu (vnd)");

	double maxHeight = 450;			// Chieu cao toi da cho mot diem la tai 450 pixel

	double diem_x[12];
	double diem_y[12];

	diem_x[0] = gocToaDo.x + 80;	// Diem dau tien cach Oy 1 khoang la 80 pixel

	// Tim doanh thu lon nhat de lam chuan khi ve chart
	double dt_max_quy;
	double dt_max_thang;
	if (thoiGian == THEO_QUY) {
		dt_max_quy = timDoanhThuLonNhat((THOIGIAN)THEO_QUY);
	}
	else {
		dt_max_thang = timDoanhThuLonNhat((THOIGIAN)THEO_THANG);
	}
	
	int i;
	for (i = 0; i < soDiem; i++) {
		// Tinh ti le cho moi line
		if (thoiGian == THEO_QUY) {
			diem_y[i] = (doanhThuQuy[i] / dt_max_quy)*maxHeight;
		}
		else {
			diem_y[i] = (doanhThuThang[i] / dt_max_thang)*maxHeight;
		}

		// Tao diem
		setcolor(MAU[i]);
		circle((int)diem_x[i], screenSize.height - (int)diem_y[i] - 195, 5);

		// Noi 2 diem lien nhau bang 1 line
		//   Voi n diem, ta can co n-1 line de noi
		//   Suy ra, den diem thu 2 moi bat dau ve line ( noi diem dau tien va diem thu hai)
		if (i != 0) {
			line(diem_x[i-1], screenSize.height - diem_y[i-1] - 195, diem_x[i], screenSize.height - diem_y[i] - 195);
		}

		// Dat ten cho tung diem (tren Ox)
		stringstream quy_ss;
		if (thoiGian == THEO_QUY) {
			quy_ss << "Quy " << i+1;
		}
		else {
			quy_ss << "Thang " << i+1;
		}
		outtextxy(diem_x[i] - 10, gocToaDo.y + 10, (char*)quy_ss.str().c_str());

		// Dat text cho doanh thu vao tung do
		stringstream doanhThu_ss;
		if (thoiGian == THEO_QUY) {
			doanhThu_ss << fixed << setprecision(3) << doanhThuQuy[i];
		}
		else {
			doanhThu_ss << fixed << setprecision(3) << doanhThuThang[i];
		}
		outtextxy(gocToaDo.x - 100, screenSize.height - diem_y[i] - 200, (char*)doanhThu_ss.str().c_str());

		// Hai diem lien nhau cach nhau mot khoang 80 pixel
		if (i != soDiem - 1) {
			diem_x[i+1] = diem_x[i] + 80;
		}
	}

	// Giu do thi hien thi tren man hinh, cho den khi nao nguoi dung nhan mot phim bat ky
	getch();

	// Tat do thi
	closegraph();
}

// Ve bar chart
void veBarChart(THOIGIAN thoiGian)
{
	khoiTaoGraphWindow();

	// Ve hoanh do Ox, tung do Oy
	Diem gocToaDo = {200, screenSize.height - 150};
	line(gocToaDo.x, gocToaDo.y, screenSize.width - 100, gocToaDo.y);
	line(gocToaDo.x, gocToaDo.y, gocToaDo.x, 100);

	int soBar;
	if (thoiGian == THEO_QUY) {
		// So bar tren chart
		soBar = 4;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Bar chart doanh thu theo quy");
		// Dat ten cho hoanh do Ox
		outtextxy(screenSize.width - 100, gocToaDo.y + 10, "Quy");
	}
	else {
		// So bar tren chart
		soBar = 12;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Bar chart doanh thu theo thang");
		// Dat ten cho hoanh do Ox
		outtextxy(screenSize.width - 100, gocToaDo.y + 10, "Thang");
	}
	// Dat ten cho tung do Oy
	outtextxy(gocToaDo.x - 100, 85, "Doanh thu (vnd)");


	// Chon chieu cao, do rong, khoang cach va MAU sac cho bar
	double barHeight_max = 450;						// Chieu cao toi da cho bar la 450 pixel
	double barWidth = 40;							// Do rong cua tat bar deu la 40 pixel
	double barDistance = gocToaDo.x + barWidth;		// Bar dau tien cach Oy 50 pixel
	double barHeight;

	// Tim doanh thu lon nhat de lam chuan khi ve chart
	double dt_max_quy;
	double dt_max_thang;
	if (thoiGian == THEO_QUY) {
		dt_max_quy = timDoanhThuLonNhat((THOIGIAN)THEO_QUY);
	}
	else {
		dt_max_thang = timDoanhThuLonNhat((THOIGIAN)THEO_THANG);
	}
	
	int i;
	for (i = 0; i < soBar; i++) {
		// Tinh ti le cho moi line
		if (thoiGian == THEO_QUY) {
			barHeight = (doanhThuQuy[i] / dt_max_quy)*barHeight_max;
		}
		else {
			barHeight = (doanhThuThang[i] / dt_max_thang)*barHeight_max;
		}

		// Ve bar
		setcolor(MAU[i]);
		setfillstyle(SOLID_FILL, MAU[i]);
		bar(barDistance, screenSize.height - barHeight - 200, barDistance + barWidth, gocToaDo.y);

		// Dat ten cho tung bar
		stringstream thoigian_ss;
		if (thoiGian == THEO_QUY) {
			thoigian_ss << "Quy " << i+1;
		}
		else {
			thoigian_ss << "Thang " << i+1;
		}
		outtextxy(barDistance, gocToaDo.y + 10, (char*)thoigian_ss.str().c_str());

		// Dat text cho doanh thu vao tung do
		stringstream doanhThu_ss;
		if (thoiGian == THEO_QUY) {
			doanhThu_ss << fixed << setprecision(3) << doanhThuQuy[i];
		}
		else {
			doanhThu_ss << fixed << setprecision(3) << doanhThuThang[i];
		}
		outtextxy(gocToaDo.x - 100, screenSize.height - barHeight - 200, (char*)doanhThu_ss.str().c_str());

		// Hai bar lien nhau cach nhau mot khoang 40 pixel
		barDistance += barWidth + 40;
	}

	// Giu do thi hien thi tren man hinh, cho den khi nao nguoi dung nhan mot phim bat ky
	getch();

	// Tat do thi
	closegraph();
}

// Ve pie chart
void vePieChart(THOIGIAN thoiGian)
{
	khoiTaoGraphWindow();

	int soPieSecion;
	if (thoiGian == THEO_QUY) {
		// So section tren chart
		soPieSecion = 4;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Pie chart doanh thu theo quy");
	}
	else {
		// So section tren chart
		soPieSecion = 12;
		// In tieu do cho chart
		outtextxy(10, 10 + 10, "Pie chart doanh thu theo thang");
	}

	// Goc toa do cua pie chart
	Diem gocToaDo = {screenSize.width/2 + 150, screenSize.height/2};

	// Ban kinh, ti le chia goc cho moi section va ti le phan tram cho moi section
	double goc360 = 360;
	double banKinh = 250;
	double pieSection_old = 0;
	double pieSection_new = 0;
	double phanTram;

	// Moi chu thich la mot hinh chu nhat co kich thuoc:
	double chuThich_width = 50;
	double chuThich_height = 30;
	double chuThich_distance = 100;

	// Tim tong doanh thu de lam chuan khi ve chart
	double dt_tong_quy;
	double dt_tong_thang;
	if (thoiGian == THEO_QUY) {
		dt_tong_quy = tinhTongDoanhThu((THOIGIAN)THEO_QUY);
	}
	else {
		dt_tong_thang = tinhTongDoanhThu((THOIGIAN)THEO_THANG);
	}
	
	int i;
	for (i = 0; i < soPieSecion; i++) {
		// Tinh ti le cua moi pie section
		if (thoiGian == THEO_QUY) {
			pieSection_new += (doanhThuQuy[i] / dt_tong_quy)*goc360;
			phanTram = (doanhThuQuy[i] / dt_tong_quy)*100.0;
		}
		else {
			pieSection_new += (doanhThuThang[i] / dt_tong_thang)*goc360;
			phanTram = (doanhThuThang[i] / dt_tong_thang)*100.0;
		}

		// Ve pie 
		setfillstyle(SOLID_FILL, MAU[i]);
		pieslice(gocToaDo.x, gocToaDo.y, pieSection_old, pieSection_new, banKinh);

		pieSection_old = pieSection_new;
 
		// Chu thich
		setcolor(MAU[i]);
		rectangle(100, chuThich_distance, chuThich_width + 100, chuThich_height + chuThich_distance);
		setfillstyle(SOLID_FILL, MAU[i]);
		floodfill(100+1, chuThich_distance+1, MAU[i]);

		// Chu thich (phan tram + tien)
		stringstream doanhThu_ss;
		if (thoiGian == THEO_QUY) {
			doanhThu_ss << "Quy " << i + 1 << ": " << fixed << setprecision(3) << phanTram << "% (" << doanhThuQuy[i] << "VND)";
		}
		else {
			doanhThu_ss << "Thang " << i + 1 << ": " << fixed << setprecision(3) << phanTram << "% (" << doanhThuThang[i] << "VND)";
		}
		outtextxy(100 + chuThich_width + 5, chuThich_distance + chuThich_height/2, (char*)doanhThu_ss.str().c_str());

		// 2 hinh chu nhat cua 2 chu thich lien nhau cach nhau 50 pixel
		chuThich_distance += 50;
	}

	// Giu do thi hien thi tren man hinh, cho den khi nao nguoi dung nhan mot phim bat ky
	getch();

	// Tat do thi
	closegraph();
}

int main()
{
	// Doc file txt
	// Neu qua trinh doc file bi loi, thong bao loi va dung chuong trinh
	bool kq = docFile(FILE_PATH);
	if (kq == false) {
		return 0;
	}

	// Tinh doanh thu
	tinhDoanhThu();

	// Hoi user muon xem loai chart nao
	int loaiChart;
	cout << "\nBan muon xem:" << endl;
	cout << "1. Line chart" << endl
		 << "2. Bar chart" << endl
		 << "3. Pie chart" << endl;

	int thoigian;			// Quy dinh khoang thoi gian (theo quy hay theo thang)
	char coMuonTiepTuc;		// User co muon tiep tuc chuong trinh khong. Nhap 'y' la tiep tuc, 'n' la dung chuong trinh

	while (true) {
		cout << "Lua chon loai chart cua ban: ";
		cin >> loaiChart;

		switch (loaiChart) {
			case 1:
				// Hoi user muon xem theo quy hay theo thang
				cout << "\nChon khoang thoi gian:" << endl;
				cout << "1. Theo quy" << endl
					 << "2. Theo thang" << endl;
				cout << "Lua chon thoi gian cua ban: ";
				cin >> thoigian;

				// Ve
				veLineChart((THOIGIAN)thoigian);
				break;
			case 2:
				// Hoi user muon xem theo quy hay theo thang
				cout << "\nChon khoang thoi gian:" << endl;
				cout << "1. Theo quy" << endl
					 << "2. Theo thang" << endl;
				cout << "Lua chon thoi gian cua ban: ";
				cin >> thoigian;

				// Ve
				veBarChart((THOIGIAN)thoigian);
				break;
			case 3:
				// Hoi user muon xem theo quy hay theo thang
				cout << "\nChon khoang thoi gian:" << endl;
				cout << "1. Theo quy" << endl
					 << "2. Theo thang" << endl;
				cout << "Lua chon thoi gian cua ban: ";
				cin >> thoigian;

				// Ve
				vePieChart((THOIGIAN)thoigian);
				break;
			default:
				cout << "Lua chon khong ton tai. Vui long chon lai!" << endl;
				break;
		}

		cout << "Ban co muon xem nhung chart khac (nhap 'y' hoac 'n'): ";
		cin >> coMuonTiepTuc;

		if (coMuonTiepTuc == 'n') {
			break;
		}
	}

	return 0;
}
