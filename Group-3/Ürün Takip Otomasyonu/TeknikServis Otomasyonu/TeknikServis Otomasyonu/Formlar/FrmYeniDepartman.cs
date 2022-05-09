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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
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
            //                              Veri Ekleme - Add()
            tbl_Departman t = new tbl_Departman();
            if (txtxDepartmanAdı.Text.Length <= 50 && txtxDepartmanAdı.Text != "")
            {
                t.Ad = txtxDepartmanAdı.Text;
                t.Aciklama = txtAcıklama.Text;
                db.tbl_Departman.Add(t);
                db.SaveChanges();

               
                MessageBox.Show("Departman Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
