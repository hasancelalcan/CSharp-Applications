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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        //Entity Bağlantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        public void temizle()
        {
            txtAkışFiyat.Text = "";
            txtMarka.Text = "";
            txtSatısFiyat.Text = "";
            txtStok.Text = "";
            txtUrunAdı.Text = "";
        }

        public void UrunListele()
        {
            //                                               ToList() - Listeleme

            //var degerler = db.tbl_Urunler.ToList();
            var degerler = from u in db.tbl_Urunler
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Marka,
                               u.AlisFiyat,
                               u.SatisFiyat,
                               Kategori = u.tbl_Kategori.Ad,
                               u.Stok
                           };
            gridControl1.DataSource = degerler.ToList(); 

        }


        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            UrunListele();

            //Kategorileri ComboBox'a Çekme
            lookUpEdit1.Properties.DataSource = (from x in db.tbl_Kategori
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.Ad
                                                 }).ToList();



        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                          Add()  -  Ekleme

            tbl_Urunler t = new tbl_Urunler();
            t.Ad = txtUrunAdı.Text;
            t.Marka = txtMarka.Text;
            t.AlisFiyat = decimal.Parse(txtAkışFiyat.Text);
            t.SatisFiyat = decimal.Parse(txtSatısFiyat.Text);
            t.Stok = short.Parse(txtStok.Text);
            t.Durum = false;
            t.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.tbl_Urunler.Add(t);
            db.SaveChanges();

            UrunListele();
            temizle();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                      Grid'den Araçlara Veri Taşıma

            try
            {
                txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtUrunAdı.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
                txtMarka.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
                txtAkışFiyat.Text = gridView1.GetFocusedRowCellValue("AlisFiyat").ToString();
                txtSatısFiyat.Text = gridView1.GetFocusedRowCellValue("SatisFiyat").ToString();
                txtStok.Text = gridView1.GetFocusedRowCellValue("Stok").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
            
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
                var deger = db.tbl_Urunler.Find(ID);
                db.tbl_Urunler.Remove(deger);
                db.SaveChanges();

                UrunListele();
                temizle();
                MessageBox.Show("Ürün Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     EntityGüncelleme

            int ID = int.Parse(txtID.Text);
            var deger = db.tbl_Urunler.Find(ID);
            deger.Ad = txtUrunAdı.Text;
            deger.Stok = short.Parse(txtStok.Text);
            deger.SatisFiyat = decimal.Parse(txtSatısFiyat.Text);
            deger.AlisFiyat = decimal.Parse(txtAkışFiyat.Text);
            deger.Marka = txtMarka.Text;
            deger.Kategori = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();

            UrunListele();
            temizle();
            MessageBox.Show("Ürün Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
