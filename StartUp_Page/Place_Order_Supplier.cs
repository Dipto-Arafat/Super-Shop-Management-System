using System;
using System.Windows.Forms;
using Business_Logic_Layer;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;


namespace StartUp_Page
{
    public partial class Place_Order_Supplier : Form
    {
        User uu;
        Supplier s = new Supplier();
        public Place_Order_Supplier(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Place_Order_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Place_Order_Supplier_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Fill Up to whom this message will be send.. And Also the message");
            }
            else
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
                    msg.To.Add(textBox1.Text);
                    msg.From = new MailAddress("tawhidaiub37@gmail.com");
                    msg.Subject = textBox3.Text;
                    msg.Body = textBox2.Text;
                    client.Send(msg);
                    MessageBox.Show("Your Message Has Been Sent To The Supplier Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Hide();
                All_User u = new All_User(uu);
                u.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            All_User au = new All_User(uu);
            au.Show();
        }
    }
}
