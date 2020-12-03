using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_MuonTraSach_Frm : Form
    {
        List<List<string>> tatCaSachMuon = new List<List<string>>();
        DateTime ngayHomNay = DateTime.Now.Date;

        public Admin_MuonTraSach_Frm()
        {
            InitializeComponent();

            // Load tất cả sách và lưu vào List
            LoadSach();
        }

        // Load tất cả sách từ SachMuonTra.csv
        private void LoadSach()
        {
            // Clear list để đảm bảo data mới nhất
            tatCaSachMuon.Clear();

            // Đọc từ file CSV. Nếu quá trình đọc bị lỗi, dừng hàm
            Csv csv = new Csv(HangSo.CSV_SACHMUONTRA_PATH);
            if (!csv.ReadAll(tatCaSachMuon))
            {
                return;
            }

            // Sau khi có tất cả thông tin sách, hiển thị trên DataGridView
            HienThiTrenDatagridview(tatCaSachMuon);
        }

        // Hiển thị tất cả thông tin sách trên DataGridView
        private void HienThiTrenDatagridview(List<List<string>> sachList)
        {
            // Clear DataGridView để đảm bảo data mới nhất
            sach_dataGridView.Rows.Clear();

            ///////////////////////////////////////////////////////////////////
            // Add từng thông tin của từng sách vào từng cell của DataGridView
            ///////////////////////////////////////////////////////////////////
            object[] buffer = new object[11];
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (List<string> sach in sachList)
            {
                buffer[0] = sach[(int)Csv_SachMuonTra_Enum.MaMuonTra];      // maMuonTra_col
                buffer[1] = sach[(int)Csv_SachMuonTra_Enum.MaSach];         // maSach_col
                buffer[2] = sach[(int)Csv_SachMuonTra_Enum.TenSach];        // tenSach_col
                buffer[3] = sach[(int)Csv_SachMuonTra_Enum.MaDocGia];       // maDocGia_col
                buffer[4] = sach[(int)Csv_SachMuonTra_Enum.TenDocGia];      // tenDocGia_col
                buffer[5] = sach[(int)Csv_SachMuonTra_Enum.SoLuongMuon];    // soLuongSachMuon_col
                buffer[6] = sach[(int)Csv_SachMuonTra_Enum.NgayMuon];       // ngayMuon_col
                buffer[7] = sach[(int)Csv_SachMuonTra_Enum.NgayTraQuyDinh]; // ngayTraQuyDinh_col
                buffer[8] = (sach[(int)Csv_SachMuonTra_Enum.NgayTraThucTe].CompareTo("null") == 0) ? "" : sach[(int)Csv_SachMuonTra_Enum.NgayTraThucTe];        // ngayTraThucTe_col

                // Số ngày còn lại
                DateTime ngayTraQuyDinh_datetime = Convert.ToDateTime(DateTime.ParseExact(sach[(int)Csv_SachMuonTra_Enum.NgayTraQuyDinh], HangSo.DATE_FORMAT, CultureInfo.InvariantCulture));
                double soNgayConLai = (ngayTraQuyDinh_datetime - ngayHomNay).TotalDays;
                buffer[9] = soNgayConLai.ToString();        // soNgayConLai_col

                // Tịnh trang mượn trả
                string tinhTrang;
                if ( sach[(int)Csv_SachMuonTra_Enum.NgayTraThucTe].CompareTo("null") != 0) tinhTrang = "Đã trả";
                else
                    if (soNgayConLai < 0) tinhTrang = "Quá hạn";
                    else tinhTrang = "Chưa trả";
                buffer[10] = tinhTrang;                     // tinhTrangMuonTra_col

                // Sau khi có tất cả data, tạo tất cả cell cho từng row trong DataGridView
                rows.Add(new DataGridViewRow());
                rows[rows.Count - 1].CreateCells(sach_dataGridView, buffer);
            }

            // Sau khi có tất cả row, add tát cả row vào DataGridView
            sach_dataGridView.Rows.AddRange(rows.ToArray());
        }

        // Hàm xử lý event cho combobox khi chuyển giữa các item
        private void TinhTrangFilter_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in sach_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Hàm xử lý event cho textbox khi thả nút bấm keyboard
        private void TimSach_txt_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in sach_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Hàm xử lý event cho textbox khi thả nút bấm keyboard
        private void TimDocGia_txt_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in sach_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Ẩn/hiện row trong DataGridView theo kết quả filter
        private void AnHienRow_Datagridview(DataGridViewRow row)
        {
            // Tịnh trạng mượn trả sách
            // Nếu data từ commbobox khác data trong cell và không phải "Tất cả", ẩn row
            if (row.Cells[10].Value.ToString().CompareTo(tinhTrangFilter_cbb.Text) != 0)
            {
                if (tinhTrangFilter_cbb.Text.CompareTo("Tất cả") != 0)
                {
                    row.Visible = false;
                    return;
                }
            }

            // Thông tin sách (mã sách + tên sách)
            // Nếu data từ textbox khác data trong cell, ẩn row
            if ( !row.Cells[1].Value.ToString().ToLower().Contains(maSach_txt.Text.ToLower()) 
                || !row.Cells[2].Value.ToString().ToLower().Contains(tenSach_txt.Text.ToLower()) )
            {
                row.Visible = false;
                return;
            }

            // Thông tin độc giả (mã độc giả + tên độc giả)
            // Nếu data từ textbox khác data trong cell, ẩn row
            if ( !row.Cells[3].Value.ToString().ToLower().Contains(maDocGia_txt.Text.ToLower()) 
                || !row.Cells[4].Value.ToString().ToLower().Contains(tenDocGia_txt.Text.ToLower()) )
            {
                row.Visible = false;
                return;
            }

            // Nếu không có data nào khác cả, hiện row
            row.Visible = true;
        }
    }
}
