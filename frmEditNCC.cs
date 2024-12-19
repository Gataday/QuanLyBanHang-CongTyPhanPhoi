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
    public partial class frmEditNCC : Form
    {
        private string MaNCC, TenNCC, TenNGH, MaThue, DiaChi, STK;

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            // Hiển thị lại form frmXuatKho
            frmDSNhaCungCap frmKH = new frmDSNhaCungCap();
            frmKH.Show();
        }

        public frmEditNCC(string MaNCC, string TenNCC,string TenNGH, string MaThue, string DiaChi, string STK)
        {
            InitializeComponent();
            this.MaNCC = MaNCC;
            this.TenNCC = TenNCC;
            this.TenNGH = TenNGH;
            this.MaThue = MaThue;
            this.DiaChi = DiaChi;
            this. STK = STK;
            LoadDataToForm();
        }
        private void LoadDataToForm()
        {
            txtMaNCC.Text = MaNCC;
            txtTenNCC.Text = TenNCC;
            txtTenNGH.Text = TenNGH;
            txtMaThue.Text = MaThue;
            txtDiaChi.Text = DiaChi;
            txtSTK.Text = STK;
            txtMaNCC.Enabled = false;
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, TenNGH = @TenNGH, MaThue=@MaThue, DiaChi = @DiaChi, STK=@STK where MaNCC=@MaNCC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                        cmd.Parameters.AddWithValue("@TenNGH", txtTenNGH.Text);
                        cmd.Parameters.AddWithValue("@MaThue", txtMaThue.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@STK", txtSTK.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại form frmXuatKho
                this.Close(); // Đóng form frmEditPXK
                frmDSNhaCungCap frmNCC = new frmDSNhaCungCap();
                frmNCC.Show(); // Hiển thị form frmXuatKho
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
