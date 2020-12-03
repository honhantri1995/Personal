namespace QuanLyThuVien
{
    partial class Admin_QLTaiKhoanDocGia_Frm
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
            this.maDocGia_txt = new System.Windows.Forms.TextBox();
            this.maDocGia_lbl = new System.Windows.Forms.Label();
            this.tenDocGia_txt = new System.Windows.Forms.TextBox();
            this.tenDocGia_lbl = new System.Windows.Forms.Label();
            this.capNhat_btn = new System.Windows.Forms.Button();
            this.xoaSach_btn = new System.Windows.Forms.Button();
            this.suaSach_btn = new System.Windows.Forms.Button();
            this.themSach_btn = new System.Windows.Forms.Button();
            this.gioiTinh_lbl = new System.Windows.Forms.Label();
            this.soDT_lbl = new System.Windows.Forms.Label();
            this.ngaySinh_dtp = new System.Windows.Forms.DateTimePicker();
            this.ngaySinh_lbl = new System.Windows.Forms.Label();
            this.matKhau_txt = new System.Windows.Forms.TextBox();
            this.matKhau_lbl = new System.Windows.Forms.Label();
            this.diaChi_lbl = new System.Windows.Forms.Label();
            this.diaChi_txt = new System.Windows.Forms.TextBox();
            this.soDT_txt = new System.Windows.Forms.TextBox();
            this.gioiTinh_cbb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // maDocGia_txt
            // 
            this.maDocGia_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maDocGia_txt.Location = new System.Drawing.Point(140, 28);
            this.maDocGia_txt.Name = "maDocGia_txt";
            this.maDocGia_txt.Size = new System.Drawing.Size(325, 23);
            this.maDocGia_txt.TabIndex = 1;
            // 
            // maDocGia_lbl
            // 
            this.maDocGia_lbl.AutoSize = true;
            this.maDocGia_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maDocGia_lbl.Location = new System.Drawing.Point(24, 32);
            this.maDocGia_lbl.Name = "maDocGia_lbl";
            this.maDocGia_lbl.Size = new System.Drawing.Size(75, 16);
            this.maDocGia_lbl.TabIndex = 27;
            this.maDocGia_lbl.Text = "Mã độc giả";
            // 
            // tenDocGia_txt
            // 
            this.tenDocGia_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenDocGia_txt.Location = new System.Drawing.Point(140, 72);
            this.tenDocGia_txt.Name = "tenDocGia_txt";
            this.tenDocGia_txt.Size = new System.Drawing.Size(325, 23);
            this.tenDocGia_txt.TabIndex = 2;
            // 
            // tenDocGia_lbl
            // 
            this.tenDocGia_lbl.AutoSize = true;
            this.tenDocGia_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenDocGia_lbl.Location = new System.Drawing.Point(24, 76);
            this.tenDocGia_lbl.Name = "tenDocGia_lbl";
            this.tenDocGia_lbl.Size = new System.Drawing.Size(80, 16);
            this.tenDocGia_lbl.TabIndex = 26;
            this.tenDocGia_lbl.Text = "Tên độc giả";
            // 
            // capNhat_btn
            // 
            this.capNhat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.capNhat_btn.Location = new System.Drawing.Point(27, 354);
            this.capNhat_btn.Name = "capNhat_btn";
            this.capNhat_btn.Size = new System.Drawing.Size(85, 30);
            this.capNhat_btn.TabIndex = 25;
            this.capNhat_btn.Text = "Cập nhật";
            this.capNhat_btn.UseVisualStyleBackColor = true;
            this.capNhat_btn.Click += new System.EventHandler(this.CapNhat_btn_Click);
            // 
            // xoaSach_btn
            // 
            this.xoaSach_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.xoaSach_btn.Location = new System.Drawing.Point(380, 354);
            this.xoaSach_btn.Name = "xoaSach_btn";
            this.xoaSach_btn.Size = new System.Drawing.Size(85, 30);
            this.xoaSach_btn.TabIndex = 24;
            this.xoaSach_btn.Text = "Xóa";
            this.xoaSach_btn.UseVisualStyleBackColor = true;
            this.xoaSach_btn.Click += new System.EventHandler(this.Xoa_btn_Click);
            // 
            // suaSach_btn
            // 
            this.suaSach_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.suaSach_btn.Location = new System.Drawing.Point(264, 354);
            this.suaSach_btn.Name = "suaSach_btn";
            this.suaSach_btn.Size = new System.Drawing.Size(85, 30);
            this.suaSach_btn.TabIndex = 23;
            this.suaSach_btn.Text = "Sửa";
            this.suaSach_btn.UseVisualStyleBackColor = true;
            this.suaSach_btn.Click += new System.EventHandler(this.Sua_btn_Click);
            // 
            // themSach_btn
            // 
            this.themSach_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.themSach_btn.Location = new System.Drawing.Point(145, 354);
            this.themSach_btn.Name = "themSach_btn";
            this.themSach_btn.Size = new System.Drawing.Size(85, 30);
            this.themSach_btn.TabIndex = 22;
            this.themSach_btn.Text = "Thêm";
            this.themSach_btn.UseVisualStyleBackColor = true;
            this.themSach_btn.Click += new System.EventHandler(this.Them_btn_Click);
            // 
            // gioiTinh_lbl
            // 
            this.gioiTinh_lbl.AutoSize = true;
            this.gioiTinh_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.gioiTinh_lbl.Location = new System.Drawing.Point(24, 124);
            this.gioiTinh_lbl.Name = "gioiTinh_lbl";
            this.gioiTinh_lbl.Size = new System.Drawing.Size(55, 16);
            this.gioiTinh_lbl.TabIndex = 10;
            this.gioiTinh_lbl.Text = "Giới tính";
            // 
            // soDT_lbl
            // 
            this.soDT_lbl.AutoSize = true;
            this.soDT_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.soDT_lbl.Location = new System.Drawing.Point(24, 166);
            this.soDT_lbl.Name = "soDT_lbl";
            this.soDT_lbl.Size = new System.Drawing.Size(86, 16);
            this.soDT_lbl.TabIndex = 9;
            this.soDT_lbl.Text = "Số điện thoại";
            // 
            // ngaySinh_dtp
            // 
            this.ngaySinh_dtp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.ngaySinh_dtp.CustomFormat = "dd-MM-yyyy";
            this.ngaySinh_dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ngaySinh_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngaySinh_dtp.Location = new System.Drawing.Point(140, 210);
            this.ngaySinh_dtp.Margin = new System.Windows.Forms.Padding(2);
            this.ngaySinh_dtp.Name = "ngaySinh_dtp";
            this.ngaySinh_dtp.Size = new System.Drawing.Size(325, 24);
            this.ngaySinh_dtp.TabIndex = 5;
            this.ngaySinh_dtp.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // ngaySinh_lbl
            // 
            this.ngaySinh_lbl.AutoSize = true;
            this.ngaySinh_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ngaySinh_lbl.Location = new System.Drawing.Point(24, 214);
            this.ngaySinh_lbl.Name = "ngaySinh_lbl";
            this.ngaySinh_lbl.Size = new System.Drawing.Size(68, 16);
            this.ngaySinh_lbl.TabIndex = 8;
            this.ngaySinh_lbl.Text = "Ngày sinh";
            // 
            // matKhau_txt
            // 
            this.matKhau_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.matKhau_txt.Location = new System.Drawing.Point(140, 301);
            this.matKhau_txt.MaxLength = 20;
            this.matKhau_txt.Name = "matKhau_txt";
            this.matKhau_txt.PasswordChar = '*';
            this.matKhau_txt.Size = new System.Drawing.Size(325, 23);
            this.matKhau_txt.TabIndex = 7;
            // 
            // matKhau_lbl
            // 
            this.matKhau_lbl.AutoSize = true;
            this.matKhau_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.matKhau_lbl.Location = new System.Drawing.Point(24, 305);
            this.matKhau_lbl.Name = "matKhau_lbl";
            this.matKhau_lbl.Size = new System.Drawing.Size(52, 16);
            this.matKhau_lbl.TabIndex = 7;
            this.matKhau_lbl.Text = "Mật mã";
            // 
            // diaChi_lbl
            // 
            this.diaChi_lbl.AutoSize = true;
            this.diaChi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.diaChi_lbl.Location = new System.Drawing.Point(24, 260);
            this.diaChi_lbl.Name = "diaChi_lbl";
            this.diaChi_lbl.Size = new System.Drawing.Size(48, 16);
            this.diaChi_lbl.TabIndex = 4;
            this.diaChi_lbl.Text = "Địa chỉ";
            // 
            // diaChi_txt
            // 
            this.diaChi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.diaChi_txt.Location = new System.Drawing.Point(140, 257);
            this.diaChi_txt.Name = "diaChi_txt";
            this.diaChi_txt.Size = new System.Drawing.Size(325, 23);
            this.diaChi_txt.TabIndex = 6;
            // 
            // soDT_txt
            // 
            this.soDT_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.soDT_txt.Location = new System.Drawing.Point(140, 163);
            this.soDT_txt.Name = "soDT_txt";
            this.soDT_txt.Size = new System.Drawing.Size(325, 23);
            this.soDT_txt.TabIndex = 4;
            // 
            // gioiTinh_cbb
            // 
            this.gioiTinh_cbb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gioiTinh_cbb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gioiTinh_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.gioiTinh_cbb.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.gioiTinh_cbb.Location = new System.Drawing.Point(140, 119);
            this.gioiTinh_cbb.Name = "gioiTinh_cbb";
            this.gioiTinh_cbb.Size = new System.Drawing.Size(325, 23);
            this.gioiTinh_cbb.TabIndex = 3;
            // 
            // Admin_QLTaiKhoanDocGia_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 397);
            this.Controls.Add(this.gioiTinh_cbb);
            this.Controls.Add(this.diaChi_lbl);
            this.Controls.Add(this.diaChi_txt);
            this.Controls.Add(this.matKhau_lbl);
            this.Controls.Add(this.matKhau_txt);
            this.Controls.Add(this.ngaySinh_lbl);
            this.Controls.Add(this.ngaySinh_dtp);
            this.Controls.Add(this.soDT_lbl);
            this.Controls.Add(this.soDT_txt);
            this.Controls.Add(this.gioiTinh_lbl);
            this.Controls.Add(this.capNhat_btn);
            this.Controls.Add(this.xoaSach_btn);
            this.Controls.Add(this.suaSach_btn);
            this.Controls.Add(this.themSach_btn);
            this.Controls.Add(this.tenDocGia_lbl);
            this.Controls.Add(this.tenDocGia_txt);
            this.Controls.Add(this.maDocGia_lbl);
            this.Controls.Add(this.maDocGia_txt);
            this.Name = "Admin_QLTaiKhoanDocGia_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý độc giả";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox maDocGia_txt;
        private System.Windows.Forms.Label maDocGia_lbl;
        private System.Windows.Forms.TextBox tenDocGia_txt;
        private System.Windows.Forms.Label tenDocGia_lbl;
        private System.Windows.Forms.Button capNhat_btn;
        private System.Windows.Forms.Button xoaSach_btn;
        private System.Windows.Forms.Button suaSach_btn;
        private System.Windows.Forms.Button themSach_btn;
        private System.Windows.Forms.Label gioiTinh_lbl;
        private System.Windows.Forms.Label soDT_lbl;
        private System.Windows.Forms.DateTimePicker ngaySinh_dtp;
        private System.Windows.Forms.Label ngaySinh_lbl;
        private System.Windows.Forms.TextBox matKhau_txt;
        private System.Windows.Forms.Label matKhau_lbl;
        private System.Windows.Forms.Label diaChi_lbl;
        private System.Windows.Forms.TextBox diaChi_txt;
        private System.Windows.Forms.ComboBox gioiTinh_cbb;
        private System.Windows.Forms.TextBox soDT_txt;
    }
}