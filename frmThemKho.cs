using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmThemKho : Form
    {
        // Connection string (make sure to replace with your actual connection string)
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmThemKho()
        {
            InitializeComponent();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            // Close the current form (frmThemKho)
            this.Hide();

            // Show the frmKho form
            frmKho frmThemKho = new frmKho();
            frmThemKho.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the values from the form controls
                string maKho = txtMaKho.Text; // Assuming there's a TextBox for MaKho
              
                string diaChi = txtDiaChi.Text; // Assuming there's a TextBox for DiaChi
              
                // SQL query to insert the new record into the Kho table
                string query = "INSERT INTO Kho (MaKho,  DiaChi) VALUES (@MaKho,@DiaChi)";

                // Create a new SQL connection and command
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameters to the command
                    cmd.Parameters.AddWithValue("@MaKho", maKho);
                   
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                 

                    // Open the connection
                    conn.Open();

                    // Execute the insert query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Dữ liệu đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optionally, close the form and open another form (like frmKho)
                        this.Hide();
                        frmKho frmKho = new frmKho();
                        frmKho.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu dữ liệu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
