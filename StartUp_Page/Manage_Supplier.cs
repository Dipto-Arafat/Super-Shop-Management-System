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
    public partial class Manage_Supplier : Form
    {
        User uu;
        Supplier s = new Supplier();
        public Manage_Supplier(User u)
        {
            InitializeComponent();
            uu = u;
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
            All_User au = new All_User(uu);
            au.Show();
        }

        private void Manage_Supplier_Load(object sender, EventArgs e)
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

        private void Manage_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Supplier auds = new Admin_Update_Delete_Supplier(uu);
            auds.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Supplier auds = new Admin_Update_Delete_Supplier(uu);
            auds.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Create_Supplier acs = new Admin_Create_Supplier(uu);
            acs.Show();
        }
    }
}
