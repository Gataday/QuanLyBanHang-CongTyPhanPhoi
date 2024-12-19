using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmEditPTTCT : Form
    {
        public string SoPTT { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }

        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmEditPTTCT()
        {
            InitializeComponent();
        }

        private void frmEditPTTCT_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu vào ComboBox
            LoadComboBoxData();

            // Gán giá trị cho các ComboBox và TextBox
            cbSoPTT.SelectedItem = SoPTT; // Gán giá trị cho ComboBox SoPTT
            cbMaHang.SelectedItem = MaHang; // Gán giá trị cho ComboBox MaHang
            txtSoLuong.Text = SoLuong.ToString(); // Gán giá trị cho TextBox SoLuong
            txtThanhTien.Text = ThanhTien.ToString(); // Định dạng thành tiền cho TextBox ThanhTien
        }

        private void LoadComboBoxData()
        {
            // Nạp dữ liệu vào cbSoPTT từ bảng ThanhToan
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string querySoPTT = "SELECT SoPTT FROM ThanhToan";

                using (SqlCommand command = new SqlCommand(querySoPTT, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cbSoPTT.Items.Add(reader["SoPTT"].ToString());
                    }
                }
            }

            // Nạp dữ liệu vào cbMaHang từ bảng HangHoaNhap
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryMaHang = "SELECT MaHang FROM HangHoaNhap";

                using (SqlCommand command = new SqlCommand(queryMaHang, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cbMaHang.Items.Add(reader["MaHang"].ToString());
                    }
                }
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển
            string soPTT = cbSoPTT.SelectedItem?.ToString();
            string maHang = cbMaHang.SelectedItem?.ToString();
            int soLuong;
            decimal thanhTien;

            // Kiểm tra và chuyển đổi dữ liệu
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtThanhTien.Text, out thanhTien))
            {
                MessageBox.Show("Thành tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật dữ liệu vào bảng ThanhToanChiTiet
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE ThanhToanChiTiet SET MaHang = @MaHang, SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE SoPTT = @SoPTT";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@SoPTT", soPTT);
                    command.Parameters.AddWithValue("@MaHang", maHang);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@ThanhTien", thanhTien);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có bản ghi nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form hiện tại
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}