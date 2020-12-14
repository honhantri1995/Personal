using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongThiTracNghiem
{
    class HangSo
    {
        // Đường dẫn đến các file CSV
        public const string CSV_TMP_FILEPATH = @"..\..\Database\Tmp.csv";
        public const string CSV_ADMIN_FILEPATH = @"..\..\Database\Admin.csv";
        public const string CSV_SINHVIEN_FILEPATH = @"..\..\Database\SinhVien.csv";
        public const string CSV_GIAOVIEN_FILEPATH = @"..\..\Database\GiaoVien.csv";
        public const string CSV_THONGTINDETHI_FILEPATH = @"..\..\Database\DeThi.csv";
        public const string CSV_DIEMTHI_FILEPATH = @"..\..\Database\DiemThi.csv";

        // Đường dẫn đến các file đề thi và đáp án
        public const string CSV_DETHI_DIRPATH = @"..\..\Database\DeThi\{0}\";
        public const string CSV_DAPAN_DIRPATH = @"..\..\Database\DeThi\{0}\";
        public const string CSV_DETHI_FILEPATH = @"..\..\Database\DeThi\{0}\DeThi.txt";
        public const string CSV_DAPAN_DUNG_FILEPATH = @"..\..\Database\DeThi\{0}\DapAn.txt";
        public const string CSV_DAPAN_SINHVIEN_FILEPATH = @"..\..\Database\DeThi\{0}\DapAn-{1}.txt";

        // Syntax để parse câu hỏi trong file đề thi
        public const string CAUHOI_BEGIN_DELIMITER = "##### CAUHOI_BEGIN #####";
        public const string CAUHOI_END_DELIMITER = "##### CAUHOI_END #####";

        // Định dạng ngày sẽ dùng xuyên suốt chương trình
        public const string DATE_FORMAT = "dd-MM-yyyy";

        // Trạng thái của đề thi
        public const string TINHTRANG_DETHI_OPEN = "Open";
        public const string TINHTRANG_DETHI_CLOSE = "Close";

        // Điểm số tối đa cho 1 đề thi
        public const double DIEMSO_MAX = 10.00;
    }

    // Hiện tại, chỉ hỗ trợ tối đa 5 đáp án
    enum DAP_AN
    {
        A = 0b00001,
        B = 0b00010,
        C = 0b00100,
        D = 0b01000,
        E = 0b10000,
        MAX_NUM = 5
    }

    // Admin.csv format: Ten dang nhap, Mat khau
    enum CSV_ADMIN_ENUM
    {
        TenDangNhap,
        MatKhau
    }

    // SinhVien.csv format: Ten dang nhap, Ten, Lop, Mat khau
    enum CSV_SINHVIEN_ENUM
    {
        TenDangNhap,
        Ten,
        Lop,
        MatKhau,
    }

    // GiaoVien.csv format: Ten dang nhap, Mat khau
    enum CSV_GIAOVIEN_ENUM
    {
        TenDangNhap,
        MatKhau
    }

    // DeThi.csv format: Ma de thi, Ten mon hoc, Ky thi, Tinh trang, Ngay tao, Giao vien
    enum CSV_THONGTINDETHI_ENUM
    {
        MaDe,
        TenMon,
        KyThi,
        TinhTrang,
        NgayTao,
        GiaoVien_TenDangNhap,
    }

    // DiemThi.csv format: Mã điểm thi, mã đề thi, mã sinh viên, tên sinh viên, lớp, điểm thi, môn thi, kì thi
    enum CSV_DIEMTHI_ENUM
    {
        MaDiemThi,
        MaDeThi,
        MaSinhVien,
        TenSinhVien,
        Lop,
        Diem,
        MonThi,
        KiThi
    }
}
