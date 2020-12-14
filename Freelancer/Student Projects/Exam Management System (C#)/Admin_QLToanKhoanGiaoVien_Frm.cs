using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Admin_QLTaiKhoanGiaoVien_Frm : Form
    {
        List<List<string>> giaoVien_list = new List<List<string>>();

        Form parent;    // Form mẹ

        public Admin_QLTaiKhoanGiaoVien_Frm(Form parent)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;

            LoadGiaoVien();

            // Add tất cả tên đăng nhập vào combobox
            // ==> Chức năng autocomplete khi gõ mã đề thi
            foreach (List<string> giaoVien in giaoVien_list)
            {
                tenDangNhap_cbb.Items.Add(giaoVien[(int)CSV_GIAOVIEN_ENUM.TenDangNhap]);
            }
        }

        // Load tất cả thông tin giáo viên vào list
        private bool LoadGiaoVien()
        {
            Csv csv = new Csv(HangSo.CSV_GIAOVIEN_FILEPATH);
            if (!csv.ReadAll(giaoVien_list))
            {
                return false;
            }

            return true;
        }

        // Kiểm tra thông tin từ text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            // Nếu chưa nhập tên đăng nhập hoặc mật khẩu, báo lỗi
            if (string.IsNullOrWhiteSpace(tenDangNhap_cbb.Text) || string.IsNullOrWhiteSpace(matKhau_txt.Text))
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
            record.Add(tenDangNhap_cbb.Text);
            record.Add(matKhau_txt.Text);

            return record;
        }

        // Xóa thông tin trên các textbox
        private void XoaThongTinKhoiGiaoDien()
        {
            tenDangNhap_cbb.Text = "";
            matKhau_txt.Clear();
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
            Csv csv = new Csv(HangSo.CSV_GIAOVIEN_FILEPATH);
            if (csv.IsExistRecord(tenDangNhap_cbb.Text))
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
                MessageBox.Show("Thêm giáo viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo thêm thành công
            MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaThongTinKhoiGiaoDien();
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
            Csv csv = new Csv(HangSo.CSV_GIAOVIEN_FILEPATH);
            CsvResult result = csv.UpdateRecord(tenDangNhap_cbb.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa giáo viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Csv csv = new Csv(HangSo.CSV_GIAOVIEN_FILEPATH);
            CsvResult result = csv.RemoveRecord(tenDangNhap_cbb.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa giáo viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo xóa thành công
            MessageBox.Show("Xóa giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cập nhật thông tin giáo viên cho các textbox khác dựa theo mã giáo viên
        private void TenDangNhap_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List<string> records in giaoVien_list)
            {
                // Nếu tìm thấy mã giáo viên, cập nhật thông tin giáo viên cho các textbox khác và thoát khoải hàm
                if (string.Compare(records[0], tenDangNhap_cbb.Text, true) == 0)
                {
                    matKhau_txt.Text = records[(int)CSV_GIAOVIEN_ENUM.MatKhau];
                    return;
                }
            }
        }

        // Override lại sự kiện close form (X button)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Enable lại form mẹ sau khi thoát khỏi form hiện tại
            this.parent.Enabled = true;
        }
    }
}
