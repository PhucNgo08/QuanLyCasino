using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.Remoting.Contexts;

namespace QLcasino
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        private void bnt_DN_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string tenTaiKhoan = txt_TTK.Text.Trim();
            string matKhau = txt_MK.Text.Trim();

            using (var db = new QLcasinoEntiy())
            {
                var taiKhoanTonTai = db.TaiKhoanNV
                    .FirstOrDefault(tk => tk.TenTaiKhoan == tenTaiKhoan);

                if (taiKhoanTonTai != null)
                {
                    // So sánh mật khẩu dạng chuỗi
                    if (taiKhoanTonTai.MatKhau == matKhau)
                    {
                        // Kiểm tra loại tài khoản
                        if (taiKhoanTonTai.LoaiTaiKhoan == "Admin")
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            formTQL formTQL = new formTQL();
                            formTQL.FormClosed += (s, args) => this.Close();
                            formTQL.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
