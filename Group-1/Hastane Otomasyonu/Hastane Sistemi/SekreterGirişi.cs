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
    public partial class SekreterGirişi : Form
    {
        public SekreterGirişi()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();

        private void btngiriş_Click(object sender, EventArgs e)
        {
            SqlCommand GirişYap = new SqlCommand("Select *From tbl_Sekreterler where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglantı());
            GirişYap.Parameters.AddWithValue("@p1", msktc.Text);
            GirişYap.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = GirişYap.ExecuteReader();
            if (dr.Read())
            {
                SekreterYönetimEkranı  fr = new SekreterYönetimEkranı();
                fr.TCno = msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
                txtsifre.Clear();
                msktc.Clear();
            }




        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Girişler fr = new Girişler();
            fr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
