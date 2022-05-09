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
    public partial class Hasta_Detay : Form
    {
        public Hasta_Detay()
        {
            InitializeComponent();
        }
        public string tc;
        SQLBağlantısı bgl = new SQLBağlantısı();

        private void aktifrandevu()
        {
            //                     Seçilen Doktora Göre Veri Tabanındaki Randevuları Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From tbl_Randevular where RandevuBrans='" + cmbBranş.Text + "'" + " and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void geçmişrandevu()
        {
            //                            Veri Tabanından AdSoyad Çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From tbl_Hastalar where HastaTC=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglantı().Close();
        }
        

        private void Hasta_Detay_Load(object sender, EventArgs e) 
        {
            lbltc.Text = tc;
            geçmişrandevu();
            //                                  Randevu Geçmişi Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From tbl_Randevular where HastaTC='" + tc +"'", bgl.baglantı());
            da.Fill(dt);
            dataGridView2.DataSource = dt;



            //                                  Veri Tabanındaki Branşları ComboBax'a Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranş.Items.Add(dr2[0]);
            }
            bgl.baglantı().Close();

        }

        private void cmbBranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            //                      Branşına Göre Doktoru Araçlar'a Doldurma
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From tbl_Doktorlar where DoktorBrans=@p1", bgl.baglantı());
            komut3.Parameters.AddWithValue("@p1", cmbBranş.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
     
            }
            bgl.baglantı().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktifrandevu();

        }

        private void lnkbilgidüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDuzenle fr = new HastaBilgiDuzenle();
            fr.TCno = lbltc.Text;
            fr.Show();
            this.Hide();
            
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            //                    Seçilen Randevuyu Veri Tabanında Alındı Olarak Güncelleme
            SqlCommand RandevuAl = new SqlCommand("Update tbl_Randevular Set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", bgl.baglantı());
            RandevuAl.Parameters.AddWithValue("@p1", lbltc.Text);
            RandevuAl.Parameters.AddWithValue("@p2", richŞikayet.Text);
            RandevuAl.Parameters.AddWithValue("@p3", txtid.Text);
            RandevuAl.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu Alındı");
            aktifrandevu();
            geçmişrandevu();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HastaGiriş frm = new HastaGiriş();
            frm.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anaGirişPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler frm = new Girişler();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            cmbDoktor.Text = "";
            cmbBranş.Text = "";
            richŞikayet.Clear();
        }
    }
}
