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
    public partial class frmEditKho : Form
    {
        public frmEditKho()
        {
            InitializeComponent();
        }

        public void SetData(string maKho, string diaChi)
        {
            txtMaKho.Text = maKho; // Gán giá trị cho txtMaKho
            txtDiaChi.Text = diaChi; // Gán giá trị cho txtDiaChi
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string maKho = txtMaKho.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // Kiểm tra xem các TextBox có dữ liệu hợp lệ hay không
            if (string.IsNullOrEmpty(maKho) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kết nối đến cơ sở dữ liệu và thực hiện cập nhật
            using (SqlConnection connection = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False")) // Chuỗi kết nối
            {
                try
                {
                    connection.Open();
                    // Thực hiện câu lệnh UPDATE
                    string query = "UPDATE Kho SET DiaChi = @diaChi WHERE MaKho = @maKho";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@diaChi", diaChi);
                    command.Parameters.AddWithValue("@maKho", maKho);

                    int rowsAffected = command.ExecuteNonQuery(); // Thực hiện câu lệnh và lấy số hàng bị ảnh hưởng

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã kho để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }

            // Quay lại frmKho
            this.Hide();
            frmKho frmKho = new frmKho();
            frmKho.Show();
        }
    }
}
