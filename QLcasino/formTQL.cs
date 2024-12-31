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

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm nhân viên được gọi!", "Thông báo");
            // Logic thêm nhân viên tại đây
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa nhân viên được gọi!", "Thông báo");
            // Logic xóa nhân viên tại đây
        }











        private void Fill_dgv_ThongTinKhachHang()
        {
            using (QLcasinoEntities db = new QLcasinoEntities())
            {
                var query = db.Khachhang.AsNoTracking().Select(kh => new
                {
                    kh.MaKhachhang,
                    kh.HoTen,
                    SoTienNap = kh.Hoadon
                                .Where(h => h.LoaiGiaoDich == "Nạp tiền")
                                .Sum(h => (int?)h.SoTien) ?? 0,
                    SoTienRut = kh.Hoadon
                                .Where(h => h.LoaiGiaoDich == "Rút tiền")
                                .Sum(h => (int?)h.SoTien) ?? 0,
                    KhuVuc = kh.Hoadon
                              .Select(h => h.LoaiGiaoDich)
                              .FirstOrDefault() ?? "Chưa rõ",
                    KhieuNai = kh.KhieuNai
                                .Select(kn => kn.LyDo)
                                .FirstOrDefault() ?? "Không có"
                });

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("STT", typeof(int));
                dataTable.Columns.Add("MaKhachhang", typeof(string));
                dataTable.Columns.Add("TenNguoiChoi", typeof(string));
                dataTable.Columns.Add("SoTienNap", typeof(int));
                dataTable.Columns.Add("SoTienRut", typeof(int));
                dataTable.Columns.Add("KhuVuc", typeof(string));
                dataTable.Columns.Add("KhieuNai", typeof(string));

                int stt = 1;
                foreach (var item in query.ToList())
                {
                    dataTable.Rows.Add(stt++, item.MaKhachhang, item.HoTen, item.SoTienNap, item.SoTienRut, item.KhuVuc, item.KhieuNai);
                }

                dgvql.DataSource = dataTable;
            }
        }





        private void XoaDinhDanhKhachHangKhoiDGV(int maKhachHang)
        {
            foreach (DataGridViewRow row in dgvql.Rows)
            {
                if (Convert.ToInt32(row.Cells["MaKhachhang"].Value) == maKhachHang)
                {
                    var rowToDelete = dgvql.Rows
                         .Cast<DataGridViewRow>()
                          .FirstOrDefault(r => Convert.ToInt32(r.Cells["MaKhachhang"].Value) == maKhachHang);

                    if (rowToDelete != null)
                    {
                        dgvql.Rows.Remove(rowToDelete);
                    }

                }
            }
        }

        private void HienThiDanhSachKhachHang()
        {
            using (QLcasinoEntities db = new QLcasinoEntities())
            {
                try
                {
                    var danhSachKhachHang = db.Khachhang.ToList();
                    dgvql.DataSource = danhSachKhachHang;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải danh sách khách hàng: {ex.Message}", "Lỗi");
                }
            }
        }






        private void formTQL_Load(object sender, EventArgs e)
        {
            Fill_dgv_ThongTinKhachHang(); // Tải thông tin khách hàng vào DataGridVie
        }

        private void dgvql_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is InvalidCastException)
            {
                MessageBox.Show("Giá trị đã chọn không hợp lệ. Vui lòng chọn một tùy chọn hợp lệ.", "Giá trị không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false;
            }
        }

        // Thêm các cột ComboBox vào DataGridView
        private void AddComboBoxColumns()
        {
            AddTroChoiComboBoxColumn();
            AddKhuVucComboBoxColumn();
        }

        private void AddTroChoiComboBoxColumn()
        {
            DataGridViewComboBoxColumn troChoiComboBoxColumn = new DataGridViewComboBoxColumn();
            troChoiComboBoxColumn.Name = "TroChoi";
            troChoiComboBoxColumn.HeaderText = "Trò Chơi";

            using (QLcasinoEntities db = new QLcasinoEntities())
            {
                var gameList = db.TroChoi.Where(g => g.TenTC != null).ToList();
                troChoiComboBoxColumn.DataSource = gameList;
                troChoiComboBoxColumn.DisplayMember = "TenTroChoi";
                troChoiComboBoxColumn.ValueMember = "MaTroChoi";
            }

            if (!dgvql.Columns.Contains("TroChoi"))
            {
                dgvql.Columns.Add(troChoiComboBoxColumn);
            }
        }
        public class KhuVuc_Service
        {
            public List<KhuVuc> GetAllKhuVuc()
            {
                List<KhuVuc> khuVucs = new List<KhuVuc>();
                string connectionString = "your_connection_string_here"; // Cập nhật chuỗi kết nối của bạn

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaKV, TenKV FROM KhuVuc";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            KhuVuc khuVuc = new KhuVuc()
                            {
                                MaKV = reader.GetInt32(0),
                                TenKV = reader.GetString(1)
                            };
                            khuVucs.Add(khuVuc);
                        }
                    }
                }

                return khuVucs;
            }
        }
        private void FillComboBoxWithKhuVuc()
        {
            KhuVuc_Service khuVucService = new KhuVuc_Service();
            List<KhuVuc> khuVucs = khuVucService.GetAllKhuVuc();

            cmbkhuvuc.Items.Clear();
            cmbkhuvuc.DataSource = khuVucs;
            cmbkhuvuc.ValueMember = "MaKV";
            cmbkhuvuc.DisplayMember = "TenKV";
        }


        public class KhuVuc
        {
            public int MaKV { get; set; }
            public string TenKV { get; set; }
        }
        public class TroChoi_Service
        {
            public List<TroChoi> GetAllTroChoi()
            {
                List<TroChoi> troChois = new List<TroChoi>();
                string connectionString = @"Server=localhost; Database=YourDatabaseName; Integrated Security=True;"; // Cập nhật chuỗi kết nối

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaTC, TenTC, LoaiTC FROM TroChoi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TroChoi troChoi = new TroChoi()
                            {
                                MaTC = reader.GetInt32(0),
                                TenTC = reader.GetString(1),
                                LoaiTC = reader.GetString(2)
                            };
                            troChois.Add(troChoi);
                        }
                    }
                }

                return troChois;
            }
        }
        private void FillComboBoxWithTroChoi()
        {
            TroChoi_Service troChoiService = new TroChoi_Service();
            List<TroChoi> troChois = troChoiService.GetAllTroChoi();

            cmb_LChonGame.Items.Clear(); // Xóa các mục cũ trong ComboBox
            cmb_LChonGame.DataSource = troChois; // Liên kết danh sách trò chơi với ComboBox
            cmb_LChonGame.ValueMember = "MaTC"; // Giá trị được chọn khi người dùng chọn một trò chơi
            cmb_LChonGame.DisplayMember = "TenTC"; // Tên hiển thị trong ComboBox
        }

        public class TroChoi
        {
            public int MaTC { get; set; }
            public string TenTC { get; set; }
            public string LoaiTC { get; set; }
        }

        private void AddKhuVucComboBoxColumn()
        {
            DataGridViewComboBoxColumn khuVucComboBoxColumn = new DataGridViewComboBoxColumn();
            khuVucComboBoxColumn.Name = "KhuVuc";
            khuVucComboBoxColumn.HeaderText = "Khu Vực";

            using (QLcasinoEntities db = new QLcasinoEntities())
            {
                var khuVucList = db.KhuVuc.ToList();
                khuVucComboBoxColumn.Items.AddRange(khuVucList.Select(kv => kv.TenKV).ToArray());
            }

            if (!dgvql.Columns.Contains("KhuVuc"))
            {
                dgvql.Columns.Add(khuVucComboBoxColumn);
            }
        }

        private void btnThemKH_Click_1(object sender, EventArgs e)
        
        {
            try
            {
                // Kiểm tra nếu DataGridView chưa có cột
                if (dgvql.Columns.Count == 0)
                {
                    // Thêm các cột vào DataGridView
                    dgvql.Columns.Add("STT", "STT");
                    dgvql.Columns.Add("MaKhachhang", "Mã Khách Hàng");
                    dgvql.Columns.Add("HoTen", "Họ Tên");
                    dgvql.Columns.Add("MaDV", "Mã Dịch Vụ");
                    dgvql.Columns.Add("NgaySinh", "Ngày Sinh");
                    dgvql.Columns.Add("SoTienNap", "Số Tiền Nạp");
                    dgvql.Columns.Add("SoTienRut", "Số Tiền Rút");
                    dgvql.Columns.Add("KhiuNai", "Khiếu Nại");
                }

                // Tạo mã khách hàng mới dưới dạng string
                string maKhachHangMoi = dgvql.Rows.Count > 0
                    ? (Convert.ToInt32(dgvql.Rows[dgvql.Rows.Count - 1].Cells["MaKhachhang"].Value) + 1).ToString()
                    : "1";  // Mã khách hàng bắt đầu từ 1, chuyển sang string

                // Thêm dòng mới vào DataGridView
                dgvql.Rows.Add(
                    dgvql.Rows.Count + 1,
                    maKhachHangMoi,
                    "Nhập họ tên tại đây",
                    "Nhập mã DV tại đây",
                    DateTime.Now.ToShortDateString(),
                    0,
                    0,
                    "Không có"
                );

                MessageBox.Show("Thêm dòng mới thành công! Vui lòng nhập thông tin vào các ô.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }



        private void SaveCustomerToDatabase(string hoTen, string ngaySinhString, string maDVString)
        {
            try
            {
                using (QLcasinoEntities db = new QLcasinoEntities())
                {
                    // Chuyển đổi ngày sinh
                    if (!DateTime.TryParse(ngaySinhString, out DateTime ngaySinh))
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng ngày.", "Lỗi");
                        return;
                    }

                    // Chuyển đổi maDVString sang int
                    if (!int.TryParse(maDVString, out int maDV))
                    {
                        MessageBox.Show("Giá trị mã DV không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi");
                        return;
                    }

                    // Tạo khách hàng mới từ lớp Khachhang trong Entity Framework
                    Khachhang newCustomer = new Khachhang
                    {
                        HoTen = hoTen,
                        NgaySinh = ngaySinh,

                        TrangThaiThanhVien = "Hoạt động" // Đặt trạng thái mặc định
                    };

                    // Thêm khách hàng mới vào cơ sở dữ liệu
                    db.Khachhang.Add(newCustomer);
                    db.SaveChanges();
                    MessageBox.Show("Khách hàng đã được thêm vào cơ sở dữ liệu!", "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void btnXoaKH_Click_1(object sender, EventArgs e)
        {
            {
                if (dgvql.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa.", "Lỗi");
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirmResult != DialogResult.Yes)
                    return;

                int maKhachHang = Convert.ToInt32(dgvql.CurrentRow.Cells["MaKhachhang"].Value);

                // Gọi phương thức xóa khách hàng
                XoaKhachHang(maKhachHang);
            }
            }

        // Xóa khách hàng từ cơ sở dữ liệu và DataGridView
        private void XoaKhachHang(int maKhachHang)
        {

            using (QLcasinoEntities db = new QLcasinoEntities())
            {
                try
                {
                    var khachHang = db.Khachhang.SingleOrDefault(kh => kh.MaKhachhang == maKhachHang);

                    if (khachHang == null)
                    {
                        MessageBox.Show("Khách hàng không tìm thấy.", "Lỗi");
                        return;
                    }

                    db.Khachhang.Remove(khachHang);
                    db.SaveChanges();

                    MessageBox.Show("Khách hàng đã được xóa!", "Thành công");

                    // Cập nhật lại DataGridView
                    Fill_dgv_ThongTinKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa khách hàng: {ex.Message}\n{ex.StackTrace}", "Lỗi");
                }
            }
        }


        private void btnkm_Click(object sender, EventArgs e)
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
    }
}
