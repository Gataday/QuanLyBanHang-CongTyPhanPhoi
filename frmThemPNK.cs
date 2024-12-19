using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemPNK : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmThemPNK()
        {
            InitializeComponent();
        }

        private void frmThemPNK_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Lấy danh sách mã kho từ bảng Kho
                    string query = "SELECT DISTINCT MaKho FROM Kho"; 

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm từng giá trị MaKho vào ComboBox cbMaKho
                                cbMaKho.Items.Add(reader["MaKho"].ToString());
                            }
                        }
                    }

                    // Lấy danh sách mã nhà cung cấp từ bảng NhaCungCap
                    string queryNCC = "SELECT MaNCC FROM NhaCungCap"; 

                    using (SqlCommand cmd = new SqlCommand(queryNCC, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm từng giá trị MaNCC vào ComboBox cbMaNCC
                                cbMaNCC.Items.Add(reader["MaNCC"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ComboBox: {ex.Message}");
            }
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtSoPNK.Text))
            {
                MessageBox.Show("Vui lòng nhập số phiếu nhập kho!");
                return;
            }

            if (cbMaKho.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã kho!");
                return;
            }

            if (cbMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhà cung cấp!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Thêm phiếu nhập kho vào bảng NhapKho
                    string query = "INSERT INTO NhapKho (SoPNK, NgayNhap, MaKho, MaNCC) VALUES (@SoPNK, @NgayNhap, @MaKho, @MaNCC)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SoPNK", txtSoPNK.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                    cmd.Parameters.AddWithValue("@TongTien", txtTongTien.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaKho", cbMaKho.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MaNCC", cbMaNCC.SelectedItem.ToString());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phiếu nhập kho thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm phiếu nhập kho. Vui lòng kiểm tra lại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu nhập kho: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại (frmThemPNK)
            this.Hide();

            // Tạo và hiển thị form frmNhapKho
            frmNhapKho frm = new frmNhapKho();
            frm.Show();
        }


        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic xử lý khi thay đổi nhà cung cấp (nếu cần)
        }

        private void cbMaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic xử lý khi thay đổi kho (nếu cần)
        }
    }
}
