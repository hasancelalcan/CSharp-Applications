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

namespace Sinema_Otomasyonu
{
    public partial class SeansEkle : Form
    {
        public SeansEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = Sinema Otomasyonu; Integrated Security = True");

        //DataSet Adresi
        SinemaTableAdapters.tbl_SeansBilgiTableAdapter filmseansı = new  SinemaTableAdapters.tbl_SeansBilgiTableAdapter();

        string seans ="";

        private void RadioButtunSeçiliyse()
        {
            //Seçilen RadioButon Yazısını Seansa Kaydeder
            if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if(radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;
            else if (radioButton10.Checked == true) seans = radioButton10.Text;
            else if (radioButton11.Checked == true) seans = radioButton11.Text;
            else if (radioButton12.Checked == true) seans = radioButton12.Text;

        }
        private void ComboBoxaFilmveSalonÇekme(ComboBox Combo,string sql,string sql2)
        {
            //ComboBox'a SQL'den Film Adı ve Salon Adı Çekme
            baglantı.Open();
            SqlCommand komut = new SqlCommand(sql,baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()==true)
            {
                Combo.Items.Add(read[sql2].ToString());
            }
            baglantı.Close();

        }
        private void TarihKarşılaştır()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *from tbl_SeansBilgi where SalonAdı='" + cmbsalon.Text + "' and Tarih='" + dateTimePicker1.Text + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglantı.Close();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {

            //DataSet Kısmında Oluşturulan INSERT Sorgusu(SeansEkle) İle Ekleme

            RadioButtunSeçiliyse();
            if (seans!="")
            {
                filmseansı.SeansEkle(cmbfilm.Text,cmbsalon.Text,dateTimePicker1.Text,seans);
                MessageBox.Show("Seans Ekleme Gerçekleşti","Kayıt");
            }
            else if (seans=="")
            {
                MessageBox.Show("Seans Seçiniz","Uyarı");
            }
            cmbsalon.Text = "";
            cmbfilm.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Seçilen Saat ve Tarih Tutatlılığı 

            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;
            }

            DateTime bugün = DateTime.Parse(DateTime.Now.ToLongDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni==bugün)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                TarihKarşılaştır();
            }
            else if (yeni>bugün)
            {
                TarihKarşılaştır();
            }
            else if (yeni<bugün)
            {
                MessageBox.Show("Geriye Dönük İşlem Yapılamaz");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }

        }

        

        private void SeansEkle_Load(object sender, EventArgs e)
        {
            //ComboBoxlara Çağırma
            ComboBoxaFilmveSalonÇekme(cmbfilm,"Select *from  tbl_FilmBilgi","FilmAdı");
            ComboBoxaFilmveSalonÇekme(cmbsalon,"Select *from tbl_SalonBilgi","SalonAdı");
        }

        private void cmbsalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
