using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class GirişEkranı : Form
    {
        public GirişEkranı()
        {
            InitializeComponent();
        }


        FrmUrunler fr;
        private void btnÜrünler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr == null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
           
        }
        public string kullanıcı;
        
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr15 == null)
            {
                fr15 = new FrmAnasayfa();

                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        FrmMusteriler fr2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr2 == null)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr3 == null)
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        FrmPersoneller fr4;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr4 == null)
            {
                fr4 = new FrmPersoneller();
                fr4.MdiParent = this;
                fr4.Show();
            }

        }

        FrmRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr5 == null)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }


        FrmGiderler fr6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr6 == null)
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        FrmBankalar fr7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr7 == null)
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        FrmFatura fr8;
        private void btnFatuaralar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr8 == null)
            {
                fr8 = new FrmFatura();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        FrmNotlar fr9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr9 == null)
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        FrmHareketler fr10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr10 == null)
            {
                fr10 = new FrmHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        FrmRaporlar fr11;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr11 == null)
            {
                fr11 = new FrmRaporlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        FrmStoklar fr12;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr12 == null)
            {
                fr12 = new FrmStoklar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        FrmAyar fr13;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            if (fr13 == null)
            {
                fr13 = new FrmAyar();
               
                fr13.Show();
            }
        }

        FrmKasa fr14;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr14 == null)
            {
                fr14 = new FrmKasa();
                fr14.ad = kullanıcı;
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        FrmAnasayfa fr15;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Form İçerisinde Form Çağırma
            if (fr15 == null)
            {
                fr15 = new FrmAnasayfa();
                
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
    }
}
