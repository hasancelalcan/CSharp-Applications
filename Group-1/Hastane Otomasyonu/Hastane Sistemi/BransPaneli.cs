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
    public partial class BransPaneli : Form
    {
        public BransPaneli()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();

       private void listele()
        {
            // Veri Tabanındaki Branşları DataGrid'e Çekme Metotu
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From tbl_Branslar", bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BransPaneli_Load(object sender, EventArgs e)
        {

            listele();
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //                                Veri Tabanına Branş Ekleme
            SqlCommand ekle = new SqlCommand("Insert into tbl_Branslar (BransAd) values (@b1)",bgl.baglantı());
            ekle.Parameters.AddWithValue("@b1", txtBranşAd.Text);
            ekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Eklendi");
            listele();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //                     Tıklanan Sütündaki Verileri Araçlar'a Çekme
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBranşID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBranşAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //                          Veri Tabanından Branş Silme
            SqlCommand sil = new SqlCommand("Delete From tbl_Branslar where Bransid=@b1", bgl.baglantı());
            sil.Parameters.AddWithValue("b1", txtBranşID.Text);
            sil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Silindi");
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

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                         Veri Tabanındaki Bransları Güncelleme
            SqlCommand güncelle = new SqlCommand("Update tbl_Branslar set BransAd=@p1 where Bransid=@p2", bgl.baglantı());
            güncelle.Parameters.AddWithValue("@p1", txtBranşAd.Text);
            güncelle.Parameters.AddWithValue("@p2", txtBranşID.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Brans Güncellendi");
            listele();
        }

        private void anaGirişPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler frm = new Girişler();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBranşAd.Clear();
            txtBranşID.Clear();
        }
    }
}
