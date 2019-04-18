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
    public partial class Admin_Create_Supplier : Form
    {
        User uu;
        Supplier s = new Supplier();
        public Admin_Create_Supplier(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Create_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            Manage_Supplier ms = new Manage_Supplier(uu);
            ms.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Can't Perform This Operation with an Empty Cell");
            }
            else
            {
                s.CreateSupplier(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show("Supplier Inserted Successfully");
            }
        }
    }
}
