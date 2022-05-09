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

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SQL'deki KullanıcıGiriş Tablosundaki Verilerle Karşılaştırır Eğer Eşleşiyor İse Giriş Yapar

            
            SqlCommand komutGiriş = new SqlCommand("Select *From tbl_Admin where KullanıcıAdı=@p1 and Sifre=@p2",bgl.baglanti());
            komutGiriş.Parameters.AddWithValue("@p1", txtKullanıcıAdı.Text);
            komutGiriş.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader oku = komutGiriş.ExecuteReader();
            if (oku.Read())
            {
                GirişEkranı yeni = new GirişEkranı();
                yeni.kullanıcı = txtKullanıcıAdı.Text;
                yeni.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş....");
            }

            bgl.baglanti().Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSifre.Properties.UseSystemPasswordChar = false;

            }
            else
            {
                txtSifre.Properties.UseSystemPasswordChar = true;
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
