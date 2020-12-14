using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class GiaoVien_QuanLyCauHoi_Frm : Form
    {
        DeThi deThi = new DeThi();
        string deThiFile;

        int index_hientai = 1;
        int index_max = 0;

        Form parent;    // Form mẹ

        public GiaoVien_QuanLyCauHoi_Frm(Form parent, string maDeThi)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            deThi.ma = maDeThi;
            cauHoiSo_txt.Text = "1";
            deThiFile = string.Format(HangSo.CSV_DETHI_FILEPATH, maDeThi);

            if (!LoadCauHoi())
            {
                return;
            }

            // FIXME (Sẽ gây lỗi nếu có câu hỏi với nội dung rỗng ở giữa những câu hỏi đầy đủ)
            index_max = deThi.cauHoi_dic.Count;

            CapNhatHienThi();
        }

        // Hàm xử lý sự kiện khi button "Thêm" được click
        private void ThemCauHoi_btn_Click(object sender, EventArgs e)
        {
            if (CauHoiTonTaiChua(cauHoiSo_txt.Text))
            {
                MessageBox.Show("Câu hỏi số " + cauHoiSo_txt.Text + " đã tòn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ThemCauHoi())
            {
                // Sau khi thêm câu hỏi, thì clear màn hình và chuyển index cho màn hình của câu hỏi tiếp theo,
                // Đồng thời tăng index max lên 1 đơn vị
                ClearManHinh();
                index_hientai++;
                if (index_hientai > index_max) index_max = index_hientai;
            }
        }

        // Thêm câu hỏi vào Dictionary
        private bool ThemCauHoi()
        {
            if (!CoDayDuThongTinChua())
            {
                return false;
            }

            if (CauHoiTonTaiChua(cauHoiSo_txt.Text))
            {
                MessageBox.Show("Câu hỏi số " + cauHoiSo_txt.Text + " đã tòn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lấy thông tin của câu hỏi
            CauHoi cauHoi = new CauHoi();
            cauHoi.so = int.Parse(cauHoiSo_txt.Text);
            cauHoi.noiDung = cauHoi_rtxb.Text;
            cauHoi.dapAn = LayDapAn();

            // Rồi thêm vào Dictionary
            deThi.cauHoi_dic.Add(cauHoi.so, cauHoi);

            // Tăng thứ tự câu hỏi lên 1 (để người dùng nhập tiếp nội dung cho câu hỏi tiếp theo, mà k cần tự nhập thứ tự câu hỏi)
            cauHoiSo_txt.Text = (cauHoi.so + 1).ToString();

            return true;
        }

        // Hàm xử lý sự kiện khi button "Sửa" được click
        private void SuaCauHoi_btn_Click(object sender, EventArgs e)
        {
            SuaCauHoi();
        }

        // Sửa câu hỏi đã có sẵn
        private void SuaCauHoi()
        {
            if (!CoDayDuThongTinChua())
            {
                return;
            }

            int cauHoiSo = int.Parse(cauHoiSo_txt.Text);
            foreach (var ch in deThi.cauHoi_dic)
            {
                if (ch.Key.CompareTo(cauHoiSo) == 0)
                {
                    CauHoi cauHoi = new CauHoi();
                    cauHoi.so = cauHoiSo;
                    cauHoi.noiDung = cauHoi_rtxb.Text;
                    cauHoi.dapAn = LayDapAn();

                    deThi.cauHoi_dic[cauHoiSo] = cauHoi;
                    return;
                }
            }
        }

        // Hàm xử lý sự kiện khi button "Xóa" được click
        private void XoaCauHoi_btn_Click(object sender, EventArgs e)
        {
            var mb = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi " + cauHoiSo_txt.Text + " không?", "Thông báo",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.No)
            {
                return;
            }

            XoaCauHoi();

            // Sau khi xóa câu hỏi, clear màn hình + clear thứ tự câu hỏi
            ClearManHinh();
            cauHoiSo_txt.Clear();
        }

        // Xóa câu hỏi
        private void XoaCauHoi()
        {
            int cauHoiSo = int.Parse(cauHoiSo_txt.Text);
            foreach (var ch in deThi.cauHoi_dic)
            {
                if (ch.Key.CompareTo(cauHoiSo) == 0)
                {
                    deThi.cauHoi_dic.Remove(cauHoiSo);
                    return;
                }
            }
        }

        // Load tất cả thông tin câu hỏi vào Dictionary
        private bool LoadCauHoi()
        {
            List<List<string>> cauHoi_list = new List<List<string>>();

            // Mở file CSV ở chế độ đọc
            using (var sr = new StreamReader(deThiFile))
            {
                bool timThayCauHoi = false;
                List<string> cauHoi = new List<string>();

                // Trong từng line của file CSV, đọc và lưu thông tin
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();

                    // Nếu line rỗng, thì bỏ qua không đọc line này
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    if (line == HangSo.CAUHOI_BEGIN_DELIMITER)
                    {
                        timThayCauHoi = true;

                        cauHoi = new List<string>();
                    }

                    if (line == HangSo.CAUHOI_END_DELIMITER)
                    {
                        timThayCauHoi = false;

                        cauHoi_list.Add(cauHoi);
                    }

                    if (timThayCauHoi && line != HangSo.CAUHOI_BEGIN_DELIMITER)
                    {
                        cauHoi.Add(line);
                    }
                }
            }

            // Load tất cả đáp án cho các câu hỏi
            List<List<string>> dapAn_list = new List<List<string>>();
            Csv csv = new Csv(string.Format(HangSo.CSV_DAPAN_DUNG_FILEPATH, deThi.ma));
            if (!csv.ReadAll(dapAn_list))
            {
                return false;
            }

            // Chuyển list qua dic
            for (int i = 0; i < cauHoi_list.Count; i++)
            {
                CauHoi cauHoi = new CauHoi();
                cauHoi.so = int.Parse(cauHoi_list[i][0]);

                // Nội dung câu hỏi có thể trải dài trên nhiều line
                for (int j = 1; j < cauHoi_list[i].Count; j++)
                {
                    cauHoi.noiDung += cauHoi_list[i][j] + "\n"; // TODO: K nên quy nhiều "\n" thành 1 "\n"
                }

                cauHoi.dapAn = int.Parse(dapAn_list[i][1]);
                deThi.cauHoi_dic.Add(cauHoi.so, cauHoi);
            }

            return true;
        }

        // Hàm xử lý sự kiện khi button "Next" được click
        private void Next_btn_Click(object sender, EventArgs e)
        {
            // Nếu đây câu hỏi cuối cùng, thì không còn gì để next
            if (index_hientai == index_max)
            {
                return;
            }

            index_hientai++;
            if (index_hientai > index_max) index_max = index_hientai;

            CapNhatHienThi();
        }

        // Hàm xử lý sự kiện khi button "Back" được click
        private void Back_btn_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Back()
        {
            // Nếu đây câu hỏi đầu tiên, thì không còn gì để back
            if (index_hientai == 1)
            {
                return;
            }

            index_hientai--;

            CapNhatHienThi();
        }

        // Kiểm tra thông tin có đầy đủ và hợp lệ chưa
        private bool CoDayDuThongTinChua()
        {
            if (string.IsNullOrWhiteSpace(cauHoiSo_txt.Text))
            {
                MessageBox.Show("Bạn chưa nhập số thứ tự câu hỏi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cauHoi_rtxb.Text))
            {
                MessageBox.Show("Bạn chưa nhập nội dung câu hỏi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (LayDapAn() == 0)
            {
                MessageBox.Show("Bạn chưa nhập đáp án cho câu hỏi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Từ đáp án dạng chữ (A, B, C ...) quy ra đáp án dạng số (1, 2, 4, 8 ...)
        // Mục đích: Để dể dàng so sánh nếu 1 câu hỏi có nhiều đáp án đúng
        // (Sử dụng toán tử hợp. VD: Nếu cả A và C đếu đúng thì đáp án dạng số sẽ là 1 | 4, tức là 5)
        private int LayDapAn()
        {
            int dapAn = (A_ckb.Checked ? (int)DAP_AN.A : 0)
                        | (B_ckb.Checked ? (int)DAP_AN.B : 0)
                        | (C_ckb.Checked ? (int)DAP_AN.C : 0)
                        | (D_ckb.Checked ? (int)DAP_AN.D : 0)
                        | (E_ckb.Checked ? (int)DAP_AN.E : 0);
            return dapAn;
        }

        private void ClearManHinh()
        {
            cauHoi_rtxb.Clear();
            A_ckb.Checked = false;
            B_ckb.Checked = false;
            C_ckb.Checked = false;
            D_ckb.Checked = false;
            E_ckb.Checked = false;
        }

        // Cập nhật hiển thị cho màn hình khi chuyển tiếp giữa các câu hỏi
        private void CapNhatHienThi()
        {
            ClearManHinh();

            // FIXME: chưa tối ưu (có thể gây lỗi)
            // Hiện tại, đang mặc định là thứ tự câu hỏi = index
            int cauHoiSo = index_hientai;

            foreach (var cauHoi in deThi.cauHoi_dic)
            {
                if (cauHoi.Key == cauHoiSo)
                {
                    cauHoiSo_txt.Text = cauHoiSo.ToString();

                    cauHoi_rtxb.Text = deThi.cauHoi_dic[cauHoiSo].noiDung;

                    int dapAn = deThi.cauHoi_dic[cauHoiSo].dapAn;
                    if ((dapAn & (int)DAP_AN.A) == (int)DAP_AN.A) A_ckb.Checked = true;
                    if ((dapAn & (int)DAP_AN.B) == (int)DAP_AN.B) B_ckb.Checked = true;
                    if ((dapAn & (int)DAP_AN.C) == (int)DAP_AN.C) C_ckb.Checked = true;
                    if ((dapAn & (int)DAP_AN.D) == (int)DAP_AN.D) D_ckb.Checked = true;
                    if ((dapAn & (int)DAP_AN.E) == (int)DAP_AN.E) E_ckb.Checked = true;

                    return;
                }
            }

            cauHoiSo_txt.Text = "";
        }

        // Kiểm tra câu hỏi có tồn tại sẵn chưa
        private bool CauHoiTonTaiChua(string cauHoiSo)
        {
            if (string.IsNullOrEmpty(cauHoiSo))
            {
                return false;
            }

            foreach (var cauHoi in deThi.cauHoi_dic)
            {
                if (cauHoi.Key == int.Parse(cauHoiSo))
                {
                    return true;
                }
            }

            return false;
        }

        // Hàm xử lý sự kiện khi button "Hoàn thành" được click
        private void HoanThanh_btn_Click(object sender, EventArgs e)
        {
            LuuFile();
        }

        // Lưu lần lượt thông tin câu hỏi + đáp án xuống file text và CSV
        private bool LuuFile()
        {
            deThi.de_filePath = string.Format(HangSo.CSV_DETHI_FILEPATH, deThi.ma);
            deThi.dapAn_filePath = string.Format(HangSo.CSV_DAPAN_DUNG_FILEPATH, deThi.ma);

            try
            {
                // Ghi câu hỏi
                // Mở file text ở chế độ override
                using (var sw = new StreamWriter(deThi.de_filePath))
                {
                    foreach (var cauHoi in deThi.cauHoi_dic)
                    {
                        sw.WriteLine(HangSo.CAUHOI_BEGIN_DELIMITER);
                        sw.WriteLine(cauHoi.Value.so.ToString());
                        sw.WriteLine(cauHoi.Value.noiDung.ToString());
                        sw.WriteLine(HangSo.CAUHOI_END_DELIMITER);
                        sw.Write("\n\n");
                    }
                }

                // Ghi đáp án
                // Trước khi ghi, xóa hết nội dung text trong file cũ (cần thiết khi sử câu hỏi)
                File.WriteAllText(deThi.dapAn_filePath, string.Empty);
                Csv csv = new Csv(deThi.dapAn_filePath);
                foreach (var cauHoi in deThi.cauHoi_dic)
                {
                    List<string> record = new List<string>();
                    record.Add(cauHoi.Value.so.ToString());
                    record.Add(cauHoi.Value.dapAn.ToString());
                    csv.AddRecord(record);
                }

                MessageBox.Show("Lưu câu hỏi cho mã đề thi " + deThi.ma + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Lưu câu hỏi thất bại!" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Hàm xử lý sự kiện khi Textbox được gõ chữ
        // Mục đích: Chỉ cho phép nhập số vào text box
        private void CauHoiSo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
