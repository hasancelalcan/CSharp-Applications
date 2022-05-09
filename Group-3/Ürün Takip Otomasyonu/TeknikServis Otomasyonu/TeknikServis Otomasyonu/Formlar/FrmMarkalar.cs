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

namespace TeknikServis_Otomasyonu.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        //Entity Baglantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VRK3DH1\SQLEXPRESS;Initial Catalog=TeknikServisOtomasyonu;Integrated Security=True");


        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            // Veri Çekme
            var degerler = db.tbl_Urunler.OrderBy(x => x.Marka).GroupBy(y => y.Marka).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();


            // Marka Verilerini Label'lara Çekme
            lblÜrünSayısı.Text = (from x in db.tbl_Urunler
                                         select x.Marka).Distinct().Count().ToString();

            label2.Text = db.tbl_Urunler.Count().ToString();

            label6.Text = (from x in db.tbl_Urunler
                                           orderby x.SatisFiyat descending
                                           select x.Marka).FirstOrDefault();
            label4.Text = db.maksurunmarka().FirstOrDefault();


            // Chart İşlemleri
            //chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 1);
            //chartControl1.Series["Series 1"].Points.AddPoint("Beko", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Toshiba", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 3);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Marka,Count(*) From tbl_Urunler Group By Marka", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select  tbl_Kategori.Ad,Count(*) From tbl_Urunler INNER JOIN tbl_Kategori ON tbl_Kategori.ID = tbl_Urunler.Kategori GROUP BY tbl_Kategori.Ad", baglanti);
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();


        }
    }
}
