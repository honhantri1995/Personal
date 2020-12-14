namespace HeThongThiTracNghiem
{
    partial class SinhVien_ChonDeThi_Frm
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
            this.maDeThi_lbl = new System.Windows.Forms.Label();
            this.chonDeThi_btn = new System.Windows.Forms.Button();
            this.maDeThi_cbb = new System.Windows.Forms.ComboBox();
            this.tinhTrang_lbl = new System.Windows.Forms.Label();
            this.tinhTrang_cbb = new System.Windows.Forms.ComboBox();
            this.ngayTao_lbl = new System.Windows.Forms.Label();
            this.ngayTao_dtp = new System.Windows.Forms.DateTimePicker();
            this.kyThi_txt = new System.Windows.Forms.TextBox();
            this.kyThi_lbl = new System.Windows.Forms.Label();
            this.monThi_txt = new System.Windows.Forms.TextBox();
            this.monThi_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maDeThi_lbl
            // 
            this.maDeThi_lbl.AutoSize = true;
            this.maDeThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.maDeThi_lbl.Location = new System.Drawing.Point(23, 38);
            this.maDeThi_lbl.Name = "maDeThi_lbl";
            this.maDeThi_lbl.Size = new System.Drawing.Size(65, 16);
            this.maDeThi_lbl.TabIndex = 3;
            this.maDeThi_lbl.Text = "Mã đề thi:";
            // 
            // chonDeThi_btn
            // 
            this.chonDeThi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chonDeThi_btn.Location = new System.Drawing.Point(245, 244);
            this.chonDeThi_btn.Name = "chonDeThi_btn";
            this.chonDeThi_btn.Size = new System.Drawing.Size(70, 31);
            this.chonDeThi_btn.TabIndex = 11;
            this.chonDeThi_btn.Text = "Chọn";
            this.chonDeThi_btn.UseVisualStyleBackColor = true;
            this.chonDeThi_btn.Click += new System.EventHandler(this.ChonDeThi_btn_Click);
            // 
            // maDeThi_cbb
            // 
            this.maDeThi_cbb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.maDeThi_cbb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.maDeThi_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.maDeThi_cbb.FormattingEnabled = true;
            this.maDeThi_cbb.Location = new System.Drawing.Point(106, 34);
            this.maDeThi_cbb.Name = "maDeThi_cbb";
            this.maDeThi_cbb.Size = new System.Drawing.Size(209, 25);
            this.maDeThi_cbb.TabIndex = 12;
            this.maDeThi_cbb.SelectedIndexChanged += new System.EventHandler(this.MaDeThi_cbb_SelectedIndexChanged);
            // 
            // tinhTrang_lbl
            // 
            this.tinhTrang_lbl.AutoSize = true;
            this.tinhTrang_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tinhTrang_lbl.Location = new System.Drawing.Point(23, 155);
            this.tinhTrang_lbl.Name = "tinhTrang_lbl";
            this.tinhTrang_lbl.Size = new System.Drawing.Size(67, 16);
            this.tinhTrang_lbl.TabIndex = 46;
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
            this.tinhTrang_cbb.Location = new System.Drawing.Point(106, 151);
            this.tinhTrang_cbb.Name = "tinhTrang_cbb";
            this.tinhTrang_cbb.Size = new System.Drawing.Size(209, 25);
            this.tinhTrang_cbb.TabIndex = 45;
            // 
            // ngayTao_lbl
            // 
            this.ngayTao_lbl.AutoSize = true;
            this.ngayTao_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ngayTao_lbl.Location = new System.Drawing.Point(23, 199);
            this.ngayTao_lbl.Name = "ngayTao_lbl";
            this.ngayTao_lbl.Size = new System.Drawing.Size(63, 16);
            this.ngayTao_lbl.TabIndex = 44;
            this.ngayTao_lbl.Text = "Ngày tạo";
            // 
            // ngayTao_dtp
            // 
            this.ngayTao_dtp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.ngayTao_dtp.CustomFormat = "dd-MM-yyyy";
            this.ngayTao_dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ngayTao_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayTao_dtp.Location = new System.Drawing.Point(106, 194);
            this.ngayTao_dtp.Margin = new System.Windows.Forms.Padding(2);
            this.ngayTao_dtp.Name = "ngayTao_dtp";
            this.ngayTao_dtp.Size = new System.Drawing.Size(209, 24);
            this.ngayTao_dtp.TabIndex = 43;
            // 
            // kyThi_txt
            // 
            this.kyThi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.kyThi_txt.Location = new System.Drawing.Point(106, 111);
            this.kyThi_txt.Name = "kyThi_txt";
            this.kyThi_txt.Size = new System.Drawing.Size(209, 23);
            this.kyThi_txt.TabIndex = 42;
            // 
            // kyThi_lbl
            // 
            this.kyThi_lbl.AutoSize = true;
            this.kyThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.kyThi_lbl.Location = new System.Drawing.Point(23, 114);
            this.kyThi_lbl.Name = "kyThi_lbl";
            this.kyThi_lbl.Size = new System.Drawing.Size(39, 16);
            this.kyThi_lbl.TabIndex = 41;
            this.kyThi_lbl.Text = "Kỳ thi";
            // 
            // monThi_txt
            // 
            this.monThi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.monThi_txt.Location = new System.Drawing.Point(106, 72);
            this.monThi_txt.Name = "monThi_txt";
            this.monThi_txt.Size = new System.Drawing.Size(209, 23);
            this.monThi_txt.TabIndex = 40;
            // 
            // monThi_lbl
            // 
            this.monThi_lbl.AutoSize = true;
            this.monThi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.monThi_lbl.Location = new System.Drawing.Point(23, 75);
            this.monThi_lbl.Name = "monThi_lbl";
            this.monThi_lbl.Size = new System.Drawing.Size(50, 16);
            this.monThi_lbl.TabIndex = 39;
            this.monThi_lbl.Text = "Môn thi";
            // 
            // SinhVien_ChonDeThi_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(341, 287);
            this.Controls.Add(this.tinhTrang_lbl);
            this.Controls.Add(this.tinhTrang_cbb);
            this.Controls.Add(this.ngayTao_lbl);
            this.Controls.Add(this.ngayTao_dtp);
            this.Controls.Add(this.kyThi_txt);
            this.Controls.Add(this.kyThi_lbl);
            this.Controls.Add(this.monThi_txt);
            this.Controls.Add(this.monThi_lbl);
            this.Controls.Add(this.maDeThi_cbb);
            this.Controls.Add(this.chonDeThi_btn);
            this.Controls.Add(this.maDeThi_lbl);
            this.Name = "SinhVien_ChonDeThi_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn đề thi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label maDeThi_lbl;
        private System.Windows.Forms.Button chonDeThi_btn;
        private System.Windows.Forms.ComboBox maDeThi_cbb;
        private System.Windows.Forms.Label tinhTrang_lbl;
        private System.Windows.Forms.ComboBox tinhTrang_cbb;
        private System.Windows.Forms.Label ngayTao_lbl;
        private System.Windows.Forms.DateTimePicker ngayTao_dtp;
        private System.Windows.Forms.TextBox kyThi_txt;
        private System.Windows.Forms.Label kyThi_lbl;
        private System.Windows.Forms.TextBox monThi_txt;
        private System.Windows.Forms.Label monThi_lbl;
    }
}

