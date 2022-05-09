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

namespace Telefon_Satış_Otomasyonu.Formlar
{
    public partial class MüşteriEkle : Form
    {
        public MüşteriEkle()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        public bool durum;
        public bool MüşteriKontrol()
        {
            //TC'si Aynı Olan Kayıt Eklenmesini Önler
            durum = true;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From tbl_Musteri", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["TC"].ToString() == msktc.Text)
                {
                    durum = false;
                }
            }
            baglantı.Close();
            return durum;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //Müşteri Ekleme
            MüşteriKontrol();
            if (durum == true)
            {
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_Musteri (AdSoyad,Email,Telefon,Adres,TC) values (@p1,@p2,@p3,@p4,@p5)", baglantı);
                ekle.Parameters.AddWithValue("@p1", txtadsoyad.Text);
                ekle.Parameters.AddWithValue("@p2", txtemail.Text);
                ekle.Parameters.AddWithValue("@p3", msktelefon.Text);
                ekle.Parameters.AddWithValue("@p4", richadres.Text);
                ekle.Parameters.AddWithValue("@p5", msktc.Text);
                ekle.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Müşteri Eklendi");
            }
            else
            {
                MessageBox.Show("Bu TC No'ya Kayıtlı Müşteri Var !!!");
            }
          
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MüşteriEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
