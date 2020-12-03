namespace QuanLyThuVien
{
    partial class Admin_QLTaiKhoanAdmin_Frm
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
            this.matKhau_lbl = new System.Windows.Forms.Label();
            this.matKhau_txt = new System.Windows.Forms.TextBox();
            this.tenDangNhap_lbl = new System.Windows.Forms.Label();
            this.tenDangNhap_txt = new System.Windows.Forms.TextBox();
            this.xoa_btn = new System.Windows.Forms.Button();
            this.sua_btn = new System.Windows.Forms.Button();
            this.them_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // matKhau_lbl
            // 
            this.matKhau_lbl.AutoSize = true;
            this.matKhau_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.matKhau_lbl.Location = new System.Drawing.Point(18, 76);
            this.matKhau_lbl.Name = "matKhau_lbl";
            this.matKhau_lbl.Size = new System.Drawing.Size(52, 16);
            this.matKhau_lbl.TabIndex = 25;
            this.matKhau_lbl.Text = "Mật mã";
            // 
            // matKhau_txt
            // 
            this.matKhau_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.matKhau_txt.Location = new System.Drawing.Point(134, 69);
            this.matKhau_txt.MaxLength = 20;
            this.matKhau_txt.Name = "matKhau_txt";
            this.matKhau_txt.PasswordChar = '*';
            this.matKhau_txt.Size = new System.Drawing.Size(329, 23);
            this.matKhau_txt.TabIndex = 24;
            // 
            // tenDangNhap_lbl
            // 
            this.tenDangNhap_lbl.AutoSize = true;
            this.tenDangNhap_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenDangNhap_lbl.Location = new System.Drawing.Point(18, 32);
            this.tenDangNhap_lbl.Name = "tenDangNhap_lbl";
            this.tenDangNhap_lbl.Size = new System.Drawing.Size(99, 16);
            this.tenDangNhap_lbl.TabIndex = 23;
            this.tenDangNhap_lbl.Text = "Tên đăng nhập";
            // 
            // tenDangNhap_txt
            // 
            this.tenDangNhap_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenDangNhap_txt.Location = new System.Drawing.Point(134, 28);
            this.tenDangNhap_txt.Name = "tenDangNhap_txt";
            this.tenDangNhap_txt.Size = new System.Drawing.Size(329, 23);
            this.tenDangNhap_txt.TabIndex = 22;
            // 
            // xoa_btn
            // 
            this.xoa_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.xoa_btn.Location = new System.Drawing.Point(314, 117);
            this.xoa_btn.Name = "xoa_btn";
            this.xoa_btn.Size = new System.Drawing.Size(85, 30);
            this.xoa_btn.TabIndex = 28;
            this.xoa_btn.Text = "Xóa";
            this.xoa_btn.UseVisualStyleBackColor = true;
            this.xoa_btn.Click += new System.EventHandler(this.Xoa_btn_Click);
            // 
            // sua_btn
            // 
            this.sua_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.sua_btn.Location = new System.Drawing.Point(198, 117);
            this.sua_btn.Name = "sua_btn";
            this.sua_btn.Size = new System.Drawing.Size(85, 30);
            this.sua_btn.TabIndex = 27;
            this.sua_btn.Text = "Sửa";
            this.sua_btn.UseVisualStyleBackColor = true;
            this.sua_btn.Click += new System.EventHandler(this.Sua_btn_Click);
            // 
            // them_btn
            // 
            this.them_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.them_btn.Location = new System.Drawing.Point(79, 117);
            this.them_btn.Name = "them_btn";
            this.them_btn.Size = new System.Drawing.Size(85, 30);
            this.them_btn.TabIndex = 26;
            this.them_btn.Text = "Thêm";
            this.them_btn.UseVisualStyleBackColor = true;
            this.them_btn.Click += new System.EventHandler(this.Them_btn_Click);
            // 
            // Admin_QLTaiKhoanAdmin_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 168);
            this.Controls.Add(this.xoa_btn);
            this.Controls.Add(this.sua_btn);
            this.Controls.Add(this.them_btn);
            this.Controls.Add(this.matKhau_lbl);
            this.Controls.Add(this.matKhau_txt);
            this.Controls.Add(this.tenDangNhap_lbl);
            this.Controls.Add(this.tenDangNhap_txt);
            this.Name = "Admin_QLTaiKhoanAdmin_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản người quản lý";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label matKhau_lbl;
        private System.Windows.Forms.TextBox matKhau_txt;
        private System.Windows.Forms.Label tenDangNhap_lbl;
        private System.Windows.Forms.TextBox tenDangNhap_txt;
        private System.Windows.Forms.Button xoa_btn;
        private System.Windows.Forms.Button sua_btn;
        private System.Windows.Forms.Button them_btn;
    }
}