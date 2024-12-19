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
    public partial class frmEditDHCT : Form
    {
        public frmEditDHCT(string maDH, string maHang, string soLuong, string thanhTien)
        {
            InitializeComponent();
            cbMDH.Text = maDH;
            cbMH.Text = maHang;
            txtSL.Text = soLuong;
            txtTT.Text = thanhTien;
        }
        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";


        private void frmEditDHCT_Load(object sender, EventArgs e)
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

                // Kiểm tra sự tồn tại của MaDH và MaHang trong bảng DatHangChiTiet
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để kiểm tra sự tồn tại của MaDH và MaHang trong bảng DatHangChiTiet
                    string checkQuery = "SELECT COUNT(*) FROM DatHangChiTiet WHERE MaDH = @MaDH AND MaHang = @MaHang";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@MaDH", maDatHang);
                    checkCmd.Parameters.AddWithValue("@MaHang", maHang);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // Nếu không tìm thấy bản ghi tương ứng, thông báo lỗi
                        MessageBox.Show("Mã đơn hàng và mã hàng không tồn tại trong bảng DatHangChiTiet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Ngừng thực hiện
                    }

                    // Nếu tìm thấy bản ghi, thực hiện cập nhật
                    string updateQuery = "UPDATE DatHangChiTiet SET SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaDH = @MaDH AND MaHang = @MaHang";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@MaDH", maDatHang);
                    updateCmd.Parameters.AddWithValue("@MaHang", maHang);
                    updateCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    updateCmd.Parameters.AddWithValue("@ThanhTien", tt);

                    // Thực thi câu lệnh UPDATE
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form sau khi cập nhật thành công
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
