namespace QuanLyThuVien
{
    partial class Login_Frm
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
            this.login_tabControl = new System.Windows.Forms.TabControl();
            this.admin_tabPage = new System.Windows.Forms.TabPage();
            this.appTitle_lbl = new System.Windows.Forms.Label();
            this.matMa_lbl = new System.Windows.Forms.Label();
            this.tenDangNhap_lbl = new System.Windows.Forms.Label();
            this.tenDangNhap_txt = new System.Windows.Forms.TextBox();
            this.matKhau_txt = new System.Windows.Forms.TextBox();
            this.thoat_btn = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.docGia_tabPage = new System.Windows.Forms.TabPage();
            this.login_tabControl.SuspendLayout();
            this.admin_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_tabControl
            // 
            this.login_tabControl.Controls.Add(this.admin_tabPage);
            this.login_tabControl.Controls.Add(this.docGia_tabPage);
            this.login_tabControl.Location = new System.Drawing.Point(-1, -1);
            this.login_tabControl.Name = "login_tabControl";
            this.login_tabControl.SelectedIndex = 0;
            this.login_tabControl.Size = new System.Drawing.Size(383, 264);
            this.login_tabControl.TabIndex = 7;
            this.login_tabControl.SelectedIndexChanged += new System.EventHandler(this.login_tabControl_SelectedIndexChanged);
            // 
            // admin_tabPage
            // 
            this.admin_tabPage.BackColor = System.Drawing.SystemColors.Control;
            this.admin_tabPage.Controls.Add(this.appTitle_lbl);
            this.admin_tabPage.Controls.Add(this.matMa_lbl);
            this.admin_tabPage.Controls.Add(this.tenDangNhap_lbl);
            this.admin_tabPage.Controls.Add(this.tenDangNhap_txt);
            this.admin_tabPage.Controls.Add(this.matKhau_txt);
            this.admin_tabPage.Controls.Add(this.thoat_btn);
            this.admin_tabPage.Controls.Add(this.login_btn);
            this.admin_tabPage.Location = new System.Drawing.Point(4, 22);
            this.admin_tabPage.Name = "admin_tabPage";
            this.admin_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.admin_tabPage.Size = new System.Drawing.Size(375, 238);
            this.admin_tabPage.TabIndex = 0;
            this.admin_tabPage.Text = "Người quản lý";
            // 
            // appTitle_lbl
            // 
            this.appTitle_lbl.AutoSize = true;
            this.appTitle_lbl.Font = new System.Drawing.Font("Cambria", 20.75F, System.Drawing.FontStyle.Bold);
            this.appTitle_lbl.Location = new System.Drawing.Point(55, 17);
            this.appTitle_lbl.Name = "appTitle_lbl";
            this.appTitle_lbl.Size = new System.Drawing.Size(244, 33);
            this.appTitle_lbl.TabIndex = 13;
            this.appTitle_lbl.Text = "Quản Lý Thư Viện";
            // 
            // matMa_lbl
            // 
            this.matMa_lbl.AutoSize = true;
            this.matMa_lbl.Location = new System.Drawing.Point(11, 134);
            this.matMa_lbl.Name = "matMa_lbl";
            this.matMa_lbl.Size = new System.Drawing.Size(52, 13);
            this.matMa_lbl.TabIndex = 12;
            this.matMa_lbl.Text = "Mật khẩu";
            // 
            // tenDangNhap_lbl
            // 
            this.tenDangNhap_lbl.AutoSize = true;
            this.tenDangNhap_lbl.Location = new System.Drawing.Point(11, 84);
            this.tenDangNhap_lbl.Name = "tenDangNhap_lbl";
            this.tenDangNhap_lbl.Size = new System.Drawing.Size(81, 13);
            this.tenDangNhap_lbl.TabIndex = 11;
            this.tenDangNhap_lbl.Text = "Tên đăng nhập";
            // 
            // tenDangNhap_txt
            // 
            this.tenDangNhap_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenDangNhap_txt.Location = new System.Drawing.Point(98, 78);
            this.tenDangNhap_txt.MaxLength = 20;
            this.tenDangNhap_txt.Name = "tenDangNhap_txt";
            this.tenDangNhap_txt.Size = new System.Drawing.Size(256, 23);
            this.tenDangNhap_txt.TabIndex = 1;
            // 
            // matKhau_txt
            // 
            this.matKhau_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.matKhau_txt.Location = new System.Drawing.Point(98, 128);
            this.matKhau_txt.MaxLength = 20;
            this.matKhau_txt.Name = "matKhau_txt";
            this.matKhau_txt.PasswordChar = '*';
            this.matKhau_txt.Size = new System.Drawing.Size(256, 23);
            this.matKhau_txt.TabIndex = 2;
            // 
            // thoat_btn
            // 
            this.thoat_btn.Location = new System.Drawing.Point(205, 192);
            this.thoat_btn.Name = "thoat_btn";
            this.thoat_btn.Size = new System.Drawing.Size(105, 30);
            this.thoat_btn.TabIndex = 8;
            this.thoat_btn.Text = "Thoát";
            this.thoat_btn.UseVisualStyleBackColor = true;
            this.thoat_btn.Click += new System.EventHandler(this.Thoat_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(56, 192);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(105, 30);
            this.login_btn.TabIndex = 7;
            this.login_btn.Text = "Đăng nhập";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // docGia_tabPage
            // 
            this.docGia_tabPage.BackColor = System.Drawing.SystemColors.Control;
            this.docGia_tabPage.Location = new System.Drawing.Point(4, 22);
            this.docGia_tabPage.Name = "docGia_tabPage";
            this.docGia_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.docGia_tabPage.Size = new System.Drawing.Size(346, 238);
            this.docGia_tabPage.TabIndex = 1;
            this.docGia_tabPage.Text = "Độc giả";
            // 
            // Login_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 263);
            this.Controls.Add(this.login_tabControl);
            this.Name = "Login_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.login_tabControl.ResumeLayout(false);
            this.admin_tabPage.ResumeLayout(false);
            this.admin_tabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl login_tabControl;
        private System.Windows.Forms.TabPage admin_tabPage;
        private System.Windows.Forms.TabPage docGia_tabPage;
        private System.Windows.Forms.Label appTitle_lbl;
        private System.Windows.Forms.Label matMa_lbl;
        private System.Windows.Forms.Label tenDangNhap_lbl;
        private System.Windows.Forms.TextBox tenDangNhap_txt;
        private System.Windows.Forms.TextBox matKhau_txt;
        private System.Windows.Forms.Button thoat_btn;
        private System.Windows.Forms.Button login_btn;
    }
}

