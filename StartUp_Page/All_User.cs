using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class All_User: Form
    {
        int picEvent = 0,picEventSearch=0;
        User uu=new User();
        public All_User(User u)
        {
            InitializeComponent();
            uu = u;
            MemoryStream ms = new MemoryStream(uu.user_Image);
            pictureBox5.Image = Image.FromStream(ms);
            if(u.User_Type==2)
            {
                button10.Visible = false;
                button14.Visible = false;
                button13.Visible = false;
                button15.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
            }
            if (u.User_Type == 3)
            {
                button10.Visible = false;
                button14.Visible = false;
                button13.Visible = false;
                button15.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button5.Visible = false;
                button4.Visible = false;
                button3.Visible = false;
                sliderpanel.Visible = false;
                pictureBox3.Visible = false;
                pictureBox5.Visible = false;
                pictureBox4.Visible = false;
                label2.Visible = true;
            }

            sliderpanel.Height = button5.Height;
            sliderpanel.Top = button5.Top;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sales_Man_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button4.Height;
            sliderpanel.Top = button4.Top;
            if (picEvent == 0)
            {
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.minus;
                picEvent = 1;
                panel5.Visible = true;
                picEventSearch = 0;
                sliderpanelProfile.Height = button11.Height;
                sliderpanelProfile.Top = button11.Top;
            }
            else
            {
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.add;
                picEvent = 0;
                panel5.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button3.Height;
            sliderpanel.Top = button3.Top;
            if (picEventSearch == 0)
            {
                picEventSearch = 1;
                panel5.Visible = false;
                picEvent = 0;
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.add;
            }
            else
            {
                picEventSearch = 0;
            }
            this.Hide();
            Search_All_Products sp1 = new Search_All_Products(uu);
            sp1.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button5.Height;
            sliderpanel.Top = button5.Top;
            this.Hide();
            Bill_Generate bg = new Bill_Generate(uu);
            bg.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sliderpanelProfile.Height = button11.Height;
            sliderpanelProfile.Top = button11.Top;
            this.Hide();
            Edit_Own_Profile eop = new Edit_Own_Profile(uu);
            eop.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sliderpanelProfile.Height = button12.Height;
            sliderpanelProfile.Top = button12.Top;
            this.Hide();
            View_Profile vp = new View_Profile(uu);
            vp.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button3.Height;
            sliderpanel.Top = button3.Top;
            if (picEventSearch == 0)
            {
                picEventSearch = 1;
                panel5.Visible= false;
                picEvent = 0;
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.add;
            }
            else
            {
                picEventSearch = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button13.Height;
            sliderpanel.Top = button13.Top;
            this.Hide();
            Manage_Product mp = new Manage_Product(uu);
            mp.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up start_up = new Start_Up(true);
            start_up.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button10.Height;
            sliderpanel.Top = button10.Top;
            this.Hide();
            Manage_Category mc = new Manage_Category(uu);
            mc.Show();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button14.Height;
            sliderpanel.Top = button14.Top;
            this.Hide();
            Place_Order_Supplier pc = new Place_Order_Supplier(uu);
            pc.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Account mgac = new Manage_Account(uu);
            mgac.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_SignUp lsu = new Login_SignUp();
            lsu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Store ms = new Manage_Store(uu);
            ms.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Supplier ms = new Manage_Supplier(uu);
            ms.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button4.Height;
            sliderpanel.Top = button4.Top;
            if (picEvent == 0)
            {
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.minus;
                picEvent = 1;
                panel5.Visible = true;
                picEventSearch = 0;
                sliderpanelProfile.Height = button11.Height;
                sliderpanelProfile.Top = button11.Top;
            }
            else
            {
                this.pictureBox3.Image = global::StartUp_Page.Properties.Resources.add;
                picEvent = 0;
                panel5.Visible = false;
            }
        }

    }
}
