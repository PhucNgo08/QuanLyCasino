using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            {
                {
                    {
                        // Lấy thông tin từ giao diện
                        string tenTaiKhoan = txt_TTK.Text.Trim();
                        string matKhau = txt_MK.Text.Trim();

                        // Kiểm tra thông tin nhập
                        if (string.IsNullOrWhiteSpace(tenTaiKhoan) || string.IsNullOrWhiteSpace(matKhau))
                        {
                            MessageBox.Show("Tên tài khoản và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            // Sử dụng Entity Framework để truy vấn cơ sở dữ liệu
                            using (QLcasinoEntities2 db = new QLcasinoEntities2())
                            {
                                var taiKhoanTonTai = db.TaiKhoans
                                            .FirstOrDefault(tk => tk.TenTaiKhoan == tenTaiKhoan && tk.MatKhau == matKhau);


                                if (taiKhoanTonTai != null)
                                {
                                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Phân loại tài khoản
                                    if (taiKhoanTonTai.LoaiTaiKhoan == "Admin")
                                    {
                                        // Mở form quản lý (Admin)
                                        formTQL formQuanLy = new formTQL();
                                        formQuanLy.Show();
                                    }
                                    else
                                    {
                                        // Mở form khách (User)

                                    }

                                    // Ẩn form đăng nhập
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }
    }
}
