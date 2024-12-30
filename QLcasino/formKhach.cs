using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLcasino.QLcasinoEntities;

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
            // Khởi tạo Entity Framework context (QLcasinoEntities1)
            using (QLcasinoEntities2 db = new QLcasinoEntities2())
            {
                // Lấy danh sách khách hàng từ cơ sở dữ liệu
                var listKhachHang = db.Khachhang.ToList();

                // Xóa các dòng hiện có trong DataGridView
                dgvKhachhang.Rows.Clear();

                // Duyệt qua từng khách hàng và điền vào DataGridView
                foreach (var khachHang in listKhachHang)
                {
                    int i = dgvKhachhang.Rows.Add();
                    dgvKhachhang.Rows[i].Cells[0].Value = khachHang.MaKhachhang; // ID khách hàng
                    dgvKhachhang.Rows[i].Cells[1].Value = khachHang.HoTen; // Tên khách hàng\
                    dgvKhachhang.Rows[i].Cells[2].Value = khachHang.SoCMND_CCCD; // Số CMND/CCCD


                    dgvKhachhang.Rows[i].Cells[3].Value = khachHang.NgaySinh; // Ngày sinh
                    dgvKhachhang.Rows[i].Cells[4].Value = khachHang.DiaChi; // Địa chỉ
                    dgvKhachhang.Rows[i].Cells[5].Value = khachHang.QuocTich; // Quốc tịch
                    dgvKhachhang.Rows[i].Cells[6].Value = khachHang.TrangThaiThanhVien; // Trạng thái thành viên
                    dgvKhachhang.Rows[i].Cells[7].Value = khachHang.MaDV; // Mã dịch vụ

                }
            }
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
