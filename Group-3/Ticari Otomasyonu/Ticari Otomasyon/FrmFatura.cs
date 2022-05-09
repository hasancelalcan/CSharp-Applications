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
    public partial class FrmFatura : Form
    {
        public FrmFatura()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_FaturaBilgi",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtVergiDiare.Text = "";
            txtTeslimEden.Text = "";
            txtTeslimAlan.Text = "";
            txtSıraNo.Text = "";
            txtSeri.Text = "";
            msksaat.Text = "";
            msktarih.Text = "";
            txtAlıcı.Text = "";
            txtID.Text = "";
        }

        private void FrmFatura_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                            FaturaID Girilmemiş ise  FaturaBilgilerini Kaydetme

            if (txtFaturaID.Text == "")
            {
                SqlCommand ekle = new SqlCommand("Insert into tbl_FaturaBilgi (Seri,SıraNo,Tarih,Saat,VergiDaire,Alıcı,TeslimEden,TeslimAlan) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                ekle.Parameters.AddWithValue("@p1",txtSeri.Text);
                ekle.Parameters.AddWithValue("@p2", txtSıraNo.Text);
                ekle.Parameters.AddWithValue("@p3",msktarih.Text);
                ekle.Parameters.AddWithValue("@p4", msksaat.Text);
                ekle.Parameters.AddWithValue("@p5", txtVergiDiare.Text);
                ekle.Parameters.AddWithValue("@p6",txtAlıcı.Text);
                ekle.Parameters.AddWithValue("@p7",txtTeslimEden.Text);
                ekle.Parameters.AddWithValue("@p8",txtTeslimAlan.Text);
                ekle.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Eklendi");
                listele();
                temizle();
            }

            //                             FaturaID Girilmiş ise  Faturaya Ait Ürün Kaydetme

            if (txtFaturaID.Text !="")
            {
                //Birim Fiyatı ve Miktara Göre Tutarı Hesaplar
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand ekle2 = new SqlCommand("Insert into tbl_FaturaDetay (UrunAd,Miktar,Fiyat,Tutar,FaturaID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                ekle2.Parameters.AddWithValue("@p1", txtUrunAdı.Text);
                ekle2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                ekle2.Parameters.AddWithValue("@p3", txtFiyat.Text);
                ekle2.Parameters.AddWithValue("@p4", txtTutar.Text);
                ekle2.Parameters.AddWithValue("@p5", txtFaturaID.Text);
                ekle2.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Kayıt Edildi Eklendi");
                listele();
                temizle();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                  Fatura Bilgilerini Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["FaturaBilgiID"].ToString();
                txtSeri.Text = dr["Seri"].ToString();
                txtSıraNo.Text = dr["SıraNo"].ToString();
                msktarih.Text = dr["Tarih"].ToString();
                msksaat.Text = dr["Saat"].ToString();
                txtAlıcı.Text = dr["Alıcı"].ToString();
                txtTeslimAlan.Text = dr["TeslimEden"].ToString();
                txtTeslimEden.Text = dr["TeslimAlan"].ToString();
                txtVergiDiare.Text = dr["VergiDaire"].ToString();

            }
        }

        
        private void btnSil_Click_1(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme


            SqlCommand sil = new SqlCommand("Delete From tbl_FaturaBilgi Where FaturaBilgiID=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtID.Text);
            sil.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi");
            listele();
            temizle();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                                      Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update tbl_FaturaBilgi Set Seri=@p1,SıraNo=@p2,Tarih=@p3,Saat=@p4,VergiDaire=@p5,Alıcı=@p6,TeslimEden=@p7,TeslimAlan=@p8 Where FaturaBilgiID=@p9", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtSeri.Text);
            güncelle.Parameters.AddWithValue("@p2", txtSıraNo.Text);
            güncelle.Parameters.AddWithValue("@p3", msktarih.Text);
            güncelle.Parameters.AddWithValue("@p4", msksaat.Text);
            güncelle.Parameters.AddWithValue("@p5", txtVergiDiare.Text);
            güncelle.Parameters.AddWithValue("@p6", txtAlıcı.Text);
            güncelle.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            güncelle.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            güncelle.Parameters.AddWithValue("@p9", txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Güncellendi");
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //      Formlar Arası Değer Aktarma - - Faturanın Detaylarını Farklı Formda Görme

            FrmFaturaÜrünler fr = new FrmFaturaÜrünler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr !=null)
            {
                fr.ID = dr["FaturaBilgiID"].ToString();
            }
            fr.Show();
        }

        private void btnTemizle2_Click(object sender, EventArgs e)
        {
            txtFaturaID.Text = "";
            txtTutar.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtUrunAdı.Text = "";
            txtUrunID.Text = "";
        }
    }
}
