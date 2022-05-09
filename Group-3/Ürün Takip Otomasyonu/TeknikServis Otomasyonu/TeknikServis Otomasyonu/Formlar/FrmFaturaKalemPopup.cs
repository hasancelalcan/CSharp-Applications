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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }

        public int ID;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            // Fatura ID'sine Göre Fatura Detayları Çekme
            TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
            gridControl1.DataSource = db.tbl_FaturaDetay.Where(x => x.FaturaID == ID).ToList();
            gridControl2.DataSource = db.tbl_FaturaBilgi.Where(x => x.ID == ID).ToList();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            //GridControl'ü PDF'e Aktarma
            string path = "Dosya1.Pdf";
            gridControl1.ExportToPdf(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            //GridControl'ü Excel'e Aktarma
            string path = "Dosya1.Xls";
            gridControl1.ExportToXls(path);
        }
    }
}
