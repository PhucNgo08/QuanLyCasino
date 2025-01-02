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
        private QLcasinoEntiy dbContext = new QLcasinoEntiy(); // Thay tên context theo EF của bạn
        private formTQL formTQLInstance = null; // Đảm bảo instance của formTQL

        public formKhuyenMai()
        {
            InitializeComponent();
           
            LoadKhuyenMai();

        }

        private bool IsValidDate(string dateString)
        {
            DateTime tempDate;
            return DateTime.TryParse(dateString, out tempDate);
        }


            private bool ValidateInputs(out DateTime ngayBatDau, out DateTime ngayKetThuc, out decimal phanTramKM)
            {
                ngayBatDau = DateTime.MinValue;
                ngayKetThuc = DateTime.MinValue;
                phanTramKM = 0;

                if (string.IsNullOrEmpty(txt_tennc.Text) || string.IsNullOrEmpty(txt_mnc.Text) ||
                    string.IsNullOrEmpty(txt_makm.Text) || string.IsNullOrEmpty(txt_ptkm.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return false;
                }

                // Kiểm tra mã người chơi phải là số
                if (!int.TryParse(txt_mnc.Text, out _))
                {
                    MessageBox.Show("Mã người chơi phải là một số.");
                    return false;
                }

                if (!DateTime.TryParse(dtp_nbd.Text, out ngayBatDau) || !DateTime.TryParse(dtb_nkt.Text, out ngayKetThuc))
                {
                    MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.");
                    return false;
                }

                if (!decimal.TryParse(txt_ptkm.Text, out phanTramKM) || phanTramKM <= 0)
                {
                    MessageBox.Show("Phần trăm khuyến mãi không hợp lệ.");
                    return false;
                }

                return true;
            }

            private void ClearInputFields()
            {
                txt_tennc.Clear();
                txt_mnc.Clear();
                txt_makm.Clear();
                txt_ptkm.Clear();
                dtp_nbd.Value = DateTime.Now;
                dtb_nkt.Value = DateTime.Now;
            }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out DateTime ngayBatDau, out DateTime ngayKetThuc, out decimal phanTramKM))
                return;

            string tenNguoiChoi = txt_tennc.Text;
            string maNguoiChoi = txt_mnc.Text;
            string tenKhuyenMai = txt_makm.Text;
            string maKhuyenMai = txt_makm.Text;  // Mã khuyến mãi sau tên khuyến mãi

            // Thêm dữ liệu vào DataGridView (mã khuyến mãi sẽ được thêm vào sau tên khuyến mãi)
            dgvkm.Rows.Add(tenNguoiChoi, maNguoiChoi, tenKhuyenMai, maKhuyenMai, ngayBatDau, ngayKetThuc, phanTramKM);

            // Sau khi thêm, làm sạch các trường
            ClearInputFields();
        }


        private void LoadKhuyenMai()
        {
            try
            {
                // Lấy danh sách Khuyến Mãi từ cơ sở dữ liệu thông qua Entity Framework và sắp xếp theo thứ tự
                var khuyenMais = dbContext.KhuyenMai
                                           .Select(km => new
                                           {
                                               km.TenKM,           // Tên khuyến mãi
                                               km.MaKM,            // Mã khuyến mãi
                                               km.NgayBatDau,      // Ngày bắt đầu
                                               km.NgayKetThuc,     // Ngày kết thúc
                                               km.PhanTramKM,      // Phần trăm khuyến mãi
                                           })
                                           .OrderBy(km => km.TenKM)          // Sắp xếp theo tên khuyến mãi
                                           .ThenBy(km => km.MaKM)           // Sau đó sắp xếp theo mã khuyến mãi
                                           .ThenBy(km => km.NgayKetThuc)    // Sắp xếp theo ngày kết thúc
                                           .ThenBy(km => km.NgayBatDau)     // Sắp xếp theo ngày bắt đầu
                                           .ThenBy(km => km.PhanTramKM)     // Sắp xếp theo phần trăm khuyến mãi
                                           .ToList();

                dgvkm.Rows.Clear(); // Xóa dữ liệu cũ trong DataGridView

                // Duyệt qua danh sách và thêm dữ liệu vào DataGridView
                foreach (var km in khuyenMais)
                {
                    // Thêm một dòng mới vào DataGridView
                    int rowIndex = dgvkm.Rows.Add();
                    dgvkm.Rows[rowIndex].Cells[0].Value = ""; // Cột trống ở vị trí đầu tiên
                    dgvkm.Rows[rowIndex].Cells[1].Value = ""; // Cột trống ở vị trí 1

                    // Điền dữ liệu cho các cột còn lại
                    dgvkm.Rows[rowIndex].Cells[2].Value = km.TenKM;          // Tên khuyến mãi
                    dgvkm.Rows[rowIndex].Cells[3].Value = km.MaKM;           // Mã khuyến mãi
                    dgvkm.Rows[rowIndex].Cells[4].Value = km.NgayBatDau;     // Ngày bắt đầu
                    dgvkm.Rows[rowIndex].Cells[5].Value = km.NgayKetThuc;    // Ngày kết thúc
                    dgvkm.Rows[rowIndex].Cells[6].Value = km.PhanTramKM;     // Phần trăm khuyến mãi
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khuyến mãi: " + ex.Message);
            }
        }



        // Thêm khuyến mãi vào cơ sở dữ liệu
        private void AddKhuyenMai()
        {
            string tenKM = txt_makm.Text;  // Mã khuyến mãi
            decimal phanTramKM = decimal.Parse(txt_ptkm.Text); // Phần trăm khuyến mãi
            DateTime ngayBatDau = dtp_nbd.Value;  // Ngày bắt đầu
            DateTime ngayKetThuc = dtb_nkt.Value; // Ngày kết thúc

            // Kiểm tra mã khuyến mãi có tồn tại không
            // Cập nhật nếu MaKM là số
            if (int.TryParse(tenKM, out int maKM))
            {
                if (dbContext.KhuyenMai.Any(existingKM => existingKM.MaKM == maKM))  // Kiểm tra MaKM trong cơ sở dữ liệu
                {
                    MessageBox.Show("Mã khuyến mãi đã tồn tại.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mã khuyến mãi không hợp lệ.");
                return;
            }

            // Tạo đối tượng KhuyenMai mới
            KhuyenMai km = new KhuyenMai
            {
                TenKM = txt_tennc.Text,
                PhanTramKM = phanTramKM,
                NgayBatDau = ngayBatDau,
                NgayKetThuc = ngayKetThuc
            };

            dbContext.KhuyenMai.Add(km);
            dbContext.SaveChanges(); // Lưu vào cơ sở dữ liệu

            MessageBox.Show("Khuyến mãi đã được thêm.");
            LoadKhuyenMai();  // Load lại dữ liệu sau khi thêm
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
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

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            if (dgvkm.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvkm.SelectedRows[0];

                // Cập nhật thông tin dòng đã chọn
                row.Cells[0].Value = txt_tennc.Text;
                row.Cells[1].Value = txt_mnc.Text;
                row.Cells[2].Value = txt_makm.Text;
                row.Cells[3].Value = dtp_nbd.Text;
                row.Cells[4].Value = dtb_nkt.Text;

                // Cập nhật cơ sở dữ liệu
                int maKM = 0;

                // Kiểm tra xem txt_makm.Text có thể chuyển sang int không
                if (int.TryParse(txt_makm.Text, out maKM))
                {
                    var kmToUpdate = dbContext.KhuyenMai.FirstOrDefault(km => km.MaKM == maKM); // Sửa lỗi so sánh int và string
                    if (kmToUpdate != null)
                    {
                        kmToUpdate.TenKM = txt_tennc.Text;
                        kmToUpdate.PhanTramKM = decimal.Parse(txt_ptkm.Text);
                        kmToUpdate.NgayBatDau = dtp_nbd.Value;
                        kmToUpdate.NgayKetThuc = dtb_nkt.Value;
                        dbContext.SaveChanges();

                        MessageBox.Show("Thông tin khuyến mãi đã được sửa.");
                        LoadKhuyenMai();
                    }
                    else
                    {
                        MessageBox.Show("Mã khuyến mãi không tồn tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Mã khuyến mãi không hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.");
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)

        {
            this.Hide();  // Ẩn form hiện tại (formKM)

            // Tạo instance của formDK
            formDK formDKInstance = new formDK();

            // Gán giá trị cho mã người chơi và mã khuyến mãi
            formDKInstance.MaNguoiChoi = txt_mnc.Text;  // Giả sử mã người chơi từ txt_mnc
            formDKInstance.MaKhuyenMai = txt_makm.Text; // Giả sử mã khuyến mãi từ txt_makm

            // Hiển thị formDK
            formDKInstance.Show();  // Mở form Đăng Ký

            // Bạn có thể đóng formKM nếu không cần thiết nữa
            // this.Close(); 
        }

        private void dgvkm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void formKhuyenMai_Load(object sender, EventArgs e)
        
        {
            if (dgvkm.SelectedRows.Count > 0)
            {
                var row = dgvkm.SelectedRows[0];
                txt_tennc.Text = row.Cells[0].Value.ToString();
                txt_mnc.Text = row.Cells[1].Value.ToString();
                // Tiếp tục cho các trường khác...
            }
        }

    }
}
    


