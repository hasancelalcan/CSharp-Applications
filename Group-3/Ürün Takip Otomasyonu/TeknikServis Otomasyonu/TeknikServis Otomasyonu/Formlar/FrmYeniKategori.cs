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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Entity Bağlantısı
            TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

            //                                          Add()  -  Ekleme
            if (txtKategoriAdı.Text!="" && txtKategoriAdı.Text.Length<=30)
            {
                tbl_Kategori t = new tbl_Kategori();
                t.Ad = txtKategoriAdı.Text;
                db.tbl_Kategori.Add(t);

                db.SaveChanges();
                MessageBox.Show("Kategori Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Karakter Sayısını 0-30 arasında giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
