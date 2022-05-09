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

namespace Telefon_Satış_Otomasyonu
{
    public partial class YeniKullanıcı : Form
    {
        public YeniKullanıcı()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");


        private void YeniKullanıcı_Load(object sender, EventArgs e)
        {

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //                                      Kullanıcı Ekleme
            baglantı.Open();
            SqlCommand Ekle = new SqlCommand("Insert into tbl_Kullanıcı (AdıSoyadı,TelNo,Adres,Email,KullanıcıAdı,Sifre,Görevi,Resim) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",baglantı);
            Ekle.Parameters.AddWithValue("@p1",txtadısoyadı.Text);
            Ekle.Parameters.AddWithValue("@p2",txttelefon.Text);
            Ekle.Parameters.AddWithValue("@p3",txtadres.Text);
            Ekle.Parameters.AddWithValue("@p4",txtemail.Text);
            Ekle.Parameters.AddWithValue("@p5",txtkullanıcıadı.Text);
            Ekle.Parameters.AddWithValue("@p6",txtşifre.Text);
            Ekle.Parameters.AddWithValue("@p7",txtgörevi.Text);
            Ekle.Parameters.AddWithValue("@p8",pictureBox1.ImageLocation);
            Ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Yeni Kullanıcı Eklendi");
        }

        private void btnresimseç_Click(object sender, EventArgs e)
        {
            //                                  Resim Seçme
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog(); 
            pictureBox1.ImageLocation = file.FileName;
            
        }
    }
}
