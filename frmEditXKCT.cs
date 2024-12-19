using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmEditXKCT : Form
    {
        private string soPXK;
        private string theoYC;
        private string thucXuat;
        private string thanhTien;
        private string maHang;

        public frmEditXKCT(string soPXK, string theoYC, string thucXuat, string thanhTien, string maHang)
        {
            InitializeComponent();

            this.soPXK = soPXK;
            this.theoYC = theoYC;
            this.thucXuat = thucXuat;
            this.thanhTien = thanhTien;
            this.maHang = maHang;

            // Gán các giá trị vào các điều khiển trên form
            cbSoPXK.Text = soPXK;
            txtTheoYC.Text = theoYC;
            txtThucXuat.Text = thucXuat;
            txtThanhTien.Text = thanhTien;
            cbMaHang.Text = maHang;

            // Gọi hàm để tải dữ liệu vào comboboxes
            LoadSoPXK();
            LoadMaHang();
        }

        private void LoadSoPXK()
        {
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"; // Thay thế bằng chuỗi kết nối của bạn
            string query = "SELECT SoPXK FROM XuatKho";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbSoPXK.Items.Add(reader["SoPXK"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu SoPXK: " + ex.Message);
            }
        }

        private void LoadMaHang()
        {
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"; // Thay thế bằng chuỗi kết nối của bạn
            string query = "SELECT MaHang FROM HangHoaXuat";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMaHang.Items.Add(reader["MaHang"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu MaHang: " + ex.Message);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng frmXKCT
            frmXKCT formXKCT = new frmXKCT();

            // Đóng form hiện tại (frmEditXKCT)
            this.Hide(); // Hoặc bạn có thể sử dụng `this.Close();` nếu muốn đóng hoàn toàn form

            // Hiển thị form frmXKCT
            formXKCT.Show();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ các điều khiển trên form
            string soPXK = cbSoPXK.Text;
            string theoYC = txtTheoYC.Text;
            string thucXuat = txtThucXuat.Text;
            string thanhTien = txtThanhTien.Text;
            string maHang = cbMaHang.Text;

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Câu lệnh SQL để cập nhật dữ liệu
            string query = "UPDATE XuatKhoChiTiet SET TheoYC = @TheoYC, ThucXuat = @ThucXuat, ThanhTien = @ThanhTien, MaHang = @MaHang WHERE SoPXK = @SoPXK";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL để tránh lỗi SQL injection
                        command.Parameters.AddWithValue("@SoPXK", soPXK);
                        command.Parameters.AddWithValue("@TheoYC", theoYC);
                        command.Parameters.AddWithValue("@ThucXuat", thucXuat);
                        command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        command.Parameters.AddWithValue("@MaHang", maHang);

                        // Thực thi câu lệnh
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Nếu cập nhật thành công, hiển thị hộp thông báo
                            DialogResult result = MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Cập nhật thành công", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                            // Nếu người dùng nhấn OK, chuyển đến form frmXKCT
                            if (result == DialogResult.OK)
                            {
                                // Tạo đối tượng frmXKCT
                                frmXKCT formXKCT = new frmXKCT();

                                // Đóng form hiện tại (frmEditXKCT)
                                this.Hide();

                                // Hiển thị form frmXKCT
                                formXKCT.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
