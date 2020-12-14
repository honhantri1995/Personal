using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class SinhVien_XemDiemThi : Form
    {
        double diemThi;
        int tongSoCauHoi;
        int soCauTraLoiDung;

        Form parent;    // Form mẹ

        public SinhVien_XemDiemThi(Form parent, double diemThi, int tongSoCauHoi, int soCauTraLoiDung)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.diemThi = diemThi;
            this.tongSoCauHoi = tongSoCauHoi;
            this.soCauTraLoiDung = soCauTraLoiDung;

            HienThongTinLenForm();
        }

        public void HienThongTinLenForm()
        {
            diemSo_lbl.Text = diemThi.ToString();
            cauDung_lbl.Text = "Đúng " + soCauTraLoiDung.ToString() + "/" + tongSoCauHoi.ToString();
        }

        // Override lại sự kiện close form (X button)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Enable lại form mẹ sau khi thoát khỏi form hiện tại
            this.parent.Enabled = true;
        }
    }
}