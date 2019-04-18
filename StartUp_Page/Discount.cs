using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class Discount : Form
    {
        Product p = new Product();
        public Discount()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void Dicount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Dicount_Load(object sender, EventArgs e)
        {
            DataGridViewShow();
        }
        public void DataGridViewShow()
        {
            dataGridView1.DataSource = p.SearchAllDiscount();
            dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
            dataGridView1.Columns[3].HeaderCell.Value = "Price";
            dataGridView1.Columns[4].HeaderCell.Value = "Date";
            dataGridView1.Columns[5].HeaderCell.Value = "Type";
        }
    }
}
