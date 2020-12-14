using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class SinhVien_ChonDeThi_Frm : Form
    {
        SinhVienAccount sinhVienAccount;
        List<List<string>> deThi_list = new List<List<string>>();

        Form parent;    // Form mẹ

        public SinhVien_ChonDeThi_Frm(Form parent, SinhVienAccount sinhVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.sinhVienAccount = sinhVienAccount;

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

        // Load tất cả đề thi từ file CSV
        private bool LoadDeThi()
        {
            // Đảm bảo list mới nhất bằng cách clear hết list cũ
            if (deThi_list.Count > 0) deThi_list.Clear();

            Csv csv = new Csv(HangSo.CSV_THONGTINDETHI_FILEPATH);
            if (!csv.ReadAll(deThi_list))
            {
                return false;
            }
            return true;
        }

        // Hàm xử lý sự kiện khi button "Chọn" được click
        private void ChonDeThi_btn_Click(object sender, EventArgs e)
        {
            if (!MaDeThiTonTaiChua())
            {
                MessageBox.Show("Mã đề thi này chưa tồn tại. Vui lòng chọn mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DeThi deThi = new DeThi();
            // Không cho phép làm đề thi nếu nó đã bị giáo viên ĐÓNG
            if (deThi.tinhTrang == HangSo.TINHTRANG_DETHI_CLOSE)
            {
                MessageBox.Show("Đề thi này đã ĐÓNG. Bạn không thể làm nó nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu đề vẫn mở, lấy các thông tin còn lại
            deThi.ma = maDeThi_cbb.Text;
            deThi.mon = monThi_txt.Text;
            deThi.ky = kyThi_txt.Text;
            deThi.tinhTrang = tinhTrang_cbb.Text;
            deThi.ngayTao = ngayTao_dtp.Value;

            // Mở form làm đề thi
            var frm = new SinhVien_LamDeThi_Frm(this, sinhVienAccount, deThi);
            frm.Show();
            // Và đóng form hiện tại lại
            this.Close();
        }

        // Kiểm tra mã đề thi đã tồn tại chưa
        private bool MaDeThiTonTaiChua()
        {
            foreach (List<string> deThi in deThi_list)
            {
                if (string.Compare(maDeThi_cbb.Text, deThi[(int)CSV_THONGTINDETHI_ENUM.MaDe], true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Hàm xử lý sự kiện cho combobox khi chuyển giữa các phần tử
        private void MaDeThi_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (List<string> deThi in deThi_list)
            {
                if (string.Compare(maDeThi_cbb.Text, deThi[(int)CSV_THONGTINDETHI_ENUM.MaDe], true) == 0)
                {
                    // Cập nhật giao diện
                    monThi_txt.Text = deThi[(int)CSV_THONGTINDETHI_ENUM.TenMon];
                    kyThi_txt.Text = deThi[(int)CSV_THONGTINDETHI_ENUM.KyThi];
                    tinhTrang_cbb.Text = deThi[(int)CSV_THONGTINDETHI_ENUM.TinhTrang];
                    ngayTao_dtp.Value = DateTime.ParseExact(deThi[(int)CSV_THONGTINDETHI_ENUM.NgayTao], HangSo.DATE_FORMAT, CultureInfo.InvariantCulture);

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
