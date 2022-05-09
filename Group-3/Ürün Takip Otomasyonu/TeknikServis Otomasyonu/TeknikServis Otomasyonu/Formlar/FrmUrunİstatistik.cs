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
    public partial class FrmUrunİstatistik : Form
    {
        public FrmUrunİstatistik()
        {
            InitializeComponent();
        }

        //Entity Baglantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        private void FrmUrunİstatistik_Load(object sender, EventArgs e)
        {
            // SQL deki verileri İstatistik Olarak Labellara Çekme

            lblÜrünSayısı.Text = db.tbl_Urunler.Count().ToString();
            lblKategoriSayısı.Text = db.tbl_Kategori.Count().ToString();
            lblStokSayısı.Text=db.tbl_Urunler.Sum(x=>x.Stok).ToString();
            

            lblEnFazlaStok.Text = (from x in db.tbl_Urunler
                                   orderby x.Stok descending
                                   select x.Ad).FirstOrDefault();

            lblEnAzStokluUrun.Text = (from x in db.tbl_Urunler
                                   orderby x.Stok ascending
                                   select x.Ad).FirstOrDefault();

            lblEnYüksekFiyatlıUrun.Text = (from x in db.tbl_Urunler
                                           orderby x.SatisFiyat descending
                                           select x.Ad).FirstOrDefault();

            lblEnDüşükFiyatlıÜrün.Text = (from x in db.tbl_Urunler
                                          orderby x.SatisFiyat ascending
                                          select x.Ad).FirstOrDefault();

            lblBeyazEşyaStok.Text = db.tbl_Urunler.Count(x => x.Kategori == 4).ToString();
            lblBilgisayarStok.Text = db.tbl_Urunler.Count(x => x.Kategori == 1).ToString();
            lblKüçükEvAletiStok.Text = db.tbl_Urunler.Count(x => x.Kategori == 3).ToString();

            lblToplamMarkaSaysıs.Text = (from x in db.tbl_Urunler
                                         select x.Marka).Distinct().Count().ToString();

            lblArızalıÜrünSayısı.Text = db.tbl_UrunKabul.Count().ToString();
            lblEnFazlaKategori.Text = db.makskategoriurun().FirstOrDefault();


        }
    }
}
