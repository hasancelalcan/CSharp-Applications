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

namespace Telefon_Satış_Otomasyonu.Formlar
{
    public partial class GrafikSıralama : Form
    {
        public GrafikSıralama()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");


        private void GrafikSıralama_Load(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl.Clear();
            baglantı.Open();
            SqlDataAdapter komut = new SqlDataAdapter("Select UrunID,sum(Miktarı) From tbl_Satıs Group by GROUPING sets(UrunID) order by sum(Miktarı)"), baglantı);
            komut.Fill(tbl);
            dataGridView1.DataSource = tbl;
            baglantı.Close();
        }
    }
}
