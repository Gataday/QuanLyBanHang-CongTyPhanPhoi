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
    public partial class frmEditNV : Form
    {
        private string MaNV, TenNV, ViTri;

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE NhanVien SET TenNV = @TenNV, ViTri = @ViTri where MaNV=@MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại form frmXuatKho
                this.Close(); // Đóng form frmEditPXK
                frmDSNhanVien frmNV = new frmDSNhanVien();
                frmNV.Show(); // Hiển thị form frmXuatKho
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            // Hiển thị lại form frmXuatKho
            frmDSNhanVien frmNV = new frmDSNhanVien();
            frmNV.Show();
        }

        public frmEditNV(string MaNV, string TenNV, string ViTri)
        {
            InitializeComponent();
            // Gán giá trị cho các biến
            this.MaNV = MaNV;
            this.TenNV = TenNV;
            this.ViTri = ViTri;
            LoadDataToForm();
        }
        private void LoadDataToForm()
        {
            txtMaNV.Text = MaNV;
            txtTenNV.Text = TenNV;
            txtViTri.Text = ViTri;
            txtMaNV.Enabled = false;
        }
    }
}
