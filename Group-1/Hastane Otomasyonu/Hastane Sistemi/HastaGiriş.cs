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
    public partial class HastaGiriş : Form
    {
        public HastaGiriş()
        {
            InitializeComponent();
        }

        SQLBağlantısı bgl = new SQLBağlantısı();

        private void lnkÜyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıt fr = new HastaKayıt();
            fr.Show();
        }

        private void btnGiriş_Click(object sender, EventArgs e)
        {
            SqlCommand GirişYap = new SqlCommand("Select *From tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.baglantı());
            GirişYap.Parameters.AddWithValue("@p1", msktc.Text);
            GirişYap.Parameters.AddWithValue("@p2", txtşifre.Text);
            SqlDataReader dr = GirişYap.ExecuteReader();
            if (dr.Read())
            {
                Hasta_Detay fr = new Hasta_Detay();
                fr.tc = msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız...");
                txtşifre.Clear();
                msktc.Clear();
            }
        }

        private void HastaGiriş_Load(object sender, EventArgs e)
        {

        }

        

       

        private void geriDönToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Girişler fr = new Girişler();
            fr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
