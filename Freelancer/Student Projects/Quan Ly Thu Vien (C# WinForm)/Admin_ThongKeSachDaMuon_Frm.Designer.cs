namespace QuanLyThuVien
{
    partial class Admin_ThongKeSachDaMuon_Frm
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
            this.maSach_lbl = new System.Windows.Forms.Label();
            this.maSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_txt = new System.Windows.Forms.TextBox();
            this.tenSach_lbl = new System.Windows.Forms.Label();
            this.sach_dataGridView = new System.Windows.Forms.DataGridView();
            this.maMuonTra_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDocGia_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDocGia_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongSachMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayMuon_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTraQuyDinh_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTraThucTe_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // maSach_lbl
            // 
            this.maSach_lbl.AutoSize = true;
            this.maSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_lbl.Location = new System.Drawing.Point(8, 29);
            this.maSach_lbl.Name = "maSach_lbl";
            this.maSach_lbl.Size = new System.Drawing.Size(59, 16);
            this.maSach_lbl.TabIndex = 22;
            this.maSach_lbl.Text = "Mã sách";
            // 
            // maSach_txt
            // 
            this.maSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maSach_txt.Location = new System.Drawing.Point(11, 50);
            this.maSach_txt.Name = "maSach_txt";
            this.maSach_txt.Size = new System.Drawing.Size(125, 23);
            this.maSach_txt.TabIndex = 1;
            this.maSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_txt
            // 
            this.tenSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenSach_txt.Location = new System.Drawing.Point(11, 111);
            this.tenSach_txt.Name = "tenSach_txt";
            this.tenSach_txt.Size = new System.Drawing.Size(125, 23);
            this.tenSach_txt.TabIndex = 2;
            this.tenSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_lbl
            // 
            this.tenSach_lbl.AutoSize = true;
            this.tenSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenSach_lbl.Location = new System.Drawing.Point(8, 91);
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
            this.maMuonTra_col,
            this.maSach_col,
            this.tenSach_col,
            this.maDocGia_col,
            this.tenDocGia_col,
            this.soLuongSachMuon_col,
            this.ngayMuon_col,
            this.ngayTraQuyDinh_col,
            this.ngayTraThucTe_col});
            this.sach_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.sach_dataGridView.Location = new System.Drawing.Point(164, 24);
            this.sach_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.sach_dataGridView.Name = "sach_dataGridView";
            this.sach_dataGridView.RowHeadersWidth = 51;
            this.sach_dataGridView.RowTemplate.Height = 24;
            this.sach_dataGridView.Size = new System.Drawing.Size(1004, 484);
            this.sach_dataGridView.TabIndex = 23;
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
            // ngayTraThucTe_col
            // 
            this.ngayTraThucTe_col.HeaderText = "Ngày trả thực tế";
            this.ngayTraThucTe_col.Name = "ngayTraThucTe_col";
            this.ngayTraThucTe_col.Width = 104;
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.maSach_txt);
            this.flter_grb.Controls.Add(this.tenSach_lbl);
            this.flter_grb.Controls.Add(this.maSach_lbl);
            this.flter_grb.Controls.Add(this.tenSach_txt);
            this.flter_grb.Location = new System.Drawing.Point(12, 24);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 149);
            this.flter_grb.TabIndex = 33;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // Admin_ThongKeSachDaMuon_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 519);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.sach_dataGridView);
            this.Name = "Admin_ThongKeSachDaMuon_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sách đã mượn";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn maMuonTra_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDocGia_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDocGia_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongSachMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayMuon_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTraQuyDinh_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTraThucTe_col;
        private System.Windows.Forms.GroupBox flter_grb;
    }
}