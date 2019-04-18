using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class Sign_Up : Form
    {
        string imgLoc = "";
        User u = new User();
        public Sign_Up()
        {
            InitializeComponent();
            sliderpanel.Height = button5.Height;
            sliderpanel.Top = button5.Top;
        }

        private void Sign_Up_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sliderpanel.Height = button4.Height;
            sliderpanel.Top = button4.Top;
            this.Hide();
            Login_SignUp frm = new Login_SignUp();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Please Fill Up All The Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bool duplicate_id = false;
                    duplicate_id=u.Duplicate_ID_Check_User(textBox3.Text);
                    if (duplicate_id == true)
                    {
                        MessageBox.Show("User ID already exists.Try something Different");
                    }
                    else
                    {
                        u.InsertUser(textBox1.Text, textBox3.Text, textBox4.Text, comboBox1.Text, textBox5.Text, textBox6.Text, textBox7.Text, comboBox2.Text, img);
                        MessageBox.Show("Successfully Signed Up.Please wait for Admin Approval");
                        this.Hide();
                        Login_SignUp lgnp = new Login_SignUp();
                        lgnp.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Equals("Empty path name is not legal."))
                    MessageBox.Show("Please select a valid Profile Picture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    //MessageBox.Show("Duplicate User ID Is Not Allowed.Try Another", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("Server Error.Try Later");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG FILES(*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files(*.*)|*.*";
                dlg.Title = "Select Employee Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picEmp.ImageLocation = imgLoc;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up frm = new Start_Up(true);
            frm.Show();
        }
    }
}
