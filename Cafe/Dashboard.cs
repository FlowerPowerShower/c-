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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            AddItems a = new AddItems();
            this.Close();
            a.Show();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PlaceOrder po = new PlaceOrder();
            this.Close();
            po.Show();
        }

        private void btnUpdateItems_Click(object sender, EventArgs e)
        {
            UpdateItems u = new UpdateItems();
            this.Hide();
            u.Show();
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            RemoveItems ri = new RemoveItems();
            this.Hide();
            ri.Show();
        }
    }
}
