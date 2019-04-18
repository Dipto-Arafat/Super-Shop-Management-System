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
    public partial class Manage_Account : Form
    {
        User uu;
        public Manage_Account(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Manage_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Manage_Account_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            All_User aus = new All_User(uu);
            aus.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Account auda =new Admin_Update_Delete_Account(uu);
            auda.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Account auda = new Admin_Update_Delete_Account(uu);
            auda.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Create_Account aca = new Admin_Create_Account(uu);
            aca.Show();
        }
    }
}
