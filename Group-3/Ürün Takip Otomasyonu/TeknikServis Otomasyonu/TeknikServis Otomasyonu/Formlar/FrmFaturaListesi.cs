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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        void listele()
        {
            var degerler = from u in db.tbl_FaturaBilgi
                           select new
                           {
                               u.ID,
                               u.Seri,
                               u.SiraNo,
                               u.Tarih,
                               u.Saat,
                               u.VergiDaire,
                               Cari = u.tbl_Cariler.Ad + u.tbl_Cariler.Soyadı,
                               Personel = u.tbl_Personeller.Ad + u.tbl_Personeller.Soyad
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            txtID.Text = "";
            txtSaat.Text = "";
            txtSeri.Text = "";
            txtSıra.Text = "";
            txtTarih.Text = "";
            txtVergi.Text = "";
        }

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {

            listele();

            //LookUpEdit'e Departman Tablosunundaki Verileri Çekme
            lookCari.Properties.DataSource = (from x in db.tbl_Cariler
                                                 select new
                                                 {
                                                     x.ID,
                                                     Adı = x.Ad +" "+ x.Soyadı
                                                 }).ToList();

            //LookUpEdit'e Departman Tablosunundaki Verileri Çekme
            lookPersonel.Properties.DataSource = (from x in db.tbl_Personeller
                                              select new
                                              {
                                                  x.ID,
                                                  Adı = x.Ad + " " + x.Soyad
                                              }).ToList();


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tbl_FaturaBilgi t = new tbl_FaturaBilgi();
            t.Seri = txtSeri.Text;
            t.SiraNo = txtSıra.Text;
            t.Tarih = Convert.ToDateTime(txtTarih.Text);
            t.Saat = txtSaat.Text;
            t.VergiDaire = txtVergi.Text;
            t.Cari = int.Parse(lookCari.EditValue.ToString());
            t.Personel = short.Parse(lookPersonel.EditValue.ToString());
            db.tbl_FaturaBilgi.Add(t);
            db.SaveChanges();

            listele();
            temizle();
            MessageBox.Show("Fatura Sisteme Kayıt Edilmiştir");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public string ID;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Fatura Detayını Başka Forma Gönderme
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
