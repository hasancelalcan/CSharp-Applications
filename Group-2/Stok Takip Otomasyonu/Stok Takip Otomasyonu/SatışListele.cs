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

namespace Stok_Takip_Otomasyonu
{
    public partial class SatışListele : Form
    {
        public SatışListele()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=StokTakipOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void satışlistele()
        {
            //                    SQL'deki Tabloyu DataGrid'de Listeler

            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *From tbl_Satış", baglantı);
            adtr.Fill(daset, "tbl_Satış");
            dataGridView1.DataSource = daset.Tables["tbl_Satış"];
           
            baglantı.Close();
        }
        private void SatışListele_Load(object sender, EventArgs e)
        {
            satışlistele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            //Tüm Listeyi Siler
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Delete From tbl_Satış", baglantı);
            adtr.Fill(daset, "tbl_Satış");
            dataGridView1.DataSource = daset.Tables["tbl_Satış"];
            baglantı.Close();
            daset.Tables["tbl_Satış"].Clear();
            satışlistele();
            MessageBox.Show("Liste Silindi");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataGrid'deki BarkodNo'ya Göre Silme İşlemi Yapar
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Satış where BarkodNo='" + dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString() + "'", baglantı);
            sil.ExecuteNonQuery();
            baglantı.Close();
            daset.Tables["tbl_Satış"].Clear();
            satışlistele();
            MessageBox.Show("Satış Silindi");
          

        }

    }
}
