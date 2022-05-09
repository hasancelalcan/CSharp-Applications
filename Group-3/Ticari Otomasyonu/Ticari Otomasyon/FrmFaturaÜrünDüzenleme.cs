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
    public partial class FrmFaturaÜrünDüzenleme : Form
    {
        public FrmFaturaÜrünDüzenleme()
        {
            InitializeComponent();
        }

        public string UrunID;

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmFaturaÜrünDüzenleme_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = UrunID;

            //                          Araçları ID'ye Göre Doldurma

            SqlCommand komut = new SqlCommand("Select * From tbl_FaturaDetay Where FaturaUrunID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", UrunID);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAdı.Text = dr[1].ToString();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand güncelle = new SqlCommand("Update tbl_FaturaDetay Set UrunAd=@p1,Miktar=@p2,Fiyat=@p3,Tutar=@p4 Where FaturaUrunID=@p5", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1",txtUrunAdı.Text);
            güncelle.Parameters.AddWithValue("@p2",txtMiktar.Text);
            güncelle.Parameters.AddWithValue("@p3",decimal.Parse(txtFiyat.Text));
            güncelle.Parameters.AddWithValue("@p4",decimal.Parse(txtTutar.Text));
            güncelle.Parameters.AddWithValue("@p5",txtUrunID.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Değişiklikler Kayıt Edildi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From tbl_FaturaDetay Where FaturaUrunID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtUrunID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Ürün Silindi");
                
            }
        }
    }
}
