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
    public partial class SatışYap : Form
    {
        public SatışYap()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        private void SepetListele()
        {
            baglantı.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_Sepet", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();
        }

        private void Yenile()
        {
            //Toplam Kayıt Ve Telefonların Toplam Fiyatları Ve KDV Hesabı
            SepetListele();
            lblkayıtsayısı.Text = "Toplam" + " " + (dataGridView1.Rows.Count - 1) + " " + " Kayıt Listelendi";
            double tutar = 0; 
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                tutar += double.Parse(dataGridView1.Rows[i].Cells["ToplamFiyatı"].Value.ToString());
                
            }
            lbltoplamfiyat.Text = tutar.ToString();

            //Telefon Fiyatlarıyla Telefon Adetlerini Çarpıp Hesapladı
            double geneltutarkdv = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double toplamfiyat = double.Parse(dataGridView1.Rows[i].Cells["ToplamFiyatı"].Value.ToString());
                double kdv = double.Parse(dataGridView1.Rows[i].Cells["KDV"].Value.ToString());
                double kdvtutar = toplamfiyat * kdv/100;
                geneltutarkdv += kdvtutar;
            }
            lblkdv.Text = geneltutarkdv.ToString("C2");

        }

        private void TabloSırasınıSıfırla()
        {
            //Sepet Tablosunun ID'sini Sıfırlar Tekrar 1'den Başlatır
            baglantı.Open();
            SqlCommand yenile = new SqlCommand("truncate Table tbl_Sepet", baglantı);
            yenile.ExecuteNonQuery();
            baglantı.Close();
        }

        private void SatışYap_Load(object sender, EventArgs e)
        {
            SepetListele();
            Yenile();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtmüşteriıd.Text = "";
            txtserino.Text = "";
            txttoplamfiyatı.Text = "";
        }
        


        private void txtmüşteriıd_TextChanged(object sender, EventArgs e)
        {
           
            //MüşteriID ye Göre Bilgileri Araçlara Çekme
            if (txtmüşteriıd.Text == "")
            {
                txtadısoyadı.Text = "";
                txtemail.Text = "";
                msktel.Text = "";
            }

            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Musteri where ID like'" + txtmüşteriıd.Text + "'", baglantı);
            SqlDataReader dr = ara.ExecuteReader();
            while (dr.Read())
            {
                txtadısoyadı.Text = dr["AdSoyad"].ToString();
                txtemail.Text = dr["Email"].ToString();
                msktel.Text = dr["Telefon"].ToString();    
            }
            baglantı.Close();
        }

        private void txtserino_TextChanged(object sender, EventArgs e)
        {
            //SeriNo ya Göre Telefon Bilgileri Araçlara Çekme
            if (txtserino.Text == "")
            {
                txtürünıd.Text = "";
                txtmarka.Text = "";
                txtmodel.Text = "";
                txtimeino.Text = "";
                txtbirimfiyatı.Text = "";
                txtkdv.Text = "";
                txtişlemci.Text = "";
                txtişlemci.Text = "";
                txtistsistemi.Text = "";
                txtçözünürlük.Text = "";
            }

            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Urun where SeriNo like'" + txtserino.Text + "'", baglantı);
            SqlDataReader dr = ara.ExecuteReader();
            while (dr.Read())
            {
                txtürünıd.Text = dr["ID"].ToString();
                txtmarka.Text = dr["Marka"].ToString();
                txtmodel.Text = dr["Model"].ToString();
                txtimeino.Text = dr["İmeiNo"].ToString();
                txtbirimfiyatı.Text = dr["SatışFiyatı"].ToString();
                txtkdv.Text = dr["KDV"].ToString();
                txtişlemci.Text = dr["İşlemci"].ToString();
                txtistsistemi.Text = dr["İşletimSistemi"].ToString();
                txtçözünürlük.Text = dr["Cozunurluk"].ToString();

                ////Miktar*BirimFiyat=ToplamFiyat
                double Miktar = double.Parse(txtmiktarı.Text);
                double BirimFiyat = double.Parse(txtbirimfiyatı.Text);
                double ToplamFiyat = Miktar * BirimFiyat;
                txttoplamfiyatı.Text = ToplamFiyat.ToString();

            }
            baglantı.Close();
        }

        private void txtmiktarı_TextChanged(object sender, EventArgs e)
        {
            //Miktarı Değişince Yoplam Fiyat Değişir
            try
            {
                double toplamfiyat = double.Parse(txtmiktarı.Text) * double.Parse(txtbirimfiyatı.Text);
                txttoplamfiyatı.Text = toplamfiyat.ToString("0.00");
            }
            catch 
            {
            }
           
        }

        private void btnspeteEkle_Click(object sender, EventArgs e)
        {
            //Telefonu Sepete Ekleme
            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_Sepet (MusteriID,AdSoyad,SeriNo,Telefon,UrunID,Marka,Model,İmeiNo,BirimFiyatı,Miktar,ToplamFiyatı,KDV,İşlemci,İşletimSistemi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)",baglantı);
            ekle.Parameters.AddWithValue("@p1",txtmüşteriıd.Text);
            ekle.Parameters.AddWithValue("@p2",txtadısoyadı.Text);
            ekle.Parameters.AddWithValue("@p3", txtserino.Text);
            ekle.Parameters.AddWithValue("@p4", msktel.Text);
            ekle.Parameters.AddWithValue("@p5", txtürünıd.Text);
            ekle.Parameters.AddWithValue("@p6", txtmarka.Text);
            ekle.Parameters.AddWithValue("@p7", txtmodel.Text);
            ekle.Parameters.AddWithValue("@p8", txtimeino.Text);
            ekle.Parameters.AddWithValue("@p9",  double.Parse(txtbirimfiyatı.Text));
            ekle.Parameters.AddWithValue("@p10", int.Parse(txtmiktarı.Text));
            ekle.Parameters.AddWithValue("@p11", double.Parse(txttoplamfiyatı.Text));
            ekle.Parameters.AddWithValue("@p12", int.Parse(txtkdv.Text));
            ekle.Parameters.AddWithValue("@p13",txtişlemci.Text);
            ekle.Parameters.AddWithValue("@p14",txtistsistemi.Text);
            ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Ürünler Sepete Eklendi");
            Yenile();

        }

        

        private void txtödenen_TextChanged(object sender, EventArgs e)
        {
            //ParaÜstü Hesabı
            try
            {
                double tutar=0, odenen=0;
                tutar = double.Parse(lbltoplamfiyat.Text);
                odenen = double.Parse(txtödenen.Text);
                //txtödenen.Text = odenen.ToString("C2");
                double paraustu = odenen - tutar;
                txtparaüstü.Text = paraustu.ToString("C2");
            }
            catch 
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGrid'in Sil Butonu İle Listeden Telefon Silme
            if (e.ColumnIndex==0)
            {
                baglantı.Open();
                SqlCommand sil = new SqlCommand("Delete From tbl_Sepet Where ID=@p1", baglantı);
                sil.Parameters.AddWithValue("@p1",dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                sil.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Telefon Bilgileri Silindi");

                Yenile();
            }
            //DataGrid'in Artır Butonu İle Listeden Telefon Miktarını Arttırma
            if (e.ColumnIndex == 1)
            {
                baglantı.Open();
                SqlCommand arttır = new SqlCommand("Update tbl_Sepet Set Miktar=Miktar+1 Where ID=@p1", baglantı);
                arttır.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                arttır.ExecuteNonQuery();
               
                SqlCommand arttır2 = new SqlCommand("Update tbl_Sepet Set ToplamFiyatı=BirimFiyatı*Miktar Where ID=@p1", baglantı);
                arttır2.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                arttır2.ExecuteNonQuery();
                baglantı.Close();

                Yenile();
            }
            //DataGrid'in Azalt Butonu İle Listeden Telefon Miktarını Azaltma
            if (e.ColumnIndex == 2)
            {
                baglantı.Open();
                SqlCommand azalt = new SqlCommand("Update tbl_Sepet Set Miktar = Miktar - 1 Where ID = @p1", baglantı);
                azalt.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                azalt.ExecuteNonQuery();

                SqlCommand azalt2 = new SqlCommand("Update tbl_Sepet Set ToplamFiyatı=BirimFiyatı*Miktar Where ID=@p1", baglantı);
                azalt2.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                azalt2.ExecuteNonQuery();
                baglantı.Close();

                Yenile();
            }
        }

        private void btnsatışiptal_Click(object sender, EventArgs e)
        {
            //Sepete Eklenen Tüm Telefonları Kaldırma
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Sepet", baglantı);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Sepet Boşaltıldı , Satış İptal");
            
            Yenile();
            TabloSırasınıSıfırla();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {

            
        }

        private void SatışYap_KeyDown(object sender, KeyEventArgs e)
        {
            //Butonlara Kısayol Tuşları atamak
            if (e.KeyCode==Keys.F1)
            {
                cmbödemetürü.SelectedIndex = 0;
                txtödenen.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                cmbödemetürü.SelectedIndex = 1;
                txtödenen.Text = lbltoplamfiyat.Text;
                txtparaüstü.Text = "0.00";
            }
            if (e.KeyCode == Keys.F3)
            {
                cmbödemetürü.SelectedIndex = 0;
                txtödenen.Focus();
            }
            if (e.KeyCode == Keys.F4)
            {
                btnsatışonay.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                btnsatışiptal.PerformClick();
            }
            if (e.KeyCode == Keys.F6)
            {
                btnmüşteriborç.PerformClick();
            }
            if (e.KeyCode == Keys.F7)
            {
                BtnÜrünİade.PerformClick();
            }
            if (e.KeyCode == Keys.F8)
            {
                btnFiyatGör.PerformClick();
            }
            if (e.KeyCode==Keys.F9)
            {
                btnYapılanSatışlar.PerformClick();
            }
        }

        private void btnsatışonay_Click(object sender, EventArgs e)
        {
            //Sepet Tablosunu Satış Tablosuna Aktarma
            try
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    int MusteriID = int.Parse(dataGridView1.Rows[i].Cells["MusteriID"].Value.ToString());
                    string AdıSoyadı = dataGridView1.Rows[i].Cells["AdSoyad"].Value.ToString();
                    string Telefon = dataGridView1.Rows[i].Cells["Telefon"].Value.ToString();
                    string UrunID = dataGridView1.Rows[i].Cells["UrunID"].Value.ToString();
                    string Marka = dataGridView1.Rows[i].Cells["Marka"].Value.ToString();
                    string Model = dataGridView1.Rows[i].Cells["Model"].Value.ToString();
                    string SeriNo = dataGridView1.Rows[i].Cells["SeriNo"].Value.ToString();
                    string İmeiNo = dataGridView1.Rows[i].Cells["İmeiNo"].Value.ToString();
                    double BirimFiyatı = double.Parse(dataGridView1.Rows[i].Cells["BirimFiyatı"].Value.ToString());
                    int Miktarı = int.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                    double ToplamFiyatı = double.Parse(dataGridView1.Rows[i].Cells["ToplamFiyatı"].Value.ToString());
                    int KDV = int.Parse(dataGridView1.Rows[i].Cells["KDV"].Value.ToString());
                    string İslemci = dataGridView1.Rows[i].Cells["İşlemci"].Value.ToString();
                    string İsletimSistemi = dataGridView1.Rows[i].Cells["İşletimSistemi"].Value.ToString();
                    int SepetID = int.Parse(dataGridView1.Rows[i].Cells["ID"].Value.ToString());

                    
                    string sorgu = "Insert Into tbl_Satıs values('" + MusteriID + "','" + AdıSoyadı + "','" + Telefon + "','" + UrunID + "','" + Marka + "','" + Model + "'," +
                        "'" + SeriNo + "','" + İmeiNo + "',@BirimFiyatı,'" + Miktarı + "',@ToplamFiyatı,'" + KDV + "','" + İslemci + "','" + İsletimSistemi + "'," +
                        "'" + SepetID + "',@Tarih,@Saat)";
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand(sorgu, baglantı);
                    komut.Parameters.AddWithValue("@BirimFiyatı",BirimFiyatı);
                    komut.Parameters.AddWithValue("@ToplamFiyatı",ToplamFiyatı);
                    komut.Parameters.AddWithValue("@Tarih",DateTime.Parse(DateTime.Now.ToShortDateString()));
                    komut.Parameters.AddWithValue("@Saat",DateTime.Parse(DateTime.Now.ToShortTimeString()));
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Satış Gerçekleştirildi");
                    Yenile();

                    baglantı.Open();
                    SqlCommand komut3 = new SqlCommand("Update tbl_Urun Set Miktar=Miktar-'" + Miktarı + "' where ID='" + UrunID + "' ", baglantı);
                    baglantı.Close();
                }
                baglantı.Open();
                SqlCommand komut2 = new SqlCommand("Delete From tbl_Sepet",baglantı);
                komut2.ExecuteNonQuery();
                baglantı.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata="+ex.Message);
                
            }
        }

        private void btnYapılanSatışlar_Click(object sender, EventArgs e)
        {
            Formlar.SatışListele fr = new Formlar.SatışListele();
            fr.ShowDialog();
        }

        private void btnFiyatGör_Click(object sender, EventArgs e)
        {
            Formlar.FiyatGör fr = new Formlar.FiyatGör();
            fr.ShowDialog();
        }

        private void BtnÜrünİade_Click(object sender, EventArgs e)
        {
            Formlar.Ürünİade fr = new Formlar.Ürünİade();
            fr.ShowDialog();
        }
    }
}
