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
    public partial class FrmArızaListesi : Form
    {
        public FrmArızaListesi()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VRK3DH1\SQLEXPRESS;Initial Catalog=TeknikServisOtomasyonu;Integrated Security=True");

        private void FrmArızaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.tbl_UrunKabul
                           select new
                           {
                               x.IslemID,
                               Cari = x.tbl_Cariler.Ad + x.tbl_Cariler.Soyadı,
                               Personel = x.tbl_Personeller.Ad + x.tbl_Personeller.Soyad,
                               x.GelisTarihi,
                               x.CikisTarihi,
                               x.UrunSeriNo,
                           };
            gridControl1.DataSource = degerler.ToList();

            label2.Text = db.tbl_UrunKabul.Count(x=> x.UrunDurum==true).ToString();
            label4.Text = db.tbl_UrunKabul.Count(x => x.UrunDurum == false).ToString();
            label10.Text = db.tbl_Urunler.Count().ToString();



            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Marka,Count(*) From tbl_Urunler Group By Marka", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

        }
    }
}
