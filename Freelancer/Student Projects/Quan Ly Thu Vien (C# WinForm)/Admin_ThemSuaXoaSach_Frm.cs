using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_ThemSuaXoaSach_Frm : Form
    {
        List<List<string>> tatCaSach = new List<List<string>>();

        public Admin_ThemSuaXoaSach_Frm()
        {
            InitializeComponent();

            // Load tất cả sách trong thư viện và lưu vào List
            LoadSach();
        }

        // Load tất cả sách từ Sach.csv
        private void LoadSach()
        {
            // Đảm bảo List mới nhất bằng cách clear hết value cũ
            tatCaSach.Clear();

            // Load tất cả sách từ file CSV và lưu vào List
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            if (!csv.ReadAll(tatCaSach))
            {
                return;
            }

            // Add tất cả mã sách vào combobox mã sách
            // ==> Chức năng autocomplete khi gõ mã sách
            foreach (List<string> sach in tatCaSach)
            {
                maSach_cbb.Items.Add(sach[0]);
            }
        }

        // Kiểm tra thông tin từ text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            // Có đầy đủ không
            if (string.IsNullOrWhiteSpace(maSach_cbb.Text) 
                || string.IsNullOrWhiteSpace(tenSach_txt.Text)
                || string.IsNullOrWhiteSpace(tacGia_txt.Text)
                || string.IsNullOrWhiteSpace(theLoai_txt.Text)
                || string.IsNullOrWhiteSpace(soLuongSach_txt.Text)
                || string.IsNullOrWhiteSpace(nhaXuatBan_txt.Text))
            {
               MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            // Kiểm tra số lượng sách có hợp lệ không
            if ( !int.TryParse(soLuongSach_txt.Text, out _) )
            {
                MessageBox.Show("Số lượng sách phải là một con số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }

            return true;
        }

        // Lấy thông tin input từ các textbox và thêm vào List
        private List<string> LayThongTinTuGiaoDien()
        {
            // Add tất cả info vào list
            // CSV format: Ma, Ten, The loai, Tac gia, Nha xuat ban, So luong, Tinh trang
            List<string> record = new List<string>();
            record.Add(maSach_cbb.Text);
            record.Add(tenSach_txt.Text);
            record.Add(theLoai_txt.Text);
            record.Add(tacGia_txt.Text);
            record.Add(nhaXuatBan_txt.Text);
            record.Add(soLuongSach_txt.Text);
            record.Add("Còn hàng");             // Lúc mới thêm sách thì tình trạng luôn là "Còn hàng"

            return record;
        }

        // Xóa thông tin trên các textbox
        private void XoaThongTinKhoiGiaoDien()
        {
            maSach_cbb.Text = "";
            tenSach_txt.Clear();
            tacGia_txt.Clear();
            theLoai_txt.Clear();
            soLuongSach_txt.Clear();
            nhaXuatBan_txt.Clear();
        }

        // Hàm xử lý sự kiện khi button "Reset" được click
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            XoaThongTinKhoiGiaoDien();
        }

        // Hàm xử lý sự kiện cho textbox khi thả nút keyboard
        // FIXME
        private void TimSachTheoMa_txt_KeyUp(object sender, KeyEventArgs e)
        {
            List<List<string>> sachTimDuoc = new List<List<string>>();
            foreach (List<string> sach in tatCaSach)
            {
                if ( sach[(int)Csv_Sach_Enum.TenSach].ToLower().Contains(tenSach_txt.Text.ToLower()) )
                {
                    sachTimDuoc.Add(sach);
                }
            }
        }

        // Hàm xử lý sự kiện khi chuyển item trong combobox
        private void MaSach_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu tìm thấy sách trùng với sách được chọn từ combobox, hiển thị thông tin sách lên textbox
            foreach (List<string> sach in tatCaSach)
            {
                if (string.Compare(maSach_cbb.Text, sach[0], true) == 0)
                {
                    tenSach_txt.Text = sach[(int)Csv_Sach_Enum.TenSach];
                    theLoai_txt.Text = sach[(int)Csv_Sach_Enum.TheLoai];
                    tacGia_txt.Text = sach[(int)Csv_Sach_Enum.TacGia];
                    nhaXuatBan_txt.Text = sach[(int)Csv_Sach_Enum.NhaXuatBan];
                    soLuongSach_txt.Text = sach[(int)Csv_Sach_Enum.SoLuong];
                    return;
                }
            }
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void ThemSach_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Kiểm tra mã sách có tồn tại trước đó không
            // Nếu có, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            if (csv.IsExistRecord(maSach_cbb.Text))
            {
                MessageBox.Show("Mã sách này đã tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin sách từ các textbox, và add tất cả thông tin vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Add record mới vào file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            if (!csv.AddRecord(record))
            {
                MessageBox.Show("Thêm sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo thêm thành công
            MessageBox.Show("Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Sửa" được click
        private void SuaSach_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Lấy thông tin sách từ các textbox, và add tất cả thông tin vào list 'record'
            List<string> record = LayThongTinTuGiaoDien();
            // Cập nhật record vào file CSV
            // Nếu quá trình cập nhật gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            CsvResult result = csv.UpdateRecord(maSach_cbb.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sách không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void XoaSach_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Xóa record khỏi file CSV
            // Nếu quá trình xóa gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            CsvResult result = csv.RemoveRecord(maSach_cbb.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sách không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo xóa thành công
            MessageBox.Show("Xóa sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
