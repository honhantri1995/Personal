using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_QLTaiKhoanDocGia_Frm : Form
    {
        public Admin_QLTaiKhoanDocGia_Frm()
        {
            InitializeComponent();
        }

        // Kiểm tra thông tin input từ các text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrWhiteSpace(maDocGia_txt.Text)
                || string.IsNullOrWhiteSpace(tenDocGia_txt.Text)
                || string.IsNullOrWhiteSpace(gioiTinh_cbb.Text)
                || string.IsNullOrWhiteSpace(soDT_txt.Text)
                || string.IsNullOrWhiteSpace(diaChi_txt.Text)
                || string.IsNullOrWhiteSpace(matKhau_txt.Text))
            {
               MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            // Kiểm tra số điện thoại có hợp lệ không
            if ( !int.TryParse(soDT_txt.Text, out _) )
            {
                MessageBox.Show("Số điện thoại phải là một con số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Lấy thông tin input từ các textbox và thêm vào List
        private List<string> LayThongTinTuGiaoDien()
        {
            // Add tất cả info vào list
            // CSV format: Ma, Ten, Mat khau, Gioi tinh, SDT, Ngay sinh, Dia chi
            List<string> record = new List<string>();
            record.Add(maDocGia_txt.Text);
            record.Add(tenDocGia_txt.Text);
            record.Add(matKhau_txt.Text);
            record.Add(gioiTinh_cbb.Text);
            record.Add(soDT_txt.Text);
            record.Add(ngaySinh_dtp.Value.ToString(HangSo.DATE_FORMAT));
            record.Add(diaChi_txt.Text);

            return record;
        }

        // Xóa thông tin trên các textbox
        private void XoaThongTinKhoiGiaoDien()
        {
            maDocGia_txt.Clear();
            tenDocGia_txt.Clear();
            matKhau_txt.Clear();
            gioiTinh_cbb.SelectedIndex = 0;
            soDT_txt.Clear();
            ngaySinh_dtp.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            diaChi_txt.Clear();
        }

        // Cập nhật thông tin độc giả cho các textbox khác dựa theo mã độc giả
        private void CapNhat_btn_Click(object sender, EventArgs e)
        {
            // Nếu chưa nhập mã độc giả, thoát khỏi hàm
            if (string.IsNullOrWhiteSpace(maDocGia_txt.Text))
            {
                MessageBox.Show("Vui lòng nhập mã độc giả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đọc tất cả độc giả từ file CSV
            Csv csv = new Csv(HangSo.CSV_DOCGIA_PATH);
            List<List<string>> allRecords = new List<List<string>>();
            if (!csv.ReadAll(allRecords))
            {
                return;
            }

            foreach (List<string> records in allRecords)
            {
                // Nếu tìm thấy mã độc giả, cập nhật thông tin độc giả cho các textbox khác và thoát khoải hàm
                if (string.Compare(records[0], maDocGia_txt.Text, true) == 0)
                {
                    tenDocGia_txt.Text = records[(int)Csv_DocGia_Enum.Ten];
                    matKhau_txt.Text = records[(int)Csv_DocGia_Enum.MatKhau];
                    gioiTinh_cbb.Text = records[(int)Csv_DocGia_Enum.GioiTinh];
                    soDT_txt.Text = records[(int)Csv_DocGia_Enum.SDT];
                    ngaySinh_dtp.Text = records[(int)Csv_DocGia_Enum.NgaySinh];
                    diaChi_txt.Text = records[(int)Csv_DocGia_Enum.DiaChi];
                    return;
                }
            }

            // Nếu không tìm thấy mã độc giả, báo lỗi và xóa toàn bộ thông tin độc giả trên giao diện
            MessageBox.Show("Mã độc giả này không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            XoaThongTinKhoiGiaoDien();
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void Them_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ không. Nếu không, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Kiểm tra mã độc giá có tồn tại trước đó không
            // Nếu có, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_DOCGIA_PATH);
            if (csv.IsExistRecord(maDocGia_txt.Text))
            {
                MessageBox.Show("Mã độc giả này đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ các textbox, và add tất cả thông tin độc giả vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Add record mới vào file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            if (!csv.AddRecord(record))
            {
                MessageBox.Show("Thêm độc giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sau khi thêm độc giả,
            // thông báo thành công
            // và clear màn hình để tiện cho việc thêm độc giả tiếp theo
            MessageBox.Show("Thêm độc giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Lấy thông tin độc giả từ các textbox, và add tất cả thông tin vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Cập nhật record vào file CSV
            // Nếu quá trình cập nhật gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_DOCGIA_PATH);
            CsvResult result = csv.UpdateRecord(maDocGia_txt.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã độc giả không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa độc giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa độc giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void Xoa_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ không. Nếu không, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Xóa record khỏi file CSV
            // Nếu quá trình xóa gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_DOCGIA_PATH);
            CsvResult result = csv.RemoveRecord(maDocGia_txt.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã độc giả không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa độc giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Xóa độc giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
