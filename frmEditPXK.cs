using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmEditPXK : Form
    {
        private string soPXK, ngayXuat, lyDo, tongTien, maKho;

        public frmEditPXK(string soPXK, string ngayXuat, string lyDo, string tongTien, string maKho)
        {
            InitializeComponent();

            // Gán giá trị cho các biến
            this.soPXK = soPXK;
            this.ngayXuat = ngayXuat;
            this.lyDo = lyDo;
            this.tongTien = tongTien;
            this.maKho = maKho;

            // Tải dữ liệu lên ComboBox và hiển thị dữ liệu lên form
            LoadMaKhoToComboBox();
            LoadDataToForm();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại (frmEditPXK)

            // Hiển thị lại form frmXuatKho
            frmXuatKho frmXuatKho = new frmXuatKho();
            frmXuatKho.Show();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE XuatKho SET NgayXuat = @NgayXuat, LyDo = @LyDo, TongTien = @TongTien, MaKho = @MaKho WHERE SoPXK = @SoPXK";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SoPXK", soPXK);
                        cmd.Parameters.AddWithValue("@NgayXuat", dtpNgayXuat.Value);
                        cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text);
                        cmd.Parameters.AddWithValue("@TongTien", txtTongTien.Text);

                        // Lấy giá trị từ ComboBox MaKho
                        if (cbMaKho.SelectedItem != null)
                        {
                            cmd.Parameters.AddWithValue("@MaKho", cbMaKho.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn Mã Kho hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại form frmXuatKho
                this.Close(); // Đóng form frmEditPXK
                frmXuatKho frmXuatKho = new frmXuatKho();
                frmXuatKho.Show(); // Hiển thị form frmXuatKho
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMaKhoToComboBox()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "SELECT DISTINCT MaKho FROM Kho";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMaKho.Items.Add(reader["MaKho"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu MaKho: {ex.Message}");
            }
        }

        private void LoadDataToForm()
        {
            txtSoPXK.Text = soPXK;
            dtpNgayXuat.Value = DateTime.Parse(ngayXuat);
            txtLyDo.Text = lyDo;
            txtTongTien.Text = tongTien;

            // Thiết lập giá trị mặc định cho ComboBox
            cbMaKho.SelectedItem = maKho;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE XuatKho SET NgayXuat = @NgayXuat, LyDo = @LyDo, TongTien = @TongTien, MaKho = @MaKho WHERE SoPXK = @SoPXK";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SoPXK", soPXK);
                        cmd.Parameters.AddWithValue("@NgayXuat", dtpNgayXuat.Value);
                        cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text);
                        cmd.Parameters.AddWithValue("@TongTien", txtTongTien.Text);

                        // Lấy giá trị MaKho từ ComboBox
                        if (cbMaKho.SelectedItem != null)
                        {
                            cmd.Parameters.AddWithValue("@MaKho", cbMaKho.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn Mã Kho hợp lệ!");
                            return;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}