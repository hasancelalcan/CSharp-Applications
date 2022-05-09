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
    public partial class FrmYeniArızaKaydı : Form
    {
        public FrmYeniArızaKaydı()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            // Yeni Arızalı Ürün Kaydı  - Veri Ekleme

            tbl_UrunKabul t = new tbl_UrunKabul();

            t.Cari = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GelisTarihi = DateTime.Parse(txtTarih.Text);
            t.Personel = short.Parse(lookUpEdit2.EditValue.ToString());
            t.UrunSeriNo = txtSeriNo.Text;
            db.tbl_UrunKabul.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Arıza Girişi Yapıldı");

        }

        private void FrmYeniArızaKaydı_Load(object sender, EventArgs e)
        {
            //Musteri
            lookUpEdit1.Properties.DataSource = (from x in db.tbl_Cariler
                                                 select new
                                                 {
                                                     x.ID,
                                                     Ad = x.Ad + " " + x.Soyadı
                                                 }).ToList();

            //Personel
            lookUpEdit2.Properties.DataSource = (from x in db.tbl_Personeller
                                                 select new
                                                 {
                                                     x.ID,
                                                     Ad = x.Ad + " " + x.Soyad
                                                 }).ToList();
        }

        private void txtTarih_EditValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
