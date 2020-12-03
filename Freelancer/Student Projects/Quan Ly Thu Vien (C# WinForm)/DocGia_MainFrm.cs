using System;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class DocGia_MainFrm : Form
    {
        DocGiaAccount docGiaAccount;

        public DocGia_MainFrm(DocGiaAccount docGiaAccount)
        {
            InitializeComponent();

            // Khởi tại giá trị cho class member
            this.docGiaAccount = new DocGiaAccount
            {
                TenDangNhap = docGiaAccount.TenDangNhap,
                Ten = docGiaAccount.Ten,
                MatKhau = docGiaAccount.MatKhau
            };
        }

        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocGia_TimSach_Frm timSach_frm = new DocGia_TimSach_Frm();
            timSach_frm.Show();
        }

        private void muonSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocGia_MuonSach_Frm muonSach_frm = new DocGia_MuonSach_Frm(docGiaAccount);
            muonSach_frm.Show();
        }

        private void traSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocGia_TraSach_Frm traSach_frm = new DocGia_TraSach_Frm(docGiaAccount);
            traSach_frm.Show();
        }
    }
}
