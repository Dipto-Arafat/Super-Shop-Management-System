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
    public partial class Admin_Update_Delete_Store : Form
    {
        User uu;
        Store s = new Store();
        public Admin_Update_Delete_Store(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Update_Delete_Store_FormClosing(object sender, FormClosingEventArgs e)
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
            Manage_Store frm = new Manage_Store(uu);
            frm.Show();
        }

        private void Admin_Update_Delete_Store_Load(object sender, EventArgs e)
        {
            GridViewShow();
        }
        private void GridViewShow()
        {
            dataGridView1.DataSource = s.ShowAllStore();
            dataGridView1.Columns[0].HeaderCell.Value = "Store ID";
            dataGridView1.Columns[1].HeaderCell.Value = "Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Location";
            dataGridView1.Columns[3].HeaderCell.Value = "Phone";
            dataGridView1.Columns[4].HeaderCell.Value = "Mail";
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
                s.UpdateStore(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show("Updated Successfully");
                this.Hide();
                Manage_Store ma = new Manage_Store(uu);
                ma.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("You cant Perform this operation with an empty Cell");
            }
            else
            {
                 s.DeleteStore(textBox1.Text);
                 MessageBox.Show("Store Deletd Successfully");
                 this.Hide();
                 Manage_Store m = new Manage_Store(uu);
                 m.Show();
                }
            }
    }
}
