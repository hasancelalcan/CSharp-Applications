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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        private void btnGiriş_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.tbl_Admin where x.KullaniciAdi == textEdit1.Text & x.Sifre == textEdit2.Text select x;
            if (sorgu.Any())
            {
                FrmGirişEkranı frm = new FrmGirişEkranı();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
