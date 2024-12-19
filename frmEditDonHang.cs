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
    public partial class frmEditDonHang : Form
    {
        public frmEditDonHang(DataGridViewRow selectedRow, string maNV, string maKH)
        {
            InitializeComponent();
            // Gán giá trị từ selectedRow vào các TextBox hoặc điều khiển khác
            txtMD.Text = selectedRow.Cells["MaDH"].Value.ToString();
            txtTT.Text = selectedRow.Cells["TongTien"].Value.ToString();
            cbMKH.Text = maKH; // Gán mã khách hàng
            cbMNV.Text = maNV; // Gán mã nhân viên
            dtpNLD.Value = Convert.ToDateTime(selectedRow.Cells["NgayLDH"].Value); // Gán ngày
        }

        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";


        private void frmEditDonHang_Load(object sender, EventArgs e)
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
                    string query = "SELECT MaNV FROM NhanVien";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cbMNV.DataSource = dataTable;
                    cbMNV.DisplayMember = "MaNV"; // Hiển thị tên nhân viên
                    cbMNV.ValueMember = "MaNV";   // Giá trị tương ứng là mã nhân viên

                    // Gán giá trị đã chọn
                    if (!string.IsNullOrEmpty(cbMNV.Text))
                    {
                        cbMNV.SelectedValue = cbMNV.Text;
                    }
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
                    string query = "SELECT MaKH FROM KhachHang";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cbMKH.DataSource = dataTable;
                    cbMKH.DisplayMember = "MaKH"; // Hiển thị tên khách hàng
                    cbMKH.ValueMember = "MaKH";   // Giá trị tương ứng là mã khách hàng

                    // Gán giá trị đã chọn
                    if (!string.IsNullOrEmpty(cbMKH.Text))
                    {
                        cbMKH.SelectedValue = cbMKH.Text;
                    }
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

                // Kết nối cơ sở dữ liệu và cập nhật dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE DatHang SET MaNV = @MaNV, MaKH = @MaKH, NgayLDH = @NgayLDH, TongTien = @TongTien WHERE MaDH = @MaDH";

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
                            MessageBox.Show("Cập nhật đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Xóa dữ liệu sau khi cập nhật thành công
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy đơn hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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