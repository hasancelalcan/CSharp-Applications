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
    public partial class FrmArızalıUrunDetayLıstesi : Form
    {
        public FrmArızalıUrunDetayLıstesi()
        {
            InitializeComponent();
        }

        private void FrmArızalıUrunDetayLıstesi_Load(object sender, EventArgs e)
        {
            TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

            gridControl1.DataSource = (from x in db.tbl_UrunTakip
                                      select new
                                      {
                                          x.TakipID,
                                          x.SeriNo,
                                          x.Tarih,
                                          x.Acıklama
                                      }).ToList();
        }
    }
}
