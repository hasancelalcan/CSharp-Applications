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
    public partial class SekreterYönetimEkranı : Form
    {
        public SekreterYönetimEkranı()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        public string TCno;
        private void SekreterYönetimEkranı_Load(object sender, EventArgs e)
        {
            lbltc.Text = TCno;

            //AdSoyad
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From tbl_Sekreterler where SekreterTC=@p1", bgl.baglantı());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglantı().Close();

            //Branşları DataGrid'e Çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Branslar", bgl.baglantı());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları DataGrid'e Çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' +  DoktorSoyad) as 'Doktorlar',DoktorBrans From tbl_Doktorlar", bgl.baglantı());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //*****SQL Tablosundaki , 2.Sütündaki Verileri ComboBax'a Çekme*******
            SqlCommand komut2 = new SqlCommand("Select BransAd From tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranş.Items.Add(dr2[0]);
            }
            bgl.baglantı().Close();


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                 Veri Tabanına Randevu Ekleme
            SqlCommand kaydet = new SqlCommand("Insert into tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", bgl.baglantı());
            kaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            kaydet.Parameters.AddWithValue("@r2", mskSaat.Text);
            kaydet.Parameters.AddWithValue("@r3", cmbBranş.Text);
            kaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu Oluşturuldu");



        }

        private void cmbBranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            //                         Veri Tabanındaki Doktorlar Tablosundan Sadece AD,Soyad,Branş Çekti

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", cmbBranş.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);

            }
            bgl.baglantı().Close();
        }

        private void btnOluştur_Click(object sender, EventArgs e)
        {
            //                  SQL Tablosuna Veri Ekleme     
            SqlCommand komut = new SqlCommand("Insert into tbl_Duyurular (Duyuru) values (@d1)", bgl.baglantı());
            komut.Parameters.AddWithValue("@d1", richDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            RandevuListesi fr = new RandevuListesi();
            fr.Show();
            this.Hide();
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            DoktorPanelı fr = new DoktorPanelı();
            fr.Show();
            this.Hide();
        }

        private void btnBranşPaneli_Click(object sender, EventArgs e)
        {
            BransPaneli ft = new BransPaneli();
            ft.Show();
            this.Hide();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            DuyuruListesi fr = new DuyuruListesi();
            fr.Show();
            this.Hide();
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SekreterGirişi fr = new SekreterGirişi();
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
            txtTC.Clear();
            mskSaat.Clear();
            mskTarih.Clear();
            cmbBranş.Text = "";
            cmbDoktor.Text = "";
        }
    }
}
