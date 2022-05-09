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

namespace Stok_Takip_Otomasyonu
{
    public partial class MüşteriEkle : Form
    {
        public MüşteriEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        
        private void MüşteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //Veri Tabanındaki Müşteri Tablosuna Veri Ekleme

            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_Müşteri (TC,AdSoyad,Telefon,Adres,Email) values (@p1,@p2,@p3,@p4,@p5)", baglantı);
            ekle.Parameters.AddWithValue("@p1", msktc.Text);
            ekle.Parameters.AddWithValue("@p2", txtadsoyad.Text);
            ekle.Parameters.AddWithValue("@p3", msktelefon.Text);
            ekle.Parameters.AddWithValue("@p4", rchadres.Text);
            ekle.Parameters.AddWithValue("@p5", txtmail.Text);
            ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Müşteri Eklendi");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtadsoyad.Clear();
            txtmail.Clear();
            msktc.Clear();
            msktelefon.Clear();
            rchadres.Clear();
        }


    }
}
