namespace HeThongThiTracNghiem
{
    partial class GiaoVien_ThongKe_DeThi_Frm
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
            this.monThi_lbl = new System.Windows.Forms.Label();
            this.monThi_txt = new System.Windows.Forms.TextBox();
            this.deThi_dataGridView = new System.Windows.Forms.DataGridView();
            this.maDeThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyThi_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrang_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTao_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flter_grb = new System.Windows.Forms.GroupBox();
            this.tinhTrang_lbl = new System.Windows.Forms.Label();
            this.tinhTrang_cbb = new System.Windows.Forms.ComboBox();
            this.xemDiemThi_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deThi_dataGridView)).BeginInit();
            this.flter_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // monThi_lbl
            // 
            this.monThi_lbl.AutoSize = true;
            this.monThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.monThi_lbl.Location = new System.Drawing.Point(8, 29);
            this.monThi_lbl.Name = "monThi_lbl";
            this.monThi_lbl.Size = new System.Drawing.Size(50, 16);
            this.monThi_lbl.TabIndex = 22;
            this.monThi_lbl.Text = "Môn thi";
            // 
            // monThi_txt
            // 
            this.monThi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.monThi_txt.Location = new System.Drawing.Point(11, 50);
            this.monThi_txt.Name = "monThi_txt";
            this.monThi_txt.Size = new System.Drawing.Size(125, 23);
            this.monThi_txt.TabIndex = 1;
            this.monThi_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimTheoMonThi_txt_KeyUp);
            // 
            // deThi_dataGridView
            // 
            this.deThi_dataGridView.AllowUserToAddRows = false;
            this.deThi_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.deThi_dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.deThi_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.deThi_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deThi_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDeThi_col,
            this.monThi_col,
            this.kyThi_col,
            this.tinhTrang_col,
            this.ngayTao_col});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.deThi_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.deThi_dataGridView.GridColor = System.Drawing.Color.Snow;
            this.deThi_dataGridView.Location = new System.Drawing.Point(164, 24);
            this.deThi_dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.deThi_dataGridView.Name = "deThi_dataGridView";
            this.deThi_dataGridView.RowHeadersWidth = 51;
            this.deThi_dataGridView.RowTemplate.Height = 24;
            this.deThi_dataGridView.Size = new System.Drawing.Size(724, 450);
            this.deThi_dataGridView.TabIndex = 23;
            this.deThi_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeThi_dataGridView_CellClick);
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
            // kyThi_col
            // 
            this.kyThi_col.HeaderText = "Kỳ thi";
            this.kyThi_col.Name = "kyThi_col";
            this.kyThi_col.Width = 70;
            // 
            // tinhTrang_col
            // 
            this.tinhTrang_col.HeaderText = "Trạng thái";
            this.tinhTrang_col.Name = "tinhTrang_col";
            this.tinhTrang_col.Width = 103;
            // 
            // ngayTao_col
            // 
            this.ngayTao_col.HeaderText = "Ngày tạo";
            this.ngayTao_col.Name = "ngayTao_col";
            this.ngayTao_col.Width = 96;
            // 
            // flter_grb
            // 
            this.flter_grb.Controls.Add(this.tinhTrang_lbl);
            this.flter_grb.Controls.Add(this.monThi_txt);
            this.flter_grb.Controls.Add(this.tinhTrang_cbb);
            this.flter_grb.Controls.Add(this.monThi_lbl);
            this.flter_grb.Location = new System.Drawing.Point(12, 24);
            this.flter_grb.Name = "flter_grb";
            this.flter_grb.Size = new System.Drawing.Size(142, 149);
            this.flter_grb.TabIndex = 33;
            this.flter_grb.TabStop = false;
            this.flter_grb.Text = "Lọc";
            // 
            // tinhTrang_lbl
            // 
            this.tinhTrang_lbl.AutoSize = true;
            this.tinhTrang_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tinhTrang_lbl.Location = new System.Drawing.Point(8, 88);
            this.tinhTrang_lbl.Name = "tinhTrang_lbl";
            this.tinhTrang_lbl.Size = new System.Drawing.Size(67, 16);
            this.tinhTrang_lbl.TabIndex = 35;
            this.tinhTrang_lbl.Text = "Tình trạng";
            // 
            // tinhTrang_cbb
            // 
            this.tinhTrang_cbb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tinhTrang_cbb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tinhTrang_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tinhTrang_cbb.FormattingEnabled = true;
            this.tinhTrang_cbb.Items.AddRange(new object[] {
            "Tất cả",
            "Open",
            "Close"});
            this.tinhTrang_cbb.Location = new System.Drawing.Point(11, 110);
            this.tinhTrang_cbb.Name = "tinhTrang_cbb";
            this.tinhTrang_cbb.Size = new System.Drawing.Size(124, 25);
            this.tinhTrang_cbb.TabIndex = 34;
            this.tinhTrang_cbb.SelectedIndexChanged += new System.EventHandler(this.TinhTrang_cbb_SelectedIndexChanged);
            // 
            // xemDiemThi_btn
            // 
            this.xemDiemThi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.xemDiemThi_btn.Location = new System.Drawing.Point(13, 225);
            this.xemDiemThi_btn.Name = "xemDiemThi_btn";
            this.xemDiemThi_btn.Size = new System.Drawing.Size(141, 32);
            this.xemDiemThi_btn.TabIndex = 34;
            this.xemDiemThi_btn.Text = "Xem điểm thi";
            this.xemDiemThi_btn.UseVisualStyleBackColor = true;
            this.xemDiemThi_btn.Click += new System.EventHandler(this.XemDiemThi_btn_Click);
            // 
            // GiaoVien_ThongKe_DeThi_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 485);
            this.Controls.Add(this.xemDiemThi_btn);
            this.Controls.Add(this.flter_grb);
            this.Controls.Add(this.deThi_dataGridView);
            this.Name = "GiaoVien_ThongKe_DeThi_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê đề thi";
            ((System.ComponentModel.ISupportInitialize)(this.deThi_dataGridView)).EndInit();
            this.flter_grb.ResumeLayout(false);
            this.flter_grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label monThi_lbl;
        private System.Windows.Forms.TextBox monThi_txt;
        public System.Windows.Forms.DataGridView deThi_dataGridView;
        private System.Windows.Forms.GroupBox flter_grb;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDeThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn monThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyThi_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrang_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTao_col;
        private System.Windows.Forms.Label tinhTrang_lbl;
        private System.Windows.Forms.ComboBox tinhTrang_cbb;
        private System.Windows.Forms.Button xemDiemThi_btn;
    }
}