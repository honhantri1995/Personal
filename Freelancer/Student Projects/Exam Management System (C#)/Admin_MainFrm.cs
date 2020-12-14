using System;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Admin_MainFrm : Form
    {
        Form parent;    // Form mẹ

        public Admin_MainFrm(Form parent, AdminAccount adminAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
        }

        private void GiaoVien_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form quản lý tài khoản giáo viên
            var frm = new Admin_QLTaiKhoanGiaoVien_Frm(this);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form quản lý tài khoản giáo viên)
            this.Enabled = false;
        }

        private void SinhVien_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form quản lý tài khoản sinh viên
            var frm = new Admin_QLTaiKhoanSinhVien_Frm(this);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form quản lý tài khoản sinh viên)
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
