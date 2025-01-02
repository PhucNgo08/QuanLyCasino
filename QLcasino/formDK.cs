using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace QLcasino
{
    public partial class formDK : Form
    {
        public string MaNguoiChoi { get; set; }
        public string MaKhuyenMai { get; set; }

        public formDK()
        {
            InitializeComponent();
        }




        // Sự kiện khi người dùng bấm nút Đăng Ký
        private void bnt_DK_Click(object sender, EventArgs e)

        {
            // Kiểm tra Họ Tên
            if (string.IsNullOrWhiteSpace(txt_Hoten.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Hoten.Focus();
                return;
            }

            // Kiểm tra Số Điện Thoại
            if (string.IsNullOrWhiteSpace(txt_SDT.Text) || !IsPhoneNumber(txt_SDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng Số Điện Thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_SDT.Focus();
                return;
            }

            // Kiểm tra Email
            string email = txt_Email.Text.Trim();  // Sửa lại từ txt_SDT.Text thành txt_Email.Text

            // Kiểm tra email có đúng định dạng và có đuôi @gmail.com không
            if (!KiemTraEmailGmail(email))
            {
                MessageBox.Show("Email phải có đuôi @gmail.com!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra Tên Tài Khoản
            if (string.IsNullOrWhiteSpace(txt_TK.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Tài Khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TK.Focus();
                return;
            }

            // Kiểm tra Mật Khẩu
            if (string.IsNullOrWhiteSpace(txt_MK.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật Khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_MK.Focus();
                return;
            }



            // Kiểm tra độ mạnh của mật khẩu
            if (!IsStrongPassword(txt_MK.Text))
            {
                MessageBox.Show("Mật khẩu không đủ mạnh! Vui lòng sử dụng ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MK.Focus();
                return;
            }

            // Nếu tất cả đều hợp lệ
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form đăng ký
        }
        private bool IsPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{9,11}$");
        }

        private bool KiemTraEmailGmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsStrongPassword(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        private void txt_MK_TextChanged(object sender, EventArgs e)
        {
            if (IsStrongPassword(txt_MK.Text))
            {
                lbl_MK.Text = "Mật khẩu mạnh.";
                lbl_MK.ForeColor = Color.Green;
            }
            else
            {
                lbl_MK.Text = "Mật khẩu chưa đủ mạnh.";
                lbl_MK.ForeColor = Color.Red;
            }
        }

        private string GetPasswordFeedback(string password)
        {
            List<string> feedback = new List<string>();

            if (password.Length < 8)
                feedback.Add("Ít nhất 8 ký tự.");
            if (!password.Any(char.IsUpper))
                feedback.Add("Ít nhất 1 chữ cái viết hoa.");
            if (!password.Any(char.IsLower))
                feedback.Add("Ít nhất 1 chữ cái viết thường.");
            if (!password.Any(char.IsDigit))
                feedback.Add("Ít nhất 1 số.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[@$!%*?&]"))
                feedback.Add("Ít nhất 1 ký tự đặc biệt (@, $, !, %, *, ?, &).");

            return string.Join("\n", feedback);
        }

        private void txt_SDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Hoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MK_TextChanged_1(object sender, EventArgs e)
        {

        }

        
        private void bntBack_Click(object sender, EventArgs e)
        {
            
        }

        private void formDK_FormClosing(object sender, FormClosingEventArgs e)
        {


            // Hiển thị form TQL
            Application.OpenForms["formTQL"].Show();
    
        }

        private void btn_lay_Click(object sender, EventArgs e)
        {
        {
            if (dgvNV.CurrentRow != null) // Kiểm tra xem có dòng nào được chọn không
            {
                try
                {
                    // Lấy dữ liệu từ các cột trong dòng được chọn
                    string maKhuyenMai = dgvNV.CurrentRow.Cells["MaKhuyenMai"].Value?.ToString();
                    string maNguoiChoi = dgvNV.CurrentRow.Cells["MaNguoiChoi"].Value?.ToString();

                    // Hiển thị giá trị hoặc sử dụng trong logic của bạn
                    MessageBox.Show($"Mã Khuyến Mãi: {maKhuyenMai}\nMã Người Chơi: {maNguoiChoi}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu từ DataGridView: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng.");
            }
        }

    }
}
}
