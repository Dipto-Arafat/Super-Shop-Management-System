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
    public partial class Admin_Update_Delete_Supplier : Form
    {
        User uu;
        Supplier s = new Supplier();
        public Admin_Update_Delete_Supplier(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Update_Delete_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
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

        private void Admin_Update_Delete_Supplier_Load(object sender, EventArgs e)
        {
            DataGridViewShow();
        }
        public void DataGridViewShow()
        {
            dataGridView1.DataSource = s.Manage_ShowAllSuppliers();
            dataGridView1.Columns[0].HeaderCell.Value = "Supplier Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Supplier Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Location";
            dataGridView1.Columns[3].HeaderCell.Value = "Contact No";
            dataGridView1.Columns[4].HeaderCell.Value = "Gender";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("You cant Perform this operation with an empty Cell");
            }
            else
            {
                s.UpdateSupplier(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show("Updated Successfully");
                this.Hide();
                Manage_Supplier ms = new Manage_Supplier(uu);
                ms.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("You can't Perform This Operation with an Empty Cell");
            }
            else
            {
                bool res = s.DeleteSupplier(textBox1.Text);
                if (res == true)
                {
                    MessageBox.Show("Deleted Successfully");
                    this.Hide();
                    Manage_Supplier ms = new Manage_Supplier(uu);
                    ms.Show();
                }
                else
                {
                    MessageBox.Show("This supplier Id has a product assigned..Cannot perform this operation");
                }
              
            }
        }
    }
}
