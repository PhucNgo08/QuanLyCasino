namespace QLcasino
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.bnt_DN = new System.Windows.Forms.Button();
            this.lbl_MK = new System.Windows.Forms.Label();
            this.lbl_TTK = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_TTK = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnt_DN
            // 
            this.bnt_DN.Location = new System.Drawing.Point(239, 193);
            this.bnt_DN.Name = "bnt_DN";
            this.bnt_DN.Size = new System.Drawing.Size(98, 23);
            this.bnt_DN.TabIndex = 15;
            this.bnt_DN.Text = "Đăng Nhập";
            this.bnt_DN.UseVisualStyleBackColor = true;
            this.bnt_DN.Click += new System.EventHandler(this.bnt_DN_Click);
            // 
            // lbl_MK
            // 
            this.lbl_MK.AutoSize = true;
            this.lbl_MK.Location = new System.Drawing.Point(67, 147);
            this.lbl_MK.Name = "lbl_MK";
            this.lbl_MK.Size = new System.Drawing.Size(56, 13);
            this.lbl_MK.TabIndex = 14;
            this.lbl_MK.Text = "Mật Khẩu ";
            // 
            // lbl_TTK
            // 
            this.lbl_TTK.AutoSize = true;
            this.lbl_TTK.Location = new System.Drawing.Point(67, 89);
            this.lbl_TTK.Name = "lbl_TTK";
            this.lbl_TTK.Size = new System.Drawing.Size(81, 13);
            this.lbl_TTK.TabIndex = 13;
            this.lbl_TTK.Text = "Tên Tài Khoản ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(95, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = " カジノ(Casino) F88";
            // 
            // txt_MK
            // 
            this.txt_MK.Location = new System.Drawing.Point(182, 144);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.PasswordChar = '*';
            this.txt_MK.Size = new System.Drawing.Size(155, 20);
            this.txt_MK.TabIndex = 11;
            // 
            // txt_TTK
            // 
            this.txt_TTK.Location = new System.Drawing.Point(182, 82);
            this.txt_TTK.Name = "txt_TTK";
            this.txt_TTK.Size = new System.Drawing.Size(155, 20);
            this.txt_TTK.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bnt_DN);
            this.panel1.Controls.Add(this.txt_TTK);
            this.panel1.Controls.Add(this.lbl_MK);
            this.panel1.Controls.Add(this.txt_MK);
            this.panel1.Controls.Add(this.lbl_TTK);
            this.panel1.Location = new System.Drawing.Point(66, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 232);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 65);
            this.panel2.TabIndex = 16;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLcasino.Properties.Resources._20170413125239_1304chautinhtri01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "frm_Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Login_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnt_DN;
        private System.Windows.Forms.Label lbl_MK;
        private System.Windows.Forms.Label lbl_TTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.TextBox txt_TTK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}