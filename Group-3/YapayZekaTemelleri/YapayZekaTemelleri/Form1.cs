using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 
using SpeechLib;
using System.Speech.Recognition;

namespace YapayZekaTemelleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ProductList()
        {
            // Sesli komut ile datagrid'e verileri çekme
            var products = db.tblProduct.ToList();
            dataGridView1.DataSource = products;
        }

        void enabled()
        {
            txtBuyPrice.Enabled = false;
            txtName.Enabled = false;
            txtBrand.Enabled = false;
            txtStock.Enabled = false;
            txtSellPrice.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;
        }

        void ColorMethod()
        {
            txtBuyPrice.BackColor = Color.White;
            txtName.BackColor = Color.White;
            txtBrand.BackColor = Color.White;
            txtStock.BackColor = Color.White;
            txtSellPrice.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        dbProductEntities db = new dbProductEntities();

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            // Sesli komutdan okunan metini textbox'a yazar 
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                btnSpeak.Text = "Please Speak";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }
            catch (Exception)
            {

                btnSpeak.Text = "Error Try Again";
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Textbox'a girilen metini okur

            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // sesli komutla richTextBox'a yazilan degeri ilgili araçlara tasir
            if (txtName.BackColor == Color.Yellow && txtName.Enabled==true)
            {
                txtName.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (txtBrand.BackColor == Color.Yellow && txtBrand.Enabled == true)
            {
                txtBrand.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (txtStock.BackColor == Color.Yellow && txtStock.Enabled == true)
            {
                txtStock.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (txtSellPrice.BackColor==Color.Yellow && txtSellPrice.Enabled==true)
            {
                txtSellPrice.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (txtBuyPrice.BackColor == Color.Yellow && txtBuyPrice.Enabled == true)
            {
                txtBuyPrice.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (txtCategori.BackColor == Color.Yellow && txtCategori.Enabled == true)
            {
                txtCategori.Text = richTextBox1.Text;
                enabled();
                ColorMethod();
            }

            if (maskedTextBox1.BackColor == Color.Yellow && maskedTextBox1.Enabled == true)
            {
                maskedTextBox1.Text = DateTime.Now.ToShortDateString();
                enabled();
                ColorMethod();
            }

            if (comboBox1.BackColor == Color.Yellow && comboBox1.Enabled == true)
            {
                comboBox1.Text = "Active";
                enabled();
                ColorMethod();
            }


            // Sesli komutdan alınan veriye (richbox'a yazılan) göre textbox'lara gitme

            if (richTextBox1.Text == "List of products" || richTextBox1.Text == "Products List" || richTextBox1.Text == "56" )            // Sesli komut ile bu kelimeler söylenirse (richbox'a yazılır) datagrid'e deger çek
            {
                ProductList();
            }

            if (richTextBox1.Text=="Add" || richTextBox1.Text=="Add to" || richTextBox1.Text=="Add the")
            {
                tblProduct t = new tblProduct();
                t.NAME = txtName.Text;
                t.BRAND = txtBrand.Text;
                t.SELLPRICE = decimal.Parse(txtSellPrice.Text);
                t.BUYPRICE = decimal.Parse(txtBuyPrice.Text);
                t.STOCK = short.Parse(txtStock.Text);
                t.PRODUCTCASE = true;
                t.DATE = DateTime.Parse(maskedTextBox1.Text);
                t.CATEGORY = txtCategori.Text;
                db.tblProduct.Add(t);
                db.SaveChanges();
                label9.Text = "Products saved in Database";
            }
            {

            }
           
            if (richTextBox1.Text == "Name" || richTextBox1.Text == "Product" || richTextBox1.Text == "Products")
            {
                txtName.Focus();
                txtName.BackColor = Color.Yellow;
                txtName.Enabled = true;
            }

            if (richTextBox1.Text == "Mark" || richTextBox1.Text == "Brand")
            {
                txtBrand.Focus();
                txtBrand.BackColor = Color.Yellow;
                txtBrand.Enabled = true;
            }

            if (richTextBox1.Text == "Stock" || richTextBox1.Text == "Stocks" || richTextBox1.Text == "Store")
            {
                txtStock.Focus();
                txtStock.BackColor = Color.Yellow;
                txtStock.Enabled = true;
            }

            if (richTextBox1.Text == "Sell price" || richTextBox1.Text == "52" || richTextBox1.Text == "Sales" || richTextBox1.Text == "Sale")
            {
                txtSellPrice.Focus();
                txtSellPrice.BackColor = Color.Yellow;
                txtSellPrice.Enabled = true;
            }

            if (richTextBox1.Text == "By price" || richTextBox1.Text == "Buying price" || richTextBox1.Text == "Buy" || richTextBox1.Text == "By")
            {
                txtBuyPrice.Focus();
                txtBuyPrice.BackColor = Color.Yellow;
                txtBuyPrice.Enabled = true;
            }

            if (richTextBox1.Text == "Category" || richTextBox1.Text == "Set" || richTextBox1.Text == "Group" || richTextBox1.Text == "Cluster" || richTextBox1.Text == "Cents")
            {
                txtCategori.Focus();
                txtCategori.BackColor = Color.Yellow;
                txtCategori.Enabled = true;
            }

            if (richTextBox1.Text == "Date" || richTextBox1.Text == "Dates")
            {
                maskedTextBox1.Enabled = true;
                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Yellow;
            }

            if (richTextBox1.Text == "State" || richTextBox1.Text == "States" || richTextBox1.Text == "Case" || richTextBox1.Text == "Chase")
            {
                comboBox1.Enabled = true;
                comboBox1.Focus();
                comboBox1.BackColor = Color.Yellow;
            }


            // Sesli komut ile çıkış yapma
            if (richTextBox1.Text == "Exit application" || richTextBox1.Text =="Exits application" || richTextBox1.Text=="Exit app" || richTextBox1.Text=="Exit")
            {
                timer1.Stop();
                Application.Exit();
            }

            if (richTextBox1.Text == "Paint")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabled();
            ColorMethod();
            timer1.Start();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label9.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Sesli komutdan okunan metini textbox'a yazar 
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                btnSpeak.Text = "Please Speak";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }
            catch (Exception)
            {

                btnSpeak.Text = "Error Try Again";
            }
        }
    }
}
