using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon_Satış_Otomasyonu.Classlar
{
    class Kullanıcı
    {
        //SQL KOLONU KAPSÜLLEME
        private string AdıSoyadı;
        private string Telefon;
        private string Adres;
        private string Email;
        private string KullanıcıAdı;
        private string Sifre;
        private string Görevi;
        private string Resim;
        public string AdıSoyadı2
        {
            get
            { return AdıSoyadı; }
            set
            { AdıSoyadı = value; }
         
        }

        public string Telefon1 { get => Telefon; set => Telefon = value; }
        public string Adres1 { get => Adres; set => Adres = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string KullanıcıAdı1 { get => KullanıcıAdı; set => KullanıcıAdı = value; }
        public string Sifre1 { get => Sifre; set => Sifre = value; }
        public string Görevi1 { get => Görevi; set => Görevi = value; }
        public string Resim1 { get => Resim; set => Resim = value; }

        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP - VRK3DH1\\SQLEXPRESS; Initial Catalog = TelefonSatışOtomasyou; Integrated Security = True");

        //public void KullanıcıGirisi(TextBox txtşifre, TextBox txtkullanıcıadı)
        //{
        //    //SQL'deki Verilere Göre Kullanıcı Girişi

        //    if (txtkullanıcıadı.Text=="" || txtşifre.Text=="")
        //    {
        //        MessageBox.Show("Kullanıcı Adı veya Şifre Boş Geçilemez !!!");
        //    }
        //    else
        //    {
        //        baglantı.Open();
        //        SqlCommand komut = new SqlCommand("Select *From tbl_Kullanıcı Where KullanıcıAdı ='"+txtkullanıcıadı.Text+ "' and Sifre='" + txtşifre.Text + "'", baglantı);
        //        SqlDataReader dr = komut.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            AnaSayfa fr = new AnaSayfa();
        //            fr.Show();
        //            KullanıcıGiriş.ActiveForm.Visible = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hatalı Giriş");
        //        }
        //        baglantı.Close();
        //    }
        //}
    }
}
