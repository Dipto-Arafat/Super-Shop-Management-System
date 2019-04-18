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
    public partial class Edit_Own_Profile : Form
    {
        User uu;
        public Edit_Own_Profile(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Edit_Own_Profile_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Edit_Own_Profile_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            uu = uu.ViewOwnProfile(uu.User_ID);
            textBox1.Text = uu.User_Name;
            textBox2.Text = uu.User_ID;
            textBox3.Text = uu.User_Password;
            comboBox1.Text = uu.User_Gender;
            textBox5.Text = uu.User_TypeName;
            textBox6.Text = uu.User_Salary.ToString();
            textBox7.Text = uu.User_Phone;
            textBox8.Text = uu.User_House;
            textBox9.Text = uu.User_Road;
            textBox10.Text = uu.User_City;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uu.UpdateOwnProfile(textBox2.Text,textBox1.Text, textBox3.Text,comboBox1.Text,textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);
            MessageBox.Show("Profile Updated Successfully", "Done");
        }
    }
}
