using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmNKCT : Form
    {
        public frmNKCT()
        {
            InitializeComponent();
        }

        private void frmNKCT_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox và gán sự kiện SelectedIndexChanged
            InitializeComboBox();
            cbPNKCT.SelectedIndexChanged += cbPNKCT_SelectedIndexChanged;

            // Chuỗi kết nối đến cơ sở dữ liệu (cập nhật thông tin kết nối của bạn)
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Truy vấn SQL để lấy dữ liệu từ bảng NhapKhoChiTiet
            string query = "SELECT * FROM NhapKhoChiTiet";

            // Khai báo SqlConnection và SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // Tạo DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Điền dữ liệu vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable vào DataGridView
                DSPhieuNKCT.DataSource = dataTable;
            }
        }

        // Hàm tải danh sách cột từ bảng NhapKhoChiTiet vào ComboBox
        private void InitializeComboBox()
        {
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'NhapKhoChiTiet'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa các mục cũ trong ComboBox trước khi thêm mới
                    cbPNKCT.Items.Clear();

                    // Thêm các tên cột vào ComboBox
                    while (reader.Read())
                    {
                        cbPNKCT.Items.Add(reader["COLUMN_NAME"].ToString());
                    }

                    // Đóng SqlDataReader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách cột: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi chọn một mục trong ComboBox
        private void cbPNKCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cbPNKCT.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedColumn))
            {
                // Thực hiện hành động khi chọn cột, ví dụ như thay đổi thông tin tìm kiếm
                txtTimKiem.Text = ""; // Xóa nội dung tìm kiếm cũ khi chọn cột mới
            }
        }

        // Sự kiện nhấn nút tìm kiếm
        
        private void bnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập dữ liệu cần tìm kiếm chưa
                string searchValue = txtTimKiem.Text.Trim();
                string searchColumn = cbPNKCT.SelectedItem?.ToString(); // Lấy tên cột chọn từ ComboBox

                if (string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Vui lòng nhập giá trị cần tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(searchColumn))
                {
                    MessageBox.Show("Vui lòng chọn cột tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi kết nối tới cơ sở dữ liệu
                string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

                // Câu truy vấn SQL tìm kiếm theo cột và giá trị
                string query = $@"
            SELECT * 
            FROM NhapKhoChiTiet
            WHERE [{searchColumn}] LIKE @searchValue";

                // Kết nối và thực thi truy vấn
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu lệnh SQL với tham số
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán kết quả tìm kiếm vào DataGridView
                    DSPhieuNKCT.DataSource = dataTable;

                    // Hiển thị thông báo nếu không có kết quả
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa nội dung trong ComboBox và TextBox
                cbPNKCT.SelectedIndex = -1;  // Đặt ComboBox về trạng thái không có lựa chọn
                txtTimKiem.Clear();          // Xóa nội dung TextBox tìm kiếm

                // Làm mới lại DataGridView, có thể để trống hoặc hiển thị tất cả dữ liệu
                string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
                string query = "SELECT * FROM NhapKhoChiTiet"; // Truy vấn lấy lại toàn bộ dữ liệu

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Gán lại DataTable vào DataGridView
                    DSPhieuNKCT.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            frmThemNKCT frmThemNKCT = new frmThemNKCT();
            this.Hide();
            frmThemNKCT.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng trong DataGridView hay chưa
            if (DSPhieuNKCT.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = DSPhieuNKCT.SelectedRows[0];
                string maPNK = selectedRow.Cells["MaPNK"].Value.ToString(); // Thay "MaPNK" bằng tên cột thực tế
                string theoCT = selectedRow.Cells["TheoCT"].Value.ToString(); // Thay "TheoCT" bằng tên cột thực tế
                decimal thucNhap = Convert.ToDecimal(selectedRow.Cells["ThucNhap"].Value); // Thay "ThucNhap" bằng tên cột thực tế
                decimal thanhTien = Convert.ToDecimal(selectedRow.Cells["ThanhTien"].Value); // Thay "ThanhTien" bằng tên cột thực tế
                string maHang = selectedRow.Cells["MaHang"].Value.ToString(); // Lấy giá trị từ cột "MaHang"

                // Khởi tạo form frmEditNKCT và truyền các tham số cần thiết vào
                frmEditNKCT frmEdit = new frmEditNKCT(maPNK, theoCT, thucNhap, thanhTien, maHang);

                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị form frmEditNKCT
                frmEdit.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn dòng trong DataGridView hay chưa
                if (DSPhieuNKCT.SelectedRows.Count > 0)
                {
                    // Hiển thị MessageBox xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa phiếu nhập kho chi tiết này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Nếu người dùng chọn Yes, tiếp tục xóa
                    if (result == DialogResult.Yes)
                    {
                        // Lấy dữ liệu từ dòng được chọn trong DataGridView
                        DataGridViewRow selectedRow = DSPhieuNKCT.SelectedRows[0];
                        string maPNK = selectedRow.Cells["MaPNK"].Value.ToString(); // Thay "MaPNK" bằng tên cột khóa chính thực tế

                        // Câu lệnh SQL để xóa dữ liệu
                        string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
                        string query = "DELETE FROM NhapKhoChiTiet WHERE MaPNK = @maPNK"; // Thay "MaPNK" bằng tên cột khóa chính thực tế

                        // Kết nối đến cơ sở dữ liệu và thực thi câu lệnh SQL xóa
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@maPNK", maPNK);

                            int rowsAffected = command.ExecuteNonQuery(); // Thực thi câu lệnh xóa

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Dữ liệu đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Làm mới lại DataGridView sau khi xóa
                                string refreshQuery = "SELECT * FROM NhapKhoChiTiet"; // Truy vấn lấy lại toàn bộ dữ liệu
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(refreshQuery, connection);
                                DataTable dataTable = new DataTable();
                                dataAdapter.Fill(dataTable);

                                DSPhieuNKCT.DataSource = dataTable; // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.Show();
        }

        private void thanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            this.Hide();
            frmPhieuTTCT.Show();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            this.Hide();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }
}
