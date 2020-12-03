namespace QuanLyThuVien
{
    partial class DocGia_TraSach_Frm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.maSach_lbl = new System.Windows.Forms.Label();
            this.maSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_lbl = new System.Windows.Forms.Label();
            this.sach_dataGridView = new System.Windows.Forms.DataGridView();
            this.maMuonTra_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongSachMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTraQuyDinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soNgayConLai_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrangMuonSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traSach_btn = new System.Windows.Forms.Button();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            this.tinhTrangFilter_cbb = new System.Windows.Forms.ComboBox();
            this.tinhTrangSach_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // maSach_lbl
            // 
            this.maSach_lbl.AutoSize = true;
            this.maSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_lbl.Location = new System.Drawing.Point(7, 87);
            this.maSach_lbl.Name = "maSach_lbl";
            this.maSach_lbl.Size = new System.Drawing.Size(59, 16);
            this.maSach_lbl.TabIndex = 22;
            this.maSach_lbl.Text = "Mã sách";
            // 
            // maSach_txt
            // 
            this.maSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maSach_txt.Location = new System.Drawing.Point(10, 108);
            this.maSach_txt.Name = "maSach_txt";
            this.maSach_txt.Size = new System.Drawing.Size(125, 23);
            this.maSach_txt.TabIndex = 1;
            this.maSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_txt
            // 
            this.tenSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenSach_txt.Location = new System.Drawing.Point(10, 169);
            this.tenSach_txt.Name = "tenSach_txt";
            this.tenSach_txt.Size = new System.Drawing.Size(125, 23);
            this.tenSach_txt.TabIndex = 2;
            this.tenSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_lbl
            // 
            this.tenSach_lbl.AutoSize = true;
            this.tenSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenSach_lbl.Location = new System.Drawing.Point(7, 149);
            this.tenSach_lbl.Name = "tenSach_lbl";
            this.tenSach_lbl.Size = new System.Drawing.Size(64, 16);
            this.tenSach_lbl.TabIndex = 19;
            this.tenSach_lbl.Text = "Tên sách";
            // 
            // sach_dataGridView
            // 
            this.sach_dataGridView.AllowUserToAddRows = false;
            this.sach_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.sach_dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sach_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sach_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sach_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maMuonTra_col,
            this.maSach_col,
            this.tenSach_col,
            this.soLuongSachMuon_col,
            this.ngayMuon_col,
            this.ngayTraQuyDinh_col,
            this.soNgayConLai_col,
            this.tinhTrangMuonSach_col});
            this.sach_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.sach_dataGridView.Location = new System.Drawing.Point(164, 12);
            this.sach_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.sach_dataGridView.Name = "sach_dataGridView";
            this.sach_dataGridView.RowHeadersWidth = 51;
            this.sach_dataGridView.RowTemplate.Height = 24;
            this.sach_dataGridView.Size = new System.Drawing.Size(892, 495);
            this.sach_dataGridView.TabIndex = 23;
            this.sach_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Sach_DataGridView_CellClick);
            // 
            // maMuonTra_col
            // 
            this.maMuonTra_col.HeaderText = "Mã mượn trả";
            this.maMuonTra_col.Name = "maMuonTra_col";
            this.maMuonTra_col.Width = 94;
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
            // soNgayConLai_col
            // 
            this.soNgayConLai_col.HeaderText = "Số ngày còn lại";
            this.soNgayConLai_col.Name = "soNgayConLai_col";
            this.soNgayConLai_col.Width = 98;
            // 
            // tinhTrangMuonSach_col
            // 
            this.tinhTrangMuonSach_col.HeaderText = "Tình trạng";
            this.tinhTrangMuonSach_col.Name = "tinhTrangMuonSach_col";
            this.tinhTrangMuonSach_col.Width = 83;
            // 
            // traSach_btn
            // 
            this.traSach_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.traSach_btn.Location = new System.Drawing.Point(9, 477);
            this.traSach_btn.Name = "traSach_btn";
            this.traSach_btn.Size = new System.Drawing.Size(125, 30);
            this.traSach_btn.TabIndex = 24;
            this.traSach_btn.Text = "Trả sách";
            this.traSach_btn.UseVisualStyleBackColor = true;
            this.traSach_btn.Click += new System.EventHandler(this.TraSach_btn_Click);
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.tinhTrangSach_lbl);
            this.flter_grb.Controls.Add(this.maSach_lbl);
            this.flter_grb.Controls.Add(this.tenSach_lbl);
            this.flter_grb.Controls.Add(this.tinhTrangFilter_cbb);
            this.flter_grb.Controls.Add(this.tenSach_txt);
            this.flter_grb.Controls.Add(this.maSach_txt);
            this.flter_grb.Location = new System.Drawing.Point(9, 12);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 206);
            this.flter_grb.TabIndex = 31;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // tinhTrangFilter_cbb
            // 
            this.tinhTrangFilter_cbb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tinhTrangFilter_cbb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tinhTrangFilter_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tinhTrangFilter_cbb.FormattingEnabled = true;
            this.tinhTrangFilter_cbb.Items.AddRange(new object[] {
            "Tất cả",
            "Đã trả",
            "Chưa trả",
            "Quá hạn"});
            this.tinhTrangFilter_cbb.Location = new System.Drawing.Point(10, 47);
            this.tinhTrangFilter_cbb.Name = "tinhTrangFilter_cbb";
            this.tinhTrangFilter_cbb.Size = new System.Drawing.Size(124, 23);
            this.tinhTrangFilter_cbb.TabIndex = 0;
            this.tinhTrangFilter_cbb.SelectedIndex = 0;
            this.tinhTrangFilter_cbb.SelectedIndexChanged += new System.EventHandler(this.TinhTrangFilter_cbb_SelectedIndexChanged);
            // 
            // tinhTrangSach_lbl
            // 
            this.tinhTrangSach_lbl.AutoSize = true;
            this.tinhTrangSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tinhTrangSach_lbl.Location = new System.Drawing.Point(7, 25);
            this.tinhTrangSach_lbl.Name = "tinhTrangSach_lbl";
            this.tinhTrangSach_lbl.Size = new System.Drawing.Size(67, 16);
            this.tinhTrangSach_lbl.TabIndex = 23;
            this.tinhTrangSach_lbl.Text = "Tình trạng";
            // 
            // DocGia_TraSach_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 519);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.traSach_btn);
            this.Controls.Add(this.sach_dataGridView);
            this.Name = "DocGia_TraSach_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả sách";
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).EndInit();
            this.flter_grb.ResumeLayout(false);
            this.flter_grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label maSach_lbl;
        private System.Windows.Forms.TextBox maSach_txt;
        private System.Windows.Forms.TextBox tenSach_txt;
        private System.Windows.Forms.Label tenSach_lbl;
        public System.Windows.Forms.DataGridView sach_dataGridView;
        private System.Windows.Forms.Button traSach_btn;
        private System.Windows.Forms.GroupBox flter_grb;
        private System.Windows.Forms.ComboBox tinhTrangFilter_cbb;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMuonTra_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongSachMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTraQuyDinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soNgayConLai_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrangMuonSach_col;
        private System.Windows.Forms.Label tinhTrangSach_lbl;
    }
}