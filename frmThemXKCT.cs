using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemXKCT : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmThemXKCT()
        {
            InitializeComponent();
        }

        private void frmThemXKCT_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu vào ComboBox
            LoadComboBoxData();
        }

        // Phương thức để tải dữ liệu vào ComboBox
        private void LoadComboBoxData()
        {
            // Lấy dữ liệu cho cbSoPXK từ bảng XuatKho
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Truy vấn dữ liệu từ bảng XuatKho
                    string querySoPXK = "SELECT SoPXK FROM XuatKho";
                    SqlDataAdapter adapterSoPXK = new SqlDataAdapter(querySoPXK, con);
                    DataTable dtSoPXK = new DataTable();
                    adapterSoPXK.Fill(dtSoPXK);

                    // Thêm dữ liệu vào ComboBox cbSoPXK
                    cbSoPXK.DataSource = dtSoPXK;
                    cbSoPXK.DisplayMember = "SoPXK";  // Hiển thị giá trị của cột "SoPXK"
                    cbSoPXK.ValueMember = "SoPXK";    // Giá trị của ComboBox là "SoPXK"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu phiếu xuất kho: {ex.Message}");
            }

            // Lấy dữ liệu cho cbMaHang từ bảng HangHoaXuat
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Truy vấn dữ liệu từ bảng HangHoaXuat
                    string queryMaHang = "SELECT MaHang FROM HangHoaXuat";
                    SqlDataAdapter adapterMaHang = new SqlDataAdapter(queryMaHang, con);
                    DataTable dtMaHang = new DataTable();
                    adapterMaHang.Fill(dtMaHang);

                    // Thêm dữ liệu vào ComboBox cbMaHang
                    cbMaHang.DataSource = dtMaHang;
                    cbMaHang.DisplayMember = "MaHang";  // Hiển thị giá trị của cột "MaHang"
                    cbMaHang.ValueMember = "MaHang";    // Giá trị của ComboBox là "MaHang"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu mã hàng: {ex.Message}");
            }
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control trên form
            string soPXK = cbSoPXK.SelectedValue.ToString();
            string theoYC = txtTheoYC.Text;
            decimal thucXuat;
            decimal thanhTien;
            string maHang = cbMaHang.SelectedValue.ToString();

            // Kiểm tra dữ liệu nhập vào (có thể thêm kiểm tra chi tiết hơn nếu cần)
            if (string.IsNullOrEmpty(soPXK) || string.IsNullOrEmpty(theoYC) || string.IsNullOrEmpty(maHang)
                || !decimal.TryParse(txtThucXuat.Text, out thucXuat) || !decimal.TryParse(txtThanhTien.Text, out thanhTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Câu lệnh INSERT vào bảng XuatKhoChiTiet
            string query = "INSERT INTO XuatKhoChiTiet (SoPXK, MaHang, TheoYC, ThucXuat, ThanhTien) " +
                           "VALUES (@SoPXK, @MaHang, @TheoYC, @ThucXuat, @ThanhTien)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@SoPXK", soPXK);
                        cmd.Parameters.AddWithValue("@MaHang", maHang);
                        cmd.Parameters.AddWithValue("@TheoYC", theoYC);
                        cmd.Parameters.AddWithValue("@ThucXuat", thucXuat);
                        cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);

                        // Thực hiện câu lệnh INSERT
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được thêm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm dữ liệu vào bảng XuatKhoChiTiet.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}");
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại
            this.Hide();

            // Mở lại form frmXKCT (Giả sử frmXKCT đã được tạo từ form trước đó)
            frmXKCT frmXKCTForm = new frmXKCT();
            frmXKCTForm.Show();
        }

    }
}
