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
    public partial class View_Profile : Form
    {
        User uu;
        public View_Profile(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void View_Profile_FormClosing(object sender, FormClosingEventArgs e)
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
            All_User au = new All_User(uu);
            au.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up stp = new Start_Up(true);
            stp.Show();
        }

        private void View_Profile_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            uu =uu.ViewOwnProfile(uu.User_ID);
            label11.Text = uu.User_Name;
            label12.Text = uu.User_ID;
            label13.Text = uu.User_Password;
            label14.Text = uu.User_Gender;
            label15.Text = uu.User_TypeName;
            label16.Text = uu.User_Salary.ToString();
            label17.Text = uu.User_Phone;
            label18.Text = uu.User_House;
            label19.Text = uu.User_Road;
            label20.Text = uu.User_City;
        }
    }
}
