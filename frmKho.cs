using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmKho : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"; // Chuỗi kết nối

        public frmKho()
        {
            InitializeComponent();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadColumnNames();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Kho"; // Truy vấn dữ liệu từ bảng Kho
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Điền dữ liệu vào DataTable

                    DSKho.DataSource = dataTable; // Gán DataTable cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void LoadColumnNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 0 * FROM Kho"; // Không lấy dữ liệu, chỉ cần cấu trúc
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Lấy tên cột và thêm vào ComboBox
                    cbKho.Items.Clear(); // Xóa các mục cũ
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        cbKho.Items.Add(reader.GetName(i)); // Thêm tên cột vào ComboBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            string selectedColumn = cbKho.SelectedItem?.ToString(); // Lấy tên cột được chọn
            string searchValue = txtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm từ TextBox

            if (string.IsNullOrEmpty(selectedColumn) || string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng chọn cột và nhập giá trị tìm kiếm.");
                return;
            }

            SearchData(selectedColumn, searchValue);
        }

        private void SearchData(string columnName, string searchValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Tạo truy vấn tìm kiếm với tham số
                    string query = $"SELECT * FROM Kho WHERE {columnName} LIKE @searchValue";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Thêm tham số

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Điền dữ liệu vào DataTable

                    DSKho.DataSource = dataTable; // Gán DataTable cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            // Xóa giá trị trong ComboBox và TextBox
            cbKho.SelectedIndex = -1; // Bỏ chọn cột
            txtTimKiem.Clear(); // Xóa nội dung TextBox

            // Làm mới DataGridView bằng cách gọi lại LoadData
            LoadData();
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            frmThemKho frmThemKho = new frmThemKho();
            this.Hide();
            frmThemKho.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (DSKho.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = DSKho.SelectedRows[0];

                // Lấy giá trị từ các cột tương ứng
                string maKho = selectedRow.Cells["MaKho"].Value.ToString(); // Thay "MaKho" bằng tên cột thực tế
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString(); // Thay "DiaChi" bằng tên cột thực tế

                // Tạo một instance của frmEditKho và truyền dữ liệu
                frmEditKho frmEditKho = new frmEditKho();
                frmEditKho.SetData(maKho, diaChi); // Gọi phương thức để truyền dữ liệu

                // Ẩn form hiện tại và hiển thị frmEditKho
                this.Hide();
                frmEditKho.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để chỉnh sửa.");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (DSKho.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = DSKho.SelectedRows[0];

                // Lấy giá trị của mã kho từ hàng được chọn
                string maKho = selectedRow.Cells["MaKho"].Value.ToString(); // Thay "MaKho" bằng tên cột thực tế

                // Xác nhận người dùng có muốn xóa không
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thông tin kho có mã: {maKho}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Kết nối đến cơ sở dữ liệu và thực hiện xóa
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            // Thực hiện câu lệnh DELETE
                            string query = "DELETE FROM Kho WHERE MaKho = @maKho"; // Thay "MaKho" bằng tên cột thực tế
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@maKho", maKho);

                            int rowsAffected = command.ExecuteNonQuery(); // Thực hiện câu lệnh và lấy số hàng bị ảnh hưởng

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công!");
                                LoadData(); // Làm mới DataGridView để cập nhật dữ liệu
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy kho để xóa.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
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