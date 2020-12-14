using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class GiaoVien_QuanLyDeThi_Frm : Form
    {
        List<List<string>> deThi_list = new List<List<string>>();
        GiaoVienAccount giaoVienAccount;

        Form parent;    // Form mẹ

        public GiaoVien_QuanLyDeThi_Frm(Form parent, GiaoVienAccount giaoVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.giaoVienAccount = new GiaoVienAccount
            {
                TenDangNhap = giaoVienAccount.TenDangNhap,
                // Không cần lấy mật khẩu
            };

            if (!LoadDeThi())
            {
                return;
            }

            // Add tất cả mã đề thi vào combobox đề thi
            // ==> Chức năng autocomplete khi gõ mã đề thi
            foreach (List<string> deThi in deThi_list)
            {
                maDeThi_cbb.Items.Add(deThi[(int)CSV_THONGTINDETHI_ENUM.MaDe]);
            }
        }

        // Load tất cả đề thi (phụ trách bởi giáo viên này) từ file CSV
        private bool LoadDeThi()
        {
            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            if (!csv.ReadAll_WithContition(deThi_list, (int)CSV_THONGTINDETHI_ENUM.GiaoVien_TenDangNhap, giaoVienAccount.TenDangNhap))
            {
                return false;
            }
            return true;
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void ThemDeThi_btn_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin())
            {
                return;
            }

            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            if (csv.IsExistRecord(maDeThi_cbb.Text))
            {
                MessageBox.Show("Mã đề thì đã tồn tại. Vui lòng chọn mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!LuuDeThi())
            {
                return;
            }

            // Hiện form quản lý câu hỏi
            var frm = new GiaoVien_QuanLyCauHoi_Frm(this, maDeThi_cbb.Text);
            frm.Show();
            // Và close form hiện tại
            this.Close();
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
            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            CsvResult result = csv.UpdateRecord(maDeThi_cbb.Text, record);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã đề thì không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Sửa đề thì thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Sửa đề thì thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Hỏi giáo viên có muốn tiếp tực cập nhật câu hỏi và đáp án sau khi đã cập nhật đề thi hay không
            // Nếu có, mở form quản lý câu hỏi
            var mb = MessageBox.Show("Bạn có muốn tiếp tục sửa các câu hỏi trong đề thi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                var frm = new GiaoVien_QuanLyCauHoi_Frm(this, maDeThi_cbb.Text);
                frm.Show();
                // Và close form hiện tại
                this.Close();
            }
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void Xoa_btn_Click(object sender, EventArgs e)
        {
            // Xóa record khỏi file CSV
            // Nếu quá trình xóa gặp lỗi, báo lỗi và thoát khỏi hàm
            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            CsvResult result = csv.RemoveRecord(maDeThi_cbb.Text);
            if (result == CsvResult.RecordIdNotFound)
            {
                MessageBox.Show("Mã đề thì không tồn tại. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result == CsvResult.Fail)
            {
                MessageBox.Show("Xóa đề thì thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu k gặp lỗi, thông báo cập nhật thành công
            MessageBox.Show("Xóa đề thì thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Kiểm tra thông tin từ text box có đầy đủ và hợp lệ không
        private bool KiemTraThongTin()
        {
            // Có đầy đủ không
            if (string.IsNullOrWhiteSpace(maDeThi_cbb.Text)
                || string.IsNullOrWhiteSpace(monThi_txt.Text)
                || string.IsNullOrWhiteSpace(kyThi_txt.Text)
                || string.IsNullOrWhiteSpace(tinhTrang_cbb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra tình trạng có hợp lệ không
            if (tinhTrang_cbb.Text.CompareTo(HangSo.TINHTRANG_DETHI_OPEN) != 0
                && tinhTrang_cbb.Text.CompareTo(HangSo.TINHTRANG_DETHI_CLOSE) != 0)
            {
                MessageBox.Show("Tình trạng đề thi phải là một trong hai giá trị (Open hoặc Close)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Lấy thông tin input từ các textbox và thêm vào List
        private List<string> LayThongTinTuGiaoDien()
        {
            // Add tất cả info vào list
            List<string> record = new List<string>();
            record.Add(maDeThi_cbb.Text);
            record.Add(monThi_txt.Text);
            record.Add(kyThi_txt.Text);
            record.Add(tinhTrang_cbb.Text);
            record.Add(ngayTao_dtp.Text);
            record.Add(giaoVienAccount.TenDangNhap);

            return record;
        }

        // Lưu đề thi vào file text và
        private bool LuuDeThi()
        {
            // Tạo folder đề thi
            string deThiDir = string.Format(HangSo.CSV_DETHI_DIRPATH, maDeThi_cbb.Text);
            Directory.CreateDirectory(deThiDir);

            // Tạo file đề thi
            string deThiFile = string.Format(HangSo.CSV_DETHI_FILEPATH, maDeThi_cbb.Text);
            using (FileStream fs = File.Create(deThiFile))
            {
            }

            // Tạo file đáp án
            string dapAnFile = string.Format(HangSo.CSV_DAPAN_DUNG_FILEPATH, maDeThi_cbb.Text);
            using (FileStream fs = File.Create(dapAnFile))
            {
                // Ghi thêm comment CSV vào file đáp án
                var data = "# Thu tu cau hoi, dap an (dang so: 1=A, 2=B, 4=C, 8=D, 16=E, 3=A&B, 5=A&C, ...)";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);
            }

            // Lưu thông tin đề thi vào file CSV
            List<string> record = LayThongTinTuGiaoDien();
            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            if (!csv.IsExistRecord(maDeThi_cbb.Text))
            {
                if (!csv.AddRecord(record))
                {
                    MessageBox.Show("Lưu thông tin đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        // Hàm xử lý sự kiện cho combobox khi chuyển giữa các item
        private void MaDeThi_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List<string> records in deThi_list)
            {
                // Nếu tìm thấy mã đề thi, cập nhật thông tin đề thi cho các textbox khác và thoát khoải hàm
                if (string.Compare(records[0], maDeThi_cbb.Text, true) == 0)
                {
                    maDeThi_cbb.Text = records[(int)CSV_THONGTINDETHI_ENUM.MaDe];
                    monThi_txt.Text = records[(int)CSV_THONGTINDETHI_ENUM.TenMon];
                    kyThi_txt.Text = records[(int)CSV_THONGTINDETHI_ENUM.KyThi];
                    tinhTrang_cbb.Text = records[(int)CSV_THONGTINDETHI_ENUM.TinhTrang];
                    ngayTao_dtp.Value = DateTime.ParseExact(records[(int)CSV_THONGTINDETHI_ENUM.NgayTao], HangSo.DATE_FORMAT, CultureInfo.InvariantCulture);
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
