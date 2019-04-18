using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class Bill_Generate : Form
    {
        Product p = new Product();
        User uu;
        int change = 0;
        public Bill_Generate(User u)
        {
            InitializeComponent();
            uu = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc,new FileStream("Bill.pdf",FileMode.Create));
            doc.Open();
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            
            PdfPTable pdfTableFooter = new PdfPTable(1);
            pdfTableFooter.DefaultCell.BorderWidth = 0;
            pdfTableFooter.WidthPercentage = 100;
            pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column
            pdfTable1.WidthPercentage = 80;
            pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            pdfTable1.DefaultCell.BorderWidth = 0;

            PdfPTable pdfTable2 = new PdfPTable(1);
            pdfTable2.WidthPercentage = 80;
            pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            pdfTable2.DefaultCell.BorderWidth = 0;

            Chunk c1 = new Chunk("\n\n\nSuper Shop BD\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15));
            c1.Font.Color = new BaseColor(0, 0, 0);
            c1.Font.SetStyle(0);
            Phrase p1 = new Phrase();
            p1.Add(c1);
            pdfTable1.AddCell(p1);

            Chunk c2 = new Chunk("28/3 Road No: 7, Banani, Dhaka", FontFactory.GetFont("Times New Roman"));
            c2.Font.Color = new BaseColor(0, 0, 0);
            c2.Font.SetStyle(0);//0 For Normal Font
            c2.Font.Size = 11;
            Phrase p2 = new Phrase();
            p2.Add(c2);
            pdfTable2.AddCell(p2);

            Chunk c3 = new Chunk("Customer Care : +8801775885646/ +8801708919548   Email: ssbd@gmail.com \n ", FontFactory.GetFont("Times New Roman"));
            c3.Font.Color = new BaseColor(0, 0, 0);
            c3.Font.SetStyle(0);
            c3.Font.Size = 10;
            Phrase p3 = new Phrase();
            p3.Add(c3);
            pdfTable2.AddCell(p3);

            Chunk c4 = new Chunk("\nDATE: " + DateTime.Now.ToString() + "\n\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
            c4.Font.Color = new BaseColor(0, 0, 0);
            c4.Font.SetStyle(0);
            Phrase p4 = new Phrase();
            p4.Add(c4);
            pdfTable2.AddCell(p4);
            doc.Add(pdfTable1);
            doc.Add(pdfTable2);
            
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }
            table.HeaderRows = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            Chunk cnkFooter = new Chunk("\n\nTOTAL : TK.\t" + textBox1.Text+"\n\nAmount Paid:\t"+textBox2.Text+"\n\nChange Due:\t"+textBox3.Text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
            cnkFooter.Font.Size = 10;
            pdfTableFooter.AddCell(new Phrase(cnkFooter));

            doc.Add(pdfTableFooter);
            doc.Close();
            MessageBox.Show("Bill has been Generated");
            
           button1.Visible = false;
            WindowState = FormWindowState.Minimized;
           System.Diagnostics.Process.Start("F:\\Editing Going On\\Resubmission V2\\StartUp_Page\\StartUp_Page\\bin\\Debug\\Bill.pdf");
        }

        private void Bill_Generate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Bill_Generate_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = p.GenerateBillAll();
            dataGridView1.Columns[0].HeaderCell.Value = "Product Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
            dataGridView1.Columns[3].HeaderCell.Value="Price";
            dataGridView1.Columns.Remove("DiscountRate");
            dataGridView1.Columns.Remove("Self_No");
            dataGridView1.Columns.Remove("Category_Type");
            dataGridView1.Columns.Remove("Product_Date");
            int sum = 0;
            for(int i=0;i<dataGridView1.Rows.Count;++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            textBox1.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            All_User au = new All_User(uu);
            au.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text)>int.Parse(textBox2.Text) || int.Parse(textBox2.Text)<0 || textBox2.Text=="")
            {
                MessageBox.Show("Please Complete Full Payment");

            }
            else
            {
                MessageBox.Show("Payment Complete");
                if(int.Parse(textBox2.Text) > int.Parse(textBox1.Text))
                {
                    change = int.Parse(textBox2.Text) - int.Parse(textBox1.Text);
                    label3.Visible = true;
                    textBox3.Text = change.ToString();
                    textBox3.Visible = true;
                }
                button1.Visible = true;
            }
        }
    }
}
