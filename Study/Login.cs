using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Study.database;

namespace Study
{
    public partial class Login : Form
    {
        database.table.DatabaseDataContext db = new database.table.DatabaseDataContext();
        DBaccess dbac = new DBaccess();
        bool rightuser = false;
        public Login()
        {
            InitializeComponent();
            labelError.Text = labelWaring.Text = "";
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) //enter key code = 13
            {
                txtPassword.Focus();
            }    
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            string passtemp = dbac.ReturnPassword(txtUserName.Text);
            if (passtemp == "") rightuser = false;
            else rightuser = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            labelError.Text = labelWaring.Text = "";
            if (!rightuser)
            {
                labelWaring.Text = "Sai tên đăng nhập";
            }
            else if (dbac.CorectUser(txtUserName.Text, txtPassword.Text))
            {
                if(MessageBox.Show("Đăng nhập thành công", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
            }
            else
            {
                labelError.Text = "Sai mật khẩu";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Dừng đăng nhập?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }
}
