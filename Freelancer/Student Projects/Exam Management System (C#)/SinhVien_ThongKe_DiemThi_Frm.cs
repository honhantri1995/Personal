using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class SinhVien_ThongKe_DiemThi_Frm : Form
    {
        SinhVienAccount sinhVienAccount;
        List<List<string>> diemThi_list = new List<List<string>>();

        Form parent;    // Form mẹ

        public SinhVien_ThongKe_DiemThi_Frm(Form parent, SinhVienAccount sinhVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.sinhVienAccount = sinhVienAccount;

            // Load tất cả điểm thi và lưu vào List
            LoadDeThi_DiemThi();
        }

        // Load tất cả dề thi và điểm thi từ file CSV
        private void LoadDeThi_DiemThi()
        {
            // Nếu danh sách cũ, clear nó 
            if (diemThi_list.Count > 0) diemThi_list.Clear();

            // Load tất cả điểm thi (của sinh viên này) vào danh sách
            Csv csv = new Csv(HangSo.CSV_DIEMTHI_FILEPATH);
            if (!csv.ReadAll_WithContition(diemThi_list, (int)CSV_DIEMTHI_ENUM.MaSinhVien, sinhVienAccount.TenDangNhap))
            {
                return;
            }

            // Sau khi có tất cả thông tin điểm thi, hiển thị trên DataGridView
            HienThiTrenDatagridview(diemThi_list);
        }

        // Hiển thị tất cả thông tin điểm thi trên DataGridView
        private void HienThiTrenDatagridview(List<List<string>> diemThi_list_param)
        {
            // Clear DataGridView để đảm bảo data mới nhất
            diemThi_dataGridView.Rows.Clear();

            ///////////////////////////////////////////////////////////////////
            // Add từng thông tin của từng điểm thi vào từng cell của DataGridView
            ///////////////////////////////////////////////////////////////////
            object[] buffer = new object[4];
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (List<string> diemThi in diemThi_list_param)
            {
                buffer[0] = diemThi[(int)CSV_DIEMTHI_ENUM.MaDeThi];     // maSinhVien_col
                buffer[1] = diemThi[(int)CSV_DIEMTHI_ENUM.MonThi];      // monThi_col
                buffer[2] = diemThi[(int)CSV_DIEMTHI_ENUM.MaDeThi];     // maDeThi_col
                buffer[3] = diemThi[(int)CSV_DIEMTHI_ENUM.Diem];        // diem_col
        
                // Sau khi có tất cả data, tạo tất cả cell cho từng row trong DataGridView
                rows.Add(new DataGridViewRow());
                rows[rows.Count - 1].CreateCells(diemThi_dataGridView, buffer);
            }
            // Sau khi có tất cả row, add tát cả row vào DataGridView
            diemThi_dataGridView.Rows.AddRange(rows.ToArray());
        }

        // Hàm xử lý event cho textbox khi thả nút bấm keyboard
        private void TimTheoMonThi_txt_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in diemThi_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Ẩn/hiện row trong DataGridView theo kết quả filter
        private void AnHienRow_Datagridview(DataGridViewRow row)
        {
            // Môn thi
            // Nếu data từ textbox khác data trong cell, ẩn row
            if (!row.Cells[1].Value.ToString().ToLower().Contains(monThi_txt.Text.ToLower()))
            {
                row.Visible = false;
                return;
            }

            // Nếu không có data nào khác cả, hiện row
            row.Visible = true;
        }

        // Override lại sự kiện close form (X button)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Enable lại form mẹ sau khi thoát khỏi form hiện tại
            this.parent.Enabled = true;
        }
    }
}
