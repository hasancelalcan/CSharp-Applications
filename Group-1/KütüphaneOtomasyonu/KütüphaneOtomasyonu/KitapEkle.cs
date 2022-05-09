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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");

        private void temizle()
        {
            txtAçıklama.Clear();
            txtBarkodNo.Clear();
            txtKitapAdı.Clear();
            txtRafNo.Clear();
            txtSayfaSayısı.Clear();
            txtStokSayısı.Clear();
            txtYayınEvi.Clear();
            txtYazarı.Clear();
            cmbtürü.Text = "";
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //                              SQL'e Veri Ekleme Yapar
            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_KitapBilgi (BarkodNo,KitapAdı,Yazarı,YayınEvi,SayfaSayısı,Türü,StokSayısı,RafNo,Açıklama,KayıtTarihi)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",baglantı);
            ekle.Parameters.AddWithValue("@p1", txtBarkodNo.Text);
            ekle.Parameters.AddWithValue("@p2", txtKitapAdı.Text);
            ekle.Parameters.AddWithValue("@p3", txtYazarı.Text);
            ekle.Parameters.AddWithValue("@p4", txtYayınEvi.Text);
            ekle.Parameters.AddWithValue("@p5", txtSayfaSayısı.Text);
            ekle.Parameters.AddWithValue("@p6", cmbtürü.Text);
            ekle.Parameters.AddWithValue("@p7", txtStokSayısı.Text);
            ekle.Parameters.AddWithValue("@p8", txtRafNo.Text);
            ekle.Parameters.AddWithValue("@p9", txtAçıklama.Text);
            ekle.Parameters.AddWithValue("@p10", DateTime.Now.ToShortDateString());
            ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kitap Eklendi");
            temizle();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
