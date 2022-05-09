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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }


        // Entity Bağlantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();


        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            //                                          Add()  -  Ekleme

            tbl_Urunler t = new tbl_Urunler();
            t.Ad = txtUrunAdı.Text;
            t.Marka = txtMarka.Text;
            t.AlisFiyat = decimal.Parse(txtAlısFiyatı.Text);
            t.SatisFiyat = decimal.Parse(txtSatısFiyatı.Text);
            t.Stok = short.Parse(txtStok.Text);
            t.Durum = false;
            t.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.tbl_Urunler.Add(t);

            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            

        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            //Kategorileri ComboBox'a Çekme
            lookUpEdit1.Properties.DataSource = (from x in db.tbl_Kategori
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.Ad
                                                 }).ToList();

        }
    }
}
