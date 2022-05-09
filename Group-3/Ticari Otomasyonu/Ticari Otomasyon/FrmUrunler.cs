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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                      Urunler Tablosundan GridControl'e Verileri Çeker

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Urunler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            //                          Araçların İçeriğini Temizleme
            txtID.Text = "";
            txtAD.Text = "";
            txtAlış.Text = "0,00";
            txtMARKA.Text = "";
            txtMODEL.Text = "";
            txtSatış.Text = "0,00";
            mskYIL.Text = "";
            rchDetay.Text = "";
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                   Verileri Sql'e Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Urunler (UrunAd,Marka,Model,Yıl,Adet,AlisFiyat,SatisFiyat,Detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", txtAD.Text);
            ekle.Parameters.AddWithValue("@p2", txtMARKA.Text);
            ekle.Parameters.AddWithValue("@p3", txtMODEL.Text);
            ekle.Parameters.AddWithValue("@p4", mskYIL.Text);
            ekle.Parameters.AddWithValue("@p5", int.Parse((numericADET.Value).ToString()));
            ekle.Parameters.AddWithValue("@p6", decimal.Parse(txtAlış.Text));
            ekle.Parameters.AddWithValue("@p7", decimal.Parse(txtSatış.Text));
            ekle.Parameters.AddWithValue("@p8", rchDetay.Text);
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //                               Veri Silme

            SqlCommand sil = new SqlCommand("Delete From tbl_Urunler Where ID=@p1",bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtID.Text);
            sil.ExecuteNonQuery();

            MessageBox.Show("Ürün Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            listele();
            temizle();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                       Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update tbl_Urunler set UrunAd=@p1,Marka=@p2,Model=@p3,Yıl=@p4,Adet=@p5,AlisFiyat=@p6,SatisFiyat=@p7,Detay=@p8 Where ID=@p9", bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", txtAD.Text);
            güncelle.Parameters.AddWithValue("@p2", txtMARKA.Text);
            güncelle.Parameters.AddWithValue("@p3", txtMODEL.Text);
            güncelle.Parameters.AddWithValue("@p4", mskYIL.Text);
            güncelle.Parameters.AddWithValue("@p5", int.Parse((numericADET.Value).ToString()));
            güncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtAlış.Text));
            güncelle.Parameters.AddWithValue("@p7", decimal.Parse(txtSatış.Text));
            güncelle.Parameters.AddWithValue("@p8", rchDetay.Text);
            güncelle.Parameters.AddWithValue("@p9", txtID.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                          GridView'e Tıklanınca Verileri Araçlara Aktarır

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAD.Text = dr["UrunAd"].ToString();
            txtMARKA.Text = dr["Marka"].ToString();
            txtMODEL.Text = dr["Model"].ToString();
            mskYIL.Text = dr["Yıl"].ToString();
            numericADET.Value = decimal.Parse(dr["Adet"].ToString());
            txtAlış.Text = dr["AlisFiyat"].ToString();
            txtSatış.Text = dr["SatisFiyat"].ToString();
            rchDetay.Text = dr["Detay"].ToString();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
