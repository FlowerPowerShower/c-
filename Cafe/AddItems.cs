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
    public partial class AddItems : Form
    {
        Function fn = new Function();
        String query;

        public AddItems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "insert into items(name,category,price) VALUES ('" + txtItemName.Text + "', '" + txtcombC.Text + "', " + txtPrice.Text + ")";
            fn.setData(query);
            clearAll();
        }

        public void clearAll()
        {
            txtcombC.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }

        private void btnBackItems_Click(object sender, EventArgs e)
        {
            Dashboard dh = new Dashboard();
            this.Hide();
            dh.Show();
        }
    }
}
