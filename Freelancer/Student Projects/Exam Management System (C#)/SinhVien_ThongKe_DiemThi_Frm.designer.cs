namespace HeThongThiTracNghiem
{
    partial class SinhVien_ThongKe_DiemThi_Frm
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
            this.diemThi_dataGridView = new System.Windows.Forms.DataGridView();
            this.maDeThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kiThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            this.monThi_txt = new System.Windows.Forms.TextBox();
            this.monThi_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.diemThi_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
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
            this.maDeThi_col,
            this.monThi_col,
            this.kiThi_col,
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
            this.diemThi_dataGridView.Location = new System.Drawing.Point(164, 24);
            this.diemThi_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.diemThi_dataGridView.Name = "diemThi_dataGridView";
            this.diemThi_dataGridView.RowHeadersWidth = 51;
            this.diemThi_dataGridView.RowTemplate.Height = 24;
            this.diemThi_dataGridView.Size = new System.Drawing.Size(724, 450);
            this.diemThi_dataGridView.TabIndex = 23;
            // 
            // maDeThi_col
            // 
            this.maDeThi_col.HeaderText = "Mã đề thi";
            this.maDeThi_col.Name = "maDeThi_col";
            this.maDeThi_col.Width = 96;
            // 
            // monThi_col
            // 
            this.monThi_col.HeaderText = "Môn thi";
            this.monThi_col.Name = "monThi_col";
            this.monThi_col.Width = 82;
            // 
            // kiThi_col
            // 
            this.kiThi_col.HeaderText = "Kì thi";
            this.kiThi_col.Name = "kiThi_col";
            this.kiThi_col.Width = 66;
            // 
            // diemThi_col
            // 
            this.diemThi_col.HeaderText = "Điểm thi";
            this.diemThi_col.Name = "diemThi_col";
            this.diemThi_col.Width = 88;
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.monThi_txt);
            this.flter_grb.Controls.Add(this.monThi_lbl);
            this.flter_grb.Location = new System.Drawing.Point(12, 24);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 95);
            this.flter_grb.TabIndex = 33;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // monThi_txt
            // 
            this.monThi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.monThi_txt.Location = new System.Drawing.Point(11, 47);
            this.monThi_txt.Name = "monThi_txt";
            this.monThi_txt.Size = new System.Drawing.Size(125, 23);
            this.monThi_txt.TabIndex = 34;
            this.monThi_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimTheoMonThi_txt_KeyUp);
            // 
            // monThi_lbl
            // 
            this.monThi_lbl.AutoSize = true;
            this.monThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.monThi_lbl.Location = new System.Drawing.Point(8, 26);
            this.monThi_lbl.Name = "monThi_lbl";
            this.monThi_lbl.Size = new System.Drawing.Size(50, 16);
            this.monThi_lbl.TabIndex = 35;
            this.monThi_lbl.Text = "Môn thi";
            // 
            // SinhVien_ThongKe_DiemThi_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 485);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.diemThi_dataGridView);
            this.Name = "SinhVien_ThongKe_DiemThi_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê điểm thi";
            ((System.ComponentModel.ISupportInitialize)(this.diemThi_dataGridView)).EndInit();
            this.flter_grb.ResumeLayout(false);
            this.flter_grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView diemThi_dataGridView;
        private System.Windows.Forms.GroupBox flter_grb;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDeThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn monThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn kiThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemThi_col;
        private System.Windows.Forms.TextBox monThi_txt;
        private System.Windows.Forms.Label monThi_lbl;
    }
}