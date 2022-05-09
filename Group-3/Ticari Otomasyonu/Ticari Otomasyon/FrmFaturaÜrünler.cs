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
    public partial class FrmFaturaÜrünler : Form
    {
        public FrmFaturaÜrünler()
        {
            InitializeComponent();
        }

        public string ID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                          Fatura Formundan Alınan ID'ye Göre Veri Listeler

            SqlDataAdapter da = new SqlDataAdapter("Select *From tbl_FaturaDetay Where FaturaID= '"+ID+"'",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturaÜrünler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //      Formlar Arası Değer Aktarma - - Faturanın Detaylarını Farklı Formda Görme

            FrmFaturaÜrünDüzenleme fr = new FrmFaturaÜrünDüzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.UrunID = dr["FaturaUrunID"].ToString();
            }
            fr.Show();
        }
    }
}
