using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLcasino
{
    public partial class formKhuyenMai : Form
    {
        private static formTQL formTQLInstance;
        private string connectionString = "YourConnectionStringHere"; // Định nghĩa chuỗi kết nối đến cơ sở dữ liệu của bạn ở đây
        public formKhuyenMai()
        {
            InitializeComponent();

        }
        private bool IsValidDate(string dateString)
        {
            DateTime tempDate;
            return DateTime.TryParse(dateString, out tempDate);
        }
        private void btn_them_Click(object sender, EventArgs e)
 
        {
            // Kiểm tra dữ liệu đầu vào
            string tenNguoiChoi = txt_tennc.Text;
            string phanTramKhuyenMaiText = txt_ptkm.Text; // Lấy giá trị phần trăm khuyến mãi

            string maNguoiChoi = txt_mnc.Text;
            string tenKhuyenMai = txt_makm.Text;
            string ngayBatDau = dtp_nbd.Text;
            string ngayKetThuc = dtb_nkt.Text;
           
            if (string.IsNullOrEmpty(tenNguoiChoi) || string.IsNullOrEmpty(maNguoiChoi) ||
                string.IsNullOrEmpty(tenKhuyenMai) || string.IsNullOrEmpty(ngayBatDau) || string.IsNullOrEmpty(ngayKetThuc) ||
                string.IsNullOrEmpty(phanTramKhuyenMaiText)) // Kiểm tra phần trăm khuyến mãi
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (!IsValidDate(ngayBatDau) || !IsValidDate(ngayKetThuc))
            {
                MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.");
                return;
            }

            // Kiểm tra phần trăm khuyến mãi có phải là số hợp lệ hay không
            decimal phanTramKhuyenMai;
            if (!decimal.TryParse(phanTramKhuyenMaiText, out phanTramKhuyenMai) || phanTramKhuyenMai <= 0)
            {
                MessageBox.Show("Phần trăm khuyến mãi không hợp lệ.");
                return;
            }

            // Thêm dữ liệu vào DataGridView
            dgvkm.Rows.Add(tenNguoiChoi, maNguoiChoi, tenKhuyenMai, ngayBatDau, ngayKetThuc, phanTramKhuyenMai);
        }

        private void LoadKhuyenMai()
        {
            string query = "SELECT MaKM, TenKM, PhanTramKM, NgayBatDau, NgayKetThuc FROM KhuyenMai";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dt);
                    dgvkm.Rows.Clear();  // Xóa dữ liệu cũ trong DataGridView

                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dgvkm.Rows.Add();
                        dgvkm.Rows[rowIndex].Cells[0].Value = row["MaKM"];
                        dgvkm.Rows[rowIndex].Cells[1].Value = row["TenKM"];
                        dgvkm.Rows[rowIndex].Cells[2].Value = row["PhanTramKM"];
                        dgvkm.Rows[rowIndex].Cells[3].Value = row["NgayBatDau"];
                        dgvkm.Rows[rowIndex].Cells[4].Value = row["NgayKetThuc"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu khuyến mãi: " + ex.Message);
                }
            }
        }

        private void AddKhuyenMai()
        {
            string tenKM = txt_makm.Text;
            decimal phanTramKM = decimal.Parse(txt_ptkm.Text);
            DateTime ngayBatDau = dtp_nbd.Value;
            DateTime ngayKetThuc = dtb_nkt.Value;

            string query = "INSERT INTO KhuyenMai (TenKM, PhanTramKM, NgayBatDau, NgayKetThuc) VALUES (@TenKM, @PhanTramKM, @NgayBatDau, @NgayKetThuc)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKM", tenKM);
                cmd.Parameters.AddWithValue("@PhanTramKM", phanTramKM);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Khuyến mãi đã được thêm.");
                LoadKhuyenMai();  // Load lại dữ liệu sau khi thêm
            }
        }
        private void UpdateKhuyenMai(int maKM)
        {
            string tenKM = txt_makm.Text;
            decimal phanTramKM = decimal.Parse(txt_ptkm.Text);
            DateTime ngayBatDau = dtp_nbd.Value;
            DateTime ngayKetThuc = dtb_nkt.Value;

            string query = "UPDATE KhuyenMai SET TenKM = @TenKM, PhanTramKM = @PhanTramKM, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc WHERE MaKM = @MaKM";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKM", tenKM);
                cmd.Parameters.AddWithValue("@PhanTramKM", phanTramKM);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                cmd.Parameters.AddWithValue("@MaKM", maKM);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Khuyến mãi đã được cập nhật.");
                LoadKhuyenMai();  // Load lại dữ liệu sau khi sửa
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Xóa dòng đã chọn trong DataGridView
            if (dgvkm.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvkm.Rows.RemoveAt(dgvkm.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Sửa mục đã chọn trong DataGridView
            if (dgvkm.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvkm.SelectedRows[0];

                string tenNguoiChoi = txt_tennc.Text;
                string maNguoiChoi = txt_mnc.Text;
                string tenKhuyenMai = txt_makm.Text;
                string ngayBatDau = dtp_nbd.Text;
                string ngayKetThuc = dtb_nkt.Text;

                if (string.IsNullOrEmpty(tenNguoiChoi) || string.IsNullOrEmpty(maNguoiChoi) ||
                    string.IsNullOrEmpty(tenKhuyenMai) || string.IsNullOrEmpty(ngayBatDau) || string.IsNullOrEmpty(ngayKetThuc))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                if (!IsValidDate(ngayBatDau) || !IsValidDate(ngayKetThuc))
                {
                    MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.");
                    return;
                }

                // Cập nhật thông tin dòng đã chọn
                row.Cells[0].Value = tenNguoiChoi;
                row.Cells[1].Value = maNguoiChoi;
                row.Cells[2].Value = tenKhuyenMai;
                row.Cells[3].Value = ngayBatDau;
                row.Cells[4].Value = ngayKetThuc;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.");
            }
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            // Ẩn formKhuyenMai hiện tại
            this.Hide();

            // Kiểm tra xem formTQL đã được khởi tạo chưa
            if (formTQLInstance == null)
            {
                formTQLInstance = new formTQL(); // Khởi tạo instance nếu chưa có
            }

            // Hiển thị formTQL
            formTQLInstance.Show();
        }
        private void AddformKhuyenMai()
        {
            string tenKM = txt_makm.Text;
            decimal phanTramKM = decimal.Parse(txt_ptkm.Text);

            // Lấy giá trị từ các TextBox và kiểm tra nếu là ngày hợp lệ
            string ngayBatDauStr = dtp_nbd.Text;
            string ngayKetThucStr = dtb_nkt. Text;

            DateTime ngayBatDau;
            DateTime ngayKetThuc;

            if (!DateTime.TryParse(ngayBatDauStr, out ngayBatDau))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ.");
                return;
            }

            if (!DateTime.TryParse(ngayKetThucStr, out ngayKetThuc))
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ.");
                return;
            }

            string query = "INSERT INTO KhuyenMai (TenKM, PhanTramKM, NgayBatDau, NgayKetThuc) VALUES (@TenKM, @PhanTramKM, @NgayBatDau, @NgayKetThuc)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKM", tenKM);
                cmd.Parameters.AddWithValue("@PhanTramKM", phanTramKM);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Khuyến mãi đã được thêm.");
                    LoadKhuyenMai();  // Load lại dữ liệu sau khi thêm
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khuyến mãi: " + ex.Message);
                }
            }
        }


        private void dgvkm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_them_Click_1(object sender, EventArgs e)
        {

        }
    }

}
