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
    public partial class FrmYeniCari : Form
    {
        public FrmYeniCari()
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
            // Veri Ekleme - Add()

            tbl_Cariler t = new tbl_Cariler();
            t.Ad = txtAdı.Text;
            t.Soyadı = txtSoyad.Text;
            t.Telefon = txtTelefon.Text;
            t.Mail = txtMail.Text;
            t.Il = lookUpİL.Text;
            t.Ilce = lookUpiLCE.Text;
            t.Banka = txtBanka.Text;
            t.VergiDairesi = txtVergiDaire.Text;
            t.VergiNo = txtVergiNo.Text;
            t.Statu = txtStatü.Text;
            t.Adres = txtAdres.Text;
            db.tbl_Cariler.Add(t);
            db.SaveChanges();

            MessageBox.Show("Yeni Cari Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void FrmYeniCari_Load(object sender, EventArgs e)
        {
            //LookUpEdit'e Verileri Çekme
            lookUpİL.Properties.DataSource = (from x in db.tbl_Iller
                                              select new
                                              {
                                                  x.id,
                                                  x.sehir
                                              }).ToList();
        }

        private void lookUpİL_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpİL.EditValue.ToString());
            //LookUpEdit'e Verileri Çekme
            lookUpiLCE.Properties.DataSource = (from y in db.tbl_Ilce
                                                select new
                                                {
                                                    y.id,
                                                    y.ilce,
                                                    y.sehir
                                                }).Where(z => z.sehir == secilen).ToList();
        }
    }
}
