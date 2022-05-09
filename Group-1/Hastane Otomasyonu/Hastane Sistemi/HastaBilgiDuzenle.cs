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

namespace Hastane_Sistemi
{
    public partial class HastaBilgiDuzenle : Form
    {
        public HastaBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        SQLBağlantısı bgl = new SQLBağlantısı();

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                                      Hasta Veri Güncelleme
            SqlCommand güncelle = new SqlCommand("Update tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6", bgl.baglantı());
            güncelle.Parameters.AddWithValue("@p1", txtad.Text);
            güncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", msktelefon.Text);
            güncelle.Parameters.AddWithValue("@p4", txtşifre.Text);
            güncelle.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            güncelle.Parameters.AddWithValue("@p6", msktc.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglantı().Close();
            MessageBox.Show("Bilgileriniz Güncellendi");
        }

        private void HastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            //                                      Kayıtlı Olan Verileri TC'ye Göre Araçlara Taşıma
            msktc.Text = TCno;
            SqlCommand komut = new SqlCommand("Select *From tbl_Hastalar Where HastaTC=@P1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktelefon.Text = dr[4].ToString();
                txtşifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            txtad.Clear();
            txtsoyad.Clear();
            txtşifre.Clear();
            msktc.Clear();
            msktelefon.Clear();
            cmbcinsiyet.Text = "";
        }

        private void anaGirişPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler frm = new Girişler();
            frm.Show();
            this.Hide();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hasta_Detay fr = new Hasta_Detay();
            fr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}