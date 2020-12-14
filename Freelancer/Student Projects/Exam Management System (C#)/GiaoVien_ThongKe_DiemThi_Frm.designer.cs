namespace HeThongThiTracNghiem
{
    partial class GiaoVien_ThongKe_DiemThi_Frm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lop_lbl = new System.Windows.Forms.Label();
            this.lop_txt = new System.Windows.Forms.TextBox();
            this.diemThi_dataGridView = new System.Windows.Forms.DataGridView();
            this.maSinhVien_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSinhVien_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lop_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            this.maSinhVien_txt = new System.Windows.Forms.TextBox();
            this.maSinhVien_lbl = new System.Windows.Forms.Label();
            this.maDeThi_lbl = new System.Windows.Forms.Label();
            this.monThi_lbl = new System.Windows.Forms.Label();
            this.kyThi_lbl = new System.Windows.Forms.Label();
            this.maDeThi_nhap_lbl = new System.Windows.Forms.Label();
            this.monThi_nhap_lbl = new System.Windows.Forms.Label();
            this.kyThi_nhap_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.diemThi_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // lop_lbl
            // 
            this.lop_lbl.AutoSize = true;
            this.lop_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lop_lbl.Location = new System.Drawing.Point(8, 88);
            this.lop_lbl.Name = "lop_lbl";
            this.lop_lbl.Size = new System.Drawing.Size(31, 16);
            this.lop_lbl.TabIndex = 22;
            this.lop_lbl.Text = "Lớp";
            // 
            // lop_txt
            // 
            this.lop_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lop_txt.Location = new System.Drawing.Point(11, 109);
            this.lop_txt.Name = "lop_txt";
            this.lop_txt.Size = new System.Drawing.Size(125, 23);
            this.lop_txt.TabIndex = 1;
            this.lop_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimTheoLop_txt_KeyUp);
            // 
            // diemThi_dataGridView
            // 
            this.diemThi_dataGridView.AllowUserToAddRows = false;
            this.diemThi_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.diemThi_dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.diemThi_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.diemThi_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diemThi_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSinhVien_col,
            this.tenSinhVien_col,
            this.lop_col,
            this.diemThi_col});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.diemThi_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.diemThi_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.diemThi_dataGridView.Location = new System.Drawing.Point(233, 24);
            this.diemThi_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.diemThi_dataGridView.Name = "diemThi_dataGridView";
            this.diemThi_dataGridView.RowHeadersWidth = 51;
            this.diemThi_dataGridView.RowTemplate.Height = 24;
            this.diemThi_dataGridView.Size = new System.Drawing.Size(724, 450);
            this.diemThi_dataGridView.TabIndex = 23;
            // 
            // maSinhVien_col
            // 
            this.maSinhVien_col.HeaderText = "Mã sinh viên";
            this.maSinhVien_col.Name = "maSinhVien_col";
            this.maSinhVien_col.Width = 109;
            // 
            // tenSinhVien_col
            // 
            this.tenSinhVien_col.HeaderText = "Tên sinh viên";
            this.tenSinhVien_col.Name = "tenSinhVien_col";
            this.tenSinhVien_col.Width = 114;
            // 
            // lop_col
            // 
            this.lop_col.HeaderText = "Lớp";
            this.lop_col.Name = "lop_col";
            this.lop_col.Width = 59;
            // 
            // diemThi_col
            // 
            this.diemThi_col.HeaderText = "Điểm thi";
            this.diemThi_col.Name = "diemThi_col";
            this.diemThi_col.Width = 81;
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.maSinhVien_txt);
            this.flter_grb.Controls.Add(this.maSinhVien_lbl);
            this.flter_grb.Controls.Add(this.lop_txt);
            this.flter_grb.Controls.Add(this.lop_lbl);
            this.flter_grb.Location = new System.Drawing.Point(12, 225);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 149);
            this.flter_grb.TabIndex = 33;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // maSinhVien_txt
            // 
            this.maSinhVien_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maSinhVien_txt.Location = new System.Drawing.Point(11, 50);
            this.maSinhVien_txt.MaxLength = 20;
            this.maSinhVien_txt.Name = "maSinhVien_txt";
            this.maSinhVien_txt.Size = new System.Drawing.Size(125, 23);
            this.maSinhVien_txt.TabIndex = 36;
            this.maSinhVien_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimTheoMaSinhVien_txt_KeyUp);
            // 
            // maSinhVien_lbl
            // 
            this.maSinhVien_lbl.AutoSize = true;
            this.maSinhVien_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maSinhVien_lbl.Location = new System.Drawing.Point(8, 30);
            this.maSinhVien_lbl.Name = "maSinhVien_lbl";
            this.maSinhVien_lbl.Size = new System.Drawing.Size(82, 16);
            this.maSinhVien_lbl.TabIndex = 35;
            this.maSinhVien_lbl.Text = "Mã sinh viên";
            // 
            // maDeThi_lbl
            // 
            this.maDeThi_lbl.AutoSize = true;
            this.maDeThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maDeThi_lbl.Location = new System.Drawing.Point(14, 23);
            this.maDeThi_lbl.Name = "maDeThi_lbl";
            this.maDeThi_lbl.Size = new System.Drawing.Size(68, 16);
            this.maDeThi_lbl.TabIndex = 37;
            this.maDeThi_lbl.Text = "Mã đề thi: ";
            // 
            // monThi_lbl
            // 
            this.monThi_lbl.AutoSize = true;
            this.monThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.monThi_lbl.Location = new System.Drawing.Point(14, 79);
            this.monThi_lbl.Name = "monThi_lbl";
            this.monThi_lbl.Size = new System.Drawing.Size(56, 16);
            this.monThi_lbl.TabIndex = 38;
            this.monThi_lbl.Text = "Môn thi: ";
            // 
            // kyThi_lbl
            // 
            this.kyThi_lbl.AutoSize = true;
            this.kyThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.kyThi_lbl.Location = new System.Drawing.Point(14, 135);
            this.kyThi_lbl.Name = "kyThi_lbl";
            this.kyThi_lbl.Size = new System.Drawing.Size(45, 16);
            this.kyThi_lbl.TabIndex = 39;
            this.kyThi_lbl.Text = "Kỳ thi: ";
            // 
            // maDeThi_nhap_lbl
            // 
            this.maDeThi_nhap_lbl.AutoSize = true;
            this.maDeThi_nhap_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maDeThi_nhap_lbl.Location = new System.Drawing.Point(14, 46);
            this.maDeThi_nhap_lbl.Name = "maDeThi_nhap_lbl";
            this.maDeThi_nhap_lbl.Size = new System.Drawing.Size(35, 17);
            this.maDeThi_nhap_lbl.TabIndex = 40;
            this.maDeThi_nhap_lbl.Text = "___";
            // 
            // monThi_nhap_lbl
            // 
            this.monThi_nhap_lbl.AutoSize = true;
            this.monThi_nhap_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monThi_nhap_lbl.Location = new System.Drawing.Point(14, 101);
            this.monThi_nhap_lbl.Name = "monThi_nhap_lbl";
            this.monThi_nhap_lbl.Size = new System.Drawing.Size(35, 17);
            this.monThi_nhap_lbl.TabIndex = 41;
            this.monThi_nhap_lbl.Text = "___";
            // 
            // kyThi_nhap_lbl
            // 
            this.kyThi_nhap_lbl.AutoSize = true;
            this.kyThi_nhap_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kyThi_nhap_lbl.Location = new System.Drawing.Point(14, 160);
            this.kyThi_nhap_lbl.Name = "kyThi_nhap_lbl";
            this.kyThi_nhap_lbl.Size = new System.Drawing.Size(35, 17);
            this.kyThi_nhap_lbl.TabIndex = 42;
            this.kyThi_nhap_lbl.Text = "___";
            // 
            // GiaoVien_ThongKe_DiemThi_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 485);
            this.Controls.Add(this.kyThi_nhap_lbl);
            this.Controls.Add(this.monThi_nhap_lbl);
            this.Controls.Add(this.maDeThi_nhap_lbl);
            this.Controls.Add(this.kyThi_lbl);
            this.Controls.Add(this.monThi_lbl);
            this.Controls.Add(this.maDeThi_lbl);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.diemThi_dataGridView);
            this.Name = "GiaoVien_ThongKe_DiemThi_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê điểm thi";
            ((System.ComponentModel.ISupportInitialize)(this.diemThi_dataGridView)).EndInit();
            this.flter_grb.ResumeLayout(false);
            this.flter_grb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lop_lbl;
        private System.Windows.Forms.TextBox lop_txt;
        public System.Windows.Forms.DataGridView diemThi_dataGridView;
        private System.Windows.Forms.GroupBox flter_grb;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSinhVien_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSinhVien_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn lop_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemThi_col;
        private System.Windows.Forms.TextBox maSinhVien_txt;
        private System.Windows.Forms.Label maSinhVien_lbl;
        private System.Windows.Forms.Label maDeThi_lbl;
        private System.Windows.Forms.Label monThi_lbl;
        private System.Windows.Forms.Label kyThi_lbl;
        private System.Windows.Forms.Label maDeThi_nhap_lbl;
        private System.Windows.Forms.Label monThi_nhap_lbl;
        private System.Windows.Forms.Label kyThi_nhap_lbl;
    }
}