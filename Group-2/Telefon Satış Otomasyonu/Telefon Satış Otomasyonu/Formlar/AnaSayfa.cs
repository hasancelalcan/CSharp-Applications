using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon_Satış_Otomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void FormGetir(Form frm)
        {
            //Formları Panele Taşıma
            panelsayfalar.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelsayfalar.Controls.Add(frm);
            frm.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            
        }
       
        private void btnKullanıcıEkle_Click(object sender, EventArgs e)
        {
            //YeniKullanıcı Formunu Panale Taşıma
            YeniKullanıcı fr = new YeniKullanıcı();
            FormGetir(fr);
        }

        private void btnTelefonEkle_Click(object sender, EventArgs e)
        {
            //TelefonEkle Formunu Panale Taşıma
            TelefonEkle fr = new TelefonEkle();
            FormGetir(fr);
        }

        private void btnTelefonListele_Click(object sender, EventArgs e)
        {
            TelefonList fr = new TelefonList();
            FormGetir(fr);
        }

        private void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            Formlar.MarkaEkle ekle = new Formlar.MarkaEkle();
            ekle.ShowDialog();
        }

        private void btnModelEkle_Click(object sender, EventArgs e)
        {
            Formlar.ModelEkle ekle = new Formlar.ModelEkle();
            ekle.ShowDialog();
        }

        private void btnKullanıcıListele_Click(object sender, EventArgs e)
        {
            Formlar.KullanıcıListleme ekle = new Formlar.KullanıcıListleme();
            FormGetir(ekle);
        }

        private void btnMüşteriEkle_Click(object sender, EventArgs e)
        {
            Formlar.MüşteriEkle ekle = new Formlar.MüşteriEkle();
            FormGetir(ekle);
        }

        private void btnMüşteriListele_Click(object sender, EventArgs e)
        {
            Formlar.MüşteriListele ekle = new Formlar.MüşteriListele();
            FormGetir(ekle);
        }

        private void btnSatış_Click(object sender, EventArgs e)
        {
            Formlar.SatışYap ekle = new Formlar.SatışYap();
            FormGetir(ekle);
        }

        private void btnSatışlar_Click(object sender, EventArgs e)
        {
            Formlar.SatışListele ekle = new Formlar.SatışListele();
            FormGetir(ekle);
        }

     
    }
}
