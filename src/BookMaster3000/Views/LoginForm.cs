using BookMaster3000.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("False input!");
                return;
            }
            var user = DB.GetCtx().User.FirstOrDefault(x => x.UserName == txtUsername.Text && x.Password == txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("False credentials!");
                return;
            }
            DB.ApplicationUser = user;
            DialogResult = DialogResult.OK;
        }
    }
}
