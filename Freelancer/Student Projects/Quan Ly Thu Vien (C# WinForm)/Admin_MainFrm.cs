using System;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Admin_MainFrm : Form
    {
        public Admin_MainFrm(AdminAccount adminAccount)
        {
            InitializeComponent();
        }

        private void themSuaXoaSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_ThemSuaXoaSach_Frm themSuaXoaSach_frm = new Admin_ThemSuaXoaSach_Frm();
            themSuaXoaSach_frm.Show();
        }

        private void muonTraSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_MuonTraSach_Frm muonTraSach_frm = new Admin_MuonTraSach_Frm();
            muonTraSach_frm.Show();
        }

        private void thuVienSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_ThongKeTatCaSach_Frm thongKeTatCaSach_frm = new Admin_ThongKeTatCaSach_Frm();
            thongKeTatCaSach_frm.Show();
        }

        private void sachMuonTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_ThongKeSachDaMuon_Frm thongKeSachDaMuon_frm = new Admin_ThongKeSachDaMuon_Frm();
            thongKeSachDaMuon_frm.Show();
        }

        private void quanLyTaiKhoanNQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_QLTaiKhoanAdmin_Frm qLTaiKhoanAdmin_frm = new Admin_QLTaiKhoanAdmin_Frm();
            qLTaiKhoanAdmin_frm.Show();
        }

        private void quanLyTaiKhoanDocGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_QLTaiKhoanDocGia_Frm qLTaiKhoanDocGia_frm = new Admin_QLTaiKhoanDocGia_Frm();
            qLTaiKhoanDocGia_frm.Show();
        }
    }
}
