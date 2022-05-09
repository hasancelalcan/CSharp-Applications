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
    public partial class MarkaEkle : Form
    {
        public MarkaEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");

        bool durum;
        private void markaengelle()
        {
            // ****Yazılan Kategori Ve Marka İsmi Veri Tabanında Var İse Kayıt Etme Uyarı Ver****
            durum = true;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_MarkaBilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (cmbkategori.Text==read["Kategori"].ToString() && txtmarka.Text == read["Marka"].ToString() || cmbkategori.Text=="" || txtmarka.Text == "")
                {
                    durum = false;
                }
            }
            baglantı.Close();
        }

        private void markalistele()
        {
            //                  marka Tablosunu DataGrid'e Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_MarkaBilgileri", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markaengelle();
            if (durum==true)
            {
                //*******Araçlara Yazılan(TextBox) Veriyi SQL'deki Tabloya Ekledi Ve Listeledi********
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_MarkaBilgileri (Kategori,Marka) values ('" + cmbkategori.Text + "','" + txtmarka.Text + "')", baglantı);
                ekle.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Marka Eklendi");
            }
            else
            {
                MessageBox.Show("Böyle Bir Marka Ve Kategori Var");
            }
            txtmarka.Clear();
            cmbkategori.Text = "";
            markalistele();
        }

        private void MarkaEkle_Load(object sender, EventArgs e)
        {
            KategoriGetir();
            markalistele();
        }

        private void KategoriGetir()
        {
            //*****SQL'deki Tablonun , Kategori Sütünundaki Verileri ComboBax'a Doldurma*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KategoriBilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmbkategori.Items.Add(read["Kategori"].ToString());
            }
            baglantı.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //                        Veri Tabanından Marka Sildi
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_MarkaBilgileri Where Marka=@p1", baglantı);
            sil.Parameters.AddWithValue("@p1", txtmarka.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Marka Silindi");
            markalistele();
          
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                    Veri Tabanına Marka Güncelledi
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_MarkaBilgileri set Kategori=@p1,Marka=@p2 where ID=@p3", baglantı);
            güncelle.Parameters.AddWithValue("@p1", cmbkategori.Text);
            güncelle.Parameters.AddWithValue("@p2", txtmarka.Text);
            güncelle.Parameters.AddWithValue("@p3", txtID.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Marka Güncellendi");
            markalistele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //          Tıklandığında Araçları Doldurur
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbkategori.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtmarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }
    }
}
