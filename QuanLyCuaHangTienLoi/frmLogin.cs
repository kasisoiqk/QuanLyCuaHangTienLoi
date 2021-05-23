using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi
{
    public partial class frmLogin : Form
    { 
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cboPhanQuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPhanQuyen.SelectedIndex == 0)
            {
                lblText.Text = "Vui lòng nhập tài khoản admin của bạn...";
            }
            else if (cboPhanQuyen.SelectedIndex == 1)
            {
                lblText.Text = "Vui lòng nhập tài khoản chủ cửa hàng của bạn...";
            }
            else if (cboPhanQuyen.SelectedIndex == 2)
            {
                lblText.Text = "Vui lòng nhập tài khoản quản lý của bạn...";
            }
            else if (cboPhanQuyen.SelectedIndex == 3)
            {
                lblText.Text = "Vui lòng nhập tài khoản nhân viên của bạn...";
            }
            else
            {
                lblText.Text = "Vui lòng lựa chọn phân quyền.";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            KetNoiDB ketNoiDB = new KetNoiDB();

            string tk = txtUsername.Text;
            string mk = txtPassword.Text;

            string sql;
            if (cboPhanQuyen.SelectedIndex == 0)
            {
                sql = "SELECT * FROM Accounts WHERE Username = '" + tk + "' AND Password = '" + mk + "' AND Type = 0";
            }
            else if(cboPhanQuyen.SelectedIndex == 1)
            {
                sql = "SELECT * FROM Accounts WHERE Username = '" + tk + "' AND Password = '" + mk + "' AND Type = 1";
            }
            else if (cboPhanQuyen.SelectedIndex == 2)
            {
                sql = "SELECT * FROM Accounts WHERE Username = '" + tk + "' AND Password = '" + mk + "' AND Type = 2";
            }
            else
            {
                sql = "SELECT * FROM Accounts WHERE Username = '" + tk + "' AND Password = '" + mk + "' AND Type = 3";
            }

            string val = ketNoiDB.GetValue(sql);

            if (val != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(cboPhanQuyen.SelectedIndex == 0)
                {
                    frmMainAdmin _frmMainAdmin = new frmMainAdmin();
                    _frmMainAdmin.Show();

                    this.Hide();
                }
                else if (cboPhanQuyen.SelectedIndex == 2)
                {
                    frmMainQuanLy _frmMainQuanLy = new frmMainQuanLy();
                    _frmMainQuanLy.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblQuenPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ admin để lấy lại tài khoản!", "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmChangePassword _frmChangePassword = new frmChangePassword();
            _frmChangePassword.Show();
        }
    }

}
