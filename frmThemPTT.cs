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
    public partial class frmThemPTT : Form
    {
        public frmThemPTT()
        {
            InitializeComponent();
        }

        private void frmThemPTT_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng NhanVien (MaNV)
                    string queryNV = "SELECT MaNV FROM NhanVien";
                    SqlDataAdapter dataAdapterNV = new SqlDataAdapter(queryNV, connection);
                    DataTable dataTableNV = new DataTable();
                    dataAdapterNV.Fill(dataTableNV);

                    // Thêm dữ liệu từ bảng NhanVien vào ComboBox cbMaNV
                    cbMaNV.Items.Clear(); // Xóa các mục hiện tại
                    foreach (DataRow row in dataTableNV.Rows)
                    {
                        cbMaNV.Items.Add(row["MaNV"].ToString());
                    }

                    // Truy vấn dữ liệu từ bảng NhaCungCap (MaNCC)
                    string queryNCC = "SELECT MaNCC FROM NhaCungCap";
                    SqlDataAdapter dataAdapterNCC = new SqlDataAdapter(queryNCC, connection);
                    DataTable dataTableNCC = new DataTable();
                    dataAdapterNCC.Fill(dataTableNCC);

                    // Thêm dữ liệu từ bảng NhaCungCap vào ComboBox cbMaNCC
                    cbMaNCC.Items.Clear(); // Xóa các mục hiện tại
                    foreach (DataRow row in dataTableNCC.Rows)
                    {
                        cbMaNCC.Items.Add(row["MaNCC"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng frmPTT
            frmPTT frm = new frmPTT();

            // Ẩn form hiện tại (frmThemPTT)
            this.Hide();

            // Hiển thị form frmPTT
            frm.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển trên form
            string maNV = cbMaNV.SelectedItem.ToString(); // Lấy MaNV từ ComboBox
            string maNCC = cbMaNCC.SelectedItem.ToString(); // Lấy MaNCC từ ComboBox
            string soPTT = txtSoPTT.Text.Trim(); // Lấy số phiếu thanh toán từ TextBox
            DateTime ngayTT = dtpNgayTT.Value; // Lấy ngày thanh toán từ DateTimePicker
            string payMT = txtPayMT.Text.Trim(); // Lấy số tiền mặt từ TextBox
            decimal vat = decimal.Parse(txtVAT.Text.Trim()); // Lấy số VAT từ TextBox
            decimal tongTien = decimal.Parse(txtTongTien.Text.Trim()); // Lấy tổng tiền từ TextBox

            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL INSERT để thêm dữ liệu vào bảng ThanhToan
                    string query = "INSERT INTO ThanhToan (MaNV, MaNCC, SoPTT, NgayTT, Pmethod, VAT, TongTien) " +
                                   "VALUES (@MaNV, @MaNCC, @SoPTT, @NgayTT, @PayMT, @VAT, @TongTien)";

                    // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Thêm tham số vào câu lệnh SQL để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@SoPTT", soPTT);
                    cmd.Parameters.AddWithValue("@NgayTT", ngayTT);
                    cmd.Parameters.AddWithValue("@PayMT", payMT);
                    cmd.Parameters.AddWithValue("@VAT", vat);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    // Thực thi câu lệnh SQL
                    int result = cmd.ExecuteNonQuery();

                    // Kiểm tra kết quả
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

    }
}
