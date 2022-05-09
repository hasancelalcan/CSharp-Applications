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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        
        void PersonelListele()
        {
            //                                               ToList() - Listeleme

            var degerler = from u in db.tbl_Personeller
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Soyad,
                               Departman = u.tbl_Departman.Ad,                      // İlişkili olduğu tablodan ad ' ını çekme
                               u.Mail,
                               u.Telefon                        
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            txtAdı.Text = "";
           
            txtID.Text = "";
            txtMail.Text = "";
            txtSoyadı.Text = "";
            txtTel.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
           
            PersonelListele();

            //LookUpEdit'e Departman Tablosunundaki Verileri Çekme
            lookUpEdit1.Properties.DataSource = (from x in db.tbl_Departman
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.Ad
                                                 }).ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                      Grid'den Araçlara Veri Taşıma

            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAdı.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSoyadı.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            txtTel.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            

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
                var deger = db.tbl_Personeller.Find(ID);
                db.tbl_Personeller.Remove(deger);
                db.SaveChanges();

                PersonelListele();
                temizle();
                MessageBox.Show("Personel Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                              Veri Ekleme - Add()
            tbl_Personeller t = new tbl_Personeller();
            
                t.Ad = txtAdı.Text;
                t.Soyad = txtSoyadı.Text;
                t.Mail = txtMail.Text;
                t.Telefon = txtTel.Text;
                t.Departman = byte.Parse(lookUpEdit1.EditValue.ToString());


                db.tbl_Personeller.Add(t);
                db.SaveChanges();

                PersonelListele();
                temizle();
                MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     EntityGüncelleme

            int ID = int.Parse(txtID.Text);
            var deger = db.tbl_Personeller.Find(ID);
            deger.Ad = txtAdı.Text;
            deger.Soyad = txtSoyadı.Text;
            deger.Mail = txtMail.Text;
            deger.Telefon = txtTel.Text;
            deger.Departman = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();

            PersonelListele();
            temizle();
            MessageBox.Show("Personel Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
