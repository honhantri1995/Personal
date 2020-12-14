using System;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class SinhVien_MainFrm : Form
    {
        Form parent;    // Form mẹ
        SinhVienAccount sinhVienAccount;

        public SinhVien_MainFrm(Form parent, SinhVienAccount sinhVienAccount)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.sinhVienAccount = sinhVienAccount;
        }

        private void BatDauThi_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form chọn đề thi
            var frm = new SinhVien_ChonDeThi_Frm(this, sinhVienAccount);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form chọn đề thi)
            this.Enabled = false;
        }

        private void ThongKeDiemThi_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form thống kê điểm thi
            var frm = new SinhVien_ThongKe_DiemThi_Frm(this, sinhVienAccount);
            frm.Show();
            // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form thống kê điểm thi)
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
