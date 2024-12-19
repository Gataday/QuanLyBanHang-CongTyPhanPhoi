using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmXKCT : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;

        public frmXKCT()
        {
            InitializeComponent();
        }

        // Sự kiện khi form được tải
        private void frmXKCT_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM XuatKhoChiTiet";  // Truy vấn lấy dữ liệu từ bảng XuatKhoChiTiet
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);  // Đổ dữ liệu vào DataTable

                    // Gán DataTable vào DataGridView
                    DSPhieuXKCT.DataSource = dataTable;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Định dạng hiển thị tên cột (nếu cần)
                    DSPhieuXKCT.Columns["SoPXK"].HeaderText = "Số phiếu xuất kho chi tiết";
                    DSPhieuXKCT.Columns["TheoYC"].HeaderText = "Theo yêu cầu";
                    DSPhieuXKCT.Columns["ThucXuat"].HeaderText = "Thực xuất";
                    DSPhieuXKCT.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    DSPhieuXKCT.Columns["MaHang"].HeaderText = "Mã hàng";

                    // Hiển thị tên cột vào combobox cbPXK
                    cbPXK.Items.Clear();  // Xóa tất cả các mục cũ trong combobox
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        cbPXK.Items.Add(column.ColumnName);  // Thêm tên cột vào combobox
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong bảng XuatKhoChiTiet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một dòng trong DataGridView chưa
            if (DSPhieuXKCT.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DSPhieuXKCT.SelectedRows[0];

                // Lấy giá trị từ các cột cần thiết
                string soPXK = selectedRow.Cells["SoPXK"].Value?.ToString();
                string theoYC = selectedRow.Cells["TheoYC"].Value?.ToString();
                string thucXuat = selectedRow.Cells["ThucXuat"].Value?.ToString();
                string thanhTien = selectedRow.Cells["ThanhTien"].Value?.ToString();
                string maHang = selectedRow.Cells["MaHang"].Value?.ToString();

                if (!string.IsNullOrEmpty(soPXK))
                {
                    // Tạo đối tượng frmEditXKCT và truyền các giá trị vào constructor
                    frmEditXKCT formEditXKCT = new frmEditXKCT(soPXK, theoYC, thucXuat, thanhTien, maHang);

                    // Ẩn form hiện tại
                    this.Hide();

                    // Hiển thị form frmEditXKCT
                    formEditXKCT.Show();
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin phiếu xuất kho chi tiết. Vui lòng thử lại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất kho chi tiết trước khi chỉnh sửa.");
            }
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ txtTimKiem và cbPXK
                string searchText = txtTimKiem.Text.Trim();
                string selectedColumn = cbPXK.SelectedItem?.ToString();

                // Kiểm tra nếu không có giá trị tìm kiếm hoặc không chọn cột
                if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(selectedColumn))
                {
                    MessageBox.Show("Vui lòng nhập giá trị tìm kiếm và chọn cột để tìm kiếm.");
                    return;
                }

                // Tạo DataView để lọc dữ liệu từ DataTable
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = $"[{selectedColumn}] LIKE '%{searchText}%'"; // Tìm kiếm chuỗi chứa giá trị

                // Gán DataView vào DataGridView để hiển thị kết quả
                DSPhieuXKCT.DataSource = dataView;

                if (dataView.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
            }
        }

        private void bnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong cbPXK và txtTimKiem
                cbPXK.SelectedIndex = -1; // Bỏ chọn mục trong combobox
                txtTimKiem.Clear(); // Xóa nội dung trong textbox

                // Làm mới DataGridView với dữ liệu gốc từ DataTable
                if (dataTable != null)
                {
                    DSPhieuXKCT.DataSource = dataTable; // Gán lại dữ liệu gốc
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để làm mới.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}");
            }
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một instance của form frmThemXKCT
                frmThemXKCT formThemXKCT = new frmThemXKCT();

                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị form frmThemXKCT
                formThemXKCT.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi mở form thêm phiếu xuất kho chi tiết: {ex.Message}");
            }
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một instance của form frmXuatKho
                frmXuatKho formXuatKho = new frmXuatKho();

                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị form frmXuatKho
                formXuatKho.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi mở form Quản lý xuất kho: {ex.Message}");
            }
        }

        private void bnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn một dòng trong DataGridView chưa
                if (DSPhieuXKCT.SelectedRows.Count > 0)
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = DSPhieuXKCT.SelectedRows[0];
                    string soPXK = selectedRow.Cells["SoPXK"].Value?.ToString();

                    // Kiểm tra nếu có mã phiếu xuất kho chi tiết
                    if (!string.IsNullOrEmpty(soPXK))
                    {
                        // Hiển thị hộp thoại xác nhận
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Phiếu xuất kho chi tiết này?",
                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        // Nếu người dùng nhấn "Yes"
                        if (dialogResult == DialogResult.Yes)
                        {
                            using (SqlConnection con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                string query = "DELETE FROM XuatKhoChiTiet WHERE SoPXK = @SoPXK"; // Truy vấn xóa dữ liệu

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    // Thêm tham số để tránh SQL injection
                                    cmd.Parameters.AddWithValue("@SoPXK", soPXK);

                                    // Thực thi câu lệnh xóa
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    // Kiểm tra nếu xóa thành công
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Phiếu xuất kho chi tiết đã được xóa.");
                                        LoadData(); // Tải lại dữ liệu sau khi xóa
                                    }
                                    else
                                    {
                                        MessageBox.Show("Không tìm thấy phiếu xuất kho chi tiết cần xóa.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy thông tin phiếu xuất kho chi tiết. Vui lòng thử lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phiếu xuất kho chi tiết trước khi xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa dữ liệu: {ex.Message}");
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

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXKCT frmXKCT = new frmXKCT();
            this.Hide();
            frmXKCT.Show();
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