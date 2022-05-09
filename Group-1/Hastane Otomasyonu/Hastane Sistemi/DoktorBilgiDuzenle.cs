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
    public partial class DoktorBilgiDuzenle : Form
    {
        public DoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        public string TC; 
        private void DoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = TC;
            //                              Doktorun Verilerini Veri Tabanından Çekme
            SqlCommand komut1 = new SqlCommand("Select  *From tbl_Doktorlar where DoktorTC=@p1", bgl.baglantı());
            komut1.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                txtad.Text = dr1[1].ToString();
                txtsoyad.Text = dr1[2].ToString();
                cmbBranş.Text = dr1[3].ToString();
                txtşifre.Text = dr1[5].ToString();
            }
            bgl.baglantı().Close();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand güncelle = new SqlCommand("Update tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglantı());
            güncelle.Parameters.AddWithValue("@p1", txtad.Text);
            güncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", cmbBranş.Text);
            güncelle.Parameters.AddWithValue("@p4", txtşifre.Text);
            güncelle.Parameters.AddWithValue("@p5", msktc.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Güncellendi");

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoktorYönetimEkranı fr = new DoktorYönetimEkranı();
            fr.Show();
            this.Hide();
        }

        private void anaGirişPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler frm = new Girişler();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtad.Clear();
            txtsoyad.Clear();
            txtşifre.Clear();
            msktc.Clear();
            cmbBranş.Text = "";
        }
    }
}
