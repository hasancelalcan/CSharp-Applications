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
    public partial class DoktorPanelı : Form
    {
        public DoktorPanelı()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        private void listele()
        {
            //              Doktorları Veri Tabanından DataGrid'e Çekme Metotu
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From tbl_Doktorlar", bgl.baglantı());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
        private void DoktorPanelı_Load(object sender, EventArgs e)
        {
            listele();

            //                                      Branşı ComboBax'a Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranş.Items.Add(dr2[0]);
            }
            bgl.baglantı().Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //                       Veri Tabanına Doktor Ekleme
            SqlCommand ekle = new SqlCommand("Insert into tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglantı());
            ekle.Parameters.AddWithValue("@d1", txtAd.Text);
            ekle.Parameters.AddWithValue("@d2", txtSoyad.Text);
            ekle.Parameters.AddWithValue("@d3", cmbBranş.Text);
            ekle.Parameters.AddWithValue("@d4", txtTC.Text);
            ekle.Parameters.AddWithValue("@d5", txtŞifre.Text);
            ekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Eklendi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //                      Tıklanan Satırı Araçlara Taşıma
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBranş.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtŞifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //                       Doktorların Verilerini Silme
            SqlCommand sil = new SqlCommand("Delete From tbl_Doktorlar where DoktorTC=@s1", bgl.baglantı());
            sil.Parameters.AddWithValue("@s1", txtTC.Text);
            sil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Silindi");
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                      Doktorların Verilerini Güncelleme
            SqlCommand güncelle = new SqlCommand("Update  tbl_Doktorlar set DoktorAd=@g1,DoktorSoyad=@g2,DoktorBrans=@g3,DoktorSifre=@g5 where DoktorTC=@g4", bgl.baglantı());
            güncelle.Parameters.AddWithValue("@g1", txtAd.Text);
            güncelle.Parameters.AddWithValue("@g2", txtSoyad.Text);
            güncelle.Parameters.AddWithValue("@g3", cmbBranş.Text);
            güncelle.Parameters.AddWithValue("@g4", txtTC.Text);
            güncelle.Parameters.AddWithValue("@g5", txtŞifre.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Güncellendi");
            listele();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SekreterYönetimEkranı fr = new SekreterYönetimEkranı();
            fr.Show();
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
            txtAd.Clear();
            txtSoyad.Clear();
            txtTC.Clear();
            txtŞifre.Clear();
            cmbBranş.Text="";


        }
    }
}
