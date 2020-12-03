using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_QLTaiKhoanAdmin_Frm : Form
    {
        public Admin_QLTaiKhoanAdmin_Frm()
        {
            InitializeComponent();
        }

        // Kiểm tra thông tin từ text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            // Nếu chưa nhập tên đăng nhập hoặc mật khẩu, báo lỗi
            if (string.IsNullOrWhiteSpace(tenDangNhap_txt.Text) || string.IsNullOrWhiteSpace(matKhau_txt.Text))
            {
               MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }
            return true;
        }

        // Lấy thông tin input từ các textbox và thêm vào List
        private List<string> LayThongTinTuGiaoDien()
        {
            // Add tất cả info vào list
            // CSV format: Ten dang nhap, Mat khau
            List<string> record = new List<string>();
            record.Add(tenDangNhap_txt.Text);
            record.Add(matKhau_txt.Text);

            return record;
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void Them_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Kiểm tra tên đăng nhập có tồn tại trước đó không
            // Nếu có, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_ADMIN_PATH);
            if (csv.IsExistRecord(tenDangNhap_txt.Text))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add tất cả info vào list
            List<string> record = LayThongTinTuGiaoDien();
            // Add record mới vào file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            if (!csv.AddRecord(record))
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo thêm thành công
            MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Sửa" được click
        private void Sua_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Add tất cả info vào list
            List<string> record = LayThongTinTuGiaoDien();
            // Cập nhật record vào file CSV
            // Nếu quá trình cập nhật gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_ADMIN_PATH);
            CsvResult result = csv.UpdateRecord(tenDangNhap_txt.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void Xoa_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Xóa record khỏi file CSV
            // Nếu quá trình xóa gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_ADMIN_PATH);
            CsvResult result = csv.RemoveRecord(tenDangNhap_txt.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo xóa thành công
            MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
