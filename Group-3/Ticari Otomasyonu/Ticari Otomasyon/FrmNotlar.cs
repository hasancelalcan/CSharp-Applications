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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                  Veri Listeleme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Notlar", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtBaslık.Text = "";
            txtHitap.Text = "";
            txtID.Text = "";
            txtOlusturan.Text = "";
            rchDetay.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                   Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            mskTarih.Text = dr["Tarih"].ToString();
            mskSaat.Text = dr["Saat"].ToString();
            txtBaslık.Text = dr["Baslık"].ToString();
            rchDetay.Text = dr["Detay"].ToString();
            txtOlusturan.Text = dr["Olusturan"].ToString();
            txtHitap.Text = dr["Hitap"].ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From tbl_Notlar Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Not Silindi");
                listele();
                temizle();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                     Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Notlar (Tarih,Saat,Baslık,Detay,Olusturan,Hitap) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", mskTarih.Text);
            ekle.Parameters.AddWithValue("@p2", mskSaat.Text);
            ekle.Parameters.AddWithValue("@p3", txtBaslık.Text);
            ekle.Parameters.AddWithValue("@p4", rchDetay.Text);
            ekle.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            ekle.Parameters.AddWithValue("@p6", txtHitap.Text);
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Not Eklendi");
            listele();
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update tbl_Notlar Set Tarih=@p1,Saat=@p2,Baslık=@p3,Detay=@p4,Olusturan=@p5,Hitap=@p6 Where ID=@p7", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", mskTarih.Text);
            güncelle.Parameters.AddWithValue("@p2", mskSaat.Text);
            güncelle.Parameters.AddWithValue("@p3", txtBaslık.Text);
            güncelle.Parameters.AddWithValue("@p4", rchDetay.Text);
            güncelle.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            güncelle.Parameters.AddWithValue("@p6", txtHitap.Text);
            güncelle.Parameters.AddWithValue("@p7",txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Not Güncellendi");
            listele();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //                              Notlar Tablosundaki Tıklanılan Sütündaki Detay Bölümünü Yeni Bir Formda Gösterme

            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["Detay"].ToString();
            }
            fr.Show();
        }
    }
}
