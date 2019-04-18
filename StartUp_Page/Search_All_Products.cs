using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class Search_All_Products : Form
    {
        Product p = new Product();
        User uu;
        int type = 0;
        public Search_All_Products()
        {
            InitializeComponent();
            type = 0;
            fillCombo();
        }
        public Search_All_Products(User u)
        {
            InitializeComponent();
            uu = u;
            type = 1;
            fillCombo();
        }



        private void Search_All_Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                this.Hide();
                Start_Up sp = new Start_Up(true);
                sp.Show();
            }
            else if (type == 1)
            {
                this.Hide();
                All_User au = new All_User(uu);
                au.Show();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up sp = new Start_Up(true);
            sp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_Up sp = new Start_Up(true);
            sp.Show();
        }

        public void fillCombo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DELL_N5559\DIPTOTAWHID;Initial Catalog=CSharpProject;Integrated Security=True");

            string query = "SELECT * FROM PRODUCT_CATEGORY";

            SqlCommand str = new SqlCommand(query, con);
            SqlDataReader myReader;
            try
            {
                con.Open();
                myReader = str.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString(1);
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Please Fill UP 'Enter Name'Textbox ", "Empty"); }
            else
            {
                dataGridView1.DataSource = p.SearchByName(textBox1.Text);
                dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
                dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
                dataGridView1.Columns[3].HeaderCell.Value = "Price";
                dataGridView1.Columns[4].HeaderCell.Value = "Date";
                dataGridView1.Columns[5].HeaderCell.Value = "Type";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Please Fill UP 'Enter Category 'Textbox ", "Empty"); }
            else
            {
               dataGridView1.DataSource = p.SearchByCategory(comboBox1.Text);
                dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
                dataGridView1.Columns[2].HeaderCell.Value = "Entry Date";
                dataGridView1.Columns[3].HeaderCell.Value = "Price";
                dataGridView1.Columns[4].HeaderCell.Value = "Total Quantity";
                dataGridView1.Columns[5].HeaderCell.Value = "Type";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("You Must Have to fill up the Discount range and the Category");
            }
            else
            {
                dataGridView1.DataSource = p.SearchByDiscountRange(textBox3.Text,textBox4.Text,comboBox1.Text);
                dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
                dataGridView1.Columns[2].HeaderCell.Value = "Entry Date";
                dataGridView1.Columns[3].HeaderCell.Value = "Price";
                dataGridView1.Columns[4].HeaderCell.Value = "Total Quantity";
                dataGridView1.Columns[5].HeaderCell.Value = "Type";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("You Must Have to fill up the Price and the Category");
            }
            else
            {
                dataGridView1.DataSource = p.SearchByPriceLower(textBox2.Text, comboBox1.Text);
                dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
                dataGridView1.Columns[2].HeaderCell.Value = "Entry Date";
                dataGridView1.Columns[3].HeaderCell.Value = "Price";
                dataGridView1.Columns[4].HeaderCell.Value = "Total Quantity";
                dataGridView1.Columns[5].HeaderCell.Value = "Type";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("You Must Have to fill up the Price and the Category");
            }
            else
            {
                dataGridView1.DataSource = p.SearchByPriceUpper(textBox2.Text, comboBox1.Text);
                dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
                dataGridView1.Columns[2].HeaderCell.Value = "Entry Date";
                dataGridView1.Columns[3].HeaderCell.Value = "Price";
                dataGridView1.Columns[4].HeaderCell.Value = "Total Quantity";
                dataGridView1.Columns[5].HeaderCell.Value = "Type";
            }
        }
    }
}
