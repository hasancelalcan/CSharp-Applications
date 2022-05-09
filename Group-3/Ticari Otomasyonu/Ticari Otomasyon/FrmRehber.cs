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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void MusteriListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Soyad,Telefon,Mail From tbl_Musteriler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void FirmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,YetkiliAdSoyad,Telefon1,Mail,Fax From tbl_Firmalar", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            MusteriListele();
            FirmaListele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //                      Satırın başına Çift Tıklayınca Mail Kolonundaki Mail Gönder Formundaki Label'a Aktarır

            FrmMailGönder frm = new FrmMailGönder();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.Mail = dr["Mail"].ToString();
            }
            frm.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            //                      Satırın başına Çift Tıklayınca Mail Kolonundaki Mail Gönder Formundaki Label'a Aktarır

            FrmMailGönder frm = new FrmMailGönder();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.Mail = dr["Mail"].ToString();
            }
            frm.Show();
        }
    }
}
