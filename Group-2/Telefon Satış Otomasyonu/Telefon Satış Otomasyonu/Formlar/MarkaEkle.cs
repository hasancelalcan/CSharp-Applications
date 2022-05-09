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
    public partial class MarkaEkle : Form
    {
        public MarkaEkle()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        public bool durum;
        public bool MarkaKontrol()
        {
            //Markası Aynı Olan Kayıt Eklenmesini Önler
            durum = true;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From tbl_Marka", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Marka"].ToString()==textBox1.Text || textBox1.Text=="")
                {
                    durum = false;
                }
            }
            baglantı.Close();
            return durum;
        }


        private void btnekle_Click(object sender, EventArgs e)
        {
            //Marka Ekleme
            MarkaKontrol();
            if (durum == true)
            {
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_Marka (Marka) values (@p1)", baglantı);
                ekle.Parameters.AddWithValue("@p1", textBox1.Text);
                ekle.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Marka Eklendi");
            }
            else
            {
                MessageBox.Show("Bu Marka Zaten Var !!!");
            }
            
        }
    }
}
