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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        void listele()
        {
            gridControl1.DataSource = db.tbl_Notlar.Where(x => x.Durum == false).ToList();
            gridControl2.DataSource = db.tbl_Notlar.Where(y => y.Durum == true).ToList();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tbl_Notlar t = new tbl_Notlar();
            t.Baslik = txtbaslık.Text;
            t.Icerik = richTextBox1.Text;
            t.Durum = false;
            t.Tarih =DateTime.Parse(txtTarih.Text);
            db.tbl_Notlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Sisteme Kayıt Edildi");

            listele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(txtID.Text);
                var deger = db.tbl_Notlar.Find(id);
                deger.Durum = true;
                db.SaveChanges();
                MessageBox.Show("Not Okundu Olarak Güncellendi");

                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
            
                txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtbaslık.Text = "";
            txtID.Text = "";
            richTextBox1.Text = "";
        }
    }
}
