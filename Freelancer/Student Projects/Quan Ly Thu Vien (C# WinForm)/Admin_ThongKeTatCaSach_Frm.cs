using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_ThongKeTatCaSach_Frm : Form
    {
        List<List<string>> tatCaSach = new List<List<string>>();

        public Admin_ThongKeTatCaSach_Frm()
        {
            InitializeComponent();

            // Load tất cả sách và lưu vào List
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

            // Sau khi có tất cả thông tin sách, hiển thị trên DataGridView
            HienThiTrenDatagridview(tatCaSach);
        }

        // Hiển thị tất cả thông tin sách trên DataGridView
        private void HienThiTrenDatagridview(List<List<string>> sachList)
        {
            // Clear DataGridView để đảm bảo data mới nhất
            sach_dataGridView.Rows.Clear();

            object[] buffer = new object[7];
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (List<string> sach in sachList)
            {
                buffer[0] = sach[(int)Csv_Sach_Enum.MaSach];        // maSach_col
                buffer[1] = sach[(int)Csv_Sach_Enum.TenSach];       // tenSach_col
                buffer[2] = sach[(int)Csv_Sach_Enum.TheLoai];       // theLoai_col
                buffer[3] = sach[(int)Csv_Sach_Enum.TacGia];        // tacGia_col
                buffer[4] = sach[(int)Csv_Sach_Enum.NhaXuatBan];    // nhaXuatBan_col
                buffer[5] = sach[(int)Csv_Sach_Enum.SoLuong];       // soLuongSach_col
                buffer[6] = sach[(int)Csv_Sach_Enum.TinhTrang];     // tinhTrangSach_col

                // Sau khi có tất cả data, tạo tất cả cell cho từng row trong DataGridView
                rows.Add(new DataGridViewRow());
                rows[rows.Count - 1].CreateCells(sach_dataGridView, buffer);
            }
            // Sau khi có tất cả row, add tát cả row vào DataGridView
            sach_dataGridView.Rows.AddRange(rows.ToArray());
        }

        // Hàm xử lý event cho textbox khi thả nút bấm keyboard
        // Nếu thông tin sách từ textbox trùng với thông tin sách, hiện sách đó trên DataGirdView
        // Nếu không, ẩn sách khỏi DataGridView
        private void TimSach_txt_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in sach_dataGridView.Rows)
            {
                if ( row.Cells[0].Value.ToString().ToLower().Contains(maSach_txt.Text.ToLower()) 
                    && row.Cells[1].Value.ToString().ToLower().Contains(tenSach_txt.Text.ToLower()) )
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}
