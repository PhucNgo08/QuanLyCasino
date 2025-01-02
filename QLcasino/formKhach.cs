using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;   

namespace QLcasino
{
    public partial class formKhach : Form
    {
        public formKhach()
        {
            InitializeComponent();
        }
        private void Fill_dgv_DSSV()
        {
           
        }

        // Sự kiện khi form load


        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void formKhach_Load(object sender, EventArgs e)
        {
            // Gọi hàm để điền dữ liệu vào DataGridView khi form được tải
            Fill_dgv_DSSV();
        }
    }
}
