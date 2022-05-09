using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis_Otomasyonu.Iletisim
{
    public partial class FrmGelenKutusu : Form
    {
        public FrmGelenKutusu()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        private void FrmGelenKutusu_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.tbl_Iletisim
                                       select new
                                       {
                                           x.ID,
                                           x.AdSoyad,
                                           x.Konu,
                                           x.Mail,
                                           x.Mesaj
                                       }).ToList();


        }
    }
}
