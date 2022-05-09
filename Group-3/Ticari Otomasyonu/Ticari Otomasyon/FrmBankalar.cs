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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                  Veri Listeleme (SQL'de oluşturulan Prosedürü Çalıştırma)

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            //                      İller Tablosundaki Sehir Kolonunu ComboBox'a Çekme

            SqlCommand komut = new SqlCommand("Select Sehir From tbl_Iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİL.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            txtBankaAdı.Text = "";
            lookUpEdit1.Text = "";
            txtHesaNo.Text = "";
            txtHesapTürü.Text = "";
            txtID.Text = "";
            txtSube.Text = "";
            txtTarih.Text = "";
            txtYetkili.Text = "";
            cmbİL.Text = "";
            cmbİlçe.Text = "";
            mskIban.Text = "";
            mskTel.Text = "";
        }

        void FirmaListesi()
        {
            //                                  LookUpEdit Aracına Firmalar Tablosundaki ID ve Ad Kolonlarındaki Verileri Çeker

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Ad From tbl_Firmalar",bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = dt;

        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            FirmaListesi();
        }

        private void cmbİL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //                      Il Combobox'ında Seçilen İllere Göre ilçe ComboBox'ına İlçe Çekme 

            cmbİlçe.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("Select Ilce From tbl_Ilceler Where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbİL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİlçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                                   Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Bankalar (BankaAd,Il,Ilce,Sube,Iban,HesapNo,Yetkili,Telefon,Tarih,HesapTuru,FırmaID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)",bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", txtBankaAdı.Text);
            ekle.Parameters.AddWithValue("@p2", cmbİL.Text);
            ekle.Parameters.AddWithValue("@p3", cmbİlçe.Text);
            ekle.Parameters.AddWithValue("@p4", txtSube.Text);
            ekle.Parameters.AddWithValue("@p5", mskIban.Text);
            ekle.Parameters.AddWithValue("@p6", txtHesaNo.Text);
            ekle.Parameters.AddWithValue("@p7", txtYetkili.Text);
            ekle.Parameters.AddWithValue("@p8", mskTel.Text);
            ekle.Parameters.AddWithValue("@p9", txtTarih.Text);
            ekle.Parameters.AddWithValue("@p10", txtHesapTürü.Text);
            ekle.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Banka Kayıdı Eklendi");
            listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From tbl_Bankalar Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Banka Kaydı Silindi");
                listele();
                temizle();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                                Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update tbl_Bankalar Set BankaAd=@p1,Il=@p2,Ilce=@p3,Sube=@p4,Iban=@p5,HesapNo=@p6,Yetkili=@p7,Telefon=@p8,Tarih=@p9,HesapTuru=@p10,FırmaID=@p11 Where ID=@p12", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtBankaAdı.Text);
            güncelle.Parameters.AddWithValue("@p2", cmbİL.Text);
            güncelle.Parameters.AddWithValue("@p3", cmbİlçe.Text);
            güncelle.Parameters.AddWithValue("@p4", txtSube.Text);
            güncelle.Parameters.AddWithValue("@p5", mskIban.Text);
            güncelle.Parameters.AddWithValue("@p6", txtHesaNo.Text);
            güncelle.Parameters.AddWithValue("@p7", txtYetkili.Text);
            güncelle.Parameters.AddWithValue("@p8", mskTel.Text);
            güncelle.Parameters.AddWithValue("@p9", txtTarih.Text);
            güncelle.Parameters.AddWithValue("@p10", txtHesapTürü.Text);
            güncelle.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            güncelle.Parameters.AddWithValue("@p12", txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Banka Kayıdı Güncellendi");
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           //                                   Grid'den Araçlara Taşıma

           DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            txtID.Text= dr["ID"].ToString();
            txtBankaAdı.Text = dr["BankaAD"].ToString();
            txtHesaNo.Text = dr["HesapNo"].ToString();
            txtHesapTürü.Text = dr["HesapTuru"].ToString();
            txtYetkili.Text = dr["Yetkili"].ToString();
            txtSube.Text = dr["Sube"].ToString();
            txtTarih.Text = dr["Tarih"].ToString();
            cmbİlçe.Text = dr["Ilce"].ToString();
            cmbİL.Text = dr["Il"].ToString();
            mskIban.Text = dr["Iban"].ToString();
            mskTel.Text = dr["Telefon"].ToString();
        }
    }
}
