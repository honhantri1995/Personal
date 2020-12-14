using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class GiaoVien_ThongKe_DeThi_Frm : Form
    {
        DeThi deThi = new DeThi();
        List<List<string>> deThi_list = new List<List<string>>();
        GiaoVienAccount giaoVienAccount;

        Form parent;    // Form mẹ

        public GiaoVien_ThongKe_DeThi_Frm(Form parent, GiaoVienAccount giaoVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.giaoVienAccount = new GiaoVienAccount
            {
                TenDangNhap = giaoVienAccount.TenDangNhap,
                // Không cần lấy mật khẩu
            };

            // Load tất cả đề thi và lưu vào List
            LoadDeThi();
        }

        // Load tất cả đề thi từ DeThi.csv
        private void LoadDeThi()
        {
            // Đảm bảo list rỗng bằng cách xóa hết phần tử của nó
            if (deThi_list.Count > 0) deThi_list.Clear();

            // Đọc tất cả thông tin đề thi (phụ trách bởi giáo viên này) và lưu vào list
            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            if (!csv.ReadAll_WithContition(deThi_list, (int)CSV_THONGTINDETHI_ENUM.GiaoVien_TenDangNhap, giaoVienAccount.TenDangNhap))
            {
                return;
            }

            // Sau khi có tất cả thông tin đề thi, hiển thị trên DataGridView
            HienThiTrenDatagridview(deThi_list);
        }

        // Hiển thị tất cả thông tin đề thi trên DataGridView
        private void HienThiTrenDatagridview(List<List<string>> deThi_list_param)
        {
            // Clear DataGridView để đảm bảo data mới nhất
            deThi_dataGridView.Rows.Clear();

            ///////////////////////////////////////////////////////////////////
            // Add từng thông tin của từng đề thi vào từng cell của DataGridView
            ///////////////////////////////////////////////////////////////////
            object[] buffer = new object[5];
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (List<string> deThi in deThi_list_param)
            {
                buffer[0] = deThi[(int)CSV_THONGTINDETHI_ENUM.MaDe];         // maDeThi_col
                buffer[1] = deThi[(int)CSV_THONGTINDETHI_ENUM.TenMon];       // tenMonThi_col
                buffer[2] = deThi[(int)CSV_THONGTINDETHI_ENUM.KyThi];        // kyThy_col
                buffer[3] = deThi[(int)CSV_THONGTINDETHI_ENUM.TinhTrang];    // tinhTranga_col
                buffer[4] = deThi[(int)CSV_THONGTINDETHI_ENUM.NgayTao];      // ngayTao_col
        
                // Sau khi có tất cả data, tạo tất cả cell cho từng row trong DataGridView
                rows.Add(new DataGridViewRow());
                rows[rows.Count - 1].CreateCells(deThi_dataGridView, buffer);
            }
            // Sau khi có tất cả row, add tát cả row vào DataGridView
            deThi_dataGridView.Rows.AddRange(rows.ToArray());
        }


        // Hàm xử lý event cho combobox khi chuyển giữa các item
        private void TinhTrang_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in deThi_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Hàm xử lý event cho textbox khi thả nút bấm keyboard
        private void TimTheoMonThi_txt_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow row in deThi_dataGridView.Rows)
            {
                AnHienRow_Datagridview(row);
            }
        }

        // Ẩn/hiện row trong DataGridView theo kết quả filter
        private void AnHienRow_Datagridview(DataGridViewRow row)
        {
            // Tịnh trạng đề thi
            // Nếu data từ commbobox khác data trong cell và không phải "Tất cả", ẩn row
            if (row.Cells[3].Value.ToString().CompareTo(tinhTrang_cbb.Text) != 0)
            {
                if (tinhTrang_cbb.Text.CompareTo("Tất cả") != 0)
                {
                    row.Visible = false;
                    return;
                }
            }

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

        // Hàm xử lý sự kiện khi một cell trên DataGridView được click
        private void DeThi_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in deThi_dataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Lấy mã đề thi từ column 0
                        if (cell.ColumnIndex == 0)
                        {
                            deThi.ma = cell.Value.ToString();
                        }
                        // Lấy tên môn thi thi từ column 1
                        if (cell.ColumnIndex == 1)
                        {
                            deThi.mon = cell.Value.ToString();
                        }
                        // Lấy kì thi thi từ column 2
                        if (cell.ColumnIndex == 2)
                        {
                            deThi.ky = cell.Value.ToString();
                        }
                    }
                    return;
                }
            }
        }

        // Hàm xử lý sự kiện khi button "Xem điểm thi" được click
        private void XemDiemThi_btn_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn đề thi hay chưa
            if (string.IsNullOrWhiteSpace(deThi.ma))
            {
                MessageBox.Show("Bạn chưa chọn đề thi muốn xem điểm.\nXin vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form xem điểm thi
            var frm = new GiaoVien_ThongKe_DiemThi_Frm(this, deThi);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form xem điểm thi)
            this.Enabled = false;
        }

        // Override lại sự kiện close form (X button)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Enable lại form mẹ sau khi thoát khỏi form hiện tại
            this.parent.Enabled = true;
        }
    }
}
