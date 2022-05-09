using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnÜyeEkle_Click(object sender, EventArgs e)
        {
            ÜyeEklemeSayfası fr = new ÜyeEklemeSayfası();
            fr.ShowDialog();
        }

        private void btnÜyeListele_Click(object sender, EventArgs e)
        {
            ÜyeListele fr = new ÜyeListele();
            fr.ShowDialog();
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkle fr = new KitapEkle();
            fr.ShowDialog();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            KitapListele fr = new KitapListele();
            fr.ShowDialog();
        }

        private void btnEmanetver_Click(object sender, EventArgs e)
        {
            EmanetKitapVer fr = new EmanetKitapVer();
            fr.ShowDialog();
        }

        private void btnemanetlistele_Click(object sender, EventArgs e)
        {
            EmanetKitapListele fr = new EmanetKitapListele();
            fr.ShowDialog();
        }

        private void btnemanetkitapiade_Click(object sender, EventArgs e)
        {
            EmanetKitapİade fr = new EmanetKitapİade();
            fr.ShowDialog();
        }
    }
}
