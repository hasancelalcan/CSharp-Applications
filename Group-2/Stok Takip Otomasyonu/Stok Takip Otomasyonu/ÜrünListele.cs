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
    public partial class ÜrünListele : Form
    {
        public ÜrünListele()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        DataTable daset = new DataTable();
        private void temizle()
        {
            BarkodNotxt.Clear();
            Kategoritxt.Clear();
            Markatxt.Clear();
            AlışFiyatıtxt.Clear();
            SatışFiyatıtxt.Clear();
            Miktarıtxt.Clear();
            ÜrünAdıtxt.Clear();
            cmbKategori.Text = "";
            cmbMarka.Text = "";
        }
        private void KategoriGetir()
        {
            //*****SQL'deki Tablonun , Kategori Sütünundaki Verileri ComboBax'a Doldurma*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KategoriBilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbKategori.Items.Add(read["Kategori"].ToString());
            }
            baglantı.Close();
        }
        private void Listele()
        {
            // SQL'deki Tabloyu DataGrid'e Listeleler
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Ürün", baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds, "ÜrünAdı");
            dataGridView1.DataSource = ds.Tables["ÜrünAdı"];
            baglantı.Close();
        }
        private void ÜrünListele_Load(object sender, EventArgs e)
        {
            KategoriGetir();
            Listele();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //    Çift Tıkandığında Araçları Doldurur
            BarkodNotxt.Text = dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString();
            Kategoritxt.Text = dataGridView1.CurrentRow.Cells["Kategori"].Value.ToString();
            Markatxt.Text = dataGridView1.CurrentRow.Cells["Marka"].Value.ToString();
            ÜrünAdıtxt.Text = dataGridView1.CurrentRow.Cells["ÜrünAdı"].Value.ToString();
            Miktarıtxt.Text = dataGridView1.CurrentRow.Cells["Miktarı"].Value.ToString();
            AlışFiyatıtxt.Text = dataGridView1.CurrentRow.Cells["AlışFiyatı"].Value.ToString();
            SatışFiyatıtxt.Text = dataGridView1.CurrentRow.Cells["SatışFiyatı"].Value.ToString();
           
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                  SQL'deki Verileri Günceller 
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Ürün set ÜrünAdı=@p1,Miktarı=@p2,AlışFiyatı=@p3,SatışFiyatı=@p4 where BarkodNo=@p5", baglantı);
            güncelle.Parameters.AddWithValue("@p1", ÜrünAdıtxt.Text);
            güncelle.Parameters.AddWithValue("@p2", int.Parse(Miktarıtxt.Text));
            güncelle.Parameters.AddWithValue("@p3", Double.Parse(AlışFiyatıtxt.Text));
            güncelle.Parameters.AddWithValue("@p4", double.Parse(SatışFiyatıtxt.Text));
            güncelle.Parameters.AddWithValue("@p5", BarkodNotxt.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt Güncellendi");
            Listele();
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //                          SQL'deki Verileri Günceller 
            if (BarkodNotxt.Text!="")
            {
                baglantı.Open();
                SqlCommand güncelle = new SqlCommand("Update tbl_Ürün set Kategori=@p1,Marka=@p2 where BarkodNo=@p3", baglantı);
                güncelle.Parameters.AddWithValue("@p1", cmbKategori.Text);
                güncelle.Parameters.AddWithValue("@p2", cmbMarka.Text);
                güncelle.Parameters.AddWithValue("@p3", BarkodNotxt.Text);
                güncelle.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Kayıt Güncellendi");
                Listele();
                temizle();
            }
            else
            {
                MessageBox.Show("Barkod No Yazılı Değil");     
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //                 BarkodNo'yu Araçlardan Alıp SQL'de Arayıp Eşleşenleri Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_Ürün Where BarkodNo Like '%" +textBox1.Text+ "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //*****SQL Tablosundaki , Kategorisi Seçilen Markaları ComboBax'a Çekme*******

            cmbMarka.Items.Clear();
            cmbMarka.Text = "";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_MarkaBilgileri where Kategori='" + cmbKategori.SelectedItem + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbMarka.Items.Add(read["Marka"].ToString());
            }
            baglantı.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //                 BarkodNo'yu Baz Alarak Verileri Veri Tabanında Sildi
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Ürün Where BarkodNo=@p1", baglantı);
            sil.Parameters.AddWithValue("@p1", BarkodNotxt.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ürün Silindi");
            Listele();
            temizle();
        }
    }
}
