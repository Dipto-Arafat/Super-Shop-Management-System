using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;

namespace StartUp_Page
{
    public partial class Leave_a_Comment : Form
    {
        public Leave_a_Comment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("tawhidaiub37@gmail.com", "T@whidsultan");
                MailMessage msg = new MailMessage();
                msg.To.Add("artdipto@gmail.com");
                msg.From = new MailAddress("tawhidaiub37@gmail.com");
                msg.Subject = textBox1.Text;
                msg.Body = textBox2.Text;
                client.Send(msg);
                MessageBox.Show("Your Comment Has Been Sent To The Admin Successfully.Thanks.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            Start_Up s1 = new Start_Up(true);
            s1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Leave_a_Comment_Load(object sender, EventArgs e)
        {

        }

        private void Leave_a_Comment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }
    }
}
