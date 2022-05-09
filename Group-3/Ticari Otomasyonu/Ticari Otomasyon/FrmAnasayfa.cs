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
using System.Xml;


namespace Ticari_Otomasyon
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Stoklar()
        {
            // Ürünün Adeti 20 Den Az Olanlar

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,Sum(Adet) as 'Adet' From tbl_Urunler group by UrunAd having Sum(adet)<=20 order by Sum(Adet) ",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Ajanda()
        {
            //İlk 5 Notu Listeler

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 9 Tarih,Saat,Baslık From tbl_Notlar order by ID desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;

        }

        void FirmaHareketleri()
        {
            //Firmanın Özet Hareketleri

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 From tbl_Firmalar",bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        void haberler()
        {
            // Belirtilen Web Sitesindeki xml kodlarını çeker böylece veb sitesinin başlıklarını belirtilen araca aktarılır

            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name== "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            haberler();
            Ajanda();
            FirmaHareketleri();
            Stoklar();
            Fihrist();


            //WebBrowser Aracı İle İnternet Üzrinden Kur Verilerini Çekme

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
