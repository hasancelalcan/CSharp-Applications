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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                  Veri Listeleme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Personeller", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

       

        void temizle()
        {
                //                          Araçların İçeriğini Temizleme
                txtAD.Text = "";
                txtID.Text = "";
                txtMail.Text = "";
                txtSoyad.Text = "";
                mskTc.Text = "";
                mskTel1.Text = "";
                txtGörev.Text = "";
            rchAdres.Text = "";

        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            temizle();
            listele();
           
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                     Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Personeller (Ad,Soyadı,Telefon,Tc,Mail,Adres,Gorev) values (@p1,@p2,@p3,@p4,@p5,@p8,@p9)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", txtAD.Text);
            ekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            ekle.Parameters.AddWithValue("@p3", mskTel1.Text);
            ekle.Parameters.AddWithValue("@p4", mskTc.Text);
            ekle.Parameters.AddWithValue("@p5", txtMail.Text);
           
            ekle.Parameters.AddWithValue("@p8", rchAdres.Text);
            ekle.Parameters.AddWithValue("@p9", txtGörev.Text);
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi");
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
                SqlCommand sil = new SqlCommand("Delete From tbl_Personeller Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Personel Silindi");
                listele();
                temizle();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                              Veri Güncelleme
            SqlCommand güncelle = new SqlCommand("Update tbl_Personeller Set Ad=@p1,Soyadı=@p2,Telefon=@p3,Tc=@p4,Mail=@p5,Adres=@p8,Gorev=@p9 Where ID=@p10", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtAD.Text);
            güncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            güncelle.Parameters.AddWithValue("@p3", mskTel1.Text);
            güncelle.Parameters.AddWithValue("@p4", mskTc.Text);
            güncelle.Parameters.AddWithValue("@p5", txtMail.Text);
           
            güncelle.Parameters.AddWithValue("@p8", rchAdres.Text);
            güncelle.Parameters.AddWithValue("@p9", txtGörev.Text);
            güncelle.Parameters.AddWithValue("@p10", txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi");
            listele();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                   Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAD.Text = dr["Ad"].ToString();
            txtSoyad.Text = dr["Soyadı"].ToString();
            mskTel1.Text = dr["Telefon"].ToString();
            mskTc.Text = dr["Tc"].ToString();
            txtMail.Text = dr["Mail"].ToString();
           
            rchAdres.Text = dr["Adres"].ToString();
            txtGörev.Text = dr["Gorev"].ToString();
        }
    }
}
