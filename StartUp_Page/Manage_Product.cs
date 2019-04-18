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
    public partial class Manage_Product : Form
    {
        User uu;
        Product p = new Product();
        public Manage_Product(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Manage_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            All_User au = new All_User(uu);
            au.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Manage_Product_Load(object sender, EventArgs e)
        {
            GridViewShow();
        }

        public void GridViewShow()
        {
            dataGridView1.DataSource = p.Manage_ShowAllProducts();
            dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
            dataGridView1.Columns[3].HeaderCell.Value = "Price";
            dataGridView1.Columns[4].HeaderCell.Value = "Date";
            dataGridView1.Columns[5].HeaderCell.Value = "Type";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Product ap = new Admin_Update_Delete_Product(uu);
            ap.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Product ap = new Admin_Update_Delete_Product(uu);
            ap.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
           Admin_Create_Product ap = new Admin_Create_Product(uu);
            ap.Show();
        }
    }
}
