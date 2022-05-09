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

namespace Telefon_Satış_Otomasyonu
{
    public partial class KullanıcıGiriş : Form
    {
        public KullanıcıGiriş()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");
       
        private void btngiriş_Click(object sender, EventArgs e)
        { 

         //SQL'deki KullanıcıTablosundaki Verilerle Karşılaştırır Eğer Eşleşiyor İse Giriş Yapar

         baglantı.Open();       
         SqlCommand komutGiriş = new SqlCommand("Select *From tbl_Kullanıcı where KullanıcıAdı=@p1 and Sifre=@p2", baglantı);
         komutGiriş.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
         komutGiriş.Parameters.AddWithValue("@p2", txtşifre.Text);
         SqlDataReader oku = komutGiriş.ExecuteReader();
         if (oku.Read())
         {
                AnaSayfa yeni = new AnaSayfa();
                yeni.Show();
                this.Hide();
         }
         else
         {
                MessageBox.Show("Hatalı Giriş....");
         }

         baglantı.Close();
            
            txtkullanıcıadı.Clear();
            txtşifre.Clear();
        }

        private void KullanıcıGiriş_Load(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Göster/Gizle
            if (checkBox1.Checked == false)
            {
                txtşifre.UseSystemPasswordChar = true;
            }
            else
            {
                txtşifre.UseSystemPasswordChar = false;
            }
        }

        private void btnyenikullanıcı_Click(object sender, EventArgs e)
        {
            YeniKullanıcı fr = new YeniKullanıcı();
            fr.ShowDialog();
        }
    }
}
