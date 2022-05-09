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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void giderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From  tbl_Giderler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblaktif.Text = ad;

            firmahareket();
            musterihareket();
            giderler();


            //Toplam
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From tbl_FaturaDetay ",bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplam.Text = dr1[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //Fatura Gider
            SqlCommand komut2 = new SqlCommand("Select (Elektrik+Su+DogalGaz) From tbl_Giderler order by ID asc ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblodemeler.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();

            //personel maasları
            SqlCommand komut3 = new SqlCommand("Select Maaslar From tbl_Giderler order by ID asc ", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpersonelmaaş.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();

            //Musteri Sayısı 
            SqlCommand komut4 = new SqlCommand("Select Count(*) From tbl_Musteriler  ", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmusteri.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Firma Sayısı 
            SqlCommand komut5 = new SqlCommand("Select Count(*) From tbl_Firmalar  ", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirma.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Sehir Sayısı 
            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(Il)) From tbl_Firmalar  ", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehir.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Personel Sayısı 
            SqlCommand komut7 = new SqlCommand("Select Count(*) From tbl_Personeller  ", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblpersonelsayı.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Stok Sayısı 
            SqlCommand komut8 = new SqlCommand("Select Sum(Adet) From tbl_Urunler  ", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblstok.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //1.grafik elektrik faturası son 4 ay

            SqlCommand komut9 = new SqlCommand("Select top 4 Ay,Elektrik From tbl_Giderler order by ID Desc",bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
            }
            bgl.baglanti().Close();

            //2.grafik su faturası son 4 ay

            SqlCommand komut10 = new SqlCommand("Select top 4 Ay,Su From tbl_Giderler order by ID Desc", bgl.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr9.Read())
            {
                chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
            }
            bgl.baglanti().Close();




        }
    }
}
