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
    public partial class DuyuruListesi : Form
    {
        public DuyuruListesi()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        private void DuyuruListesi_Load(object sender, EventArgs e)
        {
            //                   Veri Tabanındaki Verileri DataGrid' Çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select  *From tbl_Duyurular", bgl.baglantı());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoktorYönetimEkranı fr = new DoktorYönetimEkranı();
            fr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sekreterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SekreterYönetimEkranı fr = new SekreterYönetimEkranı();
            fr.Show();
            this.Hide();
        }

        private void anaGirişPaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler frm = new Girişler();
            frm.Show();
            this.Hide();
        }
    }
}
