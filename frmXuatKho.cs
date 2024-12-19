using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmXuatKho : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;

        public frmXuatKho()
        {
            InitializeComponent();
        }

        // Sự kiện khi form được tải
        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            DSPhieuXK.AutoGenerateColumns = true;
            LoadData();
            InitializeComboBox();
        }

        public void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM XuatKho";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DSPhieuXK.DataSource = dataTable;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Định dạng hiển thị tên cột
                    DSPhieuXK.Columns["SoPXK"].HeaderText = "Số phiếu xuất kho";
                    DSPhieuXK.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                    DSPhieuXK.Columns["LyDo"].HeaderText = "Lý do";
                    DSPhieuXK.Columns["TongTien"].HeaderText = "Tổng tiền";
                    DSPhieuXK.Columns["MaKho"].HeaderText = "Mã kho";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong bảng XuatKho!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }

        private void InitializeComboBox()
        {
            cbPXK.Items.Clear();
            cbPXK.Items.Add("SoPXK");
            cbPXK.Items.Add("NgayXuat");
            cbPXK.Items.Add("LyDo");
            cbPXK.Items.Add("TongTien");
            cbPXK.Items.Add("MaKho");
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            if (cbPXK.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường tìm kiếm!");
                return;
            }

            string searchField = cbPXK.SelectedItem.ToString();
            string searchValue = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị cần tìm kiếm!");
                return;
            }

            SearchData(searchField, searchValue);
        }


        private void SearchData(string searchField, string searchValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Kiểm tra nếu tên cột hợp lệ
                    if (!dataTable.Columns.Contains(searchField))
                    {
                        MessageBox.Show("Trường tìm kiếm không hợp lệ!");
                        return;
                    }

                    // Loại bỏ khoảng trắng không cần thiết trong giá trị tìm kiếm
                    searchValue = searchValue.Trim();

                    // Chuẩn bị truy vấn SQL
                    string query = $"SELECT * FROM XuatKho WHERE {searchField} LIKE '%' + @SearchValue + '%'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@SearchValue", searchValue);

                        // Thực thi và gán dữ liệu vào bảng
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable searchTable = new DataTable();
                        adapter.Fill(searchTable);

                        // Kiểm tra nếu không có dữ liệu trả về
                        if (searchTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                        }

                        DSPhieuXK.DataSource = searchTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
            }
        }


        private void bnClear_Click(object sender, EventArgs e)
        {
            LoadData();
            cbPXK.SelectedIndex = -1;
            txtTimKiem.Clear();
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            frmThemPXK frm = new frmThemPXK();
            this.Hide();
            frm.Show();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            this.Hide();
            frm.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSPhieuXK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất kho để chỉnh sửa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSPhieuXK.SelectedRows[0];
            string soPXK = selectedRow.Cells["SoPXK"].Value.ToString();
            string ngayXuat = selectedRow.Cells["NgayXuat"].Value.ToString();
            string lyDo = selectedRow.Cells["LyDo"].Value.ToString();
            string tongTien = selectedRow.Cells["TongTien"].Value.ToString();
            string maKho = selectedRow.Cells["MaKho"].Value.ToString();

            // Tạo và mở form chỉnh sửa (frmEditPXK)
            frmEditPXK editForm = new frmEditPXK(soPXK, ngayXuat, lyDo, tongTien, maKho);
            this.Hide();
            editForm.Show();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị form frmXKCT
            frmXKCT frm = new frmXKCT();
            this.Hide();  // Ẩn form hiện tại (frmXuatKho)
            frm.Show();   // Hiển thị form frmXKCT
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSPhieuXK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất kho để xóa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSPhieuXK.SelectedRows[0];
            string soPXK = selectedRow.Cells["SoPXK"].Value.ToString();

            // Kiểm tra xem có bản ghi nào trong bảng XuatKhoChiTiet với SoPXK này không
            DialogResult dialogResult = MessageBox.Show($"Phiếu xuất kho có số phiếu: {soPXK} có thể có các chi tiết liên quan trong bảng XuatKhoChiTiet. Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Kiểm tra xem có bản ghi nào trong bảng XuatKhoChiTiet với SoPXK này không
                        string checkQuery = "SELECT COUNT(*) FROM XuatKhoChiTiet WHERE SoPXK = @SoPXK";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@SoPXK", soPXK);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                // Nếu có bản ghi trong XuatKhoChiTiet, xóa chúng trước
                                string deleteDetailsQuery = "DELETE FROM XuatKhoChiTiet WHERE SoPXK = @SoPXK";
                                using (SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, con))
                                {
                                    deleteDetailsCmd.Parameters.AddWithValue("@SoPXK", soPXK);
                                    deleteDetailsCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Xóa bản ghi trong bảng XuatKho
                        string deleteQuery = "DELETE FROM XuatKho WHERE SoPXK = @SoPXK";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@SoPXK", soPXK);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa phiếu xuất kho và chi tiết thành công!");
                                // Cập nhật lại DataGridView sau khi xóa
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy phiếu xuất kho để xóa.");
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

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            this.Hide();
            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhachHang frm = new frmDSKhachHang();
            this.Hide();
            frm.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhaCungCap frm = new frmDSNhaCungCap();
            this.Hide();
            frm.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNhanVien frm = new frmDSNhanVien();
            this.Hide();
            frm.Show();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPTT frmPTT = new frmPTT();
            this.Hide();
            frmPTT.Show();
        }

        private void nhậpKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            this.Hide();
            frmNKCT.Show();
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
