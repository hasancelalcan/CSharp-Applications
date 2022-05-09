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
    public partial class DoktorGiriş : Form
    {
        public DoktorGiriş()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        
        private void btnGiriş_Click(object sender, EventArgs e)
        {
            //                                Doktor Kullanıcı Girişi
            SqlCommand GirişYap = new SqlCommand("Select *From tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglantı());
            GirişYap.Parameters.AddWithValue("@p1", msktc.Text);
            GirişYap.Parameters.AddWithValue("@p2", txtşifre.Text);
            SqlDataReader dr = GirişYap.ExecuteReader();
            if (dr.Read())
            {
                DoktorYönetimEkranı fr = new DoktorYönetimEkranı();
                fr.TC = msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
                txtşifre.Clear();
                msktc.Clear();
            }
            bgl.baglantı().Close();

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
