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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
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
            tbl_Personeller t = new tbl_Personeller();

            t.Ad = txtAdı.Text;
            t.Soyad = txtSoyad.Text;
            t.Mail = txtMail.Text;
            t.Telefon = txtTelefon.Text;
            //t.Departman = int.Parse(txtDepartman.Text).ToString();


            db.tbl_Personeller.Add(t);
            db.SaveChanges();

            
            MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
