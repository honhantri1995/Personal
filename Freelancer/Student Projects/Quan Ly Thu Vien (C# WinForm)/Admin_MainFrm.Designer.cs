namespace QuanLyThuVien
{
    partial class Admin_MainFrm
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
            this.admin_menuStrip = new System.Windows.Forms.MenuStrip();
            this.quanLySachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muonTraSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themSuaXoaSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuVienSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sachMuonTraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyTaiKhoanNQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyTaiKhoanDocGiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // admin_menuStrip
            // 
            this.admin_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLySachToolStripMenuItem,
            this.thongKeToolStripMenuItem,
            this.heThongToolStripMenuItem});
            this.admin_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.admin_menuStrip.Name = "admin_menuStrip";
            this.admin_menuStrip.Size = new System.Drawing.Size(316, 24);
            this.admin_menuStrip.TabIndex = 0;
            this.admin_menuStrip.Text = "admin_menuStrip";
            // 
            // quanLySachToolStripMenuItem
            // 
            this.quanLySachToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muonTraSachToolStripMenuItem,
            this.themSuaXoaSachToolStripMenuItem});
            this.quanLySachToolStripMenuItem.Name = "quanLySachToolStripMenuItem";
            this.quanLySachToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.quanLySachToolStripMenuItem.Text = "Quản lý sách";
            // 
            // muonTraSachToolStripMenuItem
            // 
            this.muonTraSachToolStripMenuItem.Name = "muonTraSachToolStripMenuItem";
            this.muonTraSachToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.muonTraSachToolStripMenuItem.Text = "Mượn - trả sách";
            this.muonTraSachToolStripMenuItem.Click += new System.EventHandler(this.muonTraSachToolStripMenuItem_Click);
            // 
            // themSuaXoaSachToolStripMenuItem
            // 
            this.themSuaXoaSachToolStripMenuItem.Name = "themSuaXoaSachToolStripMenuItem";
            this.themSuaXoaSachToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.themSuaXoaSachToolStripMenuItem.Text = "Thêm - sửa - xóa sách";
            this.themSuaXoaSachToolStripMenuItem.Click += new System.EventHandler(this.themSuaXoaSachToolStripMenuItem_Click);
            // 
            // thongKeToolStripMenuItem
            // 
            this.thongKeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thuVienSachToolStripMenuItem,
            this.sachMuonTraToolStripMenuItem});
            this.thongKeToolStripMenuItem.Name = "thongKeToolStripMenuItem";
            this.thongKeToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.thongKeToolStripMenuItem.Text = "Thống kê";
            // 
            // thuVienSachToolStripMenuItem
            // 
            this.thuVienSachToolStripMenuItem.Name = "thuVienSachToolStripMenuItem";
            this.thuVienSachToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.thuVienSachToolStripMenuItem.Text = "Thư viện sách";
            this.thuVienSachToolStripMenuItem.Click += new System.EventHandler(this.thuVienSachToolStripMenuItem_Click);
            // 
            // sachMuonTraToolStripMenuItem
            // 
            this.sachMuonTraToolStripMenuItem.Name = "sachMuonTraToolStripMenuItem";
            this.sachMuonTraToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.sachMuonTraToolStripMenuItem.Text = "Sách mượn - trả";
            this.sachMuonTraToolStripMenuItem.Click += new System.EventHandler(this.sachMuonTraToolStripMenuItem_Click);
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyTaiKhoanNQLToolStripMenuItem,
            this.quanLyTaiKhoanDocGiaToolStripMenuItem});
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.heThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // quanLyTaiKhoanNQLToolStripMenuItem
            // 
            this.quanLyTaiKhoanNQLToolStripMenuItem.Name = "quanLyTaiKhoanNQLToolStripMenuItem";
            this.quanLyTaiKhoanNQLToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.quanLyTaiKhoanNQLToolStripMenuItem.Text = "Quản lý tài khoản người QL";
            this.quanLyTaiKhoanNQLToolStripMenuItem.Click += new System.EventHandler(this.quanLyTaiKhoanNQLToolStripMenuItem_Click);
            // 
            // quanLyTaiKhoanDocGiaToolStripMenuItem
            // 
            this.quanLyTaiKhoanDocGiaToolStripMenuItem.Name = "quanLyTaiKhoanDocGiaToolStripMenuItem";
            this.quanLyTaiKhoanDocGiaToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.quanLyTaiKhoanDocGiaToolStripMenuItem.Text = "Quản lý tài khoản độc giả";
            this.quanLyTaiKhoanDocGiaToolStripMenuItem.Click += new System.EventHandler(this.quanLyTaiKhoanDocGiaToolStripMenuItem_Click);
            // 
            // Admin_MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 182);
            this.Controls.Add(this.admin_menuStrip);
            this.MainMenuStrip = this.admin_menuStrip;
            this.Name = "Admin_MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người quản lý";
            this.admin_menuStrip.ResumeLayout(false);
            this.admin_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip admin_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem quanLySachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muonTraSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themSuaXoaSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuVienSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sachMuonTraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyTaiKhoanNQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyTaiKhoanDocGiaToolStripMenuItem;
    }
}