using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class DocGia_TraSach_Frm : Form
    {
        Sach sach = new Sach();
        List<List<string>> tatCaSachMuon = new List<List<string>>();
        DateTime ngayHomNay = DateTime.Now.Date;
        DocGiaAccount docGiaAccount;
        string maMuonTra;
        int soLuongSachDaMuon;

        public DocGia_TraSach_Frm(DocGiaAccount docGiaAccount)
        {
            InitializeComponent();

            // Khởi tại giá trị cho class member
            this.docGiaAccount = new DocGiaAccount
            {
                TenDangNhap = docGiaAccount.TenDangNhap,
                Ten = docGiaAccount.Ten,
                MatKhau = docGiaAccount.MatKhau
            };

            // Load tất cả sách và lưu vào List
            LoadSach();
        }

        // Load tất cả sách từ SachMuonTra.csv
        private void LoadSach()
        {
            // Đảm bảo List mới nhất bằng cách clear hết value cũ
            tatCaSachMuon.Clear();
            
            // Load tất cả sách từ file CSV và lưu vào List
            // Lưu ý: Chỉ đọc record với mã đọc giả muốn tìm
            Csv csv = new Csv(HangSo.CSV_SACHMUONTRA_PATH);
            if (!csv.ReadAll_WithContition(tatCaSachMuon, (int)Csv_SachMuonTra_Enum.MaDocGia, docGiaAccount.TenDangNhap))
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
            object[] buffer = new object[8];
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (List<string> sach in sachList)
            {
                buffer[0] = sach[(int)Csv_SachMuonTra_Enum.MaMuonTra];          // maMuonTra_col
                buffer[1] = sach[(int)Csv_SachMuonTra_Enum.MaSach];             // maSach_col
                buffer[2] = sach[(int)Csv_SachMuonTra_Enum.TenSach];            // tenSach_col
                buffer[3] = sach[(int)Csv_SachMuonTra_Enum.SoLuongMuon];        // soLuongSachMuon_col
                buffer[4] = sach[(int)Csv_SachMuonTra_Enum.NgayMuon];           // ngayMuon_col
                buffer[5] = sach[(int)Csv_SachMuonTra_Enum.NgayTraQuyDinh];     // ngayTraQuyDinh_col

                DateTime ngayTraQuyDinh_datetime = Convert.ToDateTime(DateTime.ParseExact(sach[(int)Csv_SachMuonTra_Enum.NgayTraQuyDinh], HangSo.DATE_FORMAT, CultureInfo.InvariantCulture));
                double soNgayConLai = (ngayTraQuyDinh_datetime - ngayHomNay).TotalDays;
                buffer[6] = soNgayConLai.ToString();        // soNgayConLai_col

                string tinhTrang;
                if (sach[(int)Csv_SachMuonTra_Enum.NgayTraThucTe].CompareTo("null") != 0) tinhTrang = "Đã trả";
                else
                    if (soNgayConLai < 0) tinhTrang = "Quá hạn";
                    else tinhTrang = "Chưa trả";
                buffer[7] = tinhTrang;                      // tinhTrangMuonSach_col

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

        // Ẩn/hiện row trong DataGridView theo kết quả filter
        private void AnHienRow_Datagridview(DataGridViewRow row)
        {
            // Tịnh trạng mượn trả sách
            // Nếu data từ commbobox khác data trong cell và không phải "Tất cả", ẩn row
            if (row.Cells[7].Value.ToString().CompareTo(tinhTrangFilter_cbb.Text) != 0)
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

            // Nếu không có data nào khác cả, hiện row
            row.Visible = true;
        }

        // Hàm xử lý sự kiện khi một cell trên DataGridView được click
        private void Sach_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in sach_dataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Lấy mã mượn trả từ column 0
                        if (cell.ColumnIndex == 0)
                        {
                            maMuonTra = cell.Value.ToString();
                        }
                        // Lấy mã sách từ column 1
                        if (cell.ColumnIndex == 1)
                        {
                            sach.Ma = cell.Value.ToString();
                        }
                        // Lấy số lượng sách đã mượn từ column 13
                        if (cell.ColumnIndex == 3)
                        {
                            soLuongSachDaMuon = int.Parse(cell.Value.ToString());
                        }
                    }
                    return;
                }
            }
        }

        // Hàm xử lý sự kiện khi một cell trên DataGridView được click
        private void TraSach_btn_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã nhập mã sách chưa
            if (string.IsNullOrWhiteSpace(this.sach.Ma))
            {
                MessageBox.Show("Bạn chưa chọn sinh viên muốn sửa thông tin.\nXin vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin sách và add vào List
            // CSV format: Ma muon tra, Ma sach, Ten sach, So luong muon, Ngay muon, Ngay tra quy dinh, Ngay tra thuc te, Ma doc gia, Ten doc gia
            List<string> sach = new List<string>();
            sach.Add(maMuonTra);
            sach.Add(this.sach.Ma);
            sach.Add("");
            sach.Add("");
            sach.Add("");
            sach.Add("");
            sach.Add(ngayHomNay.ToString(HangSo.DATE_FORMAT));
            sach.Add(docGiaAccount.TenDangNhap);
            sach.Add(docGiaAccount.Ten);

            // Sau khi có đầy đủ thông tin sách, cập nhật file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACHMUONTRA_PATH);
            CsvResult result = csv.UpdateRecord(maMuonTra, sach);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sách không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Cập nhật sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Bạn đã trả sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật số lượng sách sau khi trả
            CapNhatSoLuongSachSauKhiTra();

            // Reload lại list sách và datagridview
            LoadSach();
        }

        // Sau khi trả sách thì số sách trong kho sẽ tăng lên, nên phải cập nhật lại file Sach.csv
        private void CapNhatSoLuongSachSauKhiTra()
        {
            // Lấy thông tin sách và add vào List
            // CSV format: Ma, Ten, The loai, Tac gia, Nha xuat ban, So luong
            List<string> sach = new List<string>();
            sach.Add(this.sach.Ma);
            sach.Add("");
            sach.Add("");
            sach.Add("");
            sach.Add("");

            int soLuongSachSauKhiTra = this.sach.SoLuong + soLuongSachDaMuon;
            sach.Add(soLuongSachSauKhiTra.ToString());
            sach.Add((soLuongSachSauKhiTra > 0) ? "Còn hàng" : "Hết hàng");

            // Sau khi có đầy đủ thông tin sách, cập nhật file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            CsvResult result = csv.UpdateRecord(this.sach.Ma, sach);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sách không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Cập nhật sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
