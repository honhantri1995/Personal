using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class DocGia_MuonSach_Frm : Form
    {
        Sach sach = new Sach();
        List<List<string>> tatCaSach = new List<List<string>>();
        int soLuongSachConLai;
        DocGiaAccount docGiaAccount;

        public DocGia_MuonSach_Frm(DocGiaAccount docGiaAccount)
        {
            InitializeComponent();

            // Khởi tạo cho biến thành viên
            this.docGiaAccount = new DocGiaAccount
            {
                TenDangNhap = docGiaAccount.TenDangNhap,
                Ten = docGiaAccount.Ten,
                MatKhau = docGiaAccount.MatKhau
            };

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
                maSach_cbb.Items.Add(sach[(int)Csv_Sach_Enum.MaSach]);
            }
        }

        // Kiểm tra thông tin từ text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            // Có đầy đủ không
            if (string.IsNullOrWhiteSpace(maSach_cbb.Text) 
                || string.IsNullOrWhiteSpace(tenSach_txt.Text)
                || string.IsNullOrWhiteSpace(tacGia_txt.Text)
                || string.IsNullOrWhiteSpace(soLuongSach_txt.Text))
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
            soLuongSachConLai = sach.SoLuong - int.Parse(soLuongSach_txt.Text);
            if ( soLuongSachConLai < 0 )
            {
                string msg = string.Format("Số lượng sách bạn muốn mượn vượt quá số sách đang có trong thư viện.\nHiện thư viện chỉ có {0} quyển sách này.", sach.SoLuong);
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Xóa thông tin trên các textbox và combobox
        private void XoaThongTinKhoiGiaoDien()
        {
            maSach_cbb.Text = "";
            tenSach_txt.Clear();
            tacGia_txt.Clear();
            soLuongSach_txt.Clear();
        }

        // Hàm xử lý sự kiện cho combobox khi chuyển giữa các item
        // Khi chọn đúng sách mượn, cập nhật value cho các textbox khác và lưu tất cả thông tin sách vào biến member this.sach
        private void MaSach_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List<string> sach in tatCaSach)
            {
                if (string.Compare(maSach_cbb.Text, sach[(int)Csv_Sach_Enum.MaSach], true) == 0)
                {
                    // Cập nhật giao diện
                    tenSach_txt.Text = sach[(int)Csv_Sach_Enum.TenSach];
                    tacGia_txt.Text = sach[(int)Csv_Sach_Enum.TacGia];

                    // Lưu thông tin sách được chọn
                    this.sach.Ma = sach[(int)Csv_Sach_Enum.MaSach];
                    this.sach.Ten = sach[(int)Csv_Sach_Enum.TenSach];
                    this.sach.TheLoai = sach[(int)Csv_Sach_Enum.TheLoai];
                    this.sach.TacGia = sach[(int)Csv_Sach_Enum.TacGia];
                    this.sach.NhaXuatBan = sach[(int)Csv_Sach_Enum.NhaXuatBan];
                    this.sach.SoLuong = int.Parse(sach[(int)Csv_Sach_Enum.SoLuong]);

                    return;
                }
            }
        }
    
        // Hàm xử lý sự kiện khi button "Lưu" được click
        // Lưu thông tin sách cho mượn vào SachMuonTra.csv
        private void Luu_btn_Click(object sender, EventArgs e)
        {
            // Nếu thông tin không đầy đủ và hợp lệ, thoát khỏi hàm
            if (!KiemTraThongTin())
            {
               return;
            }

            // Lấy thông tin sách và add vào List
            // CSV format: Ma muon tra, Ma sach, Ten sach, So luong muon, Ngay muon, Ngay tra quy dinh, Ngay tra thuc te, Ma doc gia, Ten doc gia
            List<string> sach = new List<string>();
            sach.Add(DateTime.Now.ToString("yyyyMMddTHHmmss"));
            sach.Add(this.sach.Ma);
            sach.Add(this.sach.Ten);
            sach.Add(this.sach.SoLuong.ToString());
            sach.Add(ngayMuon_dtp.Text);
            sach.Add(ngayTra_dtp.Text);
            sach.Add("null");                       // Lúc mượn thì chưa trả sách, nên Ngày trả thực tế có value là null
            sach.Add(docGiaAccount.TenDangNhap);
            sach.Add(docGiaAccount.Ten);

            // Add record mới vào file CSV
            // Nếu quá trình add gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_SACHMUONTRA_PATH);
            if ( !csv.AddRecord(sach) )
            {
                MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Sau khi mượn sách, số lượng sách trong kho sẽ giảm, nên phải cập nhật lại file Sach.csv
            CapNhatSoLuongSachSauKhiMuon();
            // Cuối cùng, thông báo thành công
            MessageBox.Show("Mượn sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Sau khi mượn sách, số lượng sách trong kho sẽ giảm, nên phải cập nhật file Sach.csv
        private void CapNhatSoLuongSachSauKhiMuon()
        {
            // Lấy thông tin sách và add vào List
            // CSV format: Ma, Ten, The loai, Tac gia, Nha xuat ban, So luong
            List<string> sach = new List<string>();
            sach.Add(this.sach.Ma);
            sach.Add(this.sach.Ten);
            sach.Add(this.sach.TheLoai);
            sach.Add(this.sach.TacGia);
            sach.Add(this.sach.NhaXuatBan);
            sach.Add(soLuongSachConLai.ToString());
            sach.Add((soLuongSachConLai > 0) ? "Còn hàng" : "Hết hàng");

            // Sau khi có đầy đủ thông tin sách, cập nhật file CSV
            // Nếu gặp lỗi, thông báo lỗi và dừng hàm
            Csv csv = new Csv(HangSo.CSV_SACH_PATH);
            CsvResult result = csv.UpdateRecord(maSach_cbb.Text, sach);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã sách không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Cập nhật số lượng sách sau khi mượn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Hàm xử lý sự kiện khi button "Hủy" được click
        private void Huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm xử lý sự kiện khi button "Reset" được click
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            XoaThongTinKhoiGiaoDien();
        }
    }
}
