using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Admin_QLTaiKhoanSinhVien_Frm : Form
    {
        List<List<string>> sinhVien_list = new List<List<string>>();
        
        Form parent;    // Form mẹ

        public Admin_QLTaiKhoanSinhVien_Frm(Form parent)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;

            LoadSinhVien();

            // Add tất cả tên đăng nhập vào combobox
            // ==> Chức năng autocomplete khi gõ mã đề thi
            foreach (List<string> sinhVien in sinhVien_list)
            {
                tenDangNhap_cbb.Items.Add(sinhVien[(int)CSV_SINHVIEN_ENUM.TenDangNhap]);
            }
        }

        // Load tất cả thoong tin sinh viên vào list
        private bool LoadSinhVien()
        {
            Csv csv = new Csv(HangSo.CSV_SINHVIEN_FILEPATH);
            if (!csv.ReadAll(sinhVien_list))
            {
                return false;
            }
            return true;
        }

        // Kiểm tra thông tin input từ các text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap_cbb.Text)
                || string.IsNullOrWhiteSpace(tenSinhVien_txt.Text)
                || string.IsNullOrWhiteSpace(matKhau_txt.Text))
            {
               MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            return true;
        }

        // Lấy thông tin input từ các textbox và thêm vào List
        private List<string> LayThongTinTuGiaoDien()
        {
            // Add tất cả info vào list
            List<string> record = new List<string>();
            record.Add(tenDangNhap_cbb.Text);
            record.Add(tenSinhVien_txt.Text);
            record.Add(lop_txt.Text);
            record.Add(matKhau_txt.Text);

            return record;
        }

        // Xóa thông tin trên các textbox
        private void XoaThongTinKhoiGiaoDien()
        {
            tenDangNhap_cbb.Text = "";
            tenSinhVien_txt.Clear();
            lop_txt.Clear();
            matKhau_txt.Clear();
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void Them_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ không. Nếu không, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Kiểm tra tên đăng nhập có tồn tại trước đó không
            // Nếu có, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SINHVIEN_FILEPATH);
            if (csv.IsExistRecord(tenDangNhap_cbb.Text))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ các textbox, và add tất cả thông tin sinh viên vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Add record mới vào file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            if (!csv.AddRecord(record))
            {
                MessageBox.Show("Thêm sinh viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sau khi thêm sinh viên,
            // thông báo thành công
            // và clear màn hình để tiện cho việc thêm sinh viên tiếp theo
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaThongTinKhoiGiaoDien();
        }

        // Hàm xử lý sự kiện khi button "Sửa" được click
        private void Sua_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ không. Nếu không, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Lấy thông tin sinh viên từ các textbox, và add tất cả thông tin vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Cập nhật record vào file CSV
            // Nếu quá trình cập nhật gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SINHVIEN_FILEPATH);
            CsvResult result = csv.UpdateRecord(tenDangNhap_cbb.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sinh viên không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa sinh viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void Xoa_btn_Click(object sender, EventArgs e)
        {
            // Xóa record khỏi file CSV
            // Nếu quá trình xóa gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SINHVIEN_FILEPATH);
            CsvResult result = csv.RemoveRecord(tenDangNhap_cbb.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sinh viên không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa sinh viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Cập nhật thông tin sinh viên cho các textbox khác dựa theo mã sinh viên
        private void TenDangNhap_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List<string> records in sinhVien_list)
            {
                // Nếu tìm thấy mã sinh viên, cập nhật thông tin sinh viên cho các textbox khác và thoát khoải hàm
                if (string.Compare(records[0], tenDangNhap_cbb.Text, true) == 0)
                {
                    tenSinhVien_txt.Text = records[(int)CSV_SINHVIEN_ENUM.Ten];
                    lop_txt.Text = records[(int)CSV_SINHVIEN_ENUM.Lop];
                    matKhau_txt.Text = records[(int)CSV_SINHVIEN_ENUM.MatKhau];
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
