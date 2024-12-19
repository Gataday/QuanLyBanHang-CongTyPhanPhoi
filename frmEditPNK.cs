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
    public partial class frmEditPNK : Form
    {
        private string maPNK, ngayNhap, MaNCC, tongTien, maKho;

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu và cập nhật thông tin phiếu xuất kho
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "UPDATE NhapKho SET NgayNhap = @NgayNhap, MaNCC = @MaNCC, TongTien = @TongTien, MaKho = @MaKho WHERE maPNK = @maPNK";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@maPNK", maPNK);
                        cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                        cmd.Parameters.AddWithValue("@MaNCC", cbMaNCC.Text);
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

                // Quay lại form frmNhapKho
                this.Close(); // Đóng form frmEditPXK
                frmNhapKho frmNhapKho = new frmNhapKho();
                frmNhapKho.Show(); // Hiển thị form frmNhapKho
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại (frmEditPXK)

            // Hiển thị lại form frmNhapKho
            frmNhapKho frmNhapKho = new frmNhapKho();
            frmNhapKho.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {

        }

        public frmEditPNK(string maPNK, string ngayNhap, string MaNCC, string tongTien, string maKho)
        {
            InitializeComponent();
            // Gán giá trị cho các biến
            this.maPNK = maPNK;
            this.ngayNhap = ngayNhap;
            this.MaNCC = MaNCC;
            this.tongTien = tongTien;
            this.maKho = maKho;

            // Tải dữ liệu lên ComboBox và hiển thị dữ liệu lên form
            LoadMaKhoToComboBox();
            LoadDataToForm();
            LoadMaKhoToComboBoxNCC();
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
        private void LoadMaKhoToComboBoxNCC()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False"))
                {
                    con.Open();
                    string query = "SELECT DISTINCT MaNCC FROM NhaCungCap";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMaNCC.Items.Add(reader["MaNCC"].ToString());
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
            txtSoPNK.Text = maPNK;
            dtpNgayNhap.Value = DateTime.Parse(ngayNhap);
            txtTongTien.Text = tongTien;

            // Thiết lập giá trị mặc định cho ComboBox MaNCC
            if (cbMaNCC.Items.Contains(MaNCC))
            {
                cbMaNCC.SelectedItem = MaNCC;
            }
            else
            {
                cbMaNCC.Text = MaNCC; // Hiển thị giá trị nếu không tồn tại trong danh sách Items
            }

            // Thiết lập giá trị mặc định cho ComboBox MaKho
            if (cbMaKho.Items.Contains(maKho))
            {
                cbMaKho.SelectedItem = maKho;
            }
            else
            {
                cbMaKho.Text = maKho; // Hiển thị giá trị nếu không tồn tại trong danh sách Items
            }
        }

    }
}
