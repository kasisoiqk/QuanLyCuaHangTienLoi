using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCuaHangTienLoi
{

    public partial class frmMainQuanLy : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        private string State = "Reset";

        public static string username = string.Empty;
        public static string password = string.Empty;
        public frmMainQuanLy()
        {
            InitializeComponent();

            GetData();
        }

        public void GetData()
        {
            query = "SELECT * FROM Staffs";
            DataSet ds = ketNoiDB.GetDataSet(query);

            DataColumn colViewGioiTinh = new DataColumn();
            colViewGioiTinh.ColumnName = "View_GioiTinh";
            ds.Tables[0].Columns.Add(colViewGioiTinh);

            DataColumn colMaNV = new DataColumn();
            colMaNV.ColumnName = "MaNV";
            ds.Tables[0].Columns.Add(colMaNV);

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Gender"].ToString().Trim().Equals("1"))
                {
                    ds.Tables[0].Rows[i]["View_GioiTinh"] = "Nam";
                }
                else
                {
                    ds.Tables[0].Rows[i]["View_GioiTinh"] = "Nữ";
                }

                ds.Tables[0].Rows[i]["MaNV"] = "NV" + ds.Tables[0].Rows[i]["ID"].ToString();
                
            }

            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = ds.Tables[0];

            lblTongSo.Text = "Tổng số: " + ds.Tables[0].Rows.Count + " bản ghi.";
            SetControls(State);
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            
            if(RowIndex >= 0 && RowIndex < dgvStaff.Rows.Count -1)
            {
                DataGridViewRow selectedRow = dgvStaff.Rows[RowIndex];
                txtHoTen.Text = selectedRow.Cells["colHo"].Value.ToString().Trim() + " " 
                    + selectedRow.Cells["colTen"].Value.ToString().Trim();
                dtpNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["colNgaySinh"].Value);
                nudCa.Value = int.Parse(selectedRow.Cells["colSoCa"].Value.ToString().Trim());
                txtQueQuan.Text = selectedRow.Cells["colQueQuan"].Value.ToString().Trim();
                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString().Trim();

                if(selectedRow.Cells["View_GioiTinh"].Value.ToString().Equals("Nam"))
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
            }
            
        }

        public void SetControls(string State)
        {

            switch(State)
            {
                case "Reset":
                    dgvStaff.Enabled = true;

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnGhiDuLieu.Enabled = false;
                    btnBoQua.Enabled = false;

                    txtQueQuan.Enabled = false;
                    txtHoTen.Enabled = false;
                    nudCa.Enabled = false;

                    rdoNam.Checked = true;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;
                    dtpNgaySinh.Enabled = false;

                    break;

                case "Insert":
                    dgvStaff.Enabled = false;

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhiDuLieu.Enabled = true;
                    btnBoQua.Enabled = true;

                    txtQueQuan.Enabled = true;
                    txtHoTen.Enabled = true;
                    nudCa.Enabled = true;

                    rdoNam.Checked = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    dtpNgaySinh.Enabled = true;

                    txtHoTen.Text = "";
                    txtQueQuan.Text = "";
                    dtpNgaySinh.Value = DateTime.Now;
                    nudCa.Value = 0;
                    txtMaNV.Text = "";

                    break;

                case "Update":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhiDuLieu.Enabled = true;
                    btnBoQua.Enabled = true;

                    txtQueQuan.Enabled = true;
                    txtHoTen.Enabled = true;
                    nudCa.Enabled = true;

                    rdoNam.Checked = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    dtpNgaySinh.Enabled = true;

                    break;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            State = "Reset";
            SetControls(State);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Equals(""))
            {
                lblLoi.Text = "Bạn chưa chọn nhân viên muốn xóa.";
                return;
            }
            var x = MessageBox.Show("Bạn có muốn xóa nhân viên " + txtMaNV.Text + " không?", "Xóa", MessageBoxButtons.OKCancel);
            if(x == DialogResult.OK)
            {
                string[] id = txtMaNV.Text.Split('V');
                query = "DELETE FROM Accounts WHERE Username = ( SELECT Username FROM Staffs WHERE ID = '" + id[1] + "')";

                if(ketNoiDB.ThucThiCauLenh(query))
                {
                    query = "DELETE FROM Staffs WHERE ID='" + id[1] + "'";
                    if(ketNoiDB.ThucThiCauLenh(query))
                    {
                        lblTrangThai.Text = "Xóa dữ liệu thành công!";
                    }
                    else
                    {
                        lblLoi.Text = "Xóa thất bại";
                    }
                }
                else
                {
                    lblLoi.Text = "Xóa thất bại";
                }
                GetData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            State = "Insert";
            SetControls(State);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Equals(""))
            {
                lblLoi.Text = "Bạn chưa chọn nhân viên muốn sửa.";
                return;
            }
            State = "Update";
            SetControls(State);
        }

        private void btnGhiDuLieu_Click(object sender, EventArgs e)
        {
            if(State.Equals("Insert"))
            {
                if(txtHoTen.Text.Equals("") && txtQueQuan.Text.Equals("") && nudCa.Value == 0)
                {
                    lblLoi.Text = "Vui lòng nhập đầy đủ thông tin.";
                }
                else
                {
                    lblLoi.Text = "";
                    frmInput2 input = new frmInput2();
                    input.ShowDialog();

                    if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        string[] name = txtHoTen.Text.Split(' ');
                        string firstName = name[name.Length - 1];
                        string lastName = "";
                        for(int i = 0; i < name.Length - 1; i++)
                        {
                            lastName += name[i] + " ";
                        }

                        int GioiTinh = -1;
                        if(rdoNam.Checked)
                        {
                            GioiTinh = 1;
                        }
                        else
                        {
                            GioiTinh = 0;
                        }

                        query = "INSERT INTO Accounts VALUES('" + username + "', '" + password + "', '3')";
                        if(ketNoiDB.ThucThiCauLenh(query))
                        {
                            query = "INSERT INTO Staffs VALUES('" + username + "', N'" + firstName.Trim() + "', N'" + lastName.Trim() + "', '"
                                + Convert.ToDateTime(dtpNgaySinh.Value).ToString("MM/dd/yyyy") + "', '" + nudCa.Value + "', '"
                                + GioiTinh + "', N'" + txtQueQuan.Text.Trim() + "')";

                            if (ketNoiDB.ThucThiCauLenh(query))
                            {
                                GetData();
                                State = "Reset";
                                SetControls(State);
                                lblTrangThai.Text = "Thêm nhân viên thành công!";
                            }
                            else
                            {
                                lblLoi.Text = "Có lỗi sảy ra, vui lòng thử lại!";
                            }
                        }
                        else
                        {
                            lblLoi.Text = "Tên tài khoản đã được sử dụng, Vui lòng dùng tên tài khoản khác.";
                        }
                        return;
                        
                    }
                }
            }

            if(State.Equals("Update"))
            {
                if (txtHoTen.Text.Equals("") && txtQueQuan.Text.Equals("") && nudCa.Value == 0)
                {
                    lblLoi.Text = "Vui lòng nhập đầy đủ thông tin.";
                }
                else
                {
                    lblLoi.Text = "";
                    string[] name = txtHoTen.Text.Split(' ');
                    string firstName = name[name.Length - 1];
                    string lastName = "";
                    string[] id = txtMaNV.Text.Split('V');
                    for (int i = 0; i < name.Length - 1; i++)
                    {
                        lastName += name[i] + " ";
                    }

                    int GioiTinh = -1;
                    if (rdoNam.Checked)
                    {
                        GioiTinh = 1;
                    }
                    else
                    {
                        GioiTinh = 0;
                    }

                    query = "UPDATE Staffs SET Firstname = N'" + firstName + "', Lastname = N'" + lastName + "', Gender = '"
                        + GioiTinh + "', HomeTown = N'" + txtQueQuan.Text + "', Birthday = '"
                        + Convert.ToDateTime(dtpNgaySinh.Value).ToString("MM/dd/yyyy") + "' WHERE ID = '" + id[1] + "'";
                    
                    if(ketNoiDB.ThucThiCauLenh(query))
                    {
                        GetData();
                        State = "Reset";
                        SetControls(State);
                        lblTrangThai.Text = "Sửa nhân viên thành công!";
                    }
                    else
                    {
                        lblLoi.Text = "Có lỗi sảy ra, vui lòng thử lại!";
                    }
                }
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin _frmLogin = new frmLogin();
            _frmLogin.Show();
            this.Hide();
        }

        private void looutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin _frmLogin = new frmLogin();
            _frmLogin.Show();
            this.Hide();
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        // BÀiTest
        DataTable tblP;

        private void ResetValues()
        {
            txtMaSp.Text = "";
            txtTenSp.Text = "";
            txtSoLuong.Text = "0";
            txtThanhTien.Text = "0";
            txtTrangThai.Text = "";
            txtSoLuong.Enabled = true;
            txtThanhTien.Enabled = false;

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (btnThemSp.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSp.Focus();
                return;
            }
            if (tblP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSp.Text = dgvProduct.CurrentRow.Cells["MaSp"].Value.ToString().Trim();
            txtTenSp.Text = dgvProduct.CurrentRow.Cells["TenHang"].Value.ToString().Trim();
            txtSoLuong.Text = dgvProduct.CurrentRow.Cells["SoLuong"].Value.ToString().Trim();
            txtThanhTien.Text = dgvProduct.CurrentRow.Cells["ThanhTien"].Value.ToString().Trim();
        }

        private void btnThemSp_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnQuayLai.Enabled = true;
            btnGhiSp.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaSp.Enabled = true;
            txtMaSp.Focus();
            txtSoLuong.Enabled = true;
            txtThanhTien.Enabled = true;
            txtTrangThai.Enabled = true;

        }


        private void btnGhiSp_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaSp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSp.Focus();
                return;
            }
            if (txtTenSp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSp.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtThanhTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền mỗi sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhTien.Focus();
                return;
            }
            if (txtTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trang thái sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrangThai.Focus();
                return;
            }
            sql = "INSERT INTO tblP(MaSp,TenSp,SoLuong,ThanhTien, TrangThai) VALUES(N'" + txtMaSp.Text.Trim() + "',N'" + txtTenSp.Text.Trim() +
                "',N'" + txtSoLuong.Text.Trim() + "," + txtThanhTien.Text.Trim() + "," + txtTrangThai.Text.Trim() + "')";

            btnXoaSp.Enabled = true;
            btnThemSp.Enabled = true;
            btnSuaSp.Enabled = true;
            btnQuayLai.Enabled = false;
            btnGhiSp.Enabled = false;
            txtMaSp.Enabled = false;
        }

        private void btnSuaSp_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSp.Focus();
                return;
            }
            if (txtTenSp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSp.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtThanhTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền mỗi sản phẩm muốn sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhTien.Focus();
                return;
            }
            if (txtTrangThai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trang thái sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrangThai.Focus();
                return;
            }
            sql = "UPDATE tblP SET TenSp=N'" + txtTenSp.Text.Trim().ToString() + "',SoLuong=" + txtSoLuong.Text + ",ThanhTien='" + txtThanhTien.Text + "',TrangThai=N'" + txtTrangThai.Text + "' WHERE MaSp=N'" + txtMaSp.Text + "'";
        }

        private void btnXoaSp_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblP WHERE MaSp=N'" + txtMaSp.Text + "'";
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (x == DialogResult.OK)
            {
                this.Hide();
                frmLogin _frmLogin = new frmLogin();
                _frmLogin.Show();
            }
        }
    }
}
