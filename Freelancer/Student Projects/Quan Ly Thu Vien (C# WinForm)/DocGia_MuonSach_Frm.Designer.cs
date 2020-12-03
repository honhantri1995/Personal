namespace QuanLyThuVien
{
    partial class DocGia_MuonSach_Frm
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
            this.maSach_lbl = new System.Windows.Forms.Label();
            this.huy_btn = new System.Windows.Forms.Button();
            this.luu_btn = new System.Windows.Forms.Button();
            this.soLuongSach_txt = new System.Windows.Forms.TextBox();
            this.tacGia_txt = new System.Windows.Forms.TextBox();
            this.tenSach_txt = new System.Windows.Forms.TextBox();
            this.soLuongSachMuon_lbl = new System.Windows.Forms.Label();
            this.tacGia_lbl = new System.Windows.Forms.Label();
            this.tenSach_lbl = new System.Windows.Forms.Label();
            this.ngayMuon_lbl = new System.Windows.Forms.Label();
            this.ngayMuon_dtp = new System.Windows.Forms.DateTimePicker();
            this.ngayTra_lbl = new System.Windows.Forms.Label();
            this.ngayTra_dtp = new System.Windows.Forms.DateTimePicker();
            this.maSach_cbb = new System.Windows.Forms.ComboBox();
            this.reset_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maSach_lbl
            // 
            this.maSach_lbl.AutoSize = true;
            this.maSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_lbl.Location = new System.Drawing.Point(19, 35);
            this.maSach_lbl.Name = "maSach_lbl";
            this.maSach_lbl.Size = new System.Drawing.Size(59, 16);
            this.maSach_lbl.TabIndex = 33;
            this.maSach_lbl.Text = "Mã sách";
            // 
            // huy_btn
            // 
            this.huy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.huy_btn.Location = new System.Drawing.Point(344, 318);
            this.huy_btn.Name = "huy_btn";
            this.huy_btn.Size = new System.Drawing.Size(105, 30);
            this.huy_btn.TabIndex = 31;
            this.huy_btn.Text = "Hủy";
            this.huy_btn.UseVisualStyleBackColor = true;
            this.huy_btn.Click += new System.EventHandler(this.Huy_btn_Click);
            // 
            // luu_btn
            // 
            this.luu_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.luu_btn.Location = new System.Drawing.Point(222, 318);
            this.luu_btn.Name = "luu_btn";
            this.luu_btn.Size = new System.Drawing.Size(105, 30);
            this.luu_btn.TabIndex = 30;
            this.luu_btn.Text = "Lưu";
            this.luu_btn.UseVisualStyleBackColor = true;
            this.luu_btn.Click += new System.EventHandler(this.Luu_btn_Click);
            // 
            // soLuongSach_txt
            // 
            this.soLuongSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.soLuongSach_txt.Location = new System.Drawing.Point(124, 164);
            this.soLuongSach_txt.Name = "soLuongSach_txt";
            this.soLuongSach_txt.Size = new System.Drawing.Size(325, 23);
            this.soLuongSach_txt.TabIndex = 27;
            // 
            // tacGia_txt
            // 
            this.tacGia_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tacGia_txt.Location = new System.Drawing.Point(124, 119);
            this.tacGia_txt.Name = "tacGia_txt";
            this.tacGia_txt.Size = new System.Drawing.Size(325, 23);
            this.tacGia_txt.TabIndex = 25;
            // 
            // tenSach_txt
            // 
            this.tenSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenSach_txt.Location = new System.Drawing.Point(124, 75);
            this.tenSach_txt.Name = "tenSach_txt";
            this.tenSach_txt.Size = new System.Drawing.Size(325, 23);
            this.tenSach_txt.TabIndex = 32;
            // 
            // soLuongSachMuon_lbl
            // 
            this.soLuongSachMuon_lbl.AutoSize = true;
            this.soLuongSachMuon_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.soLuongSachMuon_lbl.Location = new System.Drawing.Point(19, 168);
            this.soLuongSachMuon_lbl.Name = "soLuongSachMuon_lbl";
            this.soLuongSachMuon_lbl.Size = new System.Drawing.Size(97, 16);
            this.soLuongSachMuon_lbl.TabIndex = 21;
            this.soLuongSachMuon_lbl.Text = "Số lượng mượn";
            // 
            // tacGia_lbl
            // 
            this.tacGia_lbl.AutoSize = true;
            this.tacGia_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tacGia_lbl.Location = new System.Drawing.Point(19, 123);
            this.tacGia_lbl.Name = "tacGia_lbl";
            this.tacGia_lbl.Size = new System.Drawing.Size(54, 16);
            this.tacGia_lbl.TabIndex = 19;
            this.tacGia_lbl.Text = "Tác giả";
            // 
            // tenSach_lbl
            // 
            this.tenSach_lbl.AutoSize = true;
            this.tenSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenSach_lbl.Location = new System.Drawing.Point(19, 79);
            this.tenSach_lbl.Name = "tenSach_lbl";
            this.tenSach_lbl.Size = new System.Drawing.Size(64, 16);
            this.tenSach_lbl.TabIndex = 18;
            this.tenSach_lbl.Text = "Tên sách";
            // 
            // ngayMuon_lbl
            // 
            this.ngayMuon_lbl.AutoSize = true;
            this.ngayMuon_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ngayMuon_lbl.Location = new System.Drawing.Point(19, 216);
            this.ngayMuon_lbl.Name = "ngayMuon_lbl";
            this.ngayMuon_lbl.Size = new System.Drawing.Size(77, 16);
            this.ngayMuon_lbl.TabIndex = 37;
            this.ngayMuon_lbl.Text = "Ngày mượn";
            // 
            // ngayMuon_dtp
            // 
            this.ngayMuon_dtp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.ngayMuon_dtp.CustomFormat = "dd-MM-yyyy";
            this.ngayMuon_dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ngayMuon_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayMuon_dtp.Location = new System.Drawing.Point(124, 211);
            this.ngayMuon_dtp.Margin = new System.Windows.Forms.Padding(2);
            this.ngayMuon_dtp.Name = "ngayMuon_dtp";
            this.ngayMuon_dtp.Size = new System.Drawing.Size(325, 24);
            this.ngayMuon_dtp.TabIndex = 34;
            // 
            // ngayTra_lbl
            // 
            this.ngayTra_lbl.AutoSize = true;
            this.ngayTra_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ngayTra_lbl.Location = new System.Drawing.Point(19, 263);
            this.ngayTra_lbl.Name = "ngayTra_lbl";
            this.ngayTra_lbl.Size = new System.Drawing.Size(59, 16);
            this.ngayTra_lbl.TabIndex = 38;
            this.ngayTra_lbl.Text = "Ngày trả";
            // 
            // ngayTra_dtp
            // 
            this.ngayTra_dtp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.ngayTra_dtp.CustomFormat = "dd-MM-yyyy";
            this.ngayTra_dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ngayTra_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayTra_dtp.Location = new System.Drawing.Point(124, 258);
            this.ngayTra_dtp.Margin = new System.Windows.Forms.Padding(2);
            this.ngayTra_dtp.Name = "ngayTra_dtp";
            this.ngayTra_dtp.Size = new System.Drawing.Size(325, 24);
            this.ngayTra_dtp.TabIndex = 35;
            // 
            // maSach_cbb
            // 
            this.maSach_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_cbb.FormattingEnabled = true;
            this.maSach_cbb.Location = new System.Drawing.Point(124, 32);
            this.maSach_cbb.Name = "maSach_cbb";
            this.maSach_cbb.Size = new System.Drawing.Size(325, 23);
            this.maSach_cbb.TabIndex = 1;
            this.maSach_cbb.SelectedIndexChanged += new System.EventHandler(this.MaSach_cbb_SelectedIndexChanged);
            // 
            // reset_btn
            // 
            this.reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.reset_btn.Location = new System.Drawing.Point(118, 317);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(85, 30);
            this.reset_btn.TabIndex = 40;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // DocGia_MuonSach_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 359);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.maSach_cbb);
            this.Controls.Add(this.ngayMuon_lbl);
            this.Controls.Add(this.ngayMuon_dtp);
            this.Controls.Add(this.ngayTra_lbl);
            this.Controls.Add(this.ngayTra_dtp);
            this.Controls.Add(this.maSach_lbl);
            this.Controls.Add(this.huy_btn);
            this.Controls.Add(this.luu_btn);
            this.Controls.Add(this.soLuongSach_txt);
            this.Controls.Add(this.tacGia_txt);
            this.Controls.Add(this.tenSach_txt);
            this.Controls.Add(this.soLuongSachMuon_lbl);
            this.Controls.Add(this.tacGia_lbl);
            this.Controls.Add(this.tenSach_lbl);
            this.Name = "DocGia_MuonSach_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mượn sách";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label maSach_lbl;
        private System.Windows.Forms.Button huy_btn;
        private System.Windows.Forms.Button luu_btn;
        private System.Windows.Forms.TextBox soLuongSach_txt;
        private System.Windows.Forms.TextBox tacGia_txt;
        private System.Windows.Forms.TextBox tenSach_txt;
        private System.Windows.Forms.Label soLuongSachMuon_lbl;
        private System.Windows.Forms.Label tacGia_lbl;
        private System.Windows.Forms.Label tenSach_lbl;
        private System.Windows.Forms.DateTimePicker ngayMuon_dtp;
        private System.Windows.Forms.DateTimePicker ngayTra_dtp;
        private System.Windows.Forms.Label ngayMuon_lbl;
        private System.Windows.Forms.Label ngayTra_lbl;
        private System.Windows.Forms.ComboBox maSach_cbb;
        private System.Windows.Forms.Button reset_btn;
    }
}