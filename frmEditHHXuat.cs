﻿using System;
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
    public partial class frmEditHHXuat : Form
    {
        public frmEditHHXuat()
        {
            InitializeComponent();
        }
        public frmEditHHXuat(DataGridViewRow selectedRow)
        {
            InitializeComponent();

            // Gán giá trị từ selectedRow vào các TextBox hoặc điều khiển khác
            cbMH.Text = selectedRow.Cells["DVT"].Value.ToString();
            txtTH.Text = selectedRow.Cells["TenHang"].Value.ToString();
            txtDGX.Text = selectedRow.Cells["DonGiaXuat"].Value.ToString();
            txtDVT.Text = selectedRow.Cells["MaHang"].Value.ToString();
            // Thêm các cột khác nếu cần
        }
        // Connection string to your database
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        private void frmEditHHXuat_Load(object sender, EventArgs e)
        {
            LoadMaHangToComboBox();
        }
        private void LoadMaHangToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn SQL để lấy các giá trị từ cột DVT trong bảng HangHoaXuat
                    string query = "SELECT DVT FROM HangHoaXuat";

                    // Sử dụng SqlCommand để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa các mục cũ trong ComboBox trước khi thêm mới
                    cbMH.Items.Clear();

                    // Đọc dữ liệu và thêm vào ComboBox
                    while (reader.Read())
                    {
                        cbMH.Items.Add(reader["DVT"].ToString());
                    }

                    // Đóng SqlDataReader
                    reader.Close();

                    // Tùy chọn, có thể chọn mặc định một item trong ComboBox
                    if (cbMH.Items.Count > 0)
                    {
                        cbMH.SelectedIndex = 0; // Chọn item đầu tiên nếu có
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong các TextBox
                txtTH.Text = string.Empty; // Giả sử bạn có TextBox tên là txtMaHang
                txtDVT.Text = string.Empty; // Giả sử bạn có TextBox tên là txtTenHang
                txtDGX.Text = string.Empty; // Giả sử bạn có TextBox tên là txtSoLuong

                // Đặt lại ComboBox về giá trị mặc định
                cbMH.SelectedIndex = -1; // Đặt ComboBox không chọn item nào

                // Nếu có thể, đặt lại các combobox khác nếu có
                // Ví dụ:
                // cbDanhMuc.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các TextBox và ComboBox
                string dvt = cbMH.SelectedItem?.ToString(); // Lấy giá trị MaHang từ ComboBox
                string tenHang = txtTH.Text.Trim();  // Lấy giá trị Tên Hàng từ TextBox
                string maHang = txtDVT.Text.Trim();     // Lấy giá trị Đơn Vị Tính từ TextBox
                string giaXuat = txtDGX.Text.Trim(); // Lấy giá trị Giá Xuất từ TextBox

                // Kiểm tra các trường bắt buộc đã được nhập chưa
                if (string.IsNullOrEmpty(maHang) || string.IsNullOrEmpty(tenHang) || string.IsNullOrEmpty(dvt) || string.IsNullOrEmpty(giaXuat))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Câu lệnh SQL UPDATE để cập nhật dữ liệu trong bảng HangHoaXuat
                string query = "UPDATE HangHoaXuat SET TenHang = @TenHang, DVT = @DVT, DonGiaXuat = @DonGiaXuat WHERE MaHang = @MaHang";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    connection.Open();

                    // Tạo câu lệnh SQL
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thêm các tham số vào câu lệnh SQL để tránh SQL injection
                    command.Parameters.AddWithValue("@MaHang", maHang);
                    command.Parameters.AddWithValue("@TenHang", tenHang);
                    command.Parameters.AddWithValue("@DVT", dvt);
                    command.Parameters.AddWithValue("@DonGiaXuat", giaXuat);

                    // Thực thi câu lệnh SQL
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Có thể thêm mã để reset lại form sau khi cập nhật thành công, nếu cần.
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

    }
}