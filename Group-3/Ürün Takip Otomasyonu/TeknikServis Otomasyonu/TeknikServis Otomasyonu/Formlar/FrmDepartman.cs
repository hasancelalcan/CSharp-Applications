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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        void temizle()
        {
            txtAdı.Text = "";
            txtID.Text = "";
            richacıklama.Text = "";
        }

        void DepartmanListele()
        {
            //                                               ToList() - Listeleme

            var degerler = from u in db.tbl_Departman
                           select new
                           {
                               u.ID,
                               u.Ad,
                               u.Aciklama,
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            DepartmanListele();

            //Veri Çekme
            lblDepartmanSayı.Text = db.tbl_Departman.Count().ToString();
            lbltoplampersonel.Text = db.tbl_Personeller.Count().ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            //                              Veri Ekleme - Add()
            tbl_Departman t = new tbl_Departman();
            if (txtAdı.Text.Length<=50 && txtAdı.Text!="")
            {
                t.Ad = txtAdı.Text;
                t.Aciklama = richacıklama.Text;
                db.tbl_Departman.Add(t);
                db.SaveChanges();

                DepartmanListele();
                temizle();
                MessageBox.Show("Departman Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var deger = db.tbl_Departman.Find(ID);
                db.tbl_Departman.Remove(deger);
                db.SaveChanges();

                DepartmanListele();
                temizle();
                MessageBox.Show("Departman Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                     EntityGüncelleme

            int ID = int.Parse(txtID.Text);
            var deger = db.tbl_Departman.Find(ID);
            deger.Ad = txtAdı.Text;
            deger.Aciklama = richacıklama.Text;
            db.SaveChanges();

            DepartmanListele();
            temizle();
            MessageBox.Show("Departman Sistemde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                      Grid'den Araçlara Veri Taşıma

            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAdı.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
           // richacıklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
        }
    }
}
