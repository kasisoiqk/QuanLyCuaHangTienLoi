
namespace QuanLyCuaHangTienLoi
{
    partial class frmChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorPassword2 = new System.Windows.Forms.Label();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblErrorPassword = new System.Windows.Forms.Label();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsernameNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblErrorUsername = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.cboPhanQuyen = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(366, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN\r\nĐổi mật khẩu tài khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblErrorPassword2
            // 
            this.lblErrorPassword2.AutoSize = true;
            this.lblErrorPassword2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPassword2.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPassword2.Location = new System.Drawing.Point(633, 260);
            this.lblErrorPassword2.Name = "lblErrorPassword2";
            this.lblErrorPassword2.Size = new System.Drawing.Size(360, 21);
            this.lblErrorPassword2.TabIndex = 50;
            this.lblErrorPassword2.Text = "Mật khẩu nhập lại phải trùng với mật khẩu ở trên!";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(720, 228);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(273, 29);
            this.txtPassword2.TabIndex = 49;
            this.txtPassword2.UseSystemPasswordChar = true;
            this.txtPassword2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword2_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(555, 231);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 21);
            this.label14.TabIndex = 48;
            this.label14.Text = "Nhập lại mật khẩu:";
            // 
            // lblErrorPassword
            // 
            this.lblErrorPassword.AutoSize = true;
            this.lblErrorPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPassword.Location = new System.Drawing.Point(738, 204);
            this.lblErrorPassword.Name = "lblErrorPassword";
            this.lblErrorPassword.Size = new System.Drawing.Size(255, 21);
            this.lblErrorPassword.TabIndex = 47;
            this.lblErrorPassword.Text = "Mật khẩu mới phải dài hơn 5 ký tự!";
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Location = new System.Drawing.Point(720, 172);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Size = new System.Drawing.Size(273, 29);
            this.txtPasswordNew.TabIndex = 45;
            this.txtPasswordNew.UseSystemPasswordChar = true;
            this.txtPasswordNew.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(200, 172);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(273, 29);
            this.txtUsername.TabIndex = 44;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label17.Location = new System.Drawing.Point(555, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 21);
            this.label17.TabIndex = 43;
            this.label17.Text = "Mật khẩu mới";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(54, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(124, 21);
            this.label18.TabIndex = 42;
            this.label18.Text = "Tên tài khoản cũ:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(200, 231);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(273, 29);
            this.txtPassword.TabIndex = 52;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(54, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 51;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // txtUsernameNew
            // 
            this.txtUsernameNew.Location = new System.Drawing.Point(720, 118);
            this.txtUsernameNew.Name = "txtUsernameNew";
            this.txtUsernameNew.Size = new System.Drawing.Size(273, 29);
            this.txtUsernameNew.TabIndex = 54;
            this.txtUsernameNew.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(555, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Tên tài khoản mới:";
            // 
            // lblErrorUsername
            // 
            this.lblErrorUsername.AutoSize = true;
            this.lblErrorUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsername.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUsername.Location = new System.Drawing.Point(740, 150);
            this.lblErrorUsername.Name = "lblErrorUsername";
            this.lblErrorUsername.Size = new System.Drawing.Size(253, 21);
            this.lblErrorUsername.TabIndex = 55;
            this.lblErrorUsername.Text = "Tên tài khoản phải dài hơn 5 ký tự!";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lblText.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblText.Location = new System.Drawing.Point(234, 123);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(212, 20);
            this.lblText.TabIndex = 57;
            this.lblText.Text = "Vui lòng lựa chọn phân quyền";
            // 
            // cboPhanQuyen
            // 
            this.cboPhanQuyen.Cursor = System.Windows.Forms.Cursors.Help;
            this.cboPhanQuyen.ForeColor = System.Drawing.Color.OrangeRed;
            this.cboPhanQuyen.FormattingEnabled = true;
            this.cboPhanQuyen.Items.AddRange(new object[] {
            "Admin",
            "Chủ cửa hàng",
            "Quản lý cửa hàng",
            "Nhân viên"});
            this.cboPhanQuyen.Location = new System.Drawing.Point(54, 118);
            this.cboPhanQuyen.Name = "cboPhanQuyen";
            this.cboPhanQuyen.Size = new System.Drawing.Size(169, 29);
            this.cboPhanQuyen.TabIndex = 56;
            this.cboPhanQuyen.Text = "Phân quyền";
            this.cboPhanQuyen.SelectedIndexChanged += new System.EventHandler(this.cboPhanQuyen_SelectedValueChanged);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(287, 331);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(134, 40);
            this.btnXacNhan.TabIndex = 58;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(637, 331);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(134, 40);
            this.btnQuayLai.TabIndex = 59;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1044, 418);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.cboPhanQuyen);
            this.Controls.Add(this.lblErrorUsername);
            this.Controls.Add(this.txtUsernameNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblErrorPassword2);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblErrorPassword);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrorPassword2;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblErrorPassword;
        private System.Windows.Forms.TextBox txtPasswordNew;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsernameNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblErrorUsername;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ComboBox cboPhanQuyen;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnQuayLai;
    }
}