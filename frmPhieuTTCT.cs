using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmPhieuTTCT : Form
    {
        public frmPhieuTTCT()
        {
            InitializeComponent();
        }

        private void frmPhieuTTCT_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối với cơ sở dữ liệu
                    connection.Open();

                    // Lấy thông tin về các cột trong bảng ThanhToanChiTiet
                    DataTable schemaTable = connection.GetSchema("Columns", new string[] { null, null, "ThanhToanChiTiet", null });

                    // Duyệt qua các cột và thêm tên cột vào ComboBox
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        // Lấy tên cột và thêm vào ComboBox
                        string columnName = row["COLUMN_NAME"].ToString();
                        cbPTTCT.Items.Add(columnName);
                    }

                    // Đảm bảo ComboBox không rỗng
                    if (cbPTTCT.Items.Count > 0)
                    {
                        cbPTTCT.SelectedIndex = 0; // Chọn cột đầu tiên trong ComboBox
                    }

                    // Đóng kết nối
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tên cột: " + ex.Message);
                }
            }

            // Tiếp tục với việc tải dữ liệu vào DataGridView
            LoadData();
        }
        
        private void LoadData()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Câu lệnh SQL để truy vấn dữ liệu từ bảng ThanhToanChiTiet
                string query = "SELECT * FROM ThanhToanChiTiet";

                // Tạo SqlDataAdapter để thực hiện truy vấn
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // Tạo DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                try
                {
                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable vào DataGridView để hiển thị dữ liệu
                    DSPhieuTTCT.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối dữ liệu: " + ex.Message);
                }
            }
        }

        private void DSPhieuTTCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi người dùng click vào một cell của DataGridView (nếu cần)
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            // Lấy giá trị tìm kiếm từ txtTimKiem và cbPTT
            string searchTerm = txtTimKiem.Text.Trim();  // Dữ liệu nhập từ ô tìm kiếm
            string selectedColumn = cbPTTCT.SelectedItem.ToString();  // Cột được chọn từ ComboBox

            // Kiểm tra nếu ô tìm kiếm không trống và cột được chọn hợp lệ
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn SQL động để tìm kiếm dữ liệu theo cột và giá trị
                    string query = "SELECT * FROM ThanhToanChiTiet WHERE " + selectedColumn + " LIKE @searchTerm";

                    // Tạo đối tượng SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Thêm tham số để tránh SQL Injection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView để hiển thị
                    DSPhieuTTCT.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            // Xóa giá trị tìm kiếm trong txtTimKiem
            txtTimKiem.Clear();

            // Đặt lại ComboBox (cbPTT) về giá trị mặc định (hoặc không chọn gì)
            if (cbPTTCT.Items.Count > 0)
            {
                cbPTTCT.SelectedIndex = -1;  // Không chọn gì trong ComboBox
            }

            // Lấy lại tất cả dữ liệu từ bảng ThanhToan để làm mới DataGridView
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng ThanhToan
                    string query = "SELECT * FROM ThanhToanChiTiet";

                    // Tạo đối tượng SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán lại DataTable cho DataGridView để làm mới
                    DSPhieuTTCT.DataSource = dataTable;

                    // Nếu muốn làm mới ComboBox (cbPTT) với tên cột của bảng ThanhToan
                    cbPTTCT.Items.Clear();  // Xóa các mục hiện tại trong ComboBox
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbPTTCT.Items.Add(column.ColumnName);  // Thêm tên cột vào ComboBox
                    }

                    // Đặt lại ComboBox về giá trị mặc định nếu có
                    if (cbPTTCT.Items.Count > 0)
                    {
                        cbPTTCT.SelectedIndex = 0;  // Hoặc bỏ qua dòng này nếu không muốn chọn cột mặc định
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của frmThemPTTCT
            frmThemPTTCT frmThem = new frmThemPTTCT();

            // Hiển thị form như một cửa sổ con (modal)
            frmThem.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (DSPhieuTTCT.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = DSPhieuTTCT.SelectedRows[0];

                // Retrieve the primary key value from the selected row
                string soPTT = selectedRow.Cells["SoPTT"].Value.ToString();
                string maHang = selectedRow.Cells["MaHang"].Value.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
                    string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

                    // Tạo kết nối
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            // Mở kết nối
                            connection.Open();

                            // Tạo câu truy vấn SQL để xóa dữ liệu
                            string query = "DELETE FROM ThanhToanChiTiet WHERE SoPTT = @soPTT AND MaHang = @maHang";

                            // Tạo đối tượng SqlCommand để thực hiện truy vấn
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@soPTT", soPTT);
                            command.Parameters.AddWithValue("@maHang", maHang);

                            // Thực thi câu truy vấn
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Xóa hàng khỏi DataGridView
                                DSPhieuTTCT.Rows.Remove(selectedRow);
                                MessageBox.Show("Row deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Error deleting row.");
                            }

                            // Đóng kết nối
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting row: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView hay không
            if (DSPhieuTTCT.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = DSPhieuTTCT.SelectedRows[0];

                // Tạo một đối tượng của frmEditPTTCT
                frmEditPTTCT frmEdit = new frmEditPTTCT();

                // Truyền dữ liệu từ hàng được chọn vào form Edit
                frmEdit.SoPTT = selectedRow.Cells["SoPTT"].Value.ToString();
                frmEdit.MaHang = selectedRow.Cells["MaHang"].Value.ToString();
                frmEdit.SoLuong = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);
                frmEdit.ThanhTien = Convert.ToDecimal(selectedRow.Cells["ThanhTien"].Value);

                // Hiển thị form Edit như một cửa sổ con (modal)
                frmEdit.ShowDialog();

                // Có thể làm mới DataGridView sau khi trở về từ form Edit
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để chỉnh sửa.");
            }
        }

        private void hàngHóaNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHNhap frmHHNhap = new frmHHNhap();
            this.Hide();
            frmHHNhap.Show();
        }

        private void hàngHóaXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHXuat frmHHXuat = new frmHHXuat();
            this.Hide();
            frmHHXuat.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmDSKhachHang = new frmDSKhachHang();
            this.Hide();
            frmDSKhachHang.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap frmDSNhaCungCap = new frmDSNhaCungCap();
            this.Hide();
            frmDSNhaCungCap.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien();
            this.Hide();
            frmDSNhanVien.Show();
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frmNhapKho = new frmNhapKho();
            this.Hide();
            frmNhapKho.Show();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPTT frmPTT = new frmPTT();
            this.Hide();
            frmPTT.Show();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frmXuatKho = new frmXuatKho();
            this.Hide();
            frmXuatKho.Show();
        }

        private void nhậpKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            this.Hide();
            frmNKCT.Show();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frmXKCT = new frmXKCT();
            this.Hide();
            frmXKCT.Show();
        }

        private void thanhToánChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            this.Hide();
            frmPhieuTTCT.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.Show();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            frmDonHang.ShowDialog();
        }

        private void đặtHàngChoTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }
}
