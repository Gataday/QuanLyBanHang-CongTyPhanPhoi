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
    public partial class frmThemNV : Form
    {
        public frmThemNV()
        {
            InitializeComponent();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox và combobox
            string MaNV =txtMaNV.Text.Trim();
            string TenNV = txtTenNV.Text.Trim();
            string ViTri = txtViTri.Text.Trim();

            // Kiểm tra dữ liệu có được nhập đầy đủ hay không
            if (string.IsNullOrEmpty(MaNV) || string.IsNullOrEmpty(TenNV) || string.IsNullOrEmpty(ViTri))
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
                    string query = "INSERT INTO NhanVien (MaNV, TenNV, ViTri)" +
                                   "VALUES (@MaNV, @TenNV, @ViTri)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm tham số vào lệnh SQL
                        cmd.Parameters.AddWithValue("@MaNV", MaNV);
                        cmd.Parameters.AddWithValue("@TenNV", TenNV);
                        cmd.Parameters.AddWithValue("@ViTri", ViTri);

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhân viên thành công!");

                            // Xóa dữ liệu trên form sau khi thêm thành công
                            txtMaNV.Clear();
                            txtTenNV.Clear();
                            txtViTri.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm nhân viên. Vui lòng thử lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmDSNhanVien nvForm = new frmDSNhanVien();
            this.Close();

            // Hiển thị form frmXuatKho
            nvForm.Show();
        }
    }
}
