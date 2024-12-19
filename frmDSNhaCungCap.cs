using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDSNhaCungCap : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;
        public frmDSNhaCungCap()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM NhaCungCap";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DSNhaCungCap.DataSource = dataTable;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Định dạng hiển thị tên cột
                    DSNhaCungCap.Columns["MaNCC"].HeaderText = "Mã Nhà cung cấp";
                    DSNhaCungCap.Columns["TenNCC"].HeaderText = "Tên Nhà cung cấp";
                    DSNhaCungCap.Columns["TenNGH"].HeaderText = "Tên Người giao hàng";
                    DSNhaCungCap.Columns["MaThue"].HeaderText = "Mã số thuế";
                    DSNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    DSNhaCungCap.Columns["STK"].HeaderText = "Số tài khoản";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong bảng NhaCungCap!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }

        private void InitializeComboBox()
        {
            cbNCC.Items.Clear();
            cbNCC.Items.Add("MaNCC");
            cbNCC.Items.Add("TenNCC");
            cbNCC.Items.Add("TenNGH");
            cbNCC.Items.Add("MaThue");
            cbNCC.Items.Add("DiaChi");
            cbNCC.Items.Add("STK");
        }
        private void frmNCC_Load(object sender, EventArgs e)
        {
            DSNhaCungCap.AutoGenerateColumns = true;
            LoadData();
            InitializeComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường tìm kiếm!");
                return;
            }

            string searchField = cbNCC.SelectedItem.ToString();
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
                    string query = $"SELECT * FROM NhaCungCap WHERE {searchField} LIKE '%' + @SearchValue + '%'";
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

                        DSNhaCungCap.DataSource = searchTable;
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
            cbNCC.SelectedIndex = -1;
            txtTimKiem.Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSNhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSNhaCungCap.SelectedRows[0];
            string MaNCC = selectedRow.Cells["MaNCC"].Value.ToString();

            // Xác nhận xóa
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp {MaNCC} không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Câu lệnh xóa trong bảng nhacungcap
                        string deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa nhà cung cấp thành công!");
                                // Cập nhật lại DataGridView sau khi xóa
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhà cung cấp để xóa.");
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

        private void bnCreate_Click(object sender, EventArgs e)
        {
            frmThemNCC frm = new frmThemNCC();
            this.Hide();
            frm.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSNhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để chỉnh sửa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSNhaCungCap.SelectedRows[0];
            string MaNCC = selectedRow.Cells["MaNCC"].Value.ToString();
            string TenNCC = selectedRow.Cells["TenNCC"].Value.ToString();
            string TenNGH = selectedRow.Cells["TenNGH"].Value.ToString();
            string MaThue = selectedRow.Cells["MaThue"].Value.ToString();
            string DiaChi = selectedRow.Cells["DiaChi"].Value.ToString();
            string STK = selectedRow.Cells["STK"].Value.ToString();

            // Tạo và mở form chỉnh sửa (frmEditPXK)
            frmEditNCC editForm = new frmEditNCC(MaNCC, TenNCC, TenNGH, MaThue, DiaChi, STK);
            this.Hide();
            editForm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSKhachHang frm = new frmDSKhachHang();
            this.Hide();
            frm.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSNhaCungCap frm = new frmDSNhaCungCap();
            this.Hide();
            frm.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSNhanVien frm = new frmDSNhanVien();
            this.Hide();
            frm.Show();
        }

        private void quảnLýNhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            this.Hide();
            frm.Show();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            this.Hide();
            frm.Show();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmXKCT frm = new frmXKCT();
            this.Hide();
            frm.Show();
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

        private void nhậpKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNKCT frmNKCT = new frmNKCT();
            this.Hide();
            frmNKCT.Show();
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
            frmDonHang.ShowDialog();
        }

        private void đặtHàngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatHangCT frmDatHangCT = new frmDatHangCT();
            frmDatHangCT.ShowDialog();
        }
    }
}
