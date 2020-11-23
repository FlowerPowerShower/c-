using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (username == "Adam" && password == "Kung")
            {
                Dashboard dh = new Dashboard();
                this.Hide();
                dh.Show();
                
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
