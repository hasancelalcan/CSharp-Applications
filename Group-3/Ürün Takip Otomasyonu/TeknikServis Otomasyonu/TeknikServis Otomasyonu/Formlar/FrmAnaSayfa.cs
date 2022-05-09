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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            //Tablodan  Stoğu 30 dan az olanları Çekme
            gridControl1.DataSource = (from x in db.tbl_Urunler select new { 
            
                x.Ad,
                x.Stok
            }).Where(x => x.Stok < 30).ToList();

            //Tablodan Ad Soyad Telefon Çekme
            gridControl4.DataSource = (from y in db.tbl_Cariler
                                       select new
                                       {

                                           y.Ad,
                                           y.Soyadı,
                                           y.Telefon
                                       }).ToList();

            //Prosedür Çekme
            gridControl2.DataSource = db.urunkategori().ToList();

            //
            DateTime bugun = DateTime.Today;
            var deger = (from x in db.tbl_Notlar.OrderBy(y => y.ID)
                         where (x.Tarih == bugun)
                         select new { x.Baslik, x.Icerik });
            gridControl3.DataSource = deger.ToList();


        }
    }
}
