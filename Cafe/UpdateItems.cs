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
    public partial class UpdateItems : Form
    {
        Function fn = new Function();
        String query;
        public UpdateItems()
        {
            InitializeComponent();
        }

        private void UpdateItems_Load(object sender, EventArgs e)
        {
            
            loadData();

        }
        public void loadData()
        {
            query = "SELECT * FROM Items";
            DataSet ds = fn.getData(query);
            dataGridViewUpdate.DataSource = ds.Tables[0];
        }

        private void txtItemOldName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM Items where name like '" + txtItemOldName.Text + "%' ";
            DataSet ds = fn.getData(query);
            dataGridViewUpdate.DataSource = ds.Tables[0];
        }

        int id;
        private void dataGridViewUpdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridViewUpdate.Rows[e.RowIndex].Cells[0].Value.ToString());
            String Category = dataGridViewUpdate.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = dataGridViewUpdate.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(dataGridViewUpdate.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtCategory.Text = Category;
            txtItemName.Text = name;
            txtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "Update Items set name= '" + txtItemName.Text + "', category = '" + txtCategory.Text + "', price = " + txtPrice.Text + "  where id = "+id+"";
            fn.setData(query);
            loadData();
            txtCategory.Clear();
            txtItemName.Clear();
            txtPrice.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }
    }
}
