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
    public partial class frmThemKH : Form
    {
        public frmThemKH()
        {
            InitializeComponent();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox và combobox
            string MaKH = txtMaKH.Text.Trim();
            string TenKH = txtTenKH.Text.Trim();
            string SDTKH = txtSDTKH.Text.Trim();
            string DiaChi = txtDiaChi.Text;

            // Kiểm tra dữ liệu có được nhập đầy đủ hay không
            if (string.IsNullOrEmpty(MaKH) || string.IsNullOrEmpty(TenKH) || string.IsNullOrEmpty(SDTKH) || string.IsNullOrEmpty(DiaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }


            try
            {
                // Kết nối cơ sở dữ liệu
                string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Câu lệnh SQL để chèn dữ liệu
                    string query = "INSERT INTO KhachHang (MaKH, TenKH, SDTKH, DiaChiKH) " +
                                   "VALUES (@MaKH, @TenKH, @SDTKH, @DiaChiKH)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm tham số vào lệnh SQL
                        cmd.Parameters.AddWithValue("@MaKH", MaKH);
                        cmd.Parameters.AddWithValue("@TenKH", TenKH);
                        cmd.Parameters.AddWithValue("@SDTKH", SDTKH);
                        cmd.Parameters.AddWithValue("@DiaChiKH", DiaChi);

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm khách hàng thành công!");

                            // Xóa dữ liệu trên form sau khi thêm thành công
                            txtMaKH.Clear();
                            txtTenKH.Clear();
                            txtSDTKH.Clear();
                            txtDiaChi.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm khách hàng. Vui lòng thử lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmDSKhachHang khForm = new frmDSKhachHang();
            this.Close();

            // Hiển thị form frmXuatKho
            khForm.Show();
        }

        private void frmThemKH_Load(object sender, EventArgs e)
        {

        }
    }
}

