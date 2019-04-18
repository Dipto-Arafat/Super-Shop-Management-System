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
    
    public partial class Manage_Category : Form
    {
        User uu;
        Category c = new Category();
        public Manage_Category(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Manage_Category_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Manage_Category_Load(object sender, EventArgs e)
        {
            DataGridViewShow();
        }

        public void DataGridViewShow()
        {
            dataGridView1.DataSource = c.Manage_ShowAllCategories();
            dataGridView1.Columns[0].HeaderCell.Value = "Category Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Category Type";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Create_Category ac = new Admin_Update_Delete_Create_Category(uu);
            ac.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Create_Category ac = new Admin_Update_Delete_Create_Category(uu);
            ac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Create_Category ac = new Admin_Update_Delete_Create_Category(uu);
            ac.Show();
        }
    }
}
