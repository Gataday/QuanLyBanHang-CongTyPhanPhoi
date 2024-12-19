using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemPXK : Form
    {
        public frmThemPXK()
        {
            InitializeComponent();
            LoadComboBoxData(); // Tải dữ liệu cho ComboBox cbMaKho khi form được khởi tạo
        }

        private void LoadComboBoxData()
        {
            try
            {
                string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Câu lệnh SQL để lấy danh sách MaKho từ bảng Kho
                    string query = "SELECT DISTINCT MaKho FROM Kho"; // Thay đổi bảng từ XuatKho sang Kho

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm từng giá trị MaKho vào ComboBox
                                cbMaKho.Items.Add(reader["MaKho"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu cho ComboBox MaKho: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmXuatKho xuatKhoForm = new frmXuatKho();
            this.Close();

            // Hiển thị form frmXuatKho
            xuatKhoForm.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox và combobox
            string soPXK = txtSoPXK.Text.Trim();
            string ngayXuat = dtpNgayXuat.Value.ToString("yyyy-MM-dd"); // Sử dụng DateTimePicker để chọn ngày
            string lyDo = txtLyDo.Text.Trim();
            string tongTien = txtTongTien.Text.Trim();
            string maKho = cbMaKho.SelectedItem?.ToString(); // Lấy giá trị được chọn trong ComboBox

            // Kiểm tra dữ liệu có được nhập đầy đủ hay không
            if (string.IsNullOrEmpty(soPXK) || string.IsNullOrEmpty(lyDo) || string.IsNullOrEmpty(tongTien) || string.IsNullOrEmpty(maKho))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra tổng tiền có phải số hay không
            if (!decimal.TryParse(tongTien, out decimal parsedTongTien))
            {
                MessageBox.Show("Tổng tiền phải là một số hợp lệ!");
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
                    string query = "INSERT INTO XuatKho (SoPXK, NgayXuat, LyDo, TongTien, MaKho) " +
                                   "VALUES (@SoPXK, @NgayXuat, @LyDo, @TongTien, @MaKho)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm tham số vào lệnh SQL
                        cmd.Parameters.AddWithValue("@SoPXK", soPXK);
                        cmd.Parameters.AddWithValue("@NgayXuat", ngayXuat);
                        cmd.Parameters.AddWithValue("@LyDo", lyDo);
                        cmd.Parameters.AddWithValue("@TongTien", parsedTongTien);
                        cmd.Parameters.AddWithValue("@MaKho", maKho);

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm phiếu xuất kho thành công!");

                            // Xóa dữ liệu trên form sau khi thêm thành công
                            txtSoPXK.Clear();
                            txtLyDo.Clear();
                            txtTongTien.Clear();
                            cbMaKho.SelectedIndex = -1;
                            dtpNgayXuat.Value = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm phiếu xuất kho. Vui lòng thử lại!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu xuất kho: {ex.Message}");
            }
        }

        private void cbMaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện nếu cần khi thay đổi lựa chọn trong ComboBox
        }
    }
}