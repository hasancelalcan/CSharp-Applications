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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        void listele()
        {
            var degerler = from u in db.tbl_FaturaDetay
                           select new
                           {
                               u.FaturaDetayID,
                               u.Urun,
                               u.Adet,
                               u.Fiyat,
                               u.Tutar,
                               u.FaturaID
                              
                           };
            gridControl1.DataSource = degerler.ToList();
        }


        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tbl_FaturaDetay t = new tbl_FaturaDetay();
            t.Urun = txtÜrün.Text;
            t.Adet = short.Parse(txtAdet.Text);
            t.Fiyat = decimal.Parse(txtFiyat.Text);
            t.Tutar= decimal.Parse(txtTutar.Text);
            t.FaturaID = int.Parse(txtFaturaID.Text);
            db.tbl_FaturaDetay.Add(t);
            db.SaveChanges();

            listele();
            MessageBox.Show("Faturaya Ait Kalem Girişi Başarı İle Yapıldı");
            txtAdet.Text = "";
            txtFaturaID.Text = "";
            txtFiyat.Text = "";
            txtID.Text = "";
            txtTutar.Text = "";
            txtÜrün.Text = "";


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtAdet.Text = "";
            txtFaturaID.Text = "";
            txtFiyat.Text = "";
            txtID.Text = "";
            txtTutar.Text = "";
            txtÜrün.Text = "";
        }
    }
}
