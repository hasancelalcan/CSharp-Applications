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
    public partial class FrmYeniUrunSatıs : Form
    {
        public FrmYeniUrunSatıs()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        private void FrmYeniUrunSatıs_Load(object sender, EventArgs e)
        {
            //LookUpEdit'e Verileri Çekme Ürün Adı
            lookUpİL.Properties.DataSource = (from x in db.tbl_Urunler
                                              select new
                                              {
                                                  x.ID,
                                                  x.Ad
                                              }).ToList();

            //LookUpEdit'e Verileri Çekme Cari Adı
            lookUpEdit1.Properties.DataSource = (from x in db.tbl_Cariler
                                              select new
                                              {
                                                  x.ID,
                                                  AD = x.Ad + " " + x.Soyadı
                                              }).ToList();

            //LookUpEdit'e Verileri Çekme Personel Adı
            lookUpEdit2.Properties.DataSource = (from x in db.tbl_Personeller
                                              select new
                                              {
                                                  x.ID,
                                                  AD = x.Ad + " " + x.Soyad
                                              }).ToList();

        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Ürün Satışı Yapma - tbl_UrunHaraket Tablosuna Veri Ekleme

            tbl_UrunHaraket t = new tbl_UrunHaraket();

            t.Urun = int.Parse(lookUpİL.EditValue.ToString());
            t.Musteri = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Personel = short.Parse(lookUpEdit2.EditValue.ToString());
            t.Tarih = DateTime.Parse(txtTarih.Text);
            t.Adet = short.Parse(txtAdet.Text);
            t.Fiyat = decimal.Parse(txtSatısFiyatı.Text);
            t.UrunSeriNo = txtSeriNo.Text;
            db.tbl_UrunHaraket.Add(t);
            db.SaveChanges();

            MessageBox.Show("Ürün Satışı Yapıldı");
        }

       
    }
}
