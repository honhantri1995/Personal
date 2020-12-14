namespace HeThongThiTracNghiem
{
    partial class GiaoVien_QuanLyCauHoi_Frm
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
            this.cauHoi_rtxb = new System.Windows.Forms.RichTextBox();
            this.thuCauHoi_lbl = new System.Windows.Forms.Label();
            this.cauHoiSo_txt = new System.Windows.Forms.TextBox();
            this.A_ckb = new System.Windows.Forms.CheckBox();
            this.B_ckb = new System.Windows.Forms.CheckBox();
            this.C_ckb = new System.Windows.Forms.CheckBox();
            this.D_ckb = new System.Windows.Forms.CheckBox();
            this.E_ckb = new System.Windows.Forms.CheckBox();
            this.dapAn_grb = new System.Windows.Forms.GroupBox();
            this.themCauHoi_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.suaCauHoi_btn = new System.Windows.Forms.Button();
            this.xoaCauHoi_btn = new System.Windows.Forms.Button();
            this.hoanThanh_btn = new System.Windows.Forms.Button();
            this.dapAn_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // cauHoi_rtxb
            // 
            this.cauHoi_rtxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cauHoi_rtxb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cauHoi_rtxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cauHoi_rtxb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cauHoi_rtxb.Location = new System.Drawing.Point(22, 52);
            this.cauHoi_rtxb.Margin = new System.Windows.Forms.Padding(10);
            this.cauHoi_rtxb.Name = "cauHoi_rtxb";
            this.cauHoi_rtxb.Size = new System.Drawing.Size(629, 398);
            this.cauHoi_rtxb.TabIndex = 1;
            this.cauHoi_rtxb.Text = "\"Nhập câu hỏi ở đây\"";
            // 
            // thuCauHoi_lbl
            // 
            this.thuCauHoi_lbl.AutoSize = true;
            this.thuCauHoi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.thuCauHoi_lbl.Location = new System.Drawing.Point(19, 15);
            this.thuCauHoi_lbl.Name = "thuCauHoi_lbl";
            this.thuCauHoi_lbl.Size = new System.Drawing.Size(74, 16);
            this.thuCauHoi_lbl.TabIndex = 3;
            this.thuCauHoi_lbl.Text = "Câu hỏi số:";
            // 
            // cauHoiSo_txt
            // 
            this.cauHoiSo_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cauHoiSo_txt.Location = new System.Drawing.Point(99, 12);
            this.cauHoiSo_txt.MaxLength = 10;
            this.cauHoiSo_txt.Name = "cauHoiSo_txt";
            this.cauHoiSo_txt.Size = new System.Drawing.Size(75, 21);
            this.cauHoiSo_txt.TabIndex = 4;
            this.cauHoiSo_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CauHoiSo_txt_KeyPress);
            // 
            // A_ckb
            // 
            this.A_ckb.AutoSize = true;
            this.A_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.A_ckb.Location = new System.Drawing.Point(27, 24);
            this.A_ckb.Name = "A_ckb";
            this.A_ckb.Size = new System.Drawing.Size(36, 20);
            this.A_ckb.TabIndex = 5;
            this.A_ckb.Text = "A";
            this.A_ckb.UseVisualStyleBackColor = true;
            // 
            // B_ckb
            // 
            this.B_ckb.AutoSize = true;
            this.B_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.B_ckb.Location = new System.Drawing.Point(27, 56);
            this.B_ckb.Name = "B_ckb";
            this.B_ckb.Size = new System.Drawing.Size(36, 20);
            this.B_ckb.TabIndex = 6;
            this.B_ckb.Text = "B";
            this.B_ckb.UseVisualStyleBackColor = true;
            // 
            // C_ckb
            // 
            this.C_ckb.AutoSize = true;
            this.C_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.C_ckb.Location = new System.Drawing.Point(27, 88);
            this.C_ckb.Name = "C_ckb";
            this.C_ckb.Size = new System.Drawing.Size(36, 20);
            this.C_ckb.TabIndex = 7;
            this.C_ckb.Text = "C";
            this.C_ckb.UseVisualStyleBackColor = true;
            // 
            // D_ckb
            // 
            this.D_ckb.AutoSize = true;
            this.D_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.D_ckb.Location = new System.Drawing.Point(27, 120);
            this.D_ckb.Name = "D_ckb";
            this.D_ckb.Size = new System.Drawing.Size(37, 20);
            this.D_ckb.TabIndex = 8;
            this.D_ckb.Text = "D";
            this.D_ckb.UseVisualStyleBackColor = true;
            // 
            // E_ckb
            // 
            this.E_ckb.AutoSize = true;
            this.E_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.E_ckb.Location = new System.Drawing.Point(27, 153);
            this.E_ckb.Name = "E_ckb";
            this.E_ckb.Size = new System.Drawing.Size(36, 20);
            this.E_ckb.TabIndex = 9;
            this.E_ckb.Text = "E";
            this.E_ckb.UseVisualStyleBackColor = true;
            // 
            // dapAn_grb
            // 
            this.dapAn_grb.Controls.Add(this.B_ckb);
            this.dapAn_grb.Controls.Add(this.E_ckb);
            this.dapAn_grb.Controls.Add(this.A_ckb);
            this.dapAn_grb.Controls.Add(this.D_ckb);
            this.dapAn_grb.Controls.Add(this.C_ckb);
            this.dapAn_grb.Location = new System.Drawing.Point(676, 52);
            this.dapAn_grb.Name = "dapAn_grb";
            this.dapAn_grb.Size = new System.Drawing.Size(111, 209);
            this.dapAn_grb.TabIndex = 10;
            this.dapAn_grb.TabStop = false;
            this.dapAn_grb.Text = "Đáp án";
            // 
            // themCauHoi_btn
            // 
            this.themCauHoi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.themCauHoi_btn.Location = new System.Drawing.Point(581, 16);
            this.themCauHoi_btn.Name = "themCauHoi_btn";
            this.themCauHoi_btn.Size = new System.Drawing.Size(70, 23);
            this.themCauHoi_btn.TabIndex = 11;
            this.themCauHoi_btn.Text = "Thêm";
            this.themCauHoi_btn.UseVisualStyleBackColor = true;
            this.themCauHoi_btn.Click += new System.EventHandler(this.ThemCauHoi_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.next_btn.Location = new System.Drawing.Point(575, 473);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(76, 23);
            this.next_btn.TabIndex = 12;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.back_btn.Location = new System.Drawing.Point(477, 473);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(76, 23);
            this.back_btn.TabIndex = 13;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // suaCauHoi_btn
            // 
            this.suaCauHoi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.suaCauHoi_btn.Location = new System.Drawing.Point(506, 16);
            this.suaCauHoi_btn.Name = "suaCauHoi_btn";
            this.suaCauHoi_btn.Size = new System.Drawing.Size(69, 23);
            this.suaCauHoi_btn.TabIndex = 14;
            this.suaCauHoi_btn.Text = "Sửa";
            this.suaCauHoi_btn.UseVisualStyleBackColor = true;
            this.suaCauHoi_btn.Click += new System.EventHandler(this.SuaCauHoi_btn_Click);
            // 
            // xoaCauHoi_btn
            // 
            this.xoaCauHoi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.xoaCauHoi_btn.Location = new System.Drawing.Point(430, 16);
            this.xoaCauHoi_btn.Name = "xoaCauHoi_btn";
            this.xoaCauHoi_btn.Size = new System.Drawing.Size(70, 23);
            this.xoaCauHoi_btn.TabIndex = 15;
            this.xoaCauHoi_btn.Text = "Xóa";
            this.xoaCauHoi_btn.UseVisualStyleBackColor = true;
            this.xoaCauHoi_btn.Click += new System.EventHandler(this.XoaCauHoi_btn_Click);
            // 
            // hoanThanh_btn
            // 
            this.hoanThanh_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.hoanThanh_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.hoanThanh_btn.Location = new System.Drawing.Point(22, 468);
            this.hoanThanh_btn.Name = "hoanThanh_btn";
            this.hoanThanh_btn.Size = new System.Drawing.Size(109, 33);
            this.hoanThanh_btn.TabIndex = 16;
            this.hoanThanh_btn.Text = "Hoàn thành";
            this.hoanThanh_btn.UseVisualStyleBackColor = false;
            this.hoanThanh_btn.Click += new System.EventHandler(this.HoanThanh_btn_Click);
            // 
            // GiaoVien_QuanLyCauHoi_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(811, 518);
            this.Controls.Add(this.hoanThanh_btn);
            this.Controls.Add(this.xoaCauHoi_btn);
            this.Controls.Add(this.suaCauHoi_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.themCauHoi_btn);
            this.Controls.Add(this.dapAn_grb);
            this.Controls.Add(this.cauHoiSo_txt);
            this.Controls.Add(this.thuCauHoi_lbl);
            this.Controls.Add(this.cauHoi_rtxb);
            this.Name = "GiaoVien_QuanLyCauHoi_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý câu hỏi";
            this.dapAn_grb.ResumeLayout(false);
            this.dapAn_grb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox cauHoi_rtxb;
        private System.Windows.Forms.Label thuCauHoi_lbl;
        private System.Windows.Forms.TextBox cauHoiSo_txt;
        private System.Windows.Forms.CheckBox A_ckb;
        private System.Windows.Forms.CheckBox B_ckb;
        private System.Windows.Forms.CheckBox C_ckb;
        private System.Windows.Forms.CheckBox D_ckb;
        private System.Windows.Forms.CheckBox E_ckb;
        private System.Windows.Forms.GroupBox dapAn_grb;
        private System.Windows.Forms.Button themCauHoi_btn;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button suaCauHoi_btn;
        private System.Windows.Forms.Button xoaCauHoi_btn;
        private System.Windows.Forms.Button hoanThanh_btn;
    }
}

