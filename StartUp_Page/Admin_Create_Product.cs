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
    public partial class Admin_Create_Product : Form
    {
        Product p = new Product();
        User uu;
        Category c = new Category();
        Supplier s = new Supplier();
        public Admin_Create_Product(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Admin_Create_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Product mp = new Manage_Product(uu);
            mp.Show();
        }

        private void Admin_Create_Product_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = c.Manage_ShowAllCategories();
            this.dataGridView2.DataSource = s.Manage_ShowAllSuppliers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox14.Text=="" || textBox13.Text=="" || textBox12.Text== "" || textBox11.Text== "" || textBox10.Text=="" || textBox1.Text=="" || textBox9.Text== "" || textBox8.Text=="")
            {
                MessageBox.Show("Cant Perform this Operation with an Empty Cell");
            }
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            Product p1 = new Product();
            p1=p.InsertProduct(textBox14.Text,textBox13.Text, textBox12.Text,textBox11.Text,textBox10.Text, textBox1.Text,textBox9.Text, textBox8.Text);
            MessageBox.Show("Product Inserted Successfully.ID:"+p1.Product_Id.ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_MouseEnter(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void textBox10_MouseLeave(object sender, EventArgs e)
        {
           // groupBox2.Visible = false;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
           // groupBox3.Visible = false;
        }
    }
}
