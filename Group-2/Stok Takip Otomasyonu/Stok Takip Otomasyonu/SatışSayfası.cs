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
    public partial class SatışSayfası : Form
    {
        public SatışSayfası()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");

        DataSet daset = new DataSet();

      
        private void sepetlistele()
        {
            //                                SQL'deki Tabloyu DataGrid'de Listeledi
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *From tbl_Sepet", baglantı);   
            adtr.Fill(daset,"tbl_Sepet");
            dataGridView1.DataSource = daset.Tables["tbl_Sepet"];
            //ilk 3 sütünü gizler
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            baglantı.Close();
        }

        private void Temizle()
        {
            // Temizleme Kodları
            if (txtbarkodno.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtmiktar)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }

        bool durum;
        
        private void barkodkontrol()
        {
            //        Sepette Aynı BarkodNo'lu Ürün Var İse Miktarı O ürünün Üstüne Ekler
            durum = true;
            baglantı.Open();
            SqlCommand barkod = new SqlCommand("Select * From tbl_Sepet", baglantı);
            SqlDataReader read = barkod.ExecuteReader();
            while (read.Read())
            {
                if (txtbarkodno.Text == read["BarkodNo"].ToString())
                {
                    durum = false;
                }
            }
            baglantı.Close();

        }

        private void hesapla()
        {
            //Sepetteki Toplam Fiyatı Toplayıp Label'a yazdırır
            try
            {
                baglantı.Open();
                SqlCommand hesapla = new SqlCommand("Select sum(ToplamFiyatı)From tbl_Sepet", baglantı);
                lblgeneltoplam.Text = hesapla.ExecuteScalar() + "TL";
                baglantı.Close();
            }
            catch (Exception)
            {

                ;
            }
        }

        
        private void txttc_TextChanged(object sender, EventArgs e)

        {//               TC ye Göre Araçlara Bilgileri Getirme
            if (txttc.Text == "")
            {
                txtadsoyad.Text = "";
                txttelefon.Text = "";
            }
            
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Müşteri where TC like'" + txttc.Text + "'", baglantı);
            SqlDataReader read = ara.ExecuteReader();
            while (read.Read())
            {
                txtadsoyad.Text = read["AdSoyad"].ToString();
                txttelefon.Text = read["Telefon"].ToString();

            }
            baglantı.Close();
        }

      
        private void txtbarkodno_TextChanged(object sender, EventArgs e)
        {
            //              Araçlardan BarkodNo'yu Alıp SQL'de Arayıp Eşleşenlerle Listeler
            Temizle();
           
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Ürün where BarkodNo like'" + txtbarkodno.Text + "'", baglantı);
            SqlDataReader read = ara.ExecuteReader();
            while (read.Read())
            {
                txtürünadı.Text = read["ÜrünAdı"].ToString();
                txtsatışfiyatı.Text = read["SatışFiyatı"].ToString();

            }
            baglantı.Close();
        }

       
        private void btnekle_Click(object sender, EventArgs e)
        {
            //                 SQL'deki Tabloya Ekleme Yapar
            //Sepette Aynı BarkodNo'lu Ürün Var İse Miktarı O ürünün Üstüne Ekler

            barkodkontrol();
            if (durum == true)
            {
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_Sepet(TC,AdSoyad,Telefon,BarkodNo,ÜrünAdı,Miktarı,SatışFiyatı,ToplamFiyatı,Tarih)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", baglantı);
                ekle.Parameters.AddWithValue("@p1", txttc.Text);
                ekle.Parameters.AddWithValue("@p2", txtadsoyad.Text);
                ekle.Parameters.AddWithValue("@p3", txttelefon.Text);
                ekle.Parameters.AddWithValue("@p4", txtbarkodno.Text);
                ekle.Parameters.AddWithValue("@p5", txtürünadı.Text);
                ekle.Parameters.AddWithValue("@p6", int.Parse(txtmiktar.Text));
                ekle.Parameters.AddWithValue("@p7", double.Parse(txtsatışfiyatı.Text));
                ekle.Parameters.AddWithValue("@p8", double.Parse(txttoplamfiyat.Text));
                ekle.Parameters.AddWithValue("@p9", DateTime.Now.ToString());
                ekle.ExecuteNonQuery();
                baglantı.Close();
            }
            else
            {
                baglantı.Open();
                SqlCommand ekle2 = new SqlCommand("Update  tbl_Sepet set Miktarı=Miktarı+'"+int.Parse(txtmiktar.Text)+"' where BarkodNo='"+ txtbarkodno.Text+"'", baglantı);
                ekle2.ExecuteNonQuery();
                SqlCommand ekle3 = new SqlCommand("Update  tbl_Sepet set ToplamFiyatı=Miktarı*SatışFiyatı where BarkodNo='"+txtbarkodno.Text+"'", baglantı);
                ekle3.ExecuteNonQuery();
                baglantı.Close();
            }
           
            //Temizleme Kodları
            daset.Tables["tbl_Sepet"].Clear();
            sepetlistele();
            hesapla();
            txtmiktar.Text = "1";
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtmiktar)
                    {
                        item.Text = "";
                    }
                }
            }
        }


        private void SatışSayfası_Load(object sender, EventArgs e)
        {
            sepetlistele();
        }

        
        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            //              Miktarı İle Satış Fiyatını Çarpıp Toplam Fiyata İşler
            try
            {
                txttoplamfiyat.Text=(double.Parse(txtmiktar.Text) *double.Parse(txtsatışfiyatı.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }


        private void btnsil_Click(object sender, EventArgs e)
        {
            //DataGrid'deki BarkodNo'ya Göre Silme İşlemi Yapar
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Sepet where BarkodNo='" + dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString() + "'", baglantı);
            sil.ExecuteNonQuery();
            baglantı.Close();
 
            MessageBox.Show("Ürün Sepetten Çıkarıldı");
            daset.Tables["tbl_Sepet"].Clear();
            sepetlistele();
            hesapla();
        }


        private void txtsatışfiyatı_TextChanged(object sender, EventArgs e)
        {
            //              Miktarı İle Satış Fiyatını Çarpıp Toplam Fiyata İşler
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtmiktar.Text) * double.Parse(txtsatışfiyatı.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }


        private void btnsatışıptal_Click(object sender, EventArgs e)
        {
            //Tablodaki Verileri Siler
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Sepet", baglantı);
            sil.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Ürün Sepetten Çıkarıldı");
            daset.Tables["tbl_Sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void btnsatışyap_Click(object sender, EventArgs e)
        {
            //                      Satış Yap Denilince SQL'e Kayıt Eder
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                baglantı.Open();
                SqlCommand ekle = new SqlCommand("Insert into tbl_Satış(TC,AdSoyad,Telefon,BarkodNo,ÜrünAdı,Miktarı,SatışFiyatı,ToplamFiyatı,Tarih)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", baglantı);
                ekle.Parameters.AddWithValue("@p1", txttc.Text);
                ekle.Parameters.AddWithValue("@p2", txtadsoyad.Text);
                ekle.Parameters.AddWithValue("@p3", txttelefon.Text);
                ekle.Parameters.AddWithValue("@p4", dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString());
                ekle.Parameters.AddWithValue("@p5", dataGridView1.Rows[i].Cells["ÜrünAdı"].Value.ToString()); ;
                ekle.Parameters.AddWithValue("@p6", int.Parse(dataGridView1.Rows[i].Cells["Miktarı"].Value.ToString()));
                ekle.Parameters.AddWithValue("@p7", double.Parse(dataGridView1.Rows[i].Cells["SatışFiyatı"].Value.ToString()));
                ekle.Parameters.AddWithValue("@p8", double.Parse(dataGridView1.Rows[i].Cells["ToplamFiyatı"].Value.ToString()));
                ekle.Parameters.AddWithValue("@p9", DateTime.Now.ToString());
                ekle.ExecuteNonQuery();
                MessageBox.Show("Satış Yapıldı");

                //                                  Stoktan Düşürme
                SqlCommand olanekle = new SqlCommand("Update tbl_Ürün set Miktarı=miktarı-'" + int.Parse(dataGridView1.Rows[i].Cells["Miktarı"].Value.ToString()) + "' where BarkodNo='" + dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString() + "'", baglantı);
                olanekle.ExecuteNonQuery();
                baglantı.Close();
            }
            //                                  Sepetteki Kayıtları Sil
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Sepet", baglantı);
            sil.ExecuteNonQuery();
            baglantı.Close();

            daset.Tables["tbl_Sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        







        private void button1_Click(object sender, EventArgs e)
        {
            MüşteriEkle fr = new MüşteriEkle();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MüşteriListele fr = new MüşteriListele();
            fr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ÜrünEkle fr = new ÜrünEkle();
            fr.ShowDialog();
        }

        private void btnkategori_Click(object sender, EventArgs e)
        {
            KategoriEkle fr = new KategoriEkle();
            fr.ShowDialog();
        }

        private void btnMarka_Click(object sender, EventArgs e)
        {
            MarkaEkle fr = new MarkaEkle();
            fr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ÜrünListele fr = new ÜrünListele();
            fr.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SatışListele fr = new SatışListele();
            fr.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
