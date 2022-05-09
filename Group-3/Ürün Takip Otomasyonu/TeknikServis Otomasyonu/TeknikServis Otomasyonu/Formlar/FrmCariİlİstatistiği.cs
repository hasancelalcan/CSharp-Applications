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

namespace TeknikServis_Otomasyonu.Formlar
{
    public partial class FrmCariİlİstatistiği : Form
    {
        public FrmCariİlİstatistiği()
        {
            InitializeComponent();
        }

        TeknikServisOtomasyonuEntities db = new TeknikServisOtomasyonuEntities();

        SqlConnection baglatı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TeknikServisOtomasyonu;Integrated Security=True");

        private void FrmCariİlİstatistiği_Load(object sender, EventArgs e)
        {
            //Sql'den Grafiğe veri çekme
            baglatı.Open();
            SqlCommand komut = new SqlCommand("Select Il,Count(*) From tbl_Cariler Group By Il",baglatı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglatı.Close();


            //Listeleme
            gridControl1.DataSource = db.tbl_Cariler.OrderBy(x => x.Il).GroupBy
                (y => y.Il).
                Select(z => new { İl = z.Key, Toplam = z.Count() }).ToList();



        }
    }
}
