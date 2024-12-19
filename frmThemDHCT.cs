using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemDHCT : Form
    {
        public frmThemDHCT()
        {
            InitializeComponent();
        }

        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        private void ThemDHCT_Load(object sender, EventArgs e)
        {
            LoadMaHang();
            LoadMaDonHang();
        }

        private void LoadMaHang()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy dữ liệu MaHang từ bảng DatHangChiTiet hoặc bảng liên quan
                    string query = "SELECT DISTINCT MaHang FROM DatHangChiTiet";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Gán danh sách mã hàng vào ComboBox
                    cbMH.DisplayMember = "MaHang";  // Hiển thị giá trị trong cột MaHang
                    cbMH.ValueMember = "MaHang";    // Lấy giá trị là MaHang khi chọn
                    cbMH.DataSource = dataTable;    // Gán DataTable làm nguồn dữ liệu cho ComboBox
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi tải mã hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMaDonHang()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy dữ liệu MaHang từ bảng DatHangChiTiet hoặc bảng liên quan
                    string query = "SELECT DISTINCT MaDH FROM DatHang";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Gán danh sách mã hàng vào ComboBox
                    cbMDH.DisplayMember = "MaDH";  // Hiển thị giá trị trong cột MaHang
                    cbMDH.ValueMember = "MaDH";    // Lấy giá trị là MaHang khi chọn
                    cbMDH.DataSource = dataTable;    // Gán DataTable làm nguồn dữ liệu cho ComboBox
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi tải mã hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong các TextBox
                
                txtTT.Clear();
                txtSL.Clear();
             

                // Đặt lại trạng thái mặc định của ComboBox
                cbMH.SelectedIndex = -1; // Không chọn mục nào
                cbMDH.SelectedIndex = -1;


                // Đóng form hiện tại
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện hủy thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng đã nhập dữ liệu đầy đủ
                if (cbMDH.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTT.Text) || string.IsNullOrWhiteSpace(txtSL.Text) || cbMH.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các TextBox và ComboBox
                string maDatHang = cbMDH.SelectedValue.ToString();
                string tt = txtTT.Text.Trim();
                int soLuong = int.Parse(txtSL.Text.Trim());
                string maHang = cbMH.SelectedValue.ToString();

                // Kiểm tra sự tồn tại của MaDH trong bảng DatHang
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để kiểm tra sự tồn tại của MaDH trong bảng DatHang
                    string checkMaDHQuery = "SELECT COUNT(*) FROM DatHang WHERE MaDH = @MaDH";
                    SqlCommand checkCmd = new SqlCommand(checkMaDHQuery, connection);
                    checkCmd.Parameters.AddWithValue("@MaDH", maDatHang);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // Nếu MaDH không tồn tại trong bảng DatHang, thông báo cho người dùng
                        MessageBox.Show("Mã đơn hàng không tồn tại trong bảng DatHang.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Ngừng thực hiện
                    }

                    // Nếu MaDH tồn tại, tiếp tục thực hiện câu lệnh INSERT vào bảng DatHangChiTiet
                    string query = "INSERT INTO DatHangChiTiet (MaDH, MaHang, SoLuong, ThanhTien) VALUES (@MaDH, @MaHang, @SoLuong, @ThanhTien)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDH", maDatHang);
                    command.Parameters.AddWithValue("@MaHang", maHang);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@ThanhTien", tt);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form sau khi lưu thành công
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
