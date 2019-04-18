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
    public partial class Login_SignUp : Form
    {
        User u = new User();
        public Login_SignUp()
        {
            InitializeComponent();
            sliderpanel.Height = button4.Height;
            sliderpanel.Top = button4.Top;
        }

        private void Login_SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button4.Height;
            sliderpanel.Top = button4.Top;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button5.Height;
            sliderpanel.Top = button5.Top;
            this.Hide();
            Sign_Up frm = new Sign_Up();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please Fill Up All The Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool access = u.LogInUser(textBox1.Text, textBox2.Text);
                if (access == true)
                {
                    u = u.RunTimeObjectFromDataAccess();
                    this.Hide();
                    All_User smfrm = new All_User(u);
                    smfrm.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password.Try Again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
