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
    public partial class KategoriEkle : Form
    {
        public KategoriEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        bool durum;
        private void kategoriengelle()
        {
            // ****Yazılan Kategori İsmi Veri Tabanında Var İse Kayıt Etme Uyarı Ver****
            durum = true;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KategoriBilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TXTAD.Text == read["Kategori"].ToString() || TXTAD.Text == "")
                {
                    durum = false;
                }
                
            }
            baglantı.Close();
        }
        private void kategorilistele()
        {
            //                  Kategori Tablosunu DataGrid'e Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_KategoriBilgileri", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void KategoriEkle_Load(object sender, EventArgs e)
        {
            kategorilistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategoriengelle();
            if (durum==true)
            {
                //*******Araçlara Yazılan(TextBox) Veriyi SQL'deki Tabloya Ekledi********
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_KategoriBilgileri (Kategori) values('" + TXTAD.Text + "')", baglantı);
                ekle.ExecuteNonQuery();
                baglantı.Close(); 
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Böyle Bir Kategori Var");
            }
            TXTAD.Clear();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //                        Veri Tabanından Kategori Sildi
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_KategoriBilgileri Where Kategori=@p1",baglantı);
            sil.Parameters.AddWithValue("@p1", TXTAD.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Silindi");
            kategorilistele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                    Veri Tabanına Kategori Güncelledi
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_KategoriBilgileri set Kategori=@p1 where ID=@p2", baglantı);
            güncelle.Parameters.AddWithValue("@p1", TXTAD.Text);
            güncelle.Parameters.AddWithValue("@p2", TXTID.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kategori Güncellendi");
            kategorilistele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //          Tıklandığında Araçları Doldurur
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TXTID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TXTAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
