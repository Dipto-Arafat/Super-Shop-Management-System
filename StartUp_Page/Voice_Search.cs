using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using Business_Logic_Layer;

namespace StartUp_Page
{
    public partial class Voice_Search : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        Product p = new Product();
        public Voice_Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            pictureBox1.Visible = true;
            button3.Visible = true;
            textBox1.Visible = true;
        }
        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
            recEngine.RecognizeAsyncStop();
            textBox1.Text = e.Result.Text;
            pictureBox1.Visible = false;
        }

        private void Voice_Search_Load(object sender, EventArgs e)
        {
            List<string> choices = new List<string>();
            choices = p.GetAllNameCategory();
            Choices commands = new Choices(choices.ToArray());
            GrammarBuilder gBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(
            recEngine_SpeechRecognized);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            pictureBox1.Visible = false;
            dataGridView1.DataSource = p.SearchByNameCategory(textBox1.Text);
            dataGridView1.Columns[1].HeaderCell.Value = "Product Name";
            dataGridView1.Columns[2].HeaderCell.Value = "Quantity";
            dataGridView1.Columns[3].HeaderCell.Value = "Price";
            dataGridView1.Columns[4].HeaderCell.Value = "Date";
            dataGridView1.Columns[5].HeaderCell.Value = "Type";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
