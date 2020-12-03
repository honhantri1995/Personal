namespace QuanLyThuVien
{
    partial class DocGia_MainFrm
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
            this.docGia_menuStrip = new System.Windows.Forms.MenuStrip();
            this.quanLytimKiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyMuonTraSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muonSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traSachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docGia_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // docGia_menuStrip
            // 
            this.docGia_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLytimKiemToolStripMenuItem,
            this.quanLyMuonTraSachToolStripMenuItem});
            this.docGia_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.docGia_menuStrip.Name = "docGia_menuStrip";
            this.docGia_menuStrip.Size = new System.Drawing.Size(316, 24);
            this.docGia_menuStrip.TabIndex = 0;
            this.docGia_menuStrip.Text = "docGia_menuStrip";
            // 
            // quanLytimKiemToolStripMenuItem
            // 
            this.quanLytimKiemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timKiemToolStripMenuItem});
            this.quanLytimKiemToolStripMenuItem.Name = "quanLytimKiemToolStripMenuItem";
            this.quanLytimKiemToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.quanLytimKiemToolStripMenuItem.Text = "Thư viện sách";
            // 
            // timKiemToolStripMenuItem
            // 
            this.timKiemToolStripMenuItem.Name = "timKiemToolStripMenuItem";
            this.timKiemToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.timKiemToolStripMenuItem.Text = "Tìm kiếm";
            this.timKiemToolStripMenuItem.Click += new System.EventHandler(this.timKiemToolStripMenuItem_Click);
            // 
            // quanLyMuonTraSachToolStripMenuItem
            // 
            this.quanLyMuonTraSachToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muonSachToolStripMenuItem,
            this.traSachToolStripMenuItem});
            this.quanLyMuonTraSachToolStripMenuItem.Name = "quanLyMuonTraSachToolStripMenuItem";
            this.quanLyMuonTraSachToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.quanLyMuonTraSachToolStripMenuItem.Text = "Quản lý mượn - trả sách";
            // 
            // muonSachToolStripMenuItem
            // 
            this.muonSachToolStripMenuItem.Name = "muonSachToolStripMenuItem";
            this.muonSachToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.muonSachToolStripMenuItem.Text = "Mượn sách";
            this.muonSachToolStripMenuItem.Click += new System.EventHandler(this.muonSachToolStripMenuItem_Click);
            // 
            // traSachToolStripMenuItem
            // 
            this.traSachToolStripMenuItem.Name = "traSachToolStripMenuItem";
            this.traSachToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.traSachToolStripMenuItem.Text = "Trả sách";
            this.traSachToolStripMenuItem.Click += new System.EventHandler(this.traSachToolStripMenuItem_Click);
            // 
            // DocGia_MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 182);
            this.Controls.Add(this.docGia_menuStrip);
            this.MainMenuStrip = this.docGia_menuStrip;
            this.Name = "DocGia_MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Độc giả";
            this.docGia_menuStrip.ResumeLayout(false);
            this.docGia_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip docGia_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem quanLytimKiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timKiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyMuonTraSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muonSachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traSachToolStripMenuItem;
    }
}