namespace HeThongThiTracNghiem
{
    partial class GiaoVien_MainFrm
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
            this.QuanLyDeThi_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemSuaXoaDeThi_StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeThi_DiemThi_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // admin_menuStrip
            // 
            this.admin_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyDeThi_ToolStripMenuItem,
            this.ThongKe_ToolStripMenuItem});
            this.admin_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.admin_menuStrip.Name = "admin_menuStrip";
            this.admin_menuStrip.Size = new System.Drawing.Size(316, 25);
            this.admin_menuStrip.TabIndex = 0;
            this.admin_menuStrip.Text = "admin_menuStrip";
            // 
            // QuanLyDeThi_ToolStripMenuItem
            // 
            this.QuanLyDeThi_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemSuaXoaDeThi_StripMenuItem});
            this.QuanLyDeThi_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.QuanLyDeThi_ToolStripMenuItem.Name = "QuanLyDeThi_ToolStripMenuItem";
            this.QuanLyDeThi_ToolStripMenuItem.Size = new System.Drawing.Size(101, 21);
            this.QuanLyDeThi_ToolStripMenuItem.Text = "Quản lý đề thi";
            // 
            // ThemSuaXoaDeThi_StripMenuItem
            // 
            this.ThemSuaXoaDeThi_StripMenuItem.Name = "ThemSuaXoaDeThi_StripMenuItem";
            this.ThemSuaXoaDeThi_StripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ThemSuaXoaDeThi_StripMenuItem.Text = "Thêm - sửa - xóa";
            this.ThemSuaXoaDeThi_StripMenuItem.Click += new System.EventHandler(this.QuanLyDeThi_StripMenuItem_Click);
            // 
            // ThongKe_ToolStripMenuItem
            // 
            this.ThongKe_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeThi_DiemThi_ToolStripMenuItem});
            this.ThongKe_ToolStripMenuItem.Name = "ThongKe_ToolStripMenuItem";
            this.ThongKe_ToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.ThongKe_ToolStripMenuItem.Text = "Thống kê";
            // 
            // DeThi_DiemThi_ToolStripMenuItem
            // 
            this.DeThi_DiemThi_ToolStripMenuItem.Name = "DeThi_DiemThi_ToolStripMenuItem";
            this.DeThi_DiemThi_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeThi_DiemThi_ToolStripMenuItem.Text = "Đề thi - Điểm thi";
            this.DeThi_DiemThi_ToolStripMenuItem.Click += new System.EventHandler(this.DeThi_DiemThi_ToolStripMenuItem_Click);
            // 
            // GiaoVien_MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 182);
            this.Controls.Add(this.admin_menuStrip);
            this.MainMenuStrip = this.admin_menuStrip;
            this.Name = "GiaoVien_MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giáo Viên";
            this.admin_menuStrip.ResumeLayout(false);
            this.admin_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip admin_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem QuanLyDeThi_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemSuaXoaDeThi_StripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongKe_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeThi_DiemThi_ToolStripMenuItem;
    }
}