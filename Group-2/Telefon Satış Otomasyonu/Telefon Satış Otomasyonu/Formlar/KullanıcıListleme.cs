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
    public partial class KullanıcıListleme : Form
    {
        public KullanıcıListleme()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");
        private void KullanıcıListele()
        {
            baglantı.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_Kullanıcı", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();
        }
        private void KullanıcıListleme_Load(object sender, EventArgs e)
        {
            KullanıcıListele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //kullanıcı Güncelleme
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Kullanıcı Set AdıSoyadı=@p1,TelNo=@p2,Adres=@p3,Email=@p4,KullanıcıAdı=@p5,Sifre=@p6,Görevi=@p7 Where ID=@p8",baglantı);
            güncelle.Parameters.AddWithValue("@p1", txtadısoyadı.Text);
            güncelle.Parameters.AddWithValue("@p2", txttelefon.Text);
            güncelle.Parameters.AddWithValue("@p3", txtadres.Text);
            güncelle.Parameters.AddWithValue("@p4", txtemail.Text);
            güncelle.Parameters.AddWithValue("@p5", txtkullanıcıadı.Text);
            güncelle.Parameters.AddWithValue("@p6", txtşifre.Text);
            güncelle.Parameters.AddWithValue("@p7", txtgörevi.Text);
            güncelle.Parameters.AddWithValue("@p8", txtıd.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kullanıcı Bilgileri Güncellendi");
            KullanıcıListele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Kullanıcı Silme
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Kullanıcı Where ID=@p1",baglantı);
            sil.Parameters.AddWithValue("@p1",txtıd.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kullanıcı Silindi");
            KullanıcıListele();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Araçlara Taşıma
            txtıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtadısoyadı.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txttelefon.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtkullanıcıadı.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtşifre.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtgörevi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
