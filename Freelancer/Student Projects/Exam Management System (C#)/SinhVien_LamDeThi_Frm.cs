using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class SinhVien_LamDeThi_Frm : Form
    {
        DeThi deThi = new DeThi();
        SinhVienAccount sinhVienAccount;

        string deThiDir;
        string deThiFile;
        string dapAnDungFile;
        string dapAnSVFile;

        double diemThi;

        int index_hientai = 1;
        int index_max = 0;

        Form parent;    // Form mẹ

        public SinhVien_LamDeThi_Frm(Form parent, SinhVienAccount sinhVienAccount, DeThi deThi)
        {
            InitializeComponent();

            // Khởi tạo giá trị ban đầu cho các biến thành viên của class
            this.parent = parent;
            this.sinhVienAccount = sinhVienAccount;
            this.deThi = deThi;

            sinhVienAccount.TenDangNhap = this.sinhVienAccount.TenDangNhap;

            deThiDir = string.Format(HangSo.CSV_DETHI_DIRPATH, deThi.ma);
            deThiFile = string.Format(HangSo.CSV_DETHI_FILEPATH, deThi.ma);
            dapAnDungFile = string.Format(HangSo.CSV_DAPAN_DUNG_FILEPATH, deThi.ma);
            dapAnSVFile = string.Format(HangSo.CSV_DAPAN_SINHVIEN_FILEPATH, deThi.ma, sinhVienAccount.TenDangNhap);

            if (!LoadCauHoi())
            {
                return;
            }

            // Hiện tổng số câu hỏi lên form
            tongSoCauHoi_nhap_lbl.Text = deThi.cauHoi_dic.Count.ToString();

            // FIXME (Sẽ gây lỗi nếu có câu hỏi với nội dung rỗng ở giữa những câu hỏi đầy đủ)
            index_max = deThi.cauHoi_dic.Count;

            CapNhatHienThi();
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

            // Chuyển list qua dic
            foreach (var ch in cauHoi_list)
            {
                CauHoi cauHoi = new CauHoi();
                cauHoi.so = int.Parse(ch[0]);

                // Nội dung câu hỏi có thể trải dài trên nhiều line
                for (int i = 1; i < ch.Count; i++)
                {
                    cauHoi.noiDung += ch[i] + "\n"; // TODO: K nên quy nhiều "\n" thành 1 "\n"
                }
                cauHoi.dapAn = 0;
                deThi.cauHoi_dic.Add(cauHoi.so, cauHoi);
            }

            return true;
        }

        // Hàm xử lý sự kiện khi button "Next" được click
        private void Next_btn_Click(object sender, EventArgs e)
        {
            // Lưu đáp an câu vừa trả lời vào Dict
            LuuDapAnVaoDictionary();

            // Nếu đây câu hỏi cuối cùng, thì không còn gì để next
            if (index_hientai == index_max)
            {
                MessageBox.Show("Không còn câu hỏi nào khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            index_hientai++;
            if (index_hientai > index_max) index_max = index_hientai;

            CapNhatHienThi();
        }

        // Hàm xử lý sự kiện khi button "Back" được click
        private void Back_btn_Click(object sender, EventArgs e)
        {
            // Lưu đáp an câu vừa trả lời vào Dict
            LuuDapAnVaoDictionary();

            // Nếu đây câu hỏi đầu tiên, thì không còn gì để back
            if (index_hientai == 1)
            {
                return;
            }

            index_hientai--;
            CapNhatHienThi();
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
        }

        // Lưu đáp án cho từng câu trả lời vào Dict
        private void LuuDapAnVaoDictionary()
        {
            foreach (var cauHoi in deThi.cauHoi_dic)
            {
                if (cauHoi.Key == int.Parse(cauHoiSo_txt.Text))
                {
                    cauHoi.Value.dapAn = LayDapAn();
                    return;
                }
            }
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

        // Hàm xử lý sự kiện khi button "Hoàn thành" được click
        private void HoanThanh_btn_Click(object sender, EventArgs e)
        {
            LuuDapAnVaoDictionary();        // Hiện tại code chỉ lưu điểm vào dic nếu bấm nút next,
                                            // Giả sử nếu SV câu hỏi cuối cùng, và k bấm nút next thì vẫn phải đảm bảo SV được tính điểm câu đó
            LuuDapAnXuongFile();
            TinhDiemThi();
            LuuDiemThi();
        }

        // Lưu đáp án xuống file CSV
        private bool LuuDapAnXuongFile()
        {
            // Mỗi lần làm bài thi, xóa hết đáp án cũ và thêm dòng comment CSV lên đầu file
            string data = "# Thu tu cau hoi, dap an (dang so: 1=A, 2=B, 4=C, 8=D, 16=E, 3=A&B, 5=A&C, ...)";
            File.WriteAllText(dapAnSVFile, data);

            Csv csv = new Csv(dapAnSVFile);
            foreach (var cauHoi in deThi.cauHoi_dic)
            {
                List<string> record = new List<string>();
                record.Add(cauHoi.Value.so.ToString());
                record.Add(cauHoi.Value.dapAn.ToString());
                if (!csv.AddRecord(record))
                {
                    MessageBox.Show("Lưu đáp án thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            MessageBox.Show("Chúc mừng bạn đã hoàn thành bài thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        // Tính điểm thi sau khi đã hoàn thành tất cả câu hỏi
        private bool TinhDiemThi()
        {
            // Đọc tất cả đáp án đúng
            List<List<string>> dapAnDung_list = new List<List<string>>();
            Csv csv1 = new Csv(dapAnDungFile);
            if (!csv1.ReadAll(dapAnDung_list))
            {
                MessageBox.Show("Đọc đáp án thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Đọc tất cả đáp án của sinh viên
            List<List<string>> dapAnSV_list = new List<List<string>>();
            Csv csv2 = new Csv(dapAnSVFile);
            if (!csv2.ReadAll(dapAnSV_list))
            {
                MessageBox.Show("Đọc đáp án thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Cứ mỗi lần so sánh giống nhau giữa 1 câu trả lời và 1 đáp án thì có nghĩa là câu trả lời đúng,
            // tăng biến soCauTraLoiDung lên 1
            int soCauTraLoiDung = 0;
            for (int i = 0; i < dapAnDung_list.Count; i++)
            {
                if (dapAnSV_list[i][1] == dapAnDung_list[i][1])
                {
                    soCauTraLoiDung++;
                }
            }

            // Tính điểm thi
            diemThi = soCauTraLoiDung * HangSo.DIEMSO_MAX / deThi.cauHoi_dic.Count;

            // Hỏi sinh viên có muốn xem điểm thi không,
            // nếu có, hiện form xem điểm thi
            var mb = MessageBox.Show("Bạn có muốn xem điểm thi ngay bây giờ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                // Mở form xem điểm thi
                var frm = new SinhVien_XemDiemThi(this, diemThi, deThi.cauHoi_dic.Count, soCauTraLoiDung);
                frm.Show();
                // Và disable form mẹ (sẽ enable lại sau khi thoát khỏi form xem điểm thi)
                this.Enabled = false;
            }

            return true;
        }

        // Lưu điểm thi vào file CSV
        private void LuuDiemThi()
        {
            // Tạo mã điểm thi
            string maDiemThi = deThi.ma + "_" + sinhVienAccount.TenDangNhap;

            // Lấy tất cả thông tin cần thiết
            List<string> record = new List<string>();
            record.Add(maDiemThi);
            record.Add(deThi.ma);
            record.Add(sinhVienAccount.TenDangNhap);
            record.Add(sinhVienAccount.Ten);
            record.Add(sinhVienAccount.Lop);
            record.Add(diemThi.ToString());
            record.Add(deThi.mon);
            record.Add(deThi.ky);

            // Nếu sinh viên đã làm bài thi này trước, cập nhật lại record trong file CSV
            Csv csv = new Csv(HangSo.CSV_DIEMTHI_FILEPATH);
            if (csv.IsExistRecord(maDiemThi))
            {
                if (csv.UpdateRecord(maDiemThi, record) == CsvResult.Fail)
                {
                    MessageBox.Show("Lưu điểm thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Nếu chưa làm bao giờ, thêm record mới vào file CSV
            else
            {
                if (!csv.AddRecord(record))
                {
                    MessageBox.Show("Lưu điểm thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
