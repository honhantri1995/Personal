using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Login_Frm : Form
    {
        public Login_Frm()
        {
            InitializeComponent();
        }

        private void login_tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            // Tab được chọn là "Độc giả"
            if (login_tabControl.SelectedTab == docGia_tabPage)
            {
                appTitle_lbl.Parent = docGia_tabPage;
                tenDangNhap_lbl.Parent = docGia_tabPage;
                matMa_lbl.Parent = docGia_tabPage;
                tenDangNhap_txt.Parent = docGia_tabPage;
                matKhau_txt.Parent = docGia_tabPage;
                login_btn.Parent = docGia_tabPage;
                thoat_btn.Parent = docGia_tabPage;
            }
            // Tab được chọn là "Người quản lý"
            else
            {
                appTitle_lbl.Parent = admin_tabPage;
                tenDangNhap_lbl.Parent = admin_tabPage;
                matMa_lbl.Parent = admin_tabPage;
                tenDangNhap_txt.Parent = admin_tabPage;
                matKhau_txt.Parent = admin_tabPage;
                login_btn.Parent = admin_tabPage;
                thoat_btn.Parent = admin_tabPage;
            }
        }

        // Hàm xử lý sự kiện khi button "Đăng nhập" được click
        private void Login_btn_Click(object sender, EventArgs e)
        {
            // Tab được chọn là "Người quản lý"
            if (login_tabControl.SelectedTab == admin_tabPage)
            {
                AdminAccount adminAccount = new AdminAccount();
                if (XacThuc_Admin(ref adminAccount))
                {
                    // Hide form login và mở form Admin
                    this.Hide();
                    Admin_MainFrm admin_frm = new Admin_MainFrm(adminAccount);
                    admin_frm.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Tab được chọn là "Độc giả"
            else
            {
                DocGiaAccount docGiaAccount = new DocGiaAccount();
                if (XacThuc_DocGia(ref docGiaAccount))
                {
                    // Hide form login và mở form Độc giả
                    this.Hide();
                    DocGia_MainFrm DocGia_Frm = new DocGia_MainFrm(docGiaAccount);
                    DocGia_Frm.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Xác thực Admin có đúng tên đăng nhập và mật khẩu không
        private bool XacThuc_Admin(ref AdminAccount adminAccount)
        {
            // Đọc tất cả admin từ file Admin.csv
            List<List<string>> accounts = new List<List<string>>();
            Csv csv = new Csv(HangSo.CSV_ADMIN_PATH);
            if (!csv.ReadAll(accounts))
            {
                return false;
            }

            // Nếu tìm thấy đúng admin, lưu thông tin admin và return true
            foreach (List<string> account in accounts)
            {
                if (account[(int)Csv_Admin_Enum.TenDangNhap].CompareTo(tenDangNhap_txt.Text) == 0
                    && account[(int)Csv_Admin_Enum.MatKhau].CompareTo(matKhau_txt.Text) == 0)
                {
                    adminAccount = LuuThongTin_Admin(account);
                    return true;
                }
            }

            // Nếu không tìm thấy, return false
            return false;
        }

        // Xác thực Độc giả có đúng tên đăng nhập và mật khẩu không
        private bool XacThuc_DocGia(ref DocGiaAccount docGiaAccount)
        {
            // Đọc tất cả độc giả từ file DocGia.csv
            List<List<string>> accounts = new List<List<string>>();
            Csv csv = new Csv(HangSo.CSV_DOCGIA_PATH);
            if (!csv.ReadAll(accounts))
            {
                return false;
            }

            // Nếu tìm thấy đúng độc giả, lưu thông tin độc giả và return true
            foreach (List<string> account in accounts)
            {
                if (account[(int)Csv_DocGia_Enum.TenDangNhap].CompareTo(tenDangNhap_txt.Text) == 0 
                    && account[(int)Csv_DocGia_Enum.MatKhau].CompareTo(matKhau_txt.Text) == 0)
                {
                    docGiaAccount = LuuThongTin_DocGia(account);
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
            adminAccount.TenDangNhap = account[(int)Csv_Admin_Enum.TenDangNhap];
            adminAccount.MatKhau = account[(int)Csv_Admin_Enum.MatKhau];

            return adminAccount;
        }

        // Lưu thông tin độc giả và return
        private DocGiaAccount LuuThongTin_DocGia(List<string> account)
        {
            DocGiaAccount docGiaAccount = new DocGiaAccount();
            docGiaAccount.TenDangNhap = account[(int)Csv_DocGia_Enum.TenDangNhap];
            docGiaAccount.Ten = account[(int)Csv_DocGia_Enum.Ten];
            docGiaAccount.MatKhau = account[(int)Csv_DocGia_Enum.MatKhau];
            docGiaAccount.GioiTinh = account[(int)Csv_DocGia_Enum.GioiTinh];
            docGiaAccount.SoDienThoai = int.Parse(account[(int)Csv_DocGia_Enum.SDT]);
            docGiaAccount.NgaySinh = DateTime.ParseExact(account[(int)Csv_DocGia_Enum.NgaySinh], HangSo.DATE_FORMAT, null);
            docGiaAccount.DiaChi = account[(int)Csv_DocGia_Enum.DiaChi];

            return docGiaAccount;
        }

        // Hàm xử lý sự kiện khi button "Thoát" được click
        private void Thoat_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
