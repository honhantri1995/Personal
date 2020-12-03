namespace QuanLyThuVien
{
    partial class Admin_MuonTraSach_Frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            this.tinhTrangFilter_cbb = new System.Windows.Forms.ComboBox();
            this.maSach_lbl = new System.Windows.Forms.Label();
            this.maSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_lbl = new System.Windows.Forms.Label();
            this.docGia_grb = new System.Windows.Forms.GroupBox();
            this.maDocGia_lbl = new System.Windows.Forms.Label();
            this.maDocGia_txt = new System.Windows.Forms.TextBox();
            this.tenDocGia_txt = new System.Windows.Forms.TextBox();
            this.tenDocGia_lbl = new System.Windows.Forms.Label();
            this.sach_dataGridView = new System.Windows.Forms.DataGridView();
            this.maMuongTra_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDocGia_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDocGia_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongSachMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTraQuyDinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTraThucTe_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soNgayConLai_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrangSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sach_grb = new System.Windows.Forms.GroupBox();
            this.flter_grb.SuspendLayout();
            this.docGia_grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).BeginInit();
            this.sach_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.tinhTrangFilter_cbb);
            this.flter_grb.Location = new System.Drawing.Point(12, 13);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(180, 78);
            this.flter_grb.TabIndex = 30;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // tinhTrangFilter_cbb
            // 
            this.tinhTrangFilter_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tinhTrangFilter_cbb.FormattingEnabled = true;
            this.tinhTrangFilter_cbb.Items.AddRange(new object[] {
            "Tất cả",
            "Đã trả",
            "Chưa trả",
            "Quá hạn"});
            this.tinhTrangFilter_cbb.Location = new System.Drawing.Point(10, 26);
            this.tinhTrangFilter_cbb.Name = "tinhTrangFilter_cbb";
            this.tinhTrangFilter_cbb.Size = new System.Drawing.Size(156, 23);
            this.tinhTrangFilter_cbb.TabIndex = 0;
            this.tinhTrangFilter_cbb.SelectedIndex = 0;
            this.tinhTrangFilter_cbb.SelectedIndexChanged += new System.EventHandler(this.TinhTrangFilter_cbb_SelectedIndexChanged);
            // 
            // maSach_lbl
            // 
            this.maSach_lbl.AutoSize = true;
            this.maSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_lbl.Location = new System.Drawing.Point(7, 26);
            this.maSach_lbl.Name = "maSach_lbl";
            this.maSach_lbl.Size = new System.Drawing.Size(59, 16);
            this.maSach_lbl.TabIndex = 27;
            this.maSach_lbl.Text = "Mã sách";
            // 
            // maSach_txt
            // 
            this.maSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maSach_txt.Location = new System.Drawing.Point(10, 47);
            this.maSach_txt.Name = "maSach_txt";
            this.maSach_txt.Size = new System.Drawing.Size(156, 23);
            this.maSach_txt.TabIndex = 26;
            this.maSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_txt
            // 
            this.tenSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenSach_txt.Location = new System.Drawing.Point(10, 106);
            this.tenSach_txt.Name = "tenSach_txt";
            this.tenSach_txt.Size = new System.Drawing.Size(156, 23);
            this.tenSach_txt.TabIndex = 25;
            this.tenSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_lbl
            // 
            this.tenSach_lbl.AutoSize = true;
            this.tenSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenSach_lbl.Location = new System.Drawing.Point(7, 86);
            this.tenSach_lbl.Name = "tenSach_lbl";
            this.tenSach_lbl.Size = new System.Drawing.Size(64, 16);
            this.tenSach_lbl.TabIndex = 24;
            this.tenSach_lbl.Text = "Tên sách";
            // 
            // docGia_grb
            // 
            this.docGia_grb.Controls.Add(this.maDocGia_lbl);
            this.docGia_grb.Controls.Add(this.maDocGia_txt);
            this.docGia_grb.Controls.Add(this.tenDocGia_txt);
            this.docGia_grb.Controls.Add(this.tenDocGia_lbl);
            this.docGia_grb.Location = new System.Drawing.Point(12, 305);
            this.docGia_grb.Name = "docGia_grb";
            this.docGia_grb.Size = new System.Drawing.Size(180, 145);
            this.docGia_grb.TabIndex = 28;
            this.docGia_grb.TabStop = false;
            this.docGia_grb.Text = "Độc giả";
            // 
            // maDocGia_lbl
            // 
            this.maDocGia_lbl.AutoSize = true;
            this.maDocGia_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maDocGia_lbl.Location = new System.Drawing.Point(7, 25);
            this.maDocGia_lbl.Name = "maDocGia_lbl";
            this.maDocGia_lbl.Size = new System.Drawing.Size(75, 16);
            this.maDocGia_lbl.TabIndex = 27;
            this.maDocGia_lbl.Text = "Mã độc giả";
            // 
            // maDocGia_txt
            // 
            this.maDocGia_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maDocGia_txt.Location = new System.Drawing.Point(10, 46);
            this.maDocGia_txt.Name = "maDocGia_txt";
            this.maDocGia_txt.Size = new System.Drawing.Size(158, 23);
            this.maDocGia_txt.TabIndex = 26;
            this.maDocGia_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimDocGia_txt_KeyUp);
            // 
            // tenDocGia_txt
            // 
            this.tenDocGia_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenDocGia_txt.Location = new System.Drawing.Point(10, 105);
            this.tenDocGia_txt.Name = "tenDocGia_txt";
            this.tenDocGia_txt.Size = new System.Drawing.Size(158, 23);
            this.tenDocGia_txt.TabIndex = 25;
            this.tenDocGia_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimDocGia_txt_KeyUp);
            // 
            // tenDocGia_lbl
            // 
            this.tenDocGia_lbl.AutoSize = true;
            this.tenDocGia_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenDocGia_lbl.Location = new System.Drawing.Point(7, 85);
            this.tenDocGia_lbl.Name = "tenDocGia_lbl";
            this.tenDocGia_lbl.Size = new System.Drawing.Size(80, 16);
            this.tenDocGia_lbl.TabIndex = 24;
            this.tenDocGia_lbl.Text = "Tên độc giả";
            // 
            // sach_dataGridView
            // 
            this.sach_dataGridView.AllowUserToAddRows = false;
            this.sach_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sach_dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sach_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sach_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sach_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maMuongTra_col,
            this.maSach_col,
            this.tenSach_col,
            this.maDocGia_col,
            this.tenDocGia_col,
            this.soLuongSachMuon_col,
            this.ngayMuon_col,
            this.ngayTraQuyDinh_col,
            this.ngayTraThucTe_col,
            this.soNgayConLai_col,
            this.tinhTrangSach_col});
            this.sach_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.sach_dataGridView.Location = new System.Drawing.Point(210, 25);
            this.sach_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.sach_dataGridView.Name = "sach_dataGridView";
            this.sach_dataGridView.RowHeadersWidth = 51;
            this.sach_dataGridView.RowTemplate.Height = 24;
            this.sach_dataGridView.Size = new System.Drawing.Size(1103, 517);
            this.sach_dataGridView.TabIndex = 23;
            // 
            // maMuongTra_col
            // 
            this.maMuongTra_col.HeaderText = "Mã mượn trả";
            this.maMuongTra_col.Name = "maMuongTra_col";
            this.maMuongTra_col.Width = 94;
            // 
            // maSach_col
            // 
            this.maSach_col.HeaderText = "Mã sách";
            this.maSach_col.Name = "maSach_col";
            this.maSach_col.Width = 74;
            // 
            // tenSach_col
            // 
            this.tenSach_col.HeaderText = "Tên sách";
            this.tenSach_col.Name = "tenSach_col";
            this.tenSach_col.Width = 78;
            // 
            // maDocGia_col
            // 
            this.maDocGia_col.HeaderText = "Mã độc giả";
            this.maDocGia_col.Name = "maDocGia_col";
            this.maDocGia_col.Width = 88;
            // 
            // tenDocGia_col
            // 
            this.tenDocGia_col.HeaderText = "Tên độc giả";
            this.tenDocGia_col.Name = "tenDocGia_col";
            this.tenDocGia_col.Width = 78;
            // 
            // soLuongSachMuon_col
            // 
            this.soLuongSachMuon_col.HeaderText = "Số lượng mượn";
            this.soLuongSachMuon_col.MinimumWidth = 8;
            this.soLuongSachMuon_col.Name = "soLuongSachMuon_col";
            this.soLuongSachMuon_col.Width = 106;
            // 
            // ngayMuon_col
            // 
            this.ngayMuon_col.HeaderText = "Ngày mượn";
            this.ngayMuon_col.Name = "ngayMuon_col";
            this.ngayMuon_col.Width = 87;
            // 
            // ngayTraQuyDinh_col
            // 
            this.ngayTraQuyDinh_col.HeaderText = "Ngày trả quy định";
            this.ngayTraQuyDinh_col.Name = "ngayTraQuyDinh_col";
            this.ngayTraQuyDinh_col.Width = 99;
            // 
            // ngayTraThucTe
            // 
            this.ngayTraThucTe_col.HeaderText = "Ngày trả thực tế";
            this.ngayTraThucTe_col.Name = "ngayTraThucTe";
            this.ngayTraThucTe_col.Width = 104;
            // 
            // soNgayConLai_col
            // 
            this.soNgayConLai_col.HeaderText = "Số ngày còn lại";
            this.soNgayConLai_col.Name = "soNgayConLai_col";
            this.soNgayConLai_col.Width = 98;
            // 
            // tinhTrangSach_col
            // 
            this.tinhTrangSach_col.HeaderText = "Tình trạng";
            this.tinhTrangSach_col.Name = "tinhTrangSach_col";
            this.tinhTrangSach_col.Width = 83;
            // 
            // sach_grb
            // 
            this.sach_grb.Controls.Add(this.maSach_lbl);
            this.sach_grb.Controls.Add(this.maSach_txt);
            this.sach_grb.Controls.Add(this.tenSach_txt);
            this.sach_grb.Controls.Add(this.tenSach_lbl);
            this.sach_grb.Location = new System.Drawing.Point(12, 120);
            this.sach_grb.Name = "sach_grb";
            this.sach_grb.Size = new System.Drawing.Size(178, 147);
            this.sach_grb.TabIndex = 24;
            this.sach_grb.TabStop = false;
            this.sach_grb.Text = "Sách";
            // 
            // Admin_MuonTraSach_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 553);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.docGia_grb);
            this.Controls.Add(this.sach_grb);
            this.Controls.Add(this.sach_dataGridView);
            this.Name = "Admin_MuonTraSach_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý mượn - trả sách";
            this.flter_grb.ResumeLayout(false);
            this.docGia_grb.ResumeLayout(false);
            this.docGia_grb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).EndInit();
            this.sach_grb.ResumeLayout(false);
            this.sach_grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView sach_dataGridView;
        private System.Windows.Forms.Label maSach_lbl;
        private System.Windows.Forms.TextBox maSach_txt;
        private System.Windows.Forms.TextBox tenSach_txt;
        private System.Windows.Forms.Label tenSach_lbl;
        private System.Windows.Forms.GroupBox docGia_grb;
        private System.Windows.Forms.Label maDocGia_lbl;
        private System.Windows.Forms.TextBox maDocGia_txt;
        private System.Windows.Forms.TextBox tenDocGia_txt;
        private System.Windows.Forms.Label tenDocGia_lbl;
        private System.Windows.Forms.GroupBox flter_grb;
        private System.Windows.Forms.ComboBox tinhTrangFilter_cbb;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMuongTra_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDocGia_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDocGia_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongSachMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTraQuyDinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTraThucTe_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soNgayConLai_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrangSach_col;
        private System.Windows.Forms.GroupBox sach_grb;
    }
}