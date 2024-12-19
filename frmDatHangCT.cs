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
    public partial class frmDatHangCT : Form
    {
        public frmDatHangCT()
        {
            InitializeComponent();
        }
        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        private void frmDatHangCT_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonHang();
        }
        private void LoadDanhSachDonHang()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn SQL để lấy tất cả dữ liệu từ bảng DatHang
                    string query = "SELECT * FROM DatHangChiTiet";

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSDHCT.DataSource = dataTable;

                    // Thêm tên các cột vào ComboBox
                    cbDSDHCT.Items.Clear(); // Đảm bảo ComboBox trống trước khi thêm items mới

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbDSDHCT.Items.Add(column.ColumnName); // Thêm tên cột vào ComboBox
                    }

                    // Tùy chọn, có thể chọn mặc định một item trong ComboBox
                    if (cbDSDHCT.Items.Count > 0)
                    {
                        cbDSDHCT.SelectedIndex = 0; // Chọn item đầu tiên nếu có
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
                string selectedColumn = cbDSDHCT.SelectedItem?.ToString();
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
                    string query = $"SELECT * FROM DatHang WHERE {selectedColumn} LIKE @SearchValue";

                    // Sử dụng SqlCommand để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                    // Sử dụng SqlDataAdapter để lấy dữ liệu sau khi tìm kiếm
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable từ kết quả truy vấn
                    adapter.Fill(dataTable);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    DSDHCT.DataSource = dataTable;
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
                cbDSDHCT.SelectedIndex = -1; // Không chọn cột nào

                // Gọi lại phương thức để tải tất cả dữ liệu vào DataGridView
                LoadDanhSachDonHang();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            frmDonHang.ShowDialog();
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form frmThemDHCT
                frmThemDHCT frmThemDHCT = new frmThemDHCT();
                frmThemDHCT.ShowDialog(); // Sử dụng ShowDialog để mở form mới ở chế độ Modal (chờ đến khi đóng)
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi mở form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng nào được chọn trong DataGridView
                if (DSDHCT.SelectedRows.Count > 0)
                {
                    // Lấy thông tin từ hàng được chọn
                    DataGridViewRow selectedRow = DSDHCT.SelectedRows[0];
                    string maDH = selectedRow.Cells["MaDH"].Value.ToString(); // Ví dụ cột MaDH
                    string maHang = selectedRow.Cells["MaHang"].Value.ToString(); // Ví dụ cột MaHang
                    string soLuong = selectedRow.Cells["SoLuong"].Value.ToString(); // Ví dụ cột SoLuong
                    string thanhTien = selectedRow.Cells["ThanhTien"].Value.ToString(); // Ví dụ cột ThanhTien

                    // Tạo instance của frmEditDHCT và truyền dữ liệu
                    frmEditDHCT frmEdit = new frmEditDHCT(maDH, maHang, soLuong, thanhTien);
                    frmEdit.ShowDialog(); // Mở frmEditDHCT ở chế độ modal
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để chỉnh sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi mở form Edit: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng nào được chọn trong DataGridView
                if (DSDHCT.SelectedRows.Count > 0)
                {
                    // Lấy thông tin từ hàng được chọn
                    DataGridViewRow selectedRow = DSDHCT.SelectedRows[0];
                    string maDH = selectedRow.Cells["MaDH"].Value.ToString(); // Ví dụ cột MaDH

                    // Xác nhận xóa
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng {maDH}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Kết nối đến cơ sở dữ liệu
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Bắt đầu một transaction để đảm bảo tính toàn vẹn của dữ liệu
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    // Xóa bản ghi trong bảng DatHangChiTiet
                                    string query1 = "DELETE FROM DatHangChiTiet WHERE MaDH = @MaDH";
                                    SqlCommand command1 = new SqlCommand(query1, connection, transaction);
                                    command1.Parameters.AddWithValue("@MaDH", maDH);
                                    command1.ExecuteNonQuery();

                                    // Kiểm tra xem có còn đơn hàng nào trong bảng DatHang với MaDH này không
                                    string query2 = "SELECT COUNT(*) FROM DatHang WHERE MaDH = @MaDH";
                                    SqlCommand command2 = new SqlCommand(query2, connection, transaction);
                                    command2.Parameters.AddWithValue("@MaDH", maDH);
                                    int count = (int)command2.ExecuteScalar();

                                    // Nếu không còn bản ghi nào trong DatHang với MaDH, xóa bản ghi trong bảng DatHang
                                    if (count == 0)
                                    {
                                        string query3 = "DELETE FROM DatHang WHERE MaDH = @MaDH";
                                        SqlCommand command3 = new SqlCommand(query3, connection, transaction);
                                        command3.Parameters.AddWithValue("@MaDH", maDH);
                                        command3.ExecuteNonQuery();
                                    }

                                    // Commit transaction nếu không có lỗi
                                    transaction.Commit();

                                    // Hiển thị thông báo thành công
                                    MessageBox.Show("Đã xóa đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Tải lại danh sách đơn hàng sau khi xóa
                                    LoadDanhSachDonHang();
                                }
                                catch (Exception ex)
                                {
                                    // Nếu có lỗi xảy ra, rollback transaction
                                    transaction.Rollback();
                                    MessageBox.Show("Lỗi khi xóa đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            frmHHNhap.Show();
        }

        private void hàngHóaXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHXuat frmHHXuat = new frmHHXuat();
            frmHHXuat.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmDSKhachHang = new frmDSKhachHang();
            frmDSKhachHang.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            frmKho.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap frmDSNhaCungCap = new frmDSNhaCungCap();
            frmDSNhaCungCap.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien();
            frmDSNhanVien.Show();
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frmNhapKho = new frmNhapKho();
            frmNhapKho.Show();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPTT frmPTT = new frmPTT();
            frmPTT.Show();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frmXuatKho = new frmXuatKho();
            frmXuatKho.Show();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.Show();
        }

        private void nhậpKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            frmNKCT.Show();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frmXKCT = new frmXKCT();
            frmXKCT.Show();
        }

        private void thanhToánChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            frmPhieuTTCT.Show();
        }
    }
}
