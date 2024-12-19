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
    public partial class frmDSKhachHang : Form
    {
        private string connectionString = "Data Source=ctpp2.database.windows.net;Initial Catalog=CTPhanPhoi;User ID=ctphanphoi2;Password=48k212@2;Encrypt=False";
        private DataTable dataTable;
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        private void frmDSKhachHang_Load(object sender, EventArgs e)
        {
            DSKhachHang.AutoGenerateColumns = true;
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
                    string query = "SELECT * FROM KhachHang";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DSKhachHang.DataSource = dataTable;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Định dạng hiển thị tên cột
                    DSKhachHang.Columns["MaKH"].HeaderText = "Mã Khách hàng";
                    DSKhachHang.Columns["TenKH"].HeaderText = "Tên";
                    DSKhachHang.Columns["SDTKH"].HeaderText = "Số điện thoại";
                    DSKhachHang.Columns["DiaChiKH"].HeaderText = "Địa chỉ";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong bảng KhachHang!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn dữ liệu: {ex.Message}");
            }
        }
        private void InitializeComboBox()
        {
            cbKH.Items.Clear();
            cbKH.Items.Add("MaKH");
            cbKH.Items.Add("TenKH");
            cbKH.Items.Add("SDTKH");
            cbKH.Items.Add("DiaChiKH");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbKH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trường tìm kiếm!");
                return;
            }

            string searchField = cbKH.SelectedItem.ToString();
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
                    string query = $"SELECT * FROM KhachHang WHERE {searchField} LIKE '%' + @SearchValue + '%'";
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

                        DSKhachHang.DataSource = searchTable;
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
            cbKH.SelectedIndex = -1;
            txtTimKiem.Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (DSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSKhachHang.SelectedRows[0];
            string MaKH = selectedRow.Cells["MaKH"].Value.ToString();

            // Xác nhận xóa
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {MaKH} không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Câu lệnh xóa trong bảng KhachHang
                        string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaKH", MaKH);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa khách hàng thành công!");
                                // Cập nhật lại DataGridView sau khi xóa
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng để xóa.");
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
            frmThemKH frm = new frmThemKH();
            this.Hide();
            frm.Show();
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            if (DSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa!");
                return;
            }

            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = DSKhachHang.SelectedRows[0];
            string MaKH = selectedRow.Cells["MaKH"].Value.ToString();
            string TenKH = selectedRow.Cells["TenKH"].Value.ToString();
            string SDTKH = selectedRow.Cells["SDTKH"].Value.ToString();
            string DiaChiKH = selectedRow.Cells["DiaChiKH"].Value.ToString();
            

            // Tạo và mở form chỉnh sửa (frmEditPXK)
            frmEditKH editForm = new frmEditKH(MaKH, TenKH, SDTKH, DiaChiKH);
            this.Hide();
            editForm.Show();
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

        private void quảnLýNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            this.Hide();
            frm.Show();
        }

        private void quảnLýXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            this.Hide();
            frm.Show();
        }

        private void xuấtKhoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
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
