using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis_Otomasyonu.Formlar
{
    public partial class FrmSatısListesi : Form
    {
        public FrmSatısListesi()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        private void FrmSatısListesi_Load(object sender, EventArgs e)
        {
            //Listeleme
            var degerler = from x in db.tbl_UrunHaraket
                           select new
                           {
                               x.HaraketID,
                               x.tbl_Urunler.Ad,
                               Musteri = x.tbl_Cariler.Ad + x.tbl_Cariler.Soyadı,
                               Personel = x.tbl_Personeller.Ad + x.tbl_Personeller.Soyad,
                               x.Tarih,
                               x.Adet,
                               x.Fiyat,
                               x.UrunSeriNo

                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
