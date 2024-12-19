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
    public partial class frmPTT : Form
    {
        public frmPTT()
        {
            InitializeComponent();
        }

        private void frmPTT_Load(object sender, EventArgs e)
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

                    // Truy vấn dữ liệu từ bảng ThanhToan
                    string query = "SELECT * FROM ThanhToan";

                    // Tạo đối tượng SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView để hiển thị
                    DSPhieuTT.DataSource = dataTable;

                    // Lấy tên các cột của bảng ThanhToan
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Thêm tên cột vào ComboBox
                        cbPTT.Items.Add(column.ColumnName);
                    }

                    // Tùy chọn để hiển thị tên cột đầu tiên là mặc định
                    if (cbPTT.Items.Count > 0)
                    {
                        cbPTT.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            this.Hide();
            frm.Show();
        }

        private void cbPTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            // Lấy giá trị tìm kiếm từ txtTimKiem và cbPTT
            string searchTerm = txtTimKiem.Text.Trim();  // Dữ liệu nhập từ ô tìm kiếm
            string selectedColumn = cbPTT.SelectedItem.ToString();  // Cột được chọn từ ComboBox

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
                    string query = "SELECT * FROM ThanhToan WHERE " + selectedColumn + " LIKE @searchTerm";

                    // Tạo đối tượng SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Thêm tham số để tránh SQL Injection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView để hiển thị
                    DSPhieuTT.DataSource = dataTable;
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
            if (cbPTT.Items.Count > 0)
            {
                cbPTT.SelectedIndex = -1;  // Không chọn gì trong ComboBox
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
                    string query = "SELECT * FROM ThanhToan";

                    // Tạo đối tượng SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo một DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán lại DataTable cho DataGridView để làm mới
                    DSPhieuTT.DataSource = dataTable;

                    // Nếu muốn làm mới ComboBox (cbPTT) với tên cột của bảng ThanhToan
                    cbPTT.Items.Clear();  // Xóa các mục hiện tại trong ComboBox
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbPTT.Items.Add(column.ColumnName);  // Thêm tên cột vào ComboBox
                    }

                    // Đặt lại ComboBox về giá trị mặc định nếu có
                    if (cbPTT.Items.Count > 0)
                    {
                        cbPTT.SelectedIndex = 0;  // Hoặc bỏ qua dòng này nếu không muốn chọn cột mặc định
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frm = new frmXKCT();
            this.Hide();
            frm.Show();
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            frmThemPTT frm = new frmThemPTT();
            this.Hide();
            frm.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (DSPhieuTT.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = DSPhieuTT.SelectedRows[0];

                // Extract the values from the selected row
                string soPTT = selectedRow.Cells["SoPTT"].Value.ToString();
                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                DateTime ngayTT = Convert.ToDateTime(selectedRow.Cells["NgayTT"].Value);
                string pmethod = selectedRow.Cells["Pmethod"].Value.ToString();
                decimal tongTien = Convert.ToDecimal(selectedRow.Cells["TongTien"].Value);
                decimal vat = Convert.ToDecimal(selectedRow.Cells["VAT"].Value);
                string maNCC = selectedRow.Cells["MaNCC"].Value.ToString();

                // Create an instance of frmEditPTT and pass the values
                frmEditPTT editForm = new frmEditPTT(soPTT, maNV, ngayTT, pmethod, tongTien, vat, maNCC);
                editForm.ShowDialog();  // Open frmEditPTT as a modal dialog
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (DSPhieuTT.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = DSPhieuTT.SelectedRows[0];

                // Extract the value of SoPTT from the selected row
                string soPTT = selectedRow.Cells["SoPTT"].Value.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Connection string to the SQL Server database
                    string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

                    // Create a connection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            // Open the connection
                            connection.Open();

                            // SQL query to delete the record from the database
                            string query = "DELETE FROM ThanhToan WHERE SoPTT = @SoPTT";

                            // Create a SqlCommand to execute the query
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                // Add the parameter to the command
                                cmd.Parameters.AddWithValue("@SoPTT", soPTT);

                                // Execute the command
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Remove the selected row from the DataGridView
                                    DSPhieuTT.Rows.Remove(selectedRow);

                                    MessageBox.Show("Xóa bản ghi thành công!");
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy bản ghi với số phiếu thanh toán được chọn.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors that occur during the deletion process
                            MessageBox.Show("Lỗi khi thực hiện xóa: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
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
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.Show();
        }

        private void thanhToánChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            this.Hide();
            frmPhieuTTCT.Show();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            this.Hide();
            frmDonHang.Show();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }
}
