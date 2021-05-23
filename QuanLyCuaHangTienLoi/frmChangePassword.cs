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
    public partial class frmChangePassword : Form
    {
        KetNoiDB ketNoiDB = new KetNoiDB();
        string query;

        public frmChangePassword()
        {
            InitializeComponent();

            InitUI();
        }

        public void InitUI()
        {
            lblErrorUsername.Visible = false;
            lblErrorPassword.Visible = false;
            lblErrorPassword2.Visible = false;

        }

        private void cboPhanQuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPhanQuyen.SelectedIndex == 0)
            {
                lblText.Text = "Vui lòng nhập tài khoản admin của bạn...";
            }
            else if (cboPhanQuyen.SelectedIndex == 1)
            {
                lblText.Text = "Vui lòng nhập tài khoản chủ cửu hàng của bạn...";
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

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUsernameNew.Text.Trim().Length < 6)
            {
                lblErrorUsername.Visible = true;
            }
            else
            {
                lblErrorUsername.Visible = false;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPasswordNew.Text.Trim().Length < 6)
            {
                lblErrorPassword.Visible = true;
            }
            else
            {
                lblErrorPassword.Visible = false;
            }
        }

        private void txtPassword2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtPassword2.Text.Equals(txtPasswordNew.Text))
            {
                lblErrorPassword2.Visible = true;
            }
            else
            {
                lblErrorPassword2.Visible = false;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int type = cboPhanQuyen.SelectedIndex;

            if(type == -1)
            {
                MessageBox.Show("Bạn chưa lựa chọn phân quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = "SELECT * FROM Accounts WHERE Username = '" + txtUsername.Text.Trim() + "' AND Password = '" + txtPassword.Text +
                "' AND Type = " + type;
            

            if(ketNoiDB.GetValue(query) != null)
            {
                if(txtUsernameNew.Text.Trim().Length < 6)
                {
                    MessageBox.Show("Tên tài khoản mới phải dài hơn 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if(txtPasswordNew.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải dài hơn 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if(!txtPassword2.Text.Equals(txtPasswordNew.Text))
                {
                    MessageBox.Show("Mật khẩu nhập lại khác mật khẩu nhập mới đã nhập trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(lblErrorUsername.Visible || lblErrorPassword.Visible || lblErrorPassword2.Visible)
                {
                    MessageBox.Show("Bạn nhập ký tự không hợp lệ. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    query = "UPDATE Accounts SET Username = '" + txtUsernameNew.Text.Trim() + "', Password = '" + txtPasswordNew.Text
                        + "' WHERE Username = '" + txtUsername.Text.Trim() + "' AND Password = '" + txtPassword.Text + "' AND Type = " + type;

                    if(ketNoiDB.ThucThiCauLenh(query))
                    {
                        MessageBox.Show("Thay đổi mật khẩu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi sảy ra. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
