namespace HeThongThiTracNghiem
{
    partial class SinhVien_MainFrm
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
            this.sinhVien_menuStrip = new System.Windows.Forms.MenuStrip();
            this.Thi_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BatDauThi_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKe_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKeDiemThi_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVien_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sinhVien_menuStrip
            // 
            this.sinhVien_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Thi_ToolStripMenuItem,
            this.ThongKe_ToolStripMenuItem});
            this.sinhVien_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.sinhVien_menuStrip.Name = "sinhVien_menuStrip";
            this.sinhVien_menuStrip.Size = new System.Drawing.Size(316, 25);
            this.sinhVien_menuStrip.TabIndex = 0;
            this.sinhVien_menuStrip.Text = "sinhVien_menuStrip";
            // 
            // Thi_ToolStripMenuItem
            // 
            this.Thi_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BatDauThi_ToolStripMenuItem});
            this.Thi_ToolStripMenuItem.Name = "Thi_ToolStripMenuItem";
            this.Thi_ToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.Thi_ToolStripMenuItem.Text = "Thi";
            // 
            // BatDauThi_ToolStripMenuItem
            // 
            this.BatDauThi_ToolStripMenuItem.Name = "BatDauThi_ToolStripMenuItem";
            this.BatDauThi_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BatDauThi_ToolStripMenuItem.Text = "Bắt đầu";
            this.BatDauThi_ToolStripMenuItem.Click += new System.EventHandler(this.BatDauThi_ToolStripMenuItem_Click);
            // 
            // ThongKe_ToolStripMenuItem
            // 
            this.ThongKe_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThongKeDiemThi_ToolStripMenuItem});
            this.ThongKe_ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ThongKe_ToolStripMenuItem.Name = "ThongKe_ToolStripMenuItem";
            this.ThongKe_ToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.ThongKe_ToolStripMenuItem.Text = "Thống kê";
            // 
            // ThongKeDiemThi_ToolStripMenuItem
            // 
            this.ThongKeDiemThi_ToolStripMenuItem.Name = "ThongKeDiemThi_ToolStripMenuItem";
            this.ThongKeDiemThi_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ThongKeDiemThi_ToolStripMenuItem.Text = "Điểm thi";
            this.ThongKeDiemThi_ToolStripMenuItem.Click += new System.EventHandler(this.ThongKeDiemThi_ToolStripMenuItem_Click);
            // 
            // SinhVien_MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 182);
            this.Controls.Add(this.sinhVien_menuStrip);
            this.MainMenuStrip = this.sinhVien_menuStrip;
            this.Name = "SinhVien_MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh Viên";
            this.sinhVien_menuStrip.ResumeLayout(false);
            this.sinhVien_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip sinhVien_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem Thi_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BatDauThi_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongKe_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongKeDiemThi_ToolStripMenuItem;
    }
}