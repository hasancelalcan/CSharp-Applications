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

namespace KütüphaneOtomasyonu
{
    public partial class ÜyeEklemeSayfası : Form
    {
        public ÜyeEklemeSayfası()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");

        private void temizle()
        {
            txtadres.Clear();
            txtemail.Clear();
            txtkitapsayısı.Clear();
            txttc.Clear();
            txttelefon.Clear();
            txtyaş.Clear();
            tctadsoyad.Clear();
            cmbcinsiyet.Text = "";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //                          SQL'deki Üye Tablosuna Üye Ekler
            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_ÜyeBilgi(Tc,AdSoyad,Yaş,Cinsiyet,Telefon,Adres,EMail,Okukitapsayısı)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",baglantı);
            ekle.Parameters.AddWithValue("@p1",txttc.Text);
            ekle.Parameters.AddWithValue("@p2",tctadsoyad.Text);
            ekle.Parameters.AddWithValue("@p3", txtyaş.Text);
            ekle.Parameters.AddWithValue("@p4", cmbcinsiyet.Text);
            ekle.Parameters.AddWithValue("@p5", txttelefon.Text);
            ekle.Parameters.AddWithValue("@p6", txtadres.Text);
            ekle.Parameters.AddWithValue("@p7", txtemail.Text);
            ekle.Parameters.AddWithValue("@p8", txtkitapsayısı.Text);
            ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Üye Eklendi");
            temizle();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ÜyeEklemeSayfası_Load(object sender, EventArgs e)
        {

        }
    }
}
