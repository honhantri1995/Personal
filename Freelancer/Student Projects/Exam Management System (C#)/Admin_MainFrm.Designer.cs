namespace HeThongThiTracNghiem
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
            this.QuanLyTaiKhoan_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GiaoVien_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SinhVien_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // admin_menuStrip
            // 
            this.admin_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyTaiKhoan_ToolStripMenuItem});
            this.admin_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.admin_menuStrip.Name = "admin_menuStrip";
            this.admin_menuStrip.Size = new System.Drawing.Size(316, 25);
            this.admin_menuStrip.TabIndex = 0;
            this.admin_menuStrip.Text = "admin_menuStrip";
            // 
            // QuanLyTaiKhoan_ToolStripMenuItem
            // 
            this.QuanLyTaiKhoan_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GiaoVien_ToolStripMenuItem,
            this.SinhVien_ToolStripMenuItem});
            this.QuanLyTaiKhoan_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.QuanLyTaiKhoan_ToolStripMenuItem.Name = "QuanLyTaiKhoan_ToolStripMenuItem";
            this.QuanLyTaiKhoan_ToolStripMenuItem.Size = new System.Drawing.Size(121, 21);
            this.QuanLyTaiKhoan_ToolStripMenuItem.Text = "Quản lý tài khoản";
            // 
            // GiaoVien_ToolStripMenuItem
            // 
            this.GiaoVien_ToolStripMenuItem.Name = "GiaoVien_ToolStripMenuItem";
            this.GiaoVien_ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.GiaoVien_ToolStripMenuItem.Text = "Giáo viên";
            this.GiaoVien_ToolStripMenuItem.Click += new System.EventHandler(this.GiaoVien_ToolStripMenuItem_Click);
            // 
            // SinhVien_ToolStripMenuItem
            // 
            this.SinhVien_ToolStripMenuItem.Name = "SinhVien_ToolStripMenuItem";
            this.SinhVien_ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.SinhVien_ToolStripMenuItem.Text = "Sinh viên";
            this.SinhVien_ToolStripMenuItem.Click += new System.EventHandler(this.SinhVien_ToolStripMenuItem_Click);
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
            this.Text = "Quản Trị Viên";
            this.admin_menuStrip.ResumeLayout(false);
            this.admin_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip admin_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem QuanLyTaiKhoan_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GiaoVien_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SinhVien_ToolStripMenuItem;
    }
}