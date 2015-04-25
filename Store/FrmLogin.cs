using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewLife.Security;

namespace Store
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider1.SetError(txtName, "用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "密码不能为空");
                return;
            }
            string loginName = txtName.Text.Trim();
            string password = txtName.Text.Trim();
            //Users user = Users.Find(Users._.LoginName, loginName);
            //if (user == null)
            //{
            //    errorProvider1.SetError(txtName, "用户不存在");
            //    return;
            //}
            //else if (user.Password != DataHelper.Encrypt(password, "administrator"))
            //{
            //    errorProvider1.SetError(txtPassword, "密码错误");
            //    return;
            //}
            //if (sender.ToString() == "")
            //{
            //    Frm_KJSW Frm_main = new Frm_KJSW();//进入主界面
            //    Frm_main.Show();
            //}
        }
    }
}
