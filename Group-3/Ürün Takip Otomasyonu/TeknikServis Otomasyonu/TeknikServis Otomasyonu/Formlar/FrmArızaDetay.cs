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
    public partial class FrmArızaDetay : Form
    {
        public FrmArızaDetay()
        {
            InitializeComponent();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

            tbl_UrunTakip t = new tbl_UrunTakip();

            t.Acıklama = rchDetay.Text;
            t.SeriNo = txtSeriNo.Text;
            t.Tarih = DateTime.Parse(txtTarih.Text);
            db.tbl_UrunTakip.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Arıza Detayları Güncellendi");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArızaDetay_Load(object sender, EventArgs e)
        {

        }

        private void FrmArızaDetay_Load_1(object sender, EventArgs e)
        {

        }
    }
}
