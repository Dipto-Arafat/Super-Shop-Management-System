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
    public partial class Manage_Store : Form
    {
        User uu;
        Store s = new Store();
        byte type = 1;
        public Manage_Store(User u)
        {
            InitializeComponent();
            uu = u;
            type = 1;
        }
        public Manage_Store()
        {
            InitializeComponent();
            button4.Visible = false;
            button5.Visible = false;
            button12.Visible = false;
            type = 2;

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
            if (type == 1)
            {
                this.Hide();
                All_User au = new All_User(uu);
                au.Show();
            }
            if(type==2)
            {
                this.Hide();
                Start_Up frm = new Start_Up(true);
                frm.Show();
            }
        }
        private void Manage_Store_Load(object sender, EventArgs e)
        {
            DataGridViewShow();
        }
        public void DataGridViewShow()
        {
            dataGridView1.DataSource = s.ShowAllStore();
            dataGridView1.Columns[0].HeaderCell.Value = "Store ID";
            dataGridView1.Columns[1].HeaderCell.Value = "Store Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Location";
            dataGridView1.Columns[3].HeaderCell.Value = "Phone";
            dataGridView1.Columns[4].HeaderCell.Value = "Mail ID";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Store aups = new Admin_Update_Delete_Store(uu);
            aups.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Update_Delete_Store aups = new Admin_Update_Delete_Store(uu);
            aups.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Create_Store acs = new Admin_Create_Store(uu);
            acs.Show();
        }
    }
}
