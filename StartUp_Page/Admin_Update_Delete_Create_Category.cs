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
    public partial class Admin_Update_Delete_Create_Category : Form
    {
        User uu;
        Category c = new Category();
        public Admin_Update_Delete_Create_Category(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Update_Delete_Create_Category_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Category mc = new Manage_Category(uu);
            mc.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Admin_Update_Delete_Create_Category_Load(object sender, EventArgs e)
        {
            DataGridViewShow();
        }

        public void DataGridViewShow()
        {
            dataGridView1.DataSource = c.Manage_ShowAllCategories();
            dataGridView1.Columns[0].HeaderCell.Value = "Category Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Category Type";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.UpdateCategory(textBox1.Text,textBox2.Text);
            MessageBox.Show("Category Updated");
            this.Hide();
            Manage_Category mc = new Manage_Category(uu);
            mc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("You can't Perform This Operation with an Empty Cell");
            }
            else
            {
                bool res = c.DeleteCategory(textBox1.Text, textBox2.Text);
                if (res == true)
                {
                    MessageBox.Show("Deleted Successfully");
                    this.Hide();
                    Manage_Category mc = new Manage_Category(uu);
                    mc.Show();
                }
                else
                {
                    MessageBox.Show("This Category Id has a product assigned..Cannot perform this operation");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.InsertCategory(textBox3.Text);
            MessageBox.Show("Category_Inserted Successfull");
            this.Hide();
            Manage_Category mc = new Manage_Category(uu);
            mc.Show();
        }
    }
}
