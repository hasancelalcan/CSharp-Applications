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
    public partial class DoktorYönetimEkranı : Form
    {
        public DoktorYönetimEkranı()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        public string TC;
        private void DoktorYönetimEkranı_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;

            //Doktor AdSoyad
            SqlCommand komut1 = new SqlCommand("Select DoktorAd,DoktorSoyad From tbl_Doktorlar where DoktorTC=@p1", bgl.baglantı());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0] + " " + dr1[1];
            }
            bgl.baglantı().Close();

            //       Doktora Ait Randevuları Veri Tabanından Çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Randevular where RandevuDoktor='"+lbladsoyad.Text+"'", bgl.baglantı());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

        }

        private void btnbilgidüzenle_Click(object sender, EventArgs e)
        {
            DoktorBilgiDuzenle fr = new DoktorBilgiDuzenle();
            fr.TC = lbltc.Text;
            fr.Show();
            this.Hide();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            DuyuruListesi fr = new DuyuruListesi();
            fr.Show();
            this.Hide();
        }

        private void btnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richşikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoktorGiriş fr = new DoktorGiriş();
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
    }
}
