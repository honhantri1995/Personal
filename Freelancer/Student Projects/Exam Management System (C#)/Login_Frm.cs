using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Login_Frm : Form
    {
        public Login_Frm()
        {
            InitializeComponent();
        }

        private void Login_tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            // Tab được chọn là "Quản trị viên"
            if (login_tabControl.SelectedTab == admin_tabPage)
            {
                appTitle_lbl.Parent = admin_tabPage;
                tenDangNhap_lbl.Parent = admin_tabPage;
                matMa_lbl.Parent = admin_tabPage;
                tenDangNhap_txt.Parent = admin_tabPage;
                matKhau_txt.Parent = admin_tabPage;
                login_btn.Parent = admin_tabPage;
                thoat_btn.Parent = admin_tabPage;

                // Phục vụ mục đích TESTING nhanh
                // tenDangNhap_txt.Text = "admin1";
                // matKhau_txt.Text = "admin1123";
            }
            // Tab được chọn là "Sinh viên"
            else if (login_tabControl.SelectedTab == sinhVien_tabPage)
            {
                appTitle_lbl.Parent = sinhVien_tabPage;
                tenDangNhap_lbl.Parent = sinhVien_tabPage;
                matMa_lbl.Parent = sinhVien_tabPage;
                tenDangNhap_txt.Parent = sinhVien_tabPage;
                matKhau_txt.Parent = sinhVien_tabPage;
                login_btn.Parent = sinhVien_tabPage;
                thoat_btn.Parent = sinhVien_tabPage;

                // Phục vụ mục đích TESTING nhanh
                // tenDangNhap_txt.Text = "anguyen";
                // matKhau_txt.Text = "anguyen123";
            }
            // Tab được chọn là "Giáo viên"
            else
            {
                appTitle_lbl.Parent = giaoVien_tabPage;
                tenDangNhap_lbl.Parent = giaoVien_tabPage;
                matMa_lbl.Parent = giaoVien_tabPage;
                tenDangNhap_txt.Parent = giaoVien_tabPage;
                matKhau_txt.Parent = giaoVien_tabPage;
                login_btn.Parent = giaoVien_tabPage;
                thoat_btn.Parent = giaoVien_tabPage;

                // Phục vụ mục đích TESTING nhanh
                // tenDangNhap_txt.Text = "giaovien1";
                // matKhau_txt.Text = "giaovien1123";
            }
        }

        // Hàm xử lý sự kiện khi button "Đăng nhập" được click
        private void Login_btn_Click(object sender, EventArgs e)
        {
            // Tab được chọn là "Quản trị viên"
            if (login_tabControl.SelectedTab == admin_tabPage)
            {
                AdminAccount adminAccount = new AdminAccount();
                if (XacThuc_Admin(ref adminAccount))
                {
                    // Mở form Admin
                    Admin_MainFrm admin_frm = new Admin_MainFrm(this, adminAccount);
                    admin_frm.Show();

                    // Ẩn form Login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.\nVui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Tab được chọn là "Sinh viên"
            else if (login_tabControl.SelectedTab == sinhVien_tabPage)
            {
                SinhVienAccount sinhVienAccount = new SinhVienAccount();
                if (XacThuc_SinhVien(ref sinhVienAccount))
                {
                    // Mở form sinh viên
                    SinhVien_MainFrm sinhVien_Frm = new SinhVien_MainFrm(this, sinhVienAccount);
                    sinhVien_Frm.Show();

                    // Ẩn form Login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.\nVui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Tab được chọn là "Giáo viên"
            else
            {
                GiaoVienAccount giaoVienAccount = new GiaoVienAccount();
                if (XacThuc_GiaoVien(ref giaoVienAccount))
                {
                    // Mở form sinh viên
                    GiaoVien_MainFrm sinhVien_Frm = new GiaoVien_MainFrm(this, giaoVienAccount);
                    sinhVien_Frm.Show();

                    // Ẩn form Login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.\nVui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Xác thực Admin có đúng tên đăng nhập và mật khẩu không
        private bool XacThuc_Admin(ref AdminAccount adminAccount)
        {
            // Đọc tất cả admin từ file Admin.csv
            List<List<string>> accounts = new List<List<string>>();
            Csv csv = new Csv(HangSo.CSV_ADMIN_FILEPATH);
            if (!csv.ReadAll(accounts))
            {
                return false;
            }

            // Nếu tìm thấy đúng admin, lưu thông tin admin và return true
            foreach (List<string> account in accounts)
            {
                if (account[(int)CSV_ADMIN_ENUM.TenDangNhap].CompareTo(tenDangNhap_txt.Text) == 0
                    && account[(int)CSV_ADMIN_ENUM.MatKhau].CompareTo(matKhau_txt.Text) == 0)
                {
                    adminAccount = LuuThongTin_Admin(account);
                    return true;
                }
            }

            // Nếu không tìm thấy, return false
            return false;
        }

        // Xác thực sinh viên có đúng tên đăng nhập và mật khẩu không
        private bool XacThuc_SinhVien(ref SinhVienAccount sinhVienAccount)
        {
            // Đọc tất cả sinh viên từ file sinhVien.csv
            List<List<string>> accounts = new List<List<string>>();
            Csv csv = new Csv(HangSo.CSV_SINHVIEN_FILEPATH);
            if (!csv.ReadAll(accounts))
            {
                return false;
            }

            // Nếu tìm thấy đúng sinh viên, lưu thông tin sinh viên và return true
            foreach (List<string> account in accounts)
            {
                if (account[(int)CSV_SINHVIEN_ENUM.TenDangNhap].CompareTo(tenDangNhap_txt.Text) == 0 
                    && account[(int)CSV_SINHVIEN_ENUM.MatKhau].CompareTo(matKhau_txt.Text) == 0)
                {
                    sinhVienAccount = LuuThongTin_SinhVien(account);
                    return true;
                }
            }

            // Nếu không tìm thấy, return false
            return false;
        }

        // Xác thực giáo viên có đúng tên đăng nhập và mật khẩu không
        private bool XacThuc_GiaoVien(ref GiaoVienAccount giaoVienAccount)
        {
            // Đọc tất cả admin từ file Admin.csv
            List<List<string>> accounts = new List<List<string>>();
            Csv csv = new Csv(HangSo.CSV_GIAOVIEN_FILEPATH);
            if (!csv.ReadAll(accounts))
            {
                return false;
            }

            // Nếu tìm thấy đúng admin, lưu thông tin admin và return true
            foreach (List<string> account in accounts)
            {
                if (account[(int)CSV_ADMIN_ENUM.TenDangNhap].CompareTo(tenDangNhap_txt.Text) == 0
                    && account[(int)CSV_ADMIN_ENUM.MatKhau].CompareTo(matKhau_txt.Text) == 0)
                {
                    giaoVienAccount = LuuThongTin_GiaoVien(account);
                    return true;
                }
            }

            // Nếu không tìm thấy, return false
            return false;
        }

        // Lưu thông tin admin và return
        private AdminAccount LuuThongTin_Admin(List<string> account)
        {
            AdminAccount adminAccount = new AdminAccount();
            adminAccount.TenDangNhap = account[(int)CSV_ADMIN_ENUM.TenDangNhap];
            adminAccount.MatKhau = account[(int)CSV_ADMIN_ENUM.MatKhau];

            return adminAccount;
        }

        // Lưu thông tin sinh viên và return
        private SinhVienAccount LuuThongTin_SinhVien(List<string> account)
        {
            SinhVienAccount sinhVienAccount = new SinhVienAccount();
            sinhVienAccount.TenDangNhap = account[(int)CSV_SINHVIEN_ENUM.TenDangNhap];
            sinhVienAccount.Ten = account[(int)CSV_SINHVIEN_ENUM.Ten];
            sinhVienAccount.MatKhau = account[(int)CSV_SINHVIEN_ENUM.MatKhau];
            sinhVienAccount.Lop = account[(int)CSV_SINHVIEN_ENUM.Lop];
            return sinhVienAccount;
        }

        // Lưu thông tin giáo viên và return
        private GiaoVienAccount LuuThongTin_GiaoVien(List<string> account)
        {
            GiaoVienAccount giaoVienAccount = new GiaoVienAccount();
            giaoVienAccount.TenDangNhap = account[(int)CSV_GIAOVIEN_ENUM.TenDangNhap];
            giaoVienAccount.MatKhau = account[(int)CSV_GIAOVIEN_ENUM.MatKhau];

            return giaoVienAccount;
        }

        // Hàm xử lý sự kiện khi button "Thoát" được click
        private void Thoat_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
