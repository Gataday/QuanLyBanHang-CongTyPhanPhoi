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
    public partial class frmDSNhanVien : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;
        public frmDSNhanVien()
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
                    string query = "SELECT * FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DSNhanVien.DataSource = dataTable;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Định dạng hiển thị tên cột
                    DSNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân viên";
                    DSNhanVien.Columns["TenNV"].HeaderText = "Tên Nhân viên";
                    DSNhanVien.Columns["ViTri"].HeaderText = "Vị trí";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong bảng NhanVien!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }
        private void InitializeComboBox()
        {
            cbNhanVien.Items.Clear();
            cbNhanVien.Items.Add("MaNV");
            cbNhanVien.Items.Add("TenNV");
            cbNhanVien.Items.Add("ViTri");
        }

        private void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            DSNhanVien.AutoGenerateColumns = true;
            LoadData();
            InitializeComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường tìm kiếm!");
                return;
            }

            string searchField = cbNhanVien.SelectedItem.ToString();
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
                    string query = $"SELECT * FROM NhanVien WHERE {searchField} LIKE '%' + @SearchValue + '%'";
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

                        DSNhanVien.DataSource = searchTable;
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
            cbNhanVien.SelectedIndex = -1;
            txtTimKiem.Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSNhanVien.SelectedRows[0];
            string MaNV = selectedRow.Cells["MaNV"].Value.ToString();

            // Xác nhận xóa
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {MaNV} không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Câu lệnh xóa trong bảng nhacungcap
                        string deleteQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaNV", MaNV);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa nhân viên thành công!");
                                // Cập nhật lại DataGridView sau khi xóa
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhân viên để xóa.");
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
            frmThemNV frm = new frmThemNV();
            this.Hide();
            frm.Show();

        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            if (DSNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất kho để chỉnh sửa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSNhanVien.SelectedRows[0];
            string MaNV = selectedRow.Cells["MaNV"].Value.ToString();
            string TenNV = selectedRow.Cells["TenNV"].Value.ToString();
            string ViTri = selectedRow.Cells["ViTri"].Value.ToString();


            // Tạo và mở form chỉnh sửa (frmEditPXK)
            frmEditNV editForm = new frmEditNV(MaNV, TenNV, ViTri);
            this.Hide();
            editForm.Show();
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

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frmXuatKho = new frmXuatKho();
            this.Hide();
            frmXuatKho.Show();
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
            frmPhieuTTCT frmPhieuTTCT   = new frmPhieuTTCT();
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
