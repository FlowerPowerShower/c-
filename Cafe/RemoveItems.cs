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
    public partial class RemoveItems : Form
    {
        Function fn = new Function();
        String query;
        public RemoveItems()
        {
            InitializeComponent();
        }

        private void RemoveItems_Load(object sender, EventArgs e)
        {
            DelLabel.Text = "How to Delete?";
            DelLabel.ForeColor = Color.Blue;
            loadData();
        }

        public void loadData()
        {
            query = "SELECT * FROM Items";
            DataSet ds = fn.getData(query);
            dgvDelete.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * From Items WHERE name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dgvDelete.DataSource = ds.Tables[0];
        }

        int id;
        private void dgvDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete Items?","Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
            {
                id = int.Parse(dgvDelete.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "Delete From Items where id = " + id + "";
                fn.setData(query);
                loadData();
                

            } 
        }

        private void DelLabel_Click(object sender, EventArgs e)
        {
            DelLabel.ForeColor = Color.Red;
            DelLabel.Text = "Click on Row to delete the item";
        }

        private void RemoveItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
