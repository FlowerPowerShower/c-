using DGVPrinterHelper;
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
    public partial class PlaceOrder : Form
    {
        Function fn = new Function();
        String query;

        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboCat.Text;
            query = "select name from items where category = '" + category + "'";
            DataSet ds = fn.getData(query);

            ShowItemsList(query);

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            String category = comboCat.Text;
            query = "select name from items where category = '" + category + "' and name like '" + txtSearch.Text + "%'";
            ShowItemsList(query);
        }
        private void ShowItemsList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dh = new Dashboard();
            this.Close();
            dh.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "select price from items where name = '" + text + "'";
            DataSet ds = fn.getData(query);

            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuantityUpDown.Value.ToString());
            Int64 price = Int64.Parse(txtPrice.Text);
            txtTotal.Text = (quan * price).ToString();
        }

        protected int n, total = 0;

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);

            total -= amount;
            labelTotalAmount.Text = "Rs.  " + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date, DateTime.Now.ToString("HH:mm:ss tt"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total amount :" + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            labelTotalAmount.Text = "Rs.  " + total;
        }

        private void labelTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtQuantityUpDown.Value;
                dataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                total = total + int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "Rs.  $" + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity need to be 1 or more","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
