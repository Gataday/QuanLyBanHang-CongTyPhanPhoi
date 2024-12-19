using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmEditPTT : Form
    {
        private readonly string selectedSoPTT;
        private readonly string selectedMaNV;
        private readonly DateTime selectedNgayTT;
        private readonly string selectedPmethod;
        private readonly decimal selectedTongTien;
        private readonly decimal selectedVAT;
        private readonly string selectedMaNCC;

        private readonly string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";

        public frmEditPTT(string soPTT, string maNV, DateTime ngayTT, string pmethod, decimal tongTien, decimal vat, string maNCC)
        {
            InitializeComponent();

            selectedSoPTT = soPTT;
            selectedMaNV = maNV;
            selectedNgayTT = ngayTT;
            selectedPmethod = pmethod;
            selectedTongTien = tongTien;
            selectedVAT = vat;
            selectedMaNCC = maNCC;
        }

        private void frmEditPTT_Load(object sender, EventArgs e)
        {
            try
            {
                // Display values in controls
                txtSoPTT.Text = selectedSoPTT;
                txtPayMT.Text = selectedPmethod;
                txtVAT.Text = selectedVAT.ToString("F2");
                txtTongTien.Text = selectedTongTien.ToString("F2");
                dtpNgayTT.Value = selectedNgayTT;

                LoadComboBoxData();

                // Set selected values in ComboBoxes
                cbMaNV.SelectedValue = selectedMaNV;
                cbMaNCC.SelectedValue = selectedMaNCC;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu mẫu: " + ex.Message);
            }
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Load MaNV into ComboBox
                    LoadComboBox(conn, "SELECT MaNV FROM NhanVien", cbMaNV);

                    // Load MaNCC into ComboBox
                    LoadComboBox(conn, "SELECT MaNCC FROM NhaCungCap", cbMaNCC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message);
                }
            }
        }

        private void LoadComboBox(SqlConnection conn, string query, ComboBox comboBox)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = dt.Columns[0].ColumnName;
                comboBox.ValueMember = dt.Columns[0].ColumnName;
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmPTT().Show(); // Show the main form
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc một cách chính xác.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE ThanhToan SET MaNV = @MaNV, NgayTT = @NgayTT, Pmethod = @Pmethod, VAT = @VAT, TongTien = @TongTien, MaNCC = @MaNCC WHERE SoPTT = @SoPTT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoPTT", selectedSoPTT);
                        cmd.Parameters.AddWithValue("@MaNV", cbMaNV.SelectedValue);
                        cmd.Parameters.AddWithValue("@NgayTT", dtpNgayTT.Value);
                        cmd.Parameters.AddWithValue("@Pmethod", txtPayMT.Text);
                        cmd.Parameters.AddWithValue("@VAT", decimal.Parse(txtVAT.Text));
                        cmd.Parameters.AddWithValue("@TongTien", decimal.Parse(txtTongTien.Text));
                        cmd.Parameters.AddWithValue("@MaNCC", cbMaNCC.SelectedValue);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công.");
                            this.Close();
                            new frmPTT().Show();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy bản ghi với Số PTT đã chỉ định.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật bản ghi: " + ex.Message);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPayMT.Text) ||
                string.IsNullOrWhiteSpace(txtVAT.Text) ||
                string.IsNullOrWhiteSpace(txtTongTien.Text) ||
                cbMaNV.SelectedValue == null ||
                cbMaNCC.SelectedValue == null)
            {
                return false;
            }

            if (!decimal.TryParse(txtVAT.Text, out _) ||
                !decimal.TryParse(txtTongTien.Text, out _))
            {
                return false;
            }

            return true;
        }
    }
}
