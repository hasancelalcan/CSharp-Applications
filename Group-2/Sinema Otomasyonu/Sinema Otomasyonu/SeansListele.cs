using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    public partial class SeansListele : Form
    {
        public SeansListele()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = Sinema Otomasyonu; Integrated Security = True");

        DataTable tablo = new DataTable();

       private void SeansListesi(string sql)
        {
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql,baglantı);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }

        private void SeansListele_Load(object sender, EventArgs e)
        {
            //Tarihe Göre Arama
            tablo.Clear();
           SeansListesi("Select *from tbl_SeansBilgi where Tarih like '" +dateTimePicker1.Text+"'");
        }

        private void btntümseanslar_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("Select *from tbl_SeansBilgi");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Tarihe Göre Arama
            tablo.Clear();
            SeansListesi("Select *from tbl_SeansBilgi where Tarih like '" + dateTimePicker1.Text + "'");
        }
    }
}
