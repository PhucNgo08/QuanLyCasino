using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLcasino
{


    public partial class formTQL : Form
    {
        public formTQL()
        {
            InitializeComponent();
        }
    

        private void bntKH_Click(object sender, EventArgs e)
        {
            formKhach formKhach = new formKhach();  
            formKhach.ShowDialog();
            this.Close();
        }

        private void bntNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            formDK formDK = new formDK();
           formDK.ShowDialog();
     
        }

        private void formTQL_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void bntKM_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một instance của formKhuyenMai
                formKhuyenMai khuyenMaiForm = new formKhuyenMai();

                // Hiển thị form theo cách modal (chặn các tương tác khác)
                khuyenMaiForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Khuyến Mãi: {ex.Message}", "Lỗi");
            }


        }
        private formTQL formTQLInstance = null;

        // Phương thức kiểm tra và tạo instance nếu cần
        private void ShowFormTQL()
        {
            if (formTQLInstance == null || formTQLInstance.IsDisposed)
            {
                formTQLInstance = new formTQL(); // Tạo form nếu chưa tồn tại hoặc đã bị đóng
            }
            formTQLInstance.Show(); // Hiển thị form
            formTQLInstance.BringToFront(); // Đưa form lên trước nếu đã tồn tại
        }

    }
}
