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
    public partial class FrmFaturaSorgulama : Form
    {
        public FrmFaturaSorgulama()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        private void btnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFaturaID.Text);

            var degerler = (from u in db.tbl_FaturaDetay
                           select new
                           {
                               u.FaturaDetayID,
                               u.Urun,
                               u.Adet,
                               u.Fiyat,
                               u.Tutar,
                               u.FaturaID
                           }).Where (x => x.FaturaID == id);

            gridControl1.DataSource = degerler.ToList();
        }
    }
}
