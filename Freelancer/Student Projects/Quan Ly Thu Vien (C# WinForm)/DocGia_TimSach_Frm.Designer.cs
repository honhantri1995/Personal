namespace QuanLyThuVien
{
    partial class DocGia_TimSach_Frm
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
            this.maSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theLoai_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacGia_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhaXuatBan_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrangSach_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sach_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // maSach_lbl
            // 
            this.maSach_lbl.AutoSize = true;
            this.maSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSach_lbl.Location = new System.Drawing.Point(8, 27);
            this.maSach_lbl.Name = "maSach_lbl";
            this.maSach_lbl.Size = new System.Drawing.Size(59, 16);
            this.maSach_lbl.TabIndex = 22;
            this.maSach_lbl.Text = "Mã sách";
            // 
            // maSach_txt
            // 
            this.maSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maSach_txt.Location = new System.Drawing.Point(11, 48);
            this.maSach_txt.Name = "maSach_txt";
            this.maSach_txt.Size = new System.Drawing.Size(125, 23);
            this.maSach_txt.TabIndex = 1;
            this.maSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_txt
            // 
            this.tenSach_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tenSach_txt.Location = new System.Drawing.Point(11, 109);
            this.tenSach_txt.Name = "tenSach_txt";
            this.tenSach_txt.Size = new System.Drawing.Size(125, 23);
            this.tenSach_txt.TabIndex = 2;
            this.tenSach_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimSach_txt_KeyUp);
            // 
            // tenSach_lbl
            // 
            this.tenSach_lbl.AutoSize = true;
            this.tenSach_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tenSach_lbl.Location = new System.Drawing.Point(8, 89);
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
            this.maSach_col,
            this.tenSach_col,
            this.theLoai_col,
            this.tacGia_col,
            this.nhaXuatBan_col,
            this.soLuongSach_col,
            this.tinhTrangSach_col});
            this.sach_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.sach_dataGridView.Location = new System.Drawing.Point(164, 23);
            this.sach_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.sach_dataGridView.Name = "sach_dataGridView";
            this.sach_dataGridView.RowHeadersWidth = 51;
            this.sach_dataGridView.RowTemplate.Height = 24;
            this.sach_dataGridView.Size = new System.Drawing.Size(734, 485);
            this.sach_dataGridView.TabIndex = 23;
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
            // theLoai_col
            // 
            this.theLoai_col.HeaderText = "Thể loại";
            this.theLoai_col.Name = "theLoai_col";
            this.theLoai_col.Width = 54;
            // 
            // tacGia_col
            // 
            this.tacGia_col.HeaderText = "Tác giả";
            this.tacGia_col.Name = "tacGia_col";
            this.tacGia_col.Width = 54;
            // 
            // nhaXuatBan_col
            // 
            this.nhaXuatBan_col.HeaderText = "Nhà xuất bản";
            this.nhaXuatBan_col.Name = "nhaXuatBan_col";
            this.nhaXuatBan_col.Width = 99;
            // 
            // soLuongSach
            // 
            this.soLuongSach_col.HeaderText = "Số lượng";
            this.soLuongSach_col.Name = "soLuongSach";
            this.soLuongSach_col.Width = 76;
            // 
            // tinhTrangSach
            // 
            this.tinhTrangSach_col.HeaderText = "Tình trạng";
            this.tinhTrangSach_col.Name = "tinhTrangSach";
            this.tinhTrangSach_col.Width = 83;
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.tenSach_txt);
            this.flter_grb.Controls.Add(this.tenSach_lbl);
            this.flter_grb.Controls.Add(this.maSach_lbl);
            this.flter_grb.Controls.Add(this.maSach_txt);
            this.flter_grb.Location = new System.Drawing.Point(12, 23);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 149);
            this.flter_grb.TabIndex = 32;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // DocGia_TimSach_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 519);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.sach_dataGridView);
            this.Name = "DocGia_TimSach_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm sách";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn theLoai_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacGia_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhaXuatBan_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongSach_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrangSach_col;
        private System.Windows.Forms.GroupBox flter_grb;
    }
}