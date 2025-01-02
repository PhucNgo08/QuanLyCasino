namespace QLcasino
{
    partial class formKhach
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
            this.dgvKhachhang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnt_DK = new System.Windows.Forms.Button();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_TK = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.txt_Hoten = new System.Windows.Forms.TextBox();
            this.lbl_MK = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_SDT = new System.Windows.Forms.Label();
            this.lbl_Hoten = new System.Windows.Forms.Label();
            this.lbl_TTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhachhang
            // 
            this.dgvKhachhang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvKhachhang.Location = new System.Drawing.Point(11, 231);
            this.dgvKhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKhachhang.Name = "dgvKhachhang";
            this.dgvKhachhang.RowHeadersWidth = 51;
            this.dgvKhachhang.RowTemplate.Height = 24;
            this.dgvKhachhang.Size = new System.Drawing.Size(923, 226);
            this.dgvKhachhang.TabIndex = 1;
            this.dgvKhachhang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachhang_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "MaKhachhang";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "HoTen";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "SoCMND_CCCD";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "NgaySinh";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DiaChi";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "QuocTich";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "TrangThaiThanhVien";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = " MaDV";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // bnt_DK
            // 
            this.bnt_DK.Location = new System.Drawing.Point(349, 188);
            this.bnt_DK.Name = "bnt_DK";
            this.bnt_DK.Size = new System.Drawing.Size(75, 23);
            this.bnt_DK.TabIndex = 36;
            this.bnt_DK.Text = "Đăng Kí";
            this.bnt_DK.UseVisualStyleBackColor = true;
            // 
            // txt_MK
            // 
            this.txt_MK.Location = new System.Drawing.Point(105, 188);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.Size = new System.Drawing.Size(200, 20);
            this.txt_MK.TabIndex = 35;
            // 
            // txt_TK
            // 
            this.txt_TK.Location = new System.Drawing.Point(105, 141);
            this.txt_TK.Name = "txt_TK";
            this.txt_TK.Size = new System.Drawing.Size(200, 20);
            this.txt_TK.TabIndex = 34;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(105, 92);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(200, 20);
            this.txt_Email.TabIndex = 33;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(105, 46);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(200, 20);
            this.txt_SDT.TabIndex = 32;
            // 
            // txt_Hoten
            // 
            this.txt_Hoten.Location = new System.Drawing.Point(105, 12);
            this.txt_Hoten.Name = "txt_Hoten";
            this.txt_Hoten.Size = new System.Drawing.Size(200, 20);
            this.txt_Hoten.TabIndex = 31;
            // 
            // lbl_MK
            // 
            this.lbl_MK.AutoSize = true;
            this.lbl_MK.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_MK.Location = new System.Drawing.Point(11, 188);
            this.lbl_MK.Name = "lbl_MK";
            this.lbl_MK.Size = new System.Drawing.Size(53, 13);
            this.lbl_MK.TabIndex = 30;
            this.lbl_MK.Text = "Mật Khẩu";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_email.Location = new System.Drawing.Point(11, 95);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(32, 13);
            this.lbl_email.TabIndex = 29;
            this.lbl_email.Text = "Email";
            // 
            // lbl_SDT
            // 
            this.lbl_SDT.AutoSize = true;
            this.lbl_SDT.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_SDT.Location = new System.Drawing.Point(11, 53);
            this.lbl_SDT.Name = "lbl_SDT";
            this.lbl_SDT.Size = new System.Drawing.Size(75, 13);
            this.lbl_SDT.TabIndex = 28;
            this.lbl_SDT.Text = "Số Điện Thoại";
            // 
            // lbl_Hoten
            // 
            this.lbl_Hoten.AutoSize = true;
            this.lbl_Hoten.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_Hoten.Location = new System.Drawing.Point(11, 19);
            this.lbl_Hoten.Name = "lbl_Hoten";
            this.lbl_Hoten.Size = new System.Drawing.Size(43, 13);
            this.lbl_Hoten.TabIndex = 27;
            this.lbl_Hoten.Text = "Họ Tên";
            // 
            // lbl_TTK
            // 
            this.lbl_TTK.AutoSize = true;
            this.lbl_TTK.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_TTK.Location = new System.Drawing.Point(11, 141);
            this.lbl_TTK.Name = "lbl_TTK";
            this.lbl_TTK.Size = new System.Drawing.Size(78, 13);
            this.lbl_TTK.TabIndex = 26;
            this.lbl_TTK.Text = "Tên Tài Khoản";
            // 
            // formKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(945, 468);
            this.Controls.Add(this.bnt_DK);
            this.Controls.Add(this.txt_MK);
            this.Controls.Add(this.txt_TK);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.txt_Hoten);
            this.Controls.Add(this.lbl_MK);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_SDT);
            this.Controls.Add(this.lbl_Hoten);
            this.Controls.Add(this.lbl_TTK);
            this.Controls.Add(this.dgvKhachhang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formKhach";
            this.Text = "formKhach";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button bnt_DK;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.TextBox txt_TK;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.TextBox txt_Hoten;
        private System.Windows.Forms.Label lbl_MK;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_SDT;
        private System.Windows.Forms.Label lbl_Hoten;
        private System.Windows.Forms.Label lbl_TTK;
    }
}