using System;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class GiaoVien_MainFrm : Form
    {
        Form parent;    // Form mẹ
        GiaoVienAccount giaoVienAccount;

        public GiaoVien_MainFrm(Form parent, GiaoVienAccount giaoVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.giaoVienAccount = new GiaoVienAccount
            {
                TenDangNhap = giaoVienAccount.TenDangNhap,
            };
        }

        private void QuanLyDeThi_StripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form quản lý đề thi
            var frm = new GiaoVien_QuanLyDeThi_Frm(this, giaoVienAccount);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form quản lý đề thi)
            this.Enabled = false;
        }

        private void DeThi_DiemThi_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form thống kê đề thi
            var frm = new GiaoVien_ThongKe_DeThi_Frm(this, giaoVienAccount);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form thống kê đề thi)
            this.Enabled = false;
        }

        // Override lại sự kiện close form (X button)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Enable lại form mẹ sau khi thoát khỏi form hiện tại
            this.parent.Show();
        }
    }
}
