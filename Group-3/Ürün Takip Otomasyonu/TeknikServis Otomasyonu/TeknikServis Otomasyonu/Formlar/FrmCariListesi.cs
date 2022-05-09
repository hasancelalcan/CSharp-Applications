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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        //EntityBaglantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        int secilen;

        void CariListele()
        {
            //                                               ToList() - Listeleme

            //var degerler = db.tbl_Urunler.ToList();
            var degerler = from u in db.tbl_Cariler
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Soyadı,
                               u.Telefon,
                               u.Mail,
                              u.Il,
                              u.Ilce,
                              u.Banka,
                              u.VergiDairesi,
                              u.VergiNo,
                              u.Statu,
                              u.Adres
                           };
            gridControl1.DataSource = degerler.ToList();

           
        }

        void temizle()
        {
            txtAdı.Text = "";
            txtBanka.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            txtStatü.Text = "";
            txtTelefon.Text = "";
            txtVergiDaire.Text = "";
            txtVergiNo.Text = "";
            richAdres.Text = "";
        }


        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            CariListele();

            lblÜrünSayısı.Text = db.tbl_Cariler.Count().ToString();

            //LookUpEdit'e Verileri Çekme
            lookUpİL.Properties.DataSource = (from x in db.tbl_Iller
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
            label2.Text = db.tbl_Cariler.Select(x=> x.Il).Distinct().Count().ToString();
            label6.Text = db.tbl_Cariler.Select(x => x.Ilce).Distinct().Count().ToString();


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
            t.Adres = richAdres.Text;
            db.tbl_Cariler.Add(t);
            db.SaveChanges();

            CariListele();
            temizle();
            MessageBox.Show("Yeni Cari Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                      Grid'den Araçlara Veri Taşıma

            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAdı.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            txtBanka.Text = gridView1.GetFocusedRowCellValue("Banka").ToString();
            txtVergiDaire.Text = gridView1.GetFocusedRowCellValue("VergiDairesi").ToString();
            txtVergiNo.Text = gridView1.GetFocusedRowCellValue("VergiNo").ToString();
            txtStatü.Text = gridView1.GetFocusedRowCellValue("Statu").ToString();
            richAdres.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyadı").ToString();


        
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //Güncelleme
            int ID = int.Parse(txtID.Text);
            var deger = db.tbl_Cariler.Find(ID);
            deger.Ad = txtAdı.Text;
            deger.Soyadı = txtSoyad.Text;
            deger.Telefon = txtTelefon.Text;
            deger.Mail = txtMail.Text;
            deger.Banka = txtBanka.Text;
            deger.VergiDairesi = txtVergiDaire.Text;
            deger.VergiNo = txtVergiNo.Text;
            deger.Statu = txtStatü.Text;
            deger.Adres = richAdres.Text;
            db.SaveChanges();

            CariListele();
            temizle();
            MessageBox.Show("Cari Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                  Remove()  -   Veri Silme
            if (dialog == DialogResult.Yes)
            {
                int ID = int.Parse(txtID.Text);
                var deger = db.tbl_Cariler.Find(ID);
                db.tbl_Cariler.Remove(deger);
                db.SaveChanges();

                CariListele();
                temizle();
                MessageBox.Show("Cari Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void lookUpİL_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpİL.EditValue.ToString());
            //LookUpEdit'e Verileri Çekme
            lookUpiLCE.Properties.DataSource = (from y in db.tbl_Ilce
                                                select new
                                                {
                                                    y.id,
                                                    y.ilce,
                                                    y.sehir
                                                }).Where(z=>z.sehir==secilen).ToList();
        }
    }
}
