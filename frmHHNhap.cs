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

namespace QuanLyBanHang
{
    public partial class frmHHNhap : Form
    {
        public frmHHNhap()
        {
            InitializeComponent();
        }
        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        private void frmHHNhap_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu vào DataGridView
            LoadHangHoaNhapData();
        }


        private void LoadHangHoaNhapData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn SQL để lấy tất cả dữ liệu từ bảng HangHoaNhap
                    string query = "SELECT * FROM HangHoaNhap";

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSHHNhap.DataSource = dataTable;

                    // Thêm tên các cột vào ComboBox
                    cbHHNhap.Items.Clear(); // Đảm bảo ComboBox trống trước khi thêm items mới

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbHHNhap.Items.Add(column.ColumnName); // Thêm tên cột vào ComboBox
                    }

                    // Tùy chọn, có thể chọn mặc định một item trong ComboBox
                    if (cbHHNhap.Items.Count > 0)
                    {
                        cbHHNhap.SelectedIndex = 0; // Chọn item đầu tiên nếu có
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị cột được chọn từ ComboBox
                string selectedColumn = cbHHNhap.SelectedItem?.ToString();
                // Lấy giá trị tìm kiếm từ TextBox
                string searchValue = txtTimKiem.Text.Trim();

                // Kiểm tra nếu người dùng chưa chọn cột hoặc chưa nhập giá trị tìm kiếm
                if (string.IsNullOrEmpty(selectedColumn))
                {
                    MessageBox.Show("Vui lòng chọn một cột để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn SQL tìm kiếm với cột và giá trị tìm kiếm
                    string query = $"SELECT * FROM HangHoaNhap WHERE {selectedColumn} LIKE @SearchValue";

                    // Sử dụng SqlCommand để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                    // Sử dụng SqlDataAdapter để lấy dữ liệu sau khi tìm kiếm
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSHHNhap.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong TextBox tìm kiếm
                txtTimKiem.Clear();

                // Reset lại ComboBox về giá trị mặc định (có thể chọn hoặc không)
                cbHHNhap.SelectedIndex = -1; // Không chọn cột nào

                // Gọi lại phương thức để tải tất cả dữ liệu vào DataGridView
                LoadHangHoaNhapData();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một đối tượng mới của frmThemHHNhap
                frmThemHHNhap frmThemHH = new frmThemHHNhap();

                // Mở form frmThemHHNhap
                frmThemHH.ShowDialog(); // ShowDialog() để mở form theo kiểu Modal (ngừng tương tác với form hiện tại cho đến khi đóng form này)
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng hóa nào được chọn trong DataGridView
                if (DSHHNhap.SelectedRows.Count > 0)
                {
                    // Lấy các giá trị của hàng được chọn
                    string maHang = DSHHNhap.SelectedRows[0].Cells["MaHang"].Value.ToString();
                    string tenHang = DSHHNhap.SelectedRows[0].Cells["TenHang"].Value.ToString();
                    string dvt = DSHHNhap.SelectedRows[0].Cells["DVT"].Value.ToString();
                    string donGia = DSHHNhap.SelectedRows[0].Cells["DonGiaNhap"].Value.ToString();
                    // Thêm các cột khác nếu cần...

                    // Tạo một instance của frmEditHHNhap và truyền dữ liệu vào
                    frmEditHHNhap frmEditHH = new frmEditHHNhap(maHang, tenHang, dvt, donGia);

                    // Hiển thị form chỉnh sửa
                    frmEditHH.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng hóa để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng hóa nào được chọn trong DataGridView
                if (DSHHNhap.SelectedRows.Count > 0)
                {
                    // Lấy MaHang của hàng hóa được chọn
                    string maHang = DSHHNhap.SelectedRows[0].Cells["MaHang"].Value.ToString();

                    // Hỏi người dùng xem họ có chắc chắn muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Bắt đầu một transaction để đảm bảo các thao tác xóa đều thành công hoặc không có thay đổi nào
                            SqlTransaction transaction = connection.BeginTransaction();

                            try
                            {
                                // Câu truy vấn SQL để xóa các bản ghi liên quan từ bảng ThanhToanChiTiet
                                string deleteThanhToanChiTietQuery = "DELETE FROM ThanhToanChiTiet WHERE MaHang = @MaHang";
                                SqlCommand deleteThanhToanChiTietCommand = new SqlCommand(deleteThanhToanChiTietQuery, connection, transaction);
                                deleteThanhToanChiTietCommand.Parameters.AddWithValue("@MaHang", maHang);

                                // Thực hiện câu truy vấn xóa các bản ghi từ ThanhToanChiTiet
                                deleteThanhToanChiTietCommand.ExecuteNonQuery();

                                // Câu truy vấn SQL để xóa các bản ghi liên quan từ bảng NhapKhoChiTiet
                                string deleteNhapKhoChiTietQuery = "DELETE FROM NhapKhoChiTiet WHERE MaHang = @MaHang";
                                SqlCommand deleteNhapKhoChiTietCommand = new SqlCommand(deleteNhapKhoChiTietQuery, connection, transaction);
                                deleteNhapKhoChiTietCommand.Parameters.AddWithValue("@MaHang", maHang);

                                // Thực hiện câu truy vấn xóa các bản ghi từ NhapKhoChiTiet
                                deleteNhapKhoChiTietCommand.ExecuteNonQuery();

                                // Câu truy vấn SQL để xóa hàng hóa chính từ bảng HangHoaNhap
                                string deleteHangHoaNhapQuery = "DELETE FROM HangHoaNhap WHERE MaHang = @MaHang";
                                SqlCommand deleteHangHoaNhapCommand = new SqlCommand(deleteHangHoaNhapQuery, connection, transaction);
                                deleteHangHoaNhapCommand.Parameters.AddWithValue("@MaHang", maHang);

                                // Thực hiện câu truy vấn xóa hàng hóa chính
                                int result = deleteHangHoaNhapCommand.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    // Commit transaction nếu xóa thành công
                                    transaction.Commit();
                                    MessageBox.Show("Hàng hóa đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Gọi lại phương thức để tải lại dữ liệu vào DataGridView
                                    LoadHangHoaNhapData();
                                }
                                else
                                {
                                    // Nếu không xóa được, thông báo lỗi và rollback transaction
                                    MessageBox.Show("Lỗi khi xóa hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                }
                            }
                            catch (Exception ex)
                            {
                                // Nếu có lỗi xảy ra, rollback transaction và thông báo lỗi
                                transaction.Rollback();
                                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    // Thông báo nếu không có hàng hóa nào được chọn
                    MessageBox.Show("Vui lòng chọn một hàng hóa để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hàngHóaNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHNhap frmHHNhap = new frmHHNhap();
            frmHHNhap.ShowDialog();
        }

        private void hàngHóaXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHXuat frmHHXuat = new frmHHXuat();
            frmHHXuat.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmDSKhachHang = new frmDSKhachHang();
            frmDSKhachHang.ShowDialog();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            frmKho.ShowDialog();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap frmDSNhaCungCap = new frmDSNhaCungCap();
            frmDSNhaCungCap.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien();
            frmDSNhanVien.ShowDialog();
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frmNhapKho = new frmNhapKho();
            frmNhapKho.ShowDialog();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPTT frmPTT = new frmPTT();
            frmPTT.ShowDialog();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frmXuatKho = new frmXuatKho();
            frmXuatKho.ShowDialog();
        }

        private void nhậpKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            frmNKCT.ShowDialog();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frmXKCT = new frmXKCT();
            frmXKCT.ShowDialog();
        }

        private void thanhToánChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            frmPhieuTTCT.ShowDialog();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            frmDonHang.ShowDialog();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }

}
