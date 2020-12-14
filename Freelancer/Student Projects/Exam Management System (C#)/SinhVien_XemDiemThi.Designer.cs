namespace HeThongThiTracNghiem
{
    partial class SinhVien_XemDiemThi
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cauDung_lbl = new System.Windows.Forms.Label();
            this.diemSo_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chúc mừng bạn đã hoàn thành bài thi!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(38, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điểm số của bạn là:";
            // 
            // cauDung_lbl
            // 
            this.cauDung_lbl.AutoSize = true;
            this.cauDung_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cauDung_lbl.Location = new System.Drawing.Point(38, 109);
            this.cauDung_lbl.Name = "cauDung_lbl";
            this.cauDung_lbl.Size = new System.Drawing.Size(32, 17);
            this.cauDung_lbl.TabIndex = 5;
            this.cauDung_lbl.Text = "___";
            // 
            // diemSo_lbl
            // 
            this.diemSo_lbl.AutoSize = true;
            this.diemSo_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diemSo_lbl.Location = new System.Drawing.Point(177, 67);
            this.diemSo_lbl.Name = "diemSo_lbl";
            this.diemSo_lbl.Size = new System.Drawing.Size(43, 24);
            this.diemSo_lbl.TabIndex = 7;
            this.diemSo_lbl.Text = "___";
            // 
            // SinhVien_XemDiemThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 160);
            this.Controls.Add(this.diemSo_lbl);
            this.Controls.Add(this.cauDung_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SinhVien_XemDiemThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem điểm thi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cauDung_lbl;
        private System.Windows.Forms.Label diemSo_lbl;
    }
}