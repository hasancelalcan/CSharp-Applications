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
    public partial class KullanıcıKayıt : Form
    {
        public KullanıcıKayıt()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        private void btngiriş_Click(object sender, EventArgs e)
        {
            //                             SQL'deki Tabloya Ekleme Yapar
            baglantı.Open();
            SqlCommand KayıtYap = new SqlCommand("Insert into tbl_KullanıcıGiriş (KullanıcıAdı,Şifre) values (@p1,@p2)", baglantı);
            KayıtYap.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
            KayıtYap.Parameters.AddWithValue("@p2", txtşifre.Text);
            KayıtYap.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt Yapıldı");
            txtşifre.Clear();
            txtkullanıcıadı.Clear();



        }
    }
}
