using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QLcasino.QLcasinoEntities;

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

        private void btnThemKH_Click(object sender, EventArgs e)
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



        private void SaveCustomerToDatabase(string maKhachHangString)
        {
            try
            {
                using (QLcasinoEntities2 db = new QLcasinoEntities2())
                {
                    // Lấy thông tin từ DataGridView (hoặc TextBox)
                    string hoTen = "Nhập họ tên tại đây"; // Thay thế bằng giá trị thực tế
                    string maDVString = "123"; // Giá trị chuỗi cần chuyển đổi sang int
                    int maDV;

                    // Chuyển đổi maDVString sang int
                    if (!int.TryParse(maDVString, out maDV))
                    {
                        MessageBox.Show("Giá trị mã DV không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi");
                        return;
                    }

                    DateTime ngaySinh = DateTime.Now; // Giá trị thực tế từ DataGridView

                    // Chuyển maKhachHangString sang int
                    if (!int.TryParse(maKhachHangString, out int maKhachHang))
                    {
                        MessageBox.Show("Giá trị mã khách hàng không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi");
                        return;
                    }

                    // Tạo khách hàng mới từ lớp Khachhang trong Entity Framework
                    QLcasino.QLcasinoEntities.Khachhang newCustomer = new QLcasino.QLcasinoEntities.Khachhang
                    {
                        MaKhachhang = maKhachHang, // Sử dụng giá trị int
                        HoTen = hoTen,
                        NgaySinh = ngaySinh,
                        SoTienNap = 0,
                        SoTienRut = 0,
                        MaDV = maDV,
                        KhiuNai = "Không có"
                    };

                    // Thêm khách hàng mới vào cơ sở dữ liệu
                    db.Khachhang.Add(newCustomer);
                    db.SaveChanges();
                    MessageBox.Show("Khách hàng đã được thêm vào cơ sở dữ liệu!", "Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu khách hàng vào cơ sở dữ liệu: {ex.Message}\n{ex.StackTrace}", "Lỗi");
            }
        }


        private void btnXoaKH_Click(object sender, EventArgs e)
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

        // Xóa khách hàng từ cơ sở dữ liệu và DataGridView
        private void XoaKhachHang(int maKhachHang)
        {
            using (QLcasinoEntities2 db = new QLcasinoEntities2())
            {
                try
                {
                    // Tìm khách hàng với mã khách hàng đã cho
                    var khachHang = db.Khachhang.SingleOrDefault(kh => kh.MaKhachhang == maKhachHang);

                    // Nếu không tìm thấy khách hàng
                    if (khachHang == null)
                    {
                        MessageBox.Show("Khách hàng không tìm thấy.", "Lỗi");
                        return;
                    }

                    // Xóa khách hàng khỏi cơ sở dữ liệu
                    db.Khachhang.Remove(khachHang);
                    db.SaveChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Khách hàng đã được xóa!", "Thành công");

                    // Xóa dòng khỏi DataGridView
                    XoaDinhDanhKhachHangKhoiDGV(maKhachHang);
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi chi tiết nếu có ngoại lệ
                    MessageBox.Show($"Lỗi xóa khách hàng: {ex.Message}\n{ex.StackTrace}", "Lỗi");
                }
            }
        }


        private void Fill_dgv_ThongTinKhachHang()
        {
            using (QLcasinoEntities2 db = new QLcasinoEntities2())
            {
                var query = from kh in db.Khachhang
                            join hd in db.Hoadon on kh.MaKhachhang equals hd.MaKhachhang into hdGroup
                            join kv in db.KhuVuc on kh.MaDV equals kv.MaKV
                            join kn in db.KhieuNai on kh.MaKhachhang equals kn.MaKhachhang into knGroup
                            group new { hdGroup, knGroup } by new { kh.MaKhachhang, kh.HoTen, kv.TenKV } into g
                            select new
                            {
                                MaKhachhang = g.Key.MaKhachhang,
                                TenNguoiChoi = g.Key.HoTen,
                                // Sử dụng Sum để tính tổng tiền nạp và tiền rút
                                SoTienNap = g.SelectMany(x => x.hdGroup)
                                              .Where(h => h.LoaiGiaoDich == "Nạp tiền")
                                              .Sum(h => (int?)h.SoTien) ?? 0,
                                SoTienRut = g.SelectMany(x => x.hdGroup)
                                              .Where(h => h.LoaiGiaoDich == "Rút tiền")
                                              .Sum(h => (int?)h.SoTien) ?? 0,
                                KhuVuc = g.Key.TenKV,
                                KhiuNai = g.Any() && g.FirstOrDefault().knGroup.FirstOrDefault() != null
                                          ? g.FirstOrDefault().knGroup.FirstOrDefault().LyDo
                                          : "Không có"
                            };

                dgvql.Rows.Clear();
                int stt = 1;
                foreach (var item in query)
                {
                    dgvql.Rows.Add(stt++, item.MaKhachhang, item.TenNguoiChoi, item.SoTienNap, item.SoTienRut, item.KhuVuc, item.KhiuNai);
                }
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
            using (QLcasinoEntities2 db = new QLcasinoEntities2())
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

            using (QLcasinoEntities2 db = new QLcasinoEntities2())
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

        private void AddKhuVucComboBoxColumn()
        {
            DataGridViewComboBoxColumn khuVucComboBoxColumn = new DataGridViewComboBoxColumn();
            khuVucComboBoxColumn.Name = "KhuVuc";
            khuVucComboBoxColumn.HeaderText = "Khu Vực";

            using (QLcasinoEntities2 db = new QLcasinoEntities2())
            {
                var khuVucList = db.KhuVuc.ToList();
                khuVucComboBoxColumn.Items.AddRange(khuVucList.Select(kv => kv.TenKV).ToArray());
            }

            if (!dgvql.Columns.Contains("KhuVuc"))
            {
                dgvql.Columns.Add(khuVucComboBoxColumn);
            }
        }



        private void dgvql_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmb_LChonGame_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
