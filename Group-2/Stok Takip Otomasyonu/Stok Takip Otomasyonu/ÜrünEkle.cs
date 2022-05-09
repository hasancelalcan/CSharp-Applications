using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Otomasyonu
{
    public partial class ÜrünEkle : Form
    {
        public ÜrünEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");

        private void KategoriGetir()
        {
            //*****SQL'deki Tablonun , Kategori Sütünundaki Verileri ComboBax'a Doldurma*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KategoriBilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cbmKategori.Items.Add(read["Kategori"].ToString());
            }
            baglantı.Close();
        }
        private void ÜrünEkle_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }
        private void temizle()
        {
            txtAlışFiyatı.Clear();
            txtBarkodNo.Clear();
            txtMiktarı.Clear();
            txtSatışFiyatı.Clear();
            txtÜrünAdı.Clear();
            cbmKategori.Text = "";
            cmbMarka.Text = "";

        }

        private void cbmKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //*****SQL Tablosundaki , Kategorisi Seçilen Markaları ComboBax'a Çekme*******

            cmbMarka.Items.Clear();
            cmbMarka.Text = "";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_MarkaBilgileri where Kategori='"+cbmKategori.SelectedItem+"'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbMarka.Items.Add(read["Marka"].ToString());
            }
            baglantı.Close();
        }

        private void btnyeniekle_Click(object sender, EventArgs e)
        {
            //                              Veri Tabanına Ekleme Yaptı
            baglantı.Open();
            SqlCommand yeniekle = new SqlCommand("Insert into tbl_Ürün (BarkodNo,Kategori,Marka,ÜrünAdı,Miktarı,AlışFiyatı,SatışFiyatı,Tarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglantı);
            yeniekle.Parameters.AddWithValue("@p1", txtBarkodNo.Text);
            yeniekle.Parameters.AddWithValue("@p2", cbmKategori.Text);
            yeniekle.Parameters.AddWithValue("@p3", cmbMarka.Text);
            yeniekle.Parameters.AddWithValue("@p4", txtÜrünAdı.Text);
            yeniekle.Parameters.AddWithValue("@p5", int.Parse(txtMiktarı.Text));
            yeniekle.Parameters.AddWithValue("@p6", double.Parse(txtAlışFiyatı.Text));
            yeniekle.Parameters.AddWithValue("@p7", double.Parse(txtSatışFiyatı.Text));
            yeniekle.Parameters.AddWithValue("@p8", DateTime.Now.ToString());
            yeniekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ürün Eklendi");
            temizle();

        }

        private void BarkodNotxt_TextChanged(object sender, EventArgs e)
        {
                               
            if (BarkodNotxt.Text == "")
            {
                lblMiktar.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

            // ***BarkodNo Yazıldığında O BarkodNo ile Eşleşen Bilgiler Araçlara Dolduruldu***

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_Ürün where BarkodNo like '"+BarkodNotxt.Text+"'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Kategoritxt.Text = read["Kategori"].ToString();
                Markatxt.Text = read["Marka"].ToString();
                ÜrünAdıtxt.Text = read["ÜrünAdı"].ToString();
                lblMiktar.Text = read["Miktarı"].ToString();
                AlışFiyatıtxt.Text = read["AlışFiyatı"].ToString();
                SatışFiyatıtxt.Text = read["SatışFiyatı"].ToString();
            }
            baglantı.Close();
        }

        private void btnolanekle_Click(object sender, EventArgs e)
        {
            //   ***BarkodNo'yu Baz Alarak Yazılan Miktarı Veri Tabanında Toplayarak Güncelledi***
            baglantı.Open();
            SqlCommand olanekle = new SqlCommand("Update tbl_Ürün set Miktarı=miktarı+'"+int.Parse(Miktarıtxt.Text)+"' where BarkodNo='"+BarkodNotxt.Text+"'",baglantı);
            olanekle.ExecuteNonQuery();
            baglantı.Close(); 

            MessageBox.Show("Var Olan Ürüne Ekleme Yapıldı");
            foreach (Control item in groupBox2.Controls)
            {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
            }
            
        }

        private void Kategoritxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
