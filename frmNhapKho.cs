using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmNhapKho : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadColumnNamesToComboBox();
        }

        public void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM NhapKho";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DSPhieuNK.DataSource = dataTable;
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong bảng NhapKho!");
                }
                else
                {
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }

        private void FormatDataGridView()
        {
            if (dataTable.Columns.Contains("SoPNK"))
                DSPhieuNK.Columns["MaPNK"].HeaderText = "Mã phiếu nhập kho";

            if (dataTable.Columns.Contains("NgayNhap"))
                DSPhieuNK.Columns["NgayNhap"].HeaderText = "Ngày Nhập";

            if (dataTable.Columns.Contains("MaNCC"))
                DSPhieuNK.Columns["MaNCC"].HeaderText = "MaNCC";

            if (dataTable.Columns.Contains("TongTien"))
                DSPhieuNK.Columns["TongTien"].HeaderText = "Tổng tiền";

            if (dataTable.Columns.Contains("MaKho"))
                DSPhieuNK.Columns["MaKho"].HeaderText = "Mã kho";
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho xuatKhoForm = new frmXuatKho();
            xuatKhoForm.Show();
            this.Hide();
        }

        private void LoadColumnNamesToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'NhapKho'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cbPNK.Items.Clear();
                        while (reader.Read())
                        {
                            cbPNK.Items.Add(reader["COLUMN_NAME"].ToString());
                        }

                        if (cbPNK.Items.Count > 0)
                        {
                            cbPNK.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cột: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn: " + cbPNK.SelectedItem.ToString(), "Thông báo");
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectedColumn = cbPNK.SelectedItem?.ToString(); // Use null-conditional operator
                    string searchValue = txtTimKiem.Text.Trim();

                    if (string.IsNullOrEmpty(selectedColumn))
                    {
                        MessageBox.Show("Vui lòng chọn một cột để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrEmpty(searchValue))
                    {
                        MessageBox.Show("Vui lòng nhập giá trị cần tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = $"SELECT * FROM NhapKho WHERE [{selectedColumn}] LIKE @searchValue";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchValue", $"%{searchValue}%");

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable resultTable = new DataTable();
                            dataAdapter.Fill(resultTable);
                            DSPhieuNK.DataSource = resultTable;

                            if (resultTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.Clear();
                if (cbPNK.Items.Count > 0)
                {
                    cbPNK.SelectedIndex = 0;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lại dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                frmThemPNK themPNKForm = new frmThemPNK();
                themPNKForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển sang form thêm phiếu nhập kho: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frm = new frmXKCT();
            this.Hide();
            frm.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            if (DSPhieuNK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập kho để chỉnh sửa!");
                return;
            }

            DataGridViewRow selectedRow = DSPhieuNK.SelectedRows[0];
            string soPNK = selectedRow.Cells["MaPNK"].Value.ToString();
            string ngayNhap = selectedRow.Cells["NgayNhap"].Value.ToString();
            string MaNCC = selectedRow.Cells["MaNCC"].Value.ToString();
            string tongTien = selectedRow.Cells["TongTien"].Value.ToString();
            string maKho = selectedRow.Cells["MaKho"].Value.ToString();

            frmEditPNK editForm = new frmEditPNK(soPNK, ngayNhap, MaNCC, tongTien, maKho);
            this.Hide();
            editForm.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (DSPhieuNK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập kho để xóa!");
                return;
            }

            DataGridViewRow selectedRow = DSPhieuNK.SelectedRows[0];
            string maPNK = selectedRow.Cells["MaPNK"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show($"Phiếu nhập kho có mã phiếu: {maPNK} có thể có các chi tiết liên quan trong bảng NhapKhoChiTiet. Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string checkQuery = "SELECT COUNT(*) FROM NhapKhoChiTiet WHERE MaPNK = @MaPNK";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@MaPNK", maPNK);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                string deleteDetailsQuery = "DELETE FROM NhapKhoChiTiet WHERE MaPNK = @MaPNK";
                                using (SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, con))
                                {
                                    deleteDetailsCmd.Parameters.AddWithValue("@MaPNK", maPNK);
                                    deleteDetailsCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        string deleteQuery = "DELETE FROM NhapKho WHERE MaPNK = @MaPNK";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaPNK", maPNK);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa phiếu nhập kho và chi tiết thành công!");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy phiếu nhập kho để xóa.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Thao tác xóa đã bị hủy.");
            }
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frmDSKhachHang = new frmDSKhachHang();
            this.Hide();
            frmDSKhachHang.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap frmDSNhaCungCap = new frmDSNhaCungCap();
            this.Hide();
            frmDSNhaCungCap.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien();
            this.Hide();
            frmDSNhanVien.Show();
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frmNhapKho = new frmNhapKho();
            this.Hide();
            frmNhapKho.Show();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPTT frmPTT = new frmPTT();
            this.Hide();
            frmPTT.Show();
        }

        private void hàngHóaNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHNhap frmHHNhap = new frmHHNhap();
            this.Hide();
            frmHHNhap.Show();
        }

        private void hàngHóaXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHHXuat frmHHXuat = new frmHHXuat();
            this.Hide();
            frmHHXuat.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frmKho = new frmKho();
            this.Hide();
            frmKho.Show();
        }

        private void thanhToánChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTTCT frmPhieuTTCT = new frmPhieuTTCT();
            this.Hide();
            frmPhieuTTCT.Show();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            this.Hide();
            frmDonHang.Show();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }
}