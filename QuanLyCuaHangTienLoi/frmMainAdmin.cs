using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace QuanLyCuaHangTienLoi
{
    public partial class frmMainAdmin : Form
    {
        private KetNoiDB ketNoiDB = new KetNoiDB();
        private string query;
        private string State = "Reset";

        public frmMainAdmin()
        {
            InitializeComponent();

            SetControls(State);
        }

        public void SetControls(string State)
        {
            switch(State)
            {
                case "Reset":
                    lblTimThay.Visible = false;
                    lblKhongTimThay.Visible = false;
                    lblErorrUsername.Visible = false;
                    lblErorrPassword.Visible = false;
                    lblErorrPassword2.Visible = false;
                    lblErorr.Visible = false;
                    lblSuccess.Visible = false;
                    btnWriteData.Enabled = false;
                    btnCancel.Enabled = false;
                    lblInfo.Text = "Tổng cộng có ? bản ghi";
                    btnSearch.Enabled = false;

                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;

                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    txtPassword2.Enabled = false;

                    txtSearch.Text = "";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtPassword2.Text = "";

                    panelAddInfo.Visible = false;

                    txtSearch.Enabled = true;
                    btnSearch.Enabled = true;

                    if (dgvAccounts.DataSource != null)
                        lblText.Visible = false;
                    else lblText.Visible = true;

                    break;
                case "Insert":
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtPassword2.Text = "";

                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtPassword2.Enabled = true;

                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;

                    btnSearch.Enabled = false;

                    btnWriteData.Enabled = true;
                    btnCancel.Enabled = true;

                    txtSearch.Enabled = false;

                    lblTimThay.Visible = false;
                    lblKhongTimThay.Visible = false;
                    lblCheckSearch.Visible = false;

                    break;
                case "Update":
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    txtPassword2.Enabled = true;

                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;

                    btnSearch.Enabled = false;

                    btnWriteData.Enabled = true;
                    btnCancel.Enabled = true;

                    txtSearch.Enabled = false;

                    break;
            }
        }

        public void GetData()
        {
            query = "SELECT * FROM Accounts WHERE Type = 3";
            DataSet ds = ketNoiDB.GetDataSet(query);

            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.DataSource = ds.Tables[0];

            lblInfo.Text = "Tổng số có " + ds.Tables[0].Rows.Count + " bản ghi.";
            lblText.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(x == DialogResult.OK)
            {
                this.Close();
                frmLogin _frmLogin = new frmLogin();
                _frmLogin.Show();
            }
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Yêu cầu nhập lại mật khẩu của bạn để có thể tiếp tục.", "Xác thực mật khẩu", "Nhập tại đây", -1, -1);

            query = "SELECT Password FROM Accounts WHERE Type = 0";
            string password = ketNoiDB.GetValue(query);

            if(input.Equals(password))
            {
                GetData();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mật khẩu. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Trim().Length < 6)
            {
                btnSearch.Enabled = false;
                lblCheckSearch.Visible = true;
            }
            else
            {
                btnSearch.Enabled = true;
                lblCheckSearch.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvAccounts.DataSource = null;
            lblText.Visible = true;
            lblInfo.Text = "Tổng cộng có ? bản ghi";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT Password FROM Accounts WHERE Username = '" + txtSearch.Text.Trim() + "' AND Type = 3";
            string password = ketNoiDB.GetValue(query);
            if(password != null)
            {
                lblTimThay.Visible = true;
                lblKhongTimThay.Visible = false;

                txtUsername.Text = txtSearch.Text.Trim();
                txtPassword.Text = password;

            }
            else
            {
                lblTimThay.Visible = false;
                lblKhongTimThay.Visible = true;
            }

            lblSuccess.Visible = false;
            lblErorr.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "")
            {
                State = "Update";
                SetControls(State);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản muốn sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtUsername.Text.Trim().Length < 6)
            {
                lblErorrUsername.Visible = true;
            }
            else
            {
                lblErorrUsername.Visible = false;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassword.Text.Trim().Length < 6)
            {
                lblErorrPassword.Visible = true;
            }
            else
            {
                lblErorrPassword.Visible = false;
            }
        }

        private void txtPassword2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtPassword2.Text.Equals(txtPassword.Text))
            {
                lblErorrPassword2.Visible = true;
            }
            else
            {
                lblErorrPassword2.Visible = false;
            }
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            if(State == "Update")
            {
                if(txtUsername.Text.Trim().Length > 5)
                {
                    if(txtPassword.Text.Length > 5)
                    {
                        if(txtPassword.Text.Equals(txtPassword2.Text))
                        {
                            query = "UPDATE Accounts SET Username = '" + txtUsername.Text.Trim() + "', Password = '" + txtPassword.Text + "' WHERE Username = '"
                                + txtSearch.Text.Trim() + "'";
                            if(ketNoiDB.ThucThiCauLenh(query))
                            {
                                State = "Reset";
                                SetControls(State);

                                lblSuccess.Text = "Sửa tài khoản thành công!";
                                lblSuccess.Visible = true;
                                lblErorr.Visible = false;
                            }
                            else
                            {
                                lblErorr.Text = "Có lỗi sảy ra. Vui lòng thử lại!";
                                lblErorr.Visible = true;
                                lblSuccess.Visible = false;
                            }

                            if(dgvAccounts.DataSource != null)
                            {
                                GetData();
                            }
                        }
                        else
                        {
                            lblErorr.Text = "Mật khẩu nhập lại không khớp!";
                            lblErorr.Visible = true;
                            lblSuccess.Visible = false;
                        }
                    }
                    else
                    {
                        lblErorr.Text = "Mật khẩu không hợp lệ!";
                        lblErorr.Visible = true;
                        lblSuccess.Visible = false;
                    }
                }
                else
                {
                    lblErorr.Text = "Tên tài khoản không hợp lệ";
                    lblErorr.Visible = true;
                    lblSuccess.Visible = false;
                }

            }
            else if(State == "Insert")
            {
                if (txtUsername.Text.Trim().Length > 5)
                {
                    if (txtPassword.Text.Equals(txtPassword2.Text))
                    {
                        if (txtPassword.Text.Equals(txtPassword2.Text))
                        {
                            panelAddInfo.Visible = true;

                            lblErorr.Visible = false;
                            lblSuccess.Visible = false;
                        }
                        else
                        {
                            lblErorr.Text = "Mật khẩu nhập lại không khớp!";
                            lblErorr.Visible = true;
                            lblSuccess.Visible = false;
                        }
                    }
                    else
                    {
                        lblErorr.Text = "Mật khẩu không hợp lệ!";
                        lblErorr.Visible = true;
                        lblSuccess.Visible = false;
                    }
                }
                else
                {
                    lblErorr.Text = "Tên tài khoản không hợp lệ";
                    lblErorr.Visible = true;
                    lblSuccess.Visible = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            State = "Reset";
            SetControls(State);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            State = "Insert";
            SetControls(State);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "")
            {
                var x = MessageBox.Show("Bạn có muốn xóa tài khoản " + txtUsername.Text.Trim() + " không? " +
                    "Xóa tài khoản sẽ kèm theo xóa thông tin của nhân viên này.",
                    "Xóa", MessageBoxButtons.OKCancel);
                if(x == DialogResult.OK)
                {
                    query = "DELETE FROM Accounts WHERE Username = '" + txtUsername.Text.Trim() + "'";
                    if(ketNoiDB.ThucThiCauLenh(query))
                    {
                        lblSuccess.Text = "Xóa tài khoản thành công!";
                        lblSuccess.Visible = true;
                        lblErorr.Visible = false;

                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtPassword2.Text = "";
                    }
                    else
                    {
                        lblErorr.Text = "Có lỗi sảy ra. Vui lòng thử lại!";
                        lblErorr.Visible = true;
                        lblSuccess.Visible = false;
                    }

                    if (dgvAccounts.DataSource != null)
                    {
                        GetData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            if(State.Equals("Reset") && RowIndex >= 0 && RowIndex < dgvAccounts.Rows.Count - 1)
            {
                DataGridViewRow selected = dgvAccounts.Rows[RowIndex];

                txtSearch.Text = selected.Cells["Username"].Value.ToString();
                txtUsername.Text = selected.Cells["Username"].Value.ToString();
                txtPassword.Text = selected.Cells["Password"].Value.ToString();

                lblCheckSearch.Visible = false;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            panelAddInfo.Visible = false;
        }

        private void btnGhiDuLieu_Click(object sender, EventArgs e)
        {
            if (State.Equals("Insert"))
            {
                if (txtHoTen.Text.Equals("") && txtQueQuan.Text.Equals("") && txtSdt.Text.Trim().Equals(""))
                {
                    lblLoi.Text = "Vui lòng nhập đầy đủ thông tin.";
                    lblLoi.Visible = true;
                }
                else
                {
                    lblLoi.Text = "";

                    string[] name = txtHoTen.Text.Split(' ');
                    string firstName = name[name.Length - 1];
                    string lastName = "";
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
                    query = "INSERT INTO Staffs VALUES('" + txtUsername.Text.Trim() + "', N'" + firstName.Trim() + "', N'" + lastName.Trim() + "', '"
                        + Convert.ToDateTime(dtpNgaySinh.Value).ToString("dd/mm/yyyy") + "', '" + GioiTinh + "', N'" 
                        + txtQueQuan.Text.Trim() + "', '" + txtSdt.Text.Trim() + "')";

                    if (ketNoiDB.ThucThiCauLenh(query))
                    {
                        panelAddInfo.Visible = false;

                        query = "INSERT INTO Accounts VALUES('" + txtUsername.Text.Trim() + "', '" + txtPassword.Text + "', 3)";
                        if (ketNoiDB.ThucThiCauLenh(query))
                        {
                            State = "Reset";
                            SetControls(State);

                            lblSuccess.Text = "Thêm tài khoản thành công!";
                            lblSuccess.Visible = true;
                            lblErorr.Visible = false;

                            lblLoi.Visible = false;
                        }
                        else
                        {
                            lblErorr.Text = "Có lỗi sảy ra. Vui lòng thử lại! 1";
                            lblErorr.Visible = true;
                            lblSuccess.Visible = false;

                            lblLoi.Visible = false;
                        }

                        if (dgvAccounts.DataSource != null)
                        {
                            GetData();
                        }
                    }
                    else
                    {
                        lblLoi.Text = "Có lỗi sảy ra, vui lòng thử lại! 2";
                        lblLoi.Visible = true;
                    }
                }
            }
        }

        //
        //
        // Form quan ly tai khoan chu cua hang va quan ly
        private void btnHienThiCCH_Click(object sender, EventArgs e)
        {
            query = "SELECT Username FROM Accounts WHERE Type = 1";
            string username = ketNoiDB.GetValue(query);
            query = "SELECT Password FROM Accounts WHERE Type = 1";
            string password = ketNoiDB.GetValue(query);

            if(username == null || password == null)
            {
                MessageBox.Show("Có lỗi sảy ra. Vui lòng thử lại sau");
                return;
            }

            lblUsernameChuCuaHang.Text = username;
            lblPasswordChuCuaHang.Text = password;
        }

        private void btnAnCCH_Click(object sender, EventArgs e)
        {
            lblUsernameChuCuaHang.Text = "******";
            lblPasswordChuCuaHang.Text = "******";
        }

        private void btnDoiMatKhauCCH_Click(object sender, EventArgs e)
        {
            frmChangePassword _frmChangePassword = new frmChangePassword();
            _frmChangePassword.Show();
        }

        private void btnHienThiQL_Click(object sender, EventArgs e)
        {
            query = "SELECT Username FROM Accounts WHERE Type = 2";
            string username = ketNoiDB.GetValue(query);
            query = "SELECT Password FROM Accounts WHERE Type = 2";
            string password = ketNoiDB.GetValue(query);

            if (username == null || password == null)
            {
                MessageBox.Show("Có lỗi sảy ra. Vui lòng thử lại sau");
                return;
            }

            lblUsernameQuanLy.Text = username;
            lblPasswordQuanLy.Text = password;
        }

        private void btnAnQL_Click(object sender, EventArgs e)
        {
            lblUsernameQuanLy.Text = "******";
            lblPasswordQuanLy.Text = "******";
        }

        private void btnDoiMatKhauQL_Click(object sender, EventArgs e)
        {
            frmChangePassword _frmChangePassword = new frmChangePassword();
            _frmChangePassword.Show();
        }
    }
}
