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
    public partial class frmHHXuat : Form
    {
        public frmHHXuat()
        {
            InitializeComponent();
        }
        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private void frmHHXuat_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu vào DataGridView
            LoadHangHoaXuatData();
        }

        private void DSHHXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadHangHoaXuatData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn SQL để lấy tất cả dữ liệu từ bảng HangHoaNhap
                    string query = "SELECT * FROM HangHoaXuat";

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSHHXuat.DataSource = dataTable;

                    // Thêm tên các cột vào ComboBox
                    cbHHXuat.Items.Clear(); // Đảm bảo ComboBox trống trước khi thêm items mới

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbHHXuat.Items.Add(column.ColumnName); // Thêm tên cột vào ComboBox
                    }

                    // Tùy chọn, có thể chọn mặc định một item trong ComboBox
                    if (cbHHXuat.Items.Count > 0)
                    {
                        cbHHXuat.SelectedIndex = 0; // Chọn item đầu tiên nếu có
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
                string selectedColumn = cbHHXuat.SelectedItem?.ToString();
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
                    string query = $"SELECT * FROM HangHoaXuat WHERE {selectedColumn} LIKE @SearchValue";

                    // Sử dụng SqlCommand để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                    // Sử dụng SqlDataAdapter để lấy dữ liệu sau khi tìm kiếm
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSHHXuat.DataSource = dataTable;
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
                cbHHXuat.SelectedIndex = -1; // Không chọn cột nào

                // Gọi lại phương thức để tải tất cả dữ liệu vào DataGridView
                LoadHangHoaXuatData();
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
                // Tạo một instance của frmThemHHXuat
                frmThemHHXuat themHHXuat = new frmThemHHXuat();

                // Hiển thị form frmThemHHXuat
                themHHXuat.ShowDialog();

                // Sau khi thêm xong, gọi lại phương thức Load để cập nhật DataGridView
                LoadHangHoaXuatData();
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
                // Kiểm tra nếu có hàng hóa được chọn trong DataGridView
                if (DSHHXuat.SelectedRows.Count > 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = DSHHXuat.SelectedRows[0];

                    // Tạo instance của frmEditHHXuat và truyền dữ liệu vào
                    frmEditHHXuat editHHXuat = new frmEditHHXuat(selectedRow);

                    // Hiển thị form frmEditHHXuat
                    editHHXuat.ShowDialog();

                    // Sau khi chỉnh sửa, gọi lại phương thức Load để cập nhật DataGridView
                    LoadHangHoaXuatData();
                }
                else
                {
                    // Thông báo nếu không có hàng hóa nào được chọn
                    MessageBox.Show("Vui lòng chọn một hàng hóa để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng hóa được chọn trong DataGridView
                if (DSHHXuat.SelectedRows.Count > 0)
                {
                    // Lấy MaHang của hàng hóa được chọn
                    string maHang = DSHHXuat.SelectedRows[0].Cells["MaHang"].Value.ToString();

                    // Hiển thị xác nhận trước khi xóa
                    DialogResult confirmResult = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa hàng hóa với mã '{maHang}' và các dữ liệu liên quan?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Bắt đầu giao dịch để đảm bảo tính toàn vẹn dữ liệu
                            SqlTransaction transaction = connection.BeginTransaction();

                            try
                            {
                                // Xóa dữ liệu trong XuatKhoChiTiet
                                string deleteXuatKhoChiTiet = "DELETE FROM XuatKhoChiTiet WHERE MaHang = @MaHang";
                                using (SqlCommand cmd = new SqlCommand(deleteXuatKhoChiTiet, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaHang", maHang);
                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa dữ liệu trong DatHangChiTiet
                                string deleteDatHangChiTiet = "DELETE FROM DatHangChiTiet WHERE MaHang = @MaHang";
                                using (SqlCommand cmd = new SqlCommand(deleteDatHangChiTiet, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaHang", maHang);
                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa dữ liệu trong HangHoaXuat
                                string deleteHangHoaXuat = "DELETE FROM HangHoaXuat WHERE MaHang = @MaHang";
                                using (SqlCommand cmd = new SqlCommand(deleteHangHoaXuat, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaHang", maHang);
                                    cmd.ExecuteNonQuery();
                                }

                                // Hoàn tất giao dịch
                                transaction.Commit();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Xóa hàng hóa và các dữ liệu liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Tải lại dữ liệu vào DataGridView
                                LoadHangHoaXuatData();
                            }
                            catch (Exception ex)
                            {
                                // Hủy giao dịch nếu có lỗi
                                transaction.Rollback();
                                throw ex;
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