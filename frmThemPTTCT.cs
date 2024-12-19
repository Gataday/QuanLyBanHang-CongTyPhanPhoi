using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemPTTCT : Form
    {
        public frmThemPTTCT()
        {
            InitializeComponent();
        }

        // Sự kiện Load form để tải dữ liệu vào ComboBox
        private void frmThemPTTCT_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải dữ liệu từ cơ sở dữ liệu vào ComboBox
            LoadMaHangData();
            LoadSoPTTData1();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Phương thức để lấy dữ liệu từ bảng MaHang và hiển thị vào ComboBox
        private void LoadMaHangData()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            try
            {
                // Mở kết nối với cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu từ bảng MaHang
                    string query = "SELECT MaHang FROM ThanhToanChiTiet"; // Lấy cột MaHang từ bảng MaHang


                    // Tạo SqlDataAdapter để thực thi câu lệnh SQL
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);


                    // Tạo DataTable để lưu trữ dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);


                    // Kiểm tra nếu có dữ liệu trả về
                    if (dataTable.Rows.Count > 0)
                    {
                        // Gán DataTable vào ComboBox để hiển thị các mã hàng
                        cbMH.DataSource = dataTable;
                        cbMH.DisplayMember = "MaHang";  // Hiển thị cột MaHang trong ComboBox
                        cbMH.ValueMember = "MaHang";    // Giá trị lưu trữ là MaHang

                        // Tự động chọn phần tử đầu tiên trong ComboBox (nếu có)
                        cbMH.SelectedIndex = 0;

                    }
                    else
                    {
                        // Nếu không có dữ liệu, thông báo cho người dùng
                        MessageBox.Show("Không có mã hàng nào trong cơ sở dữ liệu.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, thông báo cho người dùng
                MessageBox.Show("Lỗi khi tải dữ liệu mã hàng: " + ex.Message);
            }
        }
        // Phương thức để lấy dữ liệu từ cột SoPTT trong cơ sở dữ liệu và gán vào ComboBox cbPTTCT
        private void LoadSoPTTData1()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            try
            {
                // Mở kết nối với cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu từ cột SoPTT trong bảng ThanhToan
                    string query = "SELECT SoPTT FROM ThanhToan";

                    // Tạo SqlDataAdapter để thực thi câu lệnh SQL
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo DataTable để lưu trữ dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Kiểm tra nếu có dữ liệu trả về
                    if (dataTable.Rows.Count > 0)
                    {
                        // Gán DataTable vào ComboBox để hiển thị các SoPTT
                        cbPTTCT.DataSource = dataTable;
                        cbPTTCT.DisplayMember = "SoPTT";  // Hiển thị cột SoPTT trong ComboBox
                        cbPTTCT.ValueMember = "SoPTT";    // Giá trị lưu trữ là SoPTT
                    }
                    else
                    {
                        // Nếu không có dữ liệu, thông báo cho người dùng
                        MessageBox.Show("Không có Số Phiếu Thanh Toán nào trong cơ sở dữ liệu.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, thông báo cho người dùng
                MessageBox.Show("Lỗi khi tải dữ liệu Số Phiếu Thanh Toán: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi người dùng thay đổi lựa chọn trong ComboBox (nếu cần)
        private void cbMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu bạn cần làm gì đó khi người dùng chọn mã hàng
            if (cbMH.SelectedIndex != -1) // Đảm bảo có mục được chọn
            {
                string selectedMaHang = cbMH.SelectedValue.ToString();
                
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại (frmThemPTTCT)
            this.Close();

            //// Mở lại form frmPhieuTTCT
            //frmPhieuTTCT frm = new frmPhieuTTCT();
            //frm.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển trên form
            string soPTT = cbPTTCT.Text.ToString();  // Lấy giá trị từ TextBox SoPTT
            string maHang = cbMH.SelectedValue.ToString();  // Lấy mã hàng từ ComboBox
            int soLuong = 0;
            decimal thanhTien = 0;

            // Kiểm tra nếu SoLuong và ThanhTien hợp lệ
            if (!int.TryParse(txtSL.Text.Trim(), out soLuong))  // Kiểm tra nếu nhập đúng kiểu số cho SoLuong
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            if (!decimal.TryParse(txtThanhTien.Text.Trim(), out thanhTien))  // Kiểm tra nếu nhập đúng kiểu số cho ThanhTien
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

            try
            {
                // Mở kết nối với cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu lệnh SQL để thêm dữ liệu vào bảng ThanhToanChiTiet
                    string query = "INSERT INTO ThanhToanChiTiet (SoPTT, MaHang, SoLuong, ThanhTien) " +
                                   "VALUES (@SoPTT, @MaHang, @SoLuong, @ThanhTien)";

                    // Tạo SqlCommand để thực thi câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@SoPTT", soPTT);
                        command.Parameters.AddWithValue("@MaHang", maHang);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@ThanhTien", thanhTien);

                        // Thực thi câu lệnh Insert
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra nếu dữ liệu được thêm thành công
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được lưu thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

    }
}
