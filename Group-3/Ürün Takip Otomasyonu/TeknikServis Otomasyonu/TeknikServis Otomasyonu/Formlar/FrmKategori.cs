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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        //Entity Bağlantısı
        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        public void KategoriListele()
        {
            //                              ToList() - Listeleme      

            var degerler = from k in db.tbl_Kategori
                           select new
                           {
                               k.ID,
                               k.Ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            txtID.Text = "";
            txtKategoriAdı.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtKategoriAdı.Text = "";
        }

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            KategoriListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdı.Text!="" && txtKategoriAdı.Text.Length<=30)
            {
                tbl_Kategori t = new tbl_Kategori();
                t.Ad = txtKategoriAdı.Text;
                db.tbl_Kategori.Add(t);
                db.SaveChanges();

                KategoriListele();
                temizle();
                MessageBox.Show("Kategori Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez Ve 30 Karakterden Uzun Olamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            
        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                      Grid'den Araçlara Veri Taşıma

            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtKategoriAdı.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
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
                var deger = db.tbl_Kategori.Find(ID);
                db.tbl_Kategori.Remove(deger);
                db.SaveChanges();

                KategoriListele();
                temizle();
                MessageBox.Show("Kategori Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     EntityGüncelleme

            int ID = int.Parse(txtID.Text);
            var deger = db.tbl_Kategori.Find(ID);
            deger.Ad = txtKategoriAdı.Text;
            db.SaveChanges();

            KategoriListele();
            temizle();
            MessageBox.Show("Kategori Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
