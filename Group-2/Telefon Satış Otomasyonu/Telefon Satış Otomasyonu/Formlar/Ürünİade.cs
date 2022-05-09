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

namespace Telefon_Satış_Otomasyonu.Formlar
{
    public partial class Ürünİade : Form
    {
        public Ürünİade()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");



        public void fiyatgör()
        {
            //SeriNo ya Göre Telefon Bilgileri Araçlara Çekme
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Urun where SeriNo like'" + txtserinoara.Text + "'", baglantı);
            SqlDataReader dr = ara.ExecuteReader();
            while (dr.Read())
            {
                txtürünıd.Text = dr["ID"].ToString();
                txtmarka.Text = dr["Marka"].ToString();
                //txtmiktar.Text = dr["Miktar"].ToString();
                txtimeino.Text = dr["İmeiNo"].ToString();
                txtbirimfiyat.Text = dr["SatışFiyatı"].ToString();
            }
            baglantı.Close();
        }

        private void Ürünİade_Load(object sender, EventArgs e)
        {

        }

        private void txtserinoara_TextChanged(object sender, EventArgs e)
        {
            fiyatgör();
        }

        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtbirimfiyat.Text) * double.Parse(txtmiktar.Text)).ToString("0.00");
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Urun Set Miktar=Miktar+'"+int.Parse(txtmiktar.Text)+"' where SeriNo='" + txtserinoara.Text +"' ",baglantı);
            güncelle.ExecuteNonQuery();
            MessageBox.Show("Ürün İade Alındı");
            baglantı.Close();

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Insert ınto tbl_Satıs values ('-1','Genel','Bilinmiyor',@p1,@p2,@p3,@p4,@p5,@p6,18,'Belirtilmedi','Belirtilmedi',-1,@p7,@p8)", baglantı);
            komut.Parameters.AddWithValue("@p1",txtürünıd.Text);
            komut.Parameters.AddWithValue("@p2",txtmarka.Text);
            komut.Parameters.AddWithValue("@p3",txtimeino.Text);
            komut.Parameters.AddWithValue("@p4",double.Parse(txtbirimfiyat.Text));
            komut.Parameters.AddWithValue("@p5",-int.Parse(txtmiktar.Text));
            komut.Parameters.AddWithValue("@p6",-double.Parse(txttoplamfiyat.Text));
            komut.Parameters.AddWithValue("@p7",DateTime.Parse(DateTime.Now.ToShortDateString()));
            komut.Parameters.AddWithValue("@p8",DateTime.Parse(DateTime.Now.ToString()));
            komut.ExecuteNonQuery();
            baglantı.Close();





        }
    }
}
