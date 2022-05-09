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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                  Veri Listeleme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Musteriler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            //                      İller Tablosundaki Sehir Kolonunu ComboBox'a Çekme

            SqlCommand komut = new SqlCommand("Select Sehir From tbl_Iller",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİL.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            //                          Araçların İçeriğini Temizleme
            txtAD.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            txtVergi.Text = "";
            mskTc.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            rchAdres.Text = "";
            cmbİL.Text = "";
            cmbİlçe.Text = "";
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
           

        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                     Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Musteriler (Ad,Soyad,Telefon,Telefon2,Tc,Mail,Il,Ilce,Adres,VergiDaire) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1" ,txtAD.Text);
            ekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            ekle.Parameters.AddWithValue("@p3", mskTel1.Text);
            ekle.Parameters.AddWithValue("@p4", mskTel2.Text);
            ekle.Parameters.AddWithValue("@p5", mskTc.Text);
            ekle.Parameters.AddWithValue("@p6", txtMail.Text);
            ekle.Parameters.AddWithValue("@p7", cmbİL.Text);
            ekle.Parameters.AddWithValue("@p8", cmbİlçe.Text);
            ekle.Parameters.AddWithValue("@p9", rchAdres.Text);
            ekle.Parameters.AddWithValue("@p10", txtVergi.Text);
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Eklendi");
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
                SqlCommand sil = new SqlCommand("Delete From tbl_Musteriler Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Silindi");
                listele();
                temizle();
            }
           
        }



        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                              Veri Güncelleme
            SqlCommand güncelle = new SqlCommand("Update tbl_Musteriler Set Ad=@p1,Soyad=@p2,Telefon=@p3,Telefon2=@p4,Tc=@p5,Mail=@p6,Il=@p7,Ilce=@p8,Adres=@p9,VergiDaire=@p10 Where ID=@p11",bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtAD.Text);
            güncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", mskTel1.Text);
            güncelle.Parameters.AddWithValue("@p4", mskTel2.Text);
            güncelle.Parameters.AddWithValue("@p5", mskTc.Text);
            güncelle.Parameters.AddWithValue("@p6", txtMail.Text);
            güncelle.Parameters.AddWithValue("@p7", cmbİL.Text);
            güncelle.Parameters.AddWithValue("@p8", cmbİlçe.Text);
            güncelle.Parameters.AddWithValue("@p9", rchAdres.Text);
            güncelle.Parameters.AddWithValue("@p10", txtVergi.Text);
            güncelle.Parameters.AddWithValue("@p11", txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Güncellendi");
            listele();
            temizle();
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //                          Araçların İçeriğini Temizleme
            temizle();
        }



        private void cmbİL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //                      Il Combobox'ında Seçilen İllere Göre ilçe ComboBox'ına İlçe Çekme 

            cmbİlçe.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("Select Ilce From tbl_Ilceler Where Sehir=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",cmbİL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİlçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                   Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAD.Text = dr["Ad"].ToString();
            txtSoyad.Text = dr["Soyad"].ToString();
            mskTel1.Text = dr["Telefon"].ToString();
            mskTel2.Text = dr["Telefon2"].ToString();
            mskTc.Text = dr["Tc"].ToString();
            txtMail.Text = dr["Mail"].ToString();
            cmbİL.Text = dr["Il"].ToString();
            cmbİlçe.Text = dr["Ilce"].ToString();
            rchAdres.Text = dr["Adres"].ToString();
            txtVergi.Text = dr["VergiDaire"].ToString();

        }

        
    }
}
