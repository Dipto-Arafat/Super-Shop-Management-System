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
    public partial class Admin_Create_Account : Form
    {
        User uu;
        string imgLoc = "";
        public Admin_Create_Account(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void Admin_Create_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up sup = new Start_Up();
            sup.Show();
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
            Manage_Account auda = new Manage_Account(uu);
            auda.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox2.Text == "" || textBox2.Text=="" || comboBox3.Text=="")
                {
                    MessageBox.Show("Please Fill Up All The Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bool duplicate_id = false;
                    duplicate_id = uu.Duplicate_ID_Check_User(textBox3.Text);
                    if (duplicate_id == true)
                    {
                        MessageBox.Show("User ID already exists.Try something Different");
                    }
                    else
                    {
                        uu.CreateUser(textBox1.Text, textBox3.Text, textBox4.Text, comboBox1.Text, textBox5.Text, textBox6.Text, textBox7.Text, comboBox2.Text, img,textBox2.Text,comboBox3.Text);
                        MessageBox.Show("Account Created Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Equals("Empty path name is not legal."))
                    MessageBox.Show("Please select a valid Profile Picture", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Server Error.Try Later");
                }
            }
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void comboBox3_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
