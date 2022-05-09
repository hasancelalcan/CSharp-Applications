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
    public partial class MüşteriListele : Form
    {
        public MüşteriListele()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");

        DataSet daset = new DataSet();
        
        private void Temizle()
        {
            txtadsoyad.Clear();
            txtmail.Clear();
            msktc.Clear();
            msktelefon.Clear();
            rchadres.Clear();
        }
        private void KayıtListele()
        {
            //                  Veri Tabanındaki Tabloyu DataGrid'e Listeledi
            baglantı.Open();
            SqlDataAdapter listele = new SqlDataAdapter("Select *From tbl_Müşteri", baglantı);
            listele.Fill(daset, "tbl_Müşteri");
            dataGridView1.DataSource = daset.Tables["tbl_Müşteri"];
            baglantı.Close();
        }
        private void MüşteriListele_Load(object sender, EventArgs e)
        {
            KayıtListele();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //                  DataGride Tıklanan Sütünü Araçlara Aktarma
            msktc.Text = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
            txtadsoyad.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
            msktelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            rchadres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                   TC'yi Baz Alarak Verileri Veri Tabanında Güncelledi
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Müşteri Set AdSoyad=@adsoyad,Telefon=@telefon,Adres=@adres,Email=@email Where TC=@tc", baglantı);
            güncelle.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
            güncelle.Parameters.AddWithValue("@telefon", msktelefon.Text);
            güncelle.Parameters.AddWithValue("@adres", rchadres.Text);
            güncelle.Parameters.AddWithValue("@email", txtmail.Text);
            güncelle.Parameters.AddWithValue("@tc", msktc.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            daset.Tables["tbl_Müşteri"].Clear();
            KayıtListele();
            MessageBox.Show("Kayıt Güncellendi");
            Temizle();
          
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //                 TC'yi Baz Alarak Verileri Veri Tabanında Sildi
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Veriler Where TC=@p1", baglantı);
            sil.Parameters.AddWithValue("@p1", msktc.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            daset.Tables["tbl_Müşteri"].Clear();
            MessageBox.Show("Kayıt Silindi");
            KayıtListele();
            Temizle();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //             TC'yi Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_Müşteri Where TC Like '%" + textBox1.Text + "%'",baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
            
        }

        private void txtaraAD_TextChanged(object sender, EventArgs e)
        {
            //             AD'i Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_Müşteri Where AdSoyad Like '%" + txtaraAD.Text + "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }
    }
}
