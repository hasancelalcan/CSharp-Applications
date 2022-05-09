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
    public partial class TelefonEkle : Form
    {
        public TelefonEkle()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");


        public bool durum;
        public bool TelefonKontrol()
        {
            //İmeiNo veya SeriNo'Su Aynı Olan Kayıt Eklenmesini Önler
            durum = true;
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From tbl_Urun",baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["SeriNo"].ToString() == txtserino.Text || dr["İmeiNo"].ToString() == txtimei.Text || txtserino.Text == "" || txtimei.Text=="")
                {
                    durum = false;
                }
            }
            baglantı.Close();
            return durum;
        }


        private void TelefonEkle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'telefonSatışOtomasyouDataSet.tbl_Model' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_ModelTableAdapter.Fill(this.telefonSatışOtomasyouDataSet.tbl_Model);
            // TODO: Bu kod satırı 'telefonSatışOtomasyouDataSet.tbl_Marka' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_MarkaTableAdapter.Fill(this.telefonSatışOtomasyouDataSet.tbl_Marka);

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            // Telefon Ekleme
            TelefonKontrol();
            if (durum==true)
            {
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_Urun (Marka,Model,SeriNo,İmeiNo,UretimTarihi,AlışTarihi,AlışFiyatı,SatışFiyatı,KDV,Miktar,İşlemci,İşletimSistemi,Hafıza,Cozunurluk,Renk,Resim) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", baglantı);
                ekle.Parameters.AddWithValue("@p1", cmbmarka.Text);
                ekle.Parameters.AddWithValue("@p2", cmbmodel.Text);
                ekle.Parameters.AddWithValue("@p3", txtserino.Text);
                ekle.Parameters.AddWithValue("@p4", txtimei.Text);
                ekle.Parameters.AddWithValue("@p5", dtüretim.Value);
                ekle.Parameters.AddWithValue("@p6", dtgeliş.Value);
                ekle.Parameters.AddWithValue("@p7", double.Parse(txtalışfiyatı.Text));
                ekle.Parameters.AddWithValue("@p8", double.Parse(txtsatış.Text));
                ekle.Parameters.AddWithValue("@p9", int.Parse(txtKDV.Text));
                ekle.Parameters.AddWithValue("@p10", int.Parse(txtmiktar.Text));
                ekle.Parameters.AddWithValue("@p11", txtİşlemci.Text);
                ekle.Parameters.AddWithValue("@p12", txtişletimsist.Text);
                ekle.Parameters.AddWithValue("@p13", txthafıza.Text);
                ekle.Parameters.AddWithValue("@p14", txtçözünürlük.Text);
                ekle.Parameters.AddWithValue("@p15", txtrenk.Text);
                ekle.Parameters.AddWithValue("@p16", pictureBox1.ImageLocation);
                ekle.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Telefon Başarıyla Eklendi");
            }
            else
            {
                MessageBox.Show("İmeiNo ve/veya SeriNo Aynı Olamaz !!!");
            }
  
        }

        private void btnresimseç_Click(object sender, EventArgs e)
        {
            // Resim Seçme
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            
            
                pictureBox1.ImageLocation = file.FileName;
            
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Temizle_Click(object sender, EventArgs e)
        {
            txtalışfiyatı.Clear();
            txthafıza.Clear();
            txtimei.Clear();
            txtişletimsist.Clear();
            txtKDV.Clear();
            txtrenk.Clear();
            txtsatış.Clear();
            txtserino.Clear();
            txtçözünürlük.Clear();
            txtİşlemci.Clear();
            cmbmarka.Text = "";
            cmbmodel.Text = "";
            txtmiktar.Clear();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
