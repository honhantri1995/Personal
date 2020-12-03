using System;

namespace QuanLyThuVien
{
    public class Account
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }

    public class AdminAccount : Account
    {

    }

    public class DocGiaAccount : Account
    {
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
    }
}
