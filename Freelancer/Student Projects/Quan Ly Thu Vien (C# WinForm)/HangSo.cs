using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyThuVien
{
    public static class HangSo
    {
        // Đường dẫn đến các file CSV trong Database
        public const string CSV_ADMIN_PATH = "..\\..\\Database\\Admin.csv";
        public const string CSV_DOCGIA_PATH = "..\\..\\Database\\DocGia.csv";
        public const string CSV_SACH_PATH = "..\\..\\Database\\Sach.csv";
        public const string CSV_TMP_PATH = "..\\..\\Database\\Tmp.csv";
        public const string CSV_SACHMUONTRA_PATH = "..\\..\\Database\\SachMuonTra.csv";

        // Định dạng ngày sẽ dùng xuyên suốt chương trình
        public const string DATE_FORMAT = "dd-MM-yyyy";
    }

    // Admin.csv format: Ten dang nhap, Mat khau
    enum Csv_Admin_Enum
    {
        TenDangNhap,
        MatKhau
    }

    // DocGia.csv format: Ten dang nhap (ma doc gia), Ten, Mat khau, Gioi tinh, SDT, Ngay sinh, Dia chi
    enum Csv_DocGia_Enum
    {
        TenDangNhap,
        Ten,
        MatKhau,
        GioiTinh,
        SDT,
        NgaySinh,
        DiaChi
    }

    // Sach.csv format: Ma, Ten, The loai, Tac gia, Nha xuat ban, So luong, Tinh trang
    enum Csv_Sach_Enum
    {
        MaSach,
        TenSach,
        TheLoai,
        TacGia,
        NhaXuatBan,
        SoLuong,
        TinhTrang
    }

    // SachMuonTra.csv format: Ma muon tra, Ma sach, Ten sach, So luong muon, Ngay muon, Ngay tra quy dinh, Ngay tra thuc te, Ma doc gia, Ten doc gia
    enum Csv_SachMuonTra_Enum
    {
        MaMuonTra,
        MaSach,
        TenSach,
        SoLuongMuon,
        NgayMuon,
        NgayTraQuyDinh,
        NgayTraThucTe,
        MaDocGia,
        TenDocGia
    }
}

