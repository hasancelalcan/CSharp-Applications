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
    public partial class MüşteriListele : Form
    {
        public MüşteriListele()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        private void listele()
        {
            //Tablo Listele
            baglantı.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_Musteri", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();
        }

        private void kayıtsayısı()
        {
            //Tablodaki Toplam Müşteri Sayısı
            lblbkayıt.Text = "Toplam"+" "+(dataGridView1.Rows.Count - 1)+" "+"Kayıt Listelendi";
        }

        private void MüşteriListele_Load(object sender, EventArgs e)
        {
            listele();
            kayıtsayısı();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //Müşteri Güncelleme
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Musteri Set AdSoyad=@p1,Email=@p2,Telefon=@p3,Adres=@p4,TC=@p5 where ID=@p6",baglantı);
            güncelle.Parameters.AddWithValue("@p1",txtadsoyad.Text);
            güncelle.Parameters.AddWithValue("@p2", txtemail.Text);
            güncelle.Parameters.AddWithValue("@p3",msktelefon.Text);
            güncelle.Parameters.AddWithValue("@p4",richadres.Text);
            güncelle.Parameters.AddWithValue("@p5",msktc.Text);
            güncelle.Parameters.AddWithValue("@p6",txtıd.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi");
            listele();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Araçlara Taşıma
            txtıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtadsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            msktelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richadres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            msktc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Müşteri Silme
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Musteri where ID=@p1",baglantı);
            sil.Parameters.AddWithValue("@p1",txtıd.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Müşteri Bilgileri Silindi");
            listele();
            kayıtsayısı();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //TC'ye Göre Müşteri Arama
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Musteri where TC like '%"+textBox1.Text+"%' ",baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
            kayıtsayısı();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
