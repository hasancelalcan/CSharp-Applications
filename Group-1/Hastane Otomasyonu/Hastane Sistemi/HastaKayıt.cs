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
    public partial class HastaKayıt : Form
    {
        public HastaKayıt()
        {
            InitializeComponent();
        }
        SQLBağlantısı bgl = new SQLBağlantısı();
        private void btnkayıtyap_Click(object sender, EventArgs e)
        {
            SqlCommand kayıtyap = new SqlCommand("Insert into tbl_Hastalar(HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglantı());
            kayıtyap.Parameters.AddWithValue("@p1", txtad.Text);
            kayıtyap.Parameters.AddWithValue("@p2", txtsoyad.Text);
            kayıtyap.Parameters.AddWithValue("@p3", msktc.Text);
            kayıtyap.Parameters.AddWithValue("@p4", msktelefon.Text);
            kayıtyap.Parameters.AddWithValue("@p5", txtşifre.Text);
            kayıtyap.Parameters.AddWithValue("@p6", cmbcinsiyet.Text);
            kayıtyap.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz:"  +  txtşifre.Text, "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void geriDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HastaGiriş fr = new HastaGiriş();
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
            txtad.Clear();
            txtsoyad.Clear();
            txtşifre.Clear();
            msktc.Clear();
            msktelefon.Clear();
            cmbcinsiyet.Text= "";
        }
    }
}
