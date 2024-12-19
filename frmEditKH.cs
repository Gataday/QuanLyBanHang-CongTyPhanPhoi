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
    public partial class frmEditKH : Form
    {
        private string MaKH, TenKH, SDTKH, DiaChiKH;
        public frmEditKH(string MaKH, string TenKH, string SDTKH, string DiaChiKH)
        {
            InitializeComponent();
            // Gán giá trị cho các biến
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.SDTKH = SDTKH;
            this.DiaChiKH = DiaChiKH;
            LoadDataToForm();
        }
        private void LoadDataToForm()
        {
            txtMaKH.Text = MaKH;
            txtTenKH.Text = TenKH;
            txtSDTKH.Text = SDTKH;
            txtDiaChi.Text = DiaChiKH;
            txtMaKH.Enabled = false;
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE KhachHang SET TenKH = @TenKH, SDTKH = @SDTKH, DiaChiKH = @DiaChiKH where MaKH=@MaKH";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@SDTKH", txtSDTKH.Text);
                        cmd.Parameters.AddWithValue("@DiaChiKH", txtDiaChi.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại form frmXuatKho
                this.Close(); // Đóng form frmEditPXK
                frmDSKhachHang frmKH = new frmDSKhachHang();
                frmKH.Show(); // Hiển thị form frmXuatKho
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
            frmDSKhachHang frmKH = new frmDSKhachHang();
            frmKH.Show();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
