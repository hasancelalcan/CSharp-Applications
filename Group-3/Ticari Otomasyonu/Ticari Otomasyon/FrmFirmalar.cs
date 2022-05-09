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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                      Veri Listeleme

            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Firmalar",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtAD.Text = "";
            txtGörev.Text = "";
            txtID.Text = "";
           
            txtMail.Text = "";
            txtSektör.Text = "";
            txtVergi.Text = "";
            txtYetkili.Text = "";
            mskFax.Text = "";
            mskTel1.Text = "";
          
            cmbİL.Text = "";
            cmbİlce.Text = "";
            rchAdres.Text = "";

            mskYetkiliTc.Text = "";
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


       

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            sehirlistesi();
            
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                      Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Firmalar (Ad,YetkiliStatu,YetkiliAdSoyad,YetkiliTc,Sektör,Telefon1,Mail,Fax,Il,Ilce,VergiDaire,Adres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p9,@p10,@p11,@p12,@p13,@p14)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1",txtAD.Text);
            ekle.Parameters.AddWithValue("@p2",txtGörev.Text);
            ekle.Parameters.AddWithValue("@p3",txtYetkili.Text);
            ekle.Parameters.AddWithValue("@p4",mskYetkiliTc.Text);
            ekle.Parameters.AddWithValue("@p5",txtSektör.Text);
            ekle.Parameters.AddWithValue("@p6",mskTel1.Text);
            ekle.Parameters.AddWithValue("@p9",txtMail.Text);
            ekle.Parameters.AddWithValue("@p10",mskFax.Text);
            ekle.Parameters.AddWithValue("@p11",cmbİL.Text);
            ekle.Parameters.AddWithValue("@p12",cmbİlce.Text);
            ekle.Parameters.AddWithValue("@p13",txtVergi.Text);
            ekle.Parameters.AddWithValue("@p14",rchAdres.Text);
           
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Firma Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                SqlCommand sil = new SqlCommand("Delete From tbl_Firmalar Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Firma Silindi");
                listele();
                temizle();
            }
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                   Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAD.Text = dr["Ad"].ToString();
                txtGörev.Text = dr["YetkiliStatu"].ToString();
                txtYetkili.Text = dr["YetkiliAdSoyad"].ToString();
                mskYetkiliTc.Text = dr["YetkiliTc"].ToString();
                txtSektör.Text = dr["Sektör"].ToString();
                mskTel1.Text = dr["Telefon1"].ToString();
               
                txtMail.Text = dr["Mail"].ToString();
                mskFax.Text = dr["Fax"].ToString();
                cmbİL.Text = dr["Il"].ToString();
                cmbİlce.Text = dr["Ilce"].ToString();
                txtVergi.Text = dr["VergiDaire"].ToString();
                rchAdres.Text = dr["Adres"].ToString();
              

            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update tbl_Firmalar Set Ad=@p1,YetkiliStatu=@p2,YetkiliAdSoyad=@p3,YetkiliTc=@p4,Sektör=@p5,Telefon1=@p6,Mail=@p9,Fax=@p10,Il=@p11,Ilce=@p12,VergiDaire=@p13,Adres=@p14 Where ID=@p18",bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtAD.Text);
            güncelle.Parameters.AddWithValue("@p2", txtGörev.Text);
            güncelle.Parameters.AddWithValue("@p3", txtYetkili.Text);
            güncelle.Parameters.AddWithValue("@p4", mskYetkiliTc.Text);
            güncelle.Parameters.AddWithValue("@p5", txtSektör.Text);
            güncelle.Parameters.AddWithValue("@p6", mskTel1.Text);
           
            güncelle.Parameters.AddWithValue("@p9", txtMail.Text);
            güncelle.Parameters.AddWithValue("@p10", mskFax.Text);
            güncelle.Parameters.AddWithValue("@p11", cmbİL.Text);
            güncelle.Parameters.AddWithValue("@p12", cmbİlce.Text);
            güncelle.Parameters.AddWithValue("@p13", txtVergi.Text);
            güncelle.Parameters.AddWithValue("@p14", rchAdres.Text);
           
            güncelle.Parameters.AddWithValue("@p18", txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void cmbİL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //                      Il Combobox'ında Seçilen İllere Göre ilçe ComboBox'ına İlçe Çekme 

            cmbİlce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("Select Ilce From tbl_Ilceler Where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbİL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
