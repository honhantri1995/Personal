using System;

namespace HeThongThiTracNghiem
{
    public class Account
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }

    public class AdminAccount : Account
    {

    }

    public class SinhVienAccount : Account
    {
        public string Ten { get; set; }
        public string Lop { get; set; }
    }

    public class GiaoVienAccount : Account
    {

    }
}
