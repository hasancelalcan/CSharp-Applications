using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Otomasyonu
{
    public partial class KullanıcıGiriş : Form
    {
        public KullanıcıGiriş()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        private void btngiriş_Click(object sender, EventArgs e)
        {
            //SQL'deki KullanıcıGiriş Tablosundaki Verilerle Karşılaştırır Eğer Eşleşiyor İse Giriş Yapar

            baglantı.Open();
            SqlCommand komutGiriş = new SqlCommand("Select *From tbl_KullanıcıGiriş where KullanıcıAdı=@p1 and Şifre=@p2",baglantı);
            komutGiriş.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
            komutGiriş.Parameters.AddWithValue("@p2", txtşifre.Text);

            SqlDataReader oku = komutGiriş.ExecuteReader();
            if (oku.Read())
            {
                SatışSayfası yeni = new SatışSayfası();
                yeni.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş....");
            }

            baglantı.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullanıcıKayıt fr = new KullanıcıKayıt();
            fr.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtşifre.UseSystemPasswordChar = false;

            }
            else
            {
                txtşifre.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
