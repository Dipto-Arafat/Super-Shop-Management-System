using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUp_Page
{
    public partial class Start_Up : MetroFramework.Forms.MetroForm
    {
        public Start_Up()
        {
            Thread t = new Thread(new ThreadStart(Loading));
            t.Start();
            InitializeComponent();
            for(int i=0;i<100;i++)
            {
                Thread.Sleep(1);
            }
            t.Abort();
        }
        public Start_Up(bool a)
        {
            InitializeComponent();
        }
        void Loading()
        {
                SplashScreen frm = new SplashScreen();
                Application.Run(frm);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Log_In_Click(object sender, EventArgs e)
        {
            Login_SignUp frm = new Login_SignUp();
            frm.Show();
            this.Hide();
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Leave_a_Comment lcm = new Leave_a_Comment();
            lcm.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Voice_Search vc = new Voice_Search();
            vc.Show();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Store ms = new Manage_Store();
            ms.Show();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Contact_Details scd = new Show_Contact_Details();
            scd.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Discount d = new Discount();
            d.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_All_Products sp1 = new Search_All_Products();
            sp1.Show();
        }
    }
}
