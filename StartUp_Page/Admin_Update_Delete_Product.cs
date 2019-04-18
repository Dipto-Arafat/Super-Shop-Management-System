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
    public partial class Admin_Update_Delete_Product : Form
    {
        User uu;
        Product p = new Product();
        public Admin_Update_Delete_Product(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Update_Delete_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Product mp = new Manage_Product(uu);
            mp.Show();


        }

        private void Admin_Update_Delete_Product_Load(object sender, EventArgs e)
        {
            GridViewShow();
        }

        public void GridViewShow()
        {
            dataGridView1.DataSource = p.Manage_ShowAllProducts();
            dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
            dataGridView1.Columns[3].HeaderCell.Value = "Price";
            dataGridView1.Columns[4].HeaderCell.Value = "Add Date";
            dataGridView1.Columns[5].HeaderCell.Value = "Type";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
           // textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text= this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Cannot delete .. Cells are Empty");
            }
            else
            {
                p.DeleteProduct(textBox1.Text);
                MessageBox.Show("Deleted Successfully");
                this.Hide();
                Manage_Product mp = new Manage_Product(uu);
                mp.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Cannot Update .. Cells are Empty");
            }
            else
            {
                p.UpdateProduct(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text);
                MessageBox.Show("Updated SuccessFully");
                this.Hide();
                Manage_Product mp = new Manage_Product(uu);
                mp.Show();
            }

        }
    }
}
