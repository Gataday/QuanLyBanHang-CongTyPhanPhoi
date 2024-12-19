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
    public partial class frmThemNKCT : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmThemNKCT()
        {
            InitializeComponent();
        }

        private void LoadComboBoxData()
        {
            // Lấy dữ liệu cho cbMaHang từ bảng HangHoaXuat
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Truy vấn dữ liệu từ bảng HangHoaXuat
                    string queryMaHang = "SELECT MaHang FROM HangHoaNhap";
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

        private void frmThemNKCT_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control trên form
            string soPNK = txtMaPNK.Text.ToString();
            string theoCT = txtTheoCT.Text;
            decimal thucNhap;
            decimal thanhTien;
            string maHang = cbMaHang.SelectedValue.ToString();

            // Kiểm tra dữ liệu nhập vào (có thể thêm kiểm tra chi tiết hơn nếu cần)
            if (string.IsNullOrEmpty(soPNK) || string.IsNullOrEmpty(theoCT) || string.IsNullOrEmpty(maHang)
                || !decimal.TryParse(txtThucNhap.Text, out thucNhap) || !decimal.TryParse(txtThanhTien.Text, out thanhTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin.");
                return;
            }

            // Câu lệnh INSERT vào bảng XuatKhoChiTiet
            string query = "INSERT INTO XuatKhoChiTiet (SoPNK, MaHang, TheoCT, ThucNhap, ThanhTien) " +
                           "VALUES (@SoPNK, @MaHang, @TheoCT, @ThucNhap, @ThanhTien)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@SoPNK", soPNK);
                        cmd.Parameters.AddWithValue("@MaHang", maHang);
                        cmd.Parameters.AddWithValue("@TheoYC", theoCT);
                        cmd.Parameters.AddWithValue("@ThucXuat", thucNhap);
                        cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);

                        // Thực hiện câu lệnh INSERT
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được thêm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm dữ liệu vào bảng NhapKhoChiTiet.");
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

            // Mở lại form frmNKCT 
            frmNhapKho frmNKCTForm = new frmNhapKho();
            frmNKCTForm.Show();
        }
    }
}
