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
    public partial class Admin_Update_Delete_Account : Form
    {
        User uu;
        public Admin_Update_Delete_Account(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Update_Delete_Account_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Admin_Update_Delete_Account_Load(object sender, EventArgs e)
        {
            GridViewShow();
        }
        private void GridViewShow()
        {
            dataGridView1.DataSource = uu.Manage_Account_ShowAllUsers();
            dataGridView1.Columns[0].HeaderCell.Value = "User Name";
            dataGridView1.Columns[1].HeaderCell.Value = "User ID";
            dataGridView1.Columns[2].HeaderCell.Value = "Account Type";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderCell.Value = "Gender";
            dataGridView1.Columns[5].HeaderCell.Value = "Salary";
            dataGridView1.Columns[6].HeaderCell.Value = "Phone";
            dataGridView1.Columns[7].HeaderCell.Value = "House No";
            dataGridView1.Columns[8].HeaderCell.Value = "Road";
            dataGridView1.Columns[9].HeaderCell.Value = "City";
            dataGridView1.Columns[10].HeaderCell.Value = "Designation";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Account ma = new Manage_Account(uu);
            ma.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("You can't Perform This Operation with an Empty Cell");
            }
            else
            {
                uu.DeleteAccount(textBox1.Text);
                MessageBox.Show("Deleted Successfully");
                this.Hide();
                Manage_Account ma = new Manage_Account(uu);
                ma.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("You can't Perform This Operation with an Empty Cell");
            }
            else
            {
                uu.UpdateAccount(textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show("Updated Successfully");
                this.Hide();
                Manage_Account ma = new Manage_Account(uu);
                ma.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up sup = new Start_Up(true);
            sup.Show();
        }
    }
}
