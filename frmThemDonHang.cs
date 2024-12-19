using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemDonHang : Form
    {
        public frmThemDonHang()
        {
            InitializeComponent();
        }

        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        private void frmThemDonHang_Load(object sender, EventArgs e)
        {
            // Gọi các phương thức để tải dữ liệu vào ComboBox
            LoadNhanVienData();
            LoadKhachHangData();
        }

        private void LoadNhanVienData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy danh sách nhân viên
                    string query = "SELECT MaNV FROM NhanVien";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Gán dữ liệu vào ComboBox cbMNV
                    cbMNV.DataSource = dataTable;
                    cbMNV.DisplayMember = "MaNV"; // Hiển thị tên nhân viên
                    cbMNV.ValueMember = "MaNV";   // Giá trị tương ứng là mã nhân viên
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKhachHangData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy danh sách khách hàng
                    string query = "SELECT MaKH FROM KhachHang";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Gán dữ liệu vào ComboBox cbMKH
                    cbMKH.DataSource = dataTable;
                    cbMKH.DisplayMember = "MaKH"; // Hiển thị tên khách hàng
                    cbMKH.ValueMember = "MaKH";   // Giá trị tương ứng là mã khách hàng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong các TextBox
                txtMD.Clear();
                txtTT.Clear();

                // Đặt lại trạng thái mặc định của ComboBox
                cbMNV.SelectedIndex = -1; // Không chọn mục nào
                cbMKH.SelectedIndex = -1;

                // Đặt lại DateTimePicker về ngày hiện tại
                dtpNLD.Value = DateTime.Now;

                // Đóng form hiện tại
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện hủy thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm xóa dữ liệu sau khi thêm

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox và ComboBox
                string maDonHang = txtMD.Text.Trim();
                string maNhanVien = cbMNV.SelectedValue?.ToString();
                string maKhachHang = cbMKH.SelectedValue?.ToString();
                DateTime ngayLapDon = dtpNLD.Value;
                string tongTien = txtTT.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maDonHang) || string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(tongTien))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kết nối cơ sở dữ liệu và lưu dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO DatHang (MaDH, MaNV, MaKH, NgayLDH, TongTien) " +
                                   "VALUES (@MaDH, @MaNV, @MaKH, @NgayLDH, @TongTien)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDH", maDonHang);
                        command.Parameters.AddWithValue("@MaNV", maNhanVien);
                        command.Parameters.AddWithValue("@MaKH", maKhachHang);
                        command.Parameters.AddWithValue("@NgayLDH", ngayLapDon);
                        command.Parameters.AddWithValue("@TongTien", tongTien);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Xóa dữ liệu sau khi thêm thành công
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Thêm đơn hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm xóa dữ liệu sau khi thêm
        private void ClearInputFields()
        {
            txtMD.Clear();
            txtTT.Clear();
            cbMNV.SelectedIndex = -1;
            cbMKH.SelectedIndex = -1;
            dtpNLD.Value = DateTime.Now;
        }

    }
}
