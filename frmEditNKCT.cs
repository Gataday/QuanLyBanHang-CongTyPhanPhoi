using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmEditNKCT : Form
    {
        private int _selectedId;
        private string _maPNK;
        private string _theoCT;
        private decimal _thucNhap;
        private decimal _thanhTien;
        private string _maHang;

        // Connection string (make sure to replace with your actual connection string)
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        // Constructor accepting parameters for the fields
        public frmEditNKCT(string maPNK, string theoCT, decimal thucNhap, decimal thanhTien, string maHang)
        {
            InitializeComponent();

            _maPNK = maPNK;
            _theoCT = theoCT;
            _thucNhap = thucNhap;
            _thanhTien = thanhTien;
            _maHang = maHang;
        }

        private void frmEditNKCT_Load(object sender, EventArgs e)
        {
            // Populate the form fields with the passed data
            txtMaPNK.Text = _maPNK;
            txtTheoCT.Text = _theoCT;
            txtThucNhap.Text = _thucNhap.ToString();
            txtThanhTien.Text = _thanhTien.ToString();
            cbMaHang.SelectedItem = _maHang; // Assuming this is a combo box

            // Populate the ComboBox with MaHang from the HangHoaNhap table
            PopulateMaHangComboBox();
        }

        private void PopulateMaHangComboBox()
        {
            try
            {
                // Create a new connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // SQL query to get the MaHang from HangHoaNhap table
                    string query = "SELECT MaHang FROM HangHoaNhap";

                    // Create a SqlDataAdapter to fetch the data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    // Fill the DataTable with the data from the database
                    adapter.Fill(dt);

                    // Set the DataSource of the ComboBox
                    cbMaHang.DataSource = dt;
                    cbMaHang.DisplayMember = "MaHang";  // Column name to display in the ComboBox
                    cbMaHang.ValueMember = "MaHang";    // Value of the selected item
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            this.Hide();
            frmNKCT.Show();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the values from the form controls
                string maPNK = txtMaPNK.Text;
                string theoCT = txtTheoCT.Text;
                decimal thucNhap = decimal.Parse(txtThucNhap.Text);
                decimal thanhTien = decimal.Parse(txtThanhTien.Text);
                string maHang = cbMaHang.SelectedValue.ToString(); // Get the selected MaHang value

                // SQL query to update the record in the database
                string query = "UPDATE NhapKhoChiTiet SET TheoCT = @TheoCT, ThucNhap = @ThucNhap, ThanhTien = @ThanhTien, MaHang = @MaHang WHERE MaPNK = @MaPNK";

                // Create a new SQL connection and command
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameters to the command
                    cmd.Parameters.AddWithValue("@MaPNK", maPNK);
                    cmd.Parameters.AddWithValue("@TheoCT", theoCT);
                    cmd.Parameters.AddWithValue("@ThucNhap", thucNhap);
                    cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    cmd.Parameters.AddWithValue("@MaHang", maHang);

                    // Open the connection
                    conn.Open();

                    // Execute the update query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Show a message box indicating success (in Vietnamese)
                        DialogResult result = MessageBox.Show("Cập nhật thành công. Bạn có muốn quay lại màn hình chính không?", "Thành công", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            // Close the current form and open frmNKCT
                            frmNKCT frmNKCT = new frmNKCT();
                            this.Hide();
                            frmNKCT.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi với MaPNK đã chỉ định.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
