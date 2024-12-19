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
    public partial class frmThemNCC : Form
    {
        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox và combobox
            string MaNCC = txtMaNCC.Text.Trim();
            string TenNCC = txtTenNCC.Text.Trim();
            string TenNGH = txtTenNGH.Text.Trim();
            string STK = txtSTK.Text.Trim();
            string DiaChi = txtDiaChi.Text;
            string MaThue = txtMaThue.Text;

            // Kiểm tra dữ liệu có được nhập đầy đủ hay không
            if (string.IsNullOrEmpty(MaNCC) || string.IsNullOrEmpty(TenNCC) || string.IsNullOrEmpty(STK) || string.IsNullOrEmpty(DiaChi)
                || string.IsNullOrEmpty(MaThue) || string.IsNullOrEmpty(TenNGH))
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
                    string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, TenNGH, MaThue, DiaChi, STK) " +
                                   "VALUES (@MaNCC, @TenNCC, @TenNGH, @MaThue, @DiaChi, @STK)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm tham số vào lệnh SQL
                        cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                        cmd.Parameters.AddWithValue("@TenNCC", TenNCC);
                        cmd.Parameters.AddWithValue("@TenNGH", TenNGH);
                        cmd.Parameters.AddWithValue("@MaThue", MaThue);
                        cmd.Parameters.AddWithValue("@STK", STK);
                        cmd.Parameters.AddWithValue("@DiaChi", DiaChi);

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhà cấp thành công!");

                            // Xóa dữ liệu trên form sau khi thêm thành công
                            txtMaNCC.Clear();
                            txtTenNCC.Clear();
                            txtSTK.Clear();
                            txtDiaChi.Clear();
                            txtMaThue.Clear();
                            txtTenNGH.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm nhà cung cấp. Vui lòng thử lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap khForm = new frmDSNhaCungCap();
            this.Close();

            // Hiển thị form frmXuatKho
            khForm.Show();
        }

        private void frmThemNCC_Load(object sender, EventArgs e)
        {

        }
    }
}
