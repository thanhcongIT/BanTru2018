using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHSBanTru2018_Demo_V1.DAO.HungTD;
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                labError.Text = "Mời bạn nhập đầy đủ thông tin";
                txtUsername.Focus();
                txtPassword.ResetText();
            }
            else
            {
                int result = new LoginDAO().Login(txtUsername.Text, MD5Hash.PasswordEncryptor.MD5Hash(txtPassword.Text));
                if (result == 1)
                {
                    if (chkRemember.Checked)
                    {
                        Properties.Settings.Default.Checkbox = true;
                        Properties.Settings.Default.Username = txtUsername.Text;
                        Properties.Settings.Default.Password = txtPassword.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Checkbox = false;
                        Properties.Settings.Default.Username = "";
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.Save();
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (result == -2)
                    labError.Text = "Tài khoản không tồn tại";
                else if (result == 2)
                    labError.Text = "Mật khẩu không chính xác";
                else if (result == -1)
                    labError.Text = "Tài khoản đã bị khóa";
                else
                    labError.Text = "Đã xảy ra lỗi trong quá trình đăng nhập";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com/duchung.1510");
            //AA
            //Trần Đức Hùng
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Checkbox == true)
            {
                chkRemember.CheckState = CheckState.Checked;
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }
    }
}