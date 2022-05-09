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

namespace KütüphaneOtomasyonu
{
    public partial class EmanetKitapListele : Form
    {
        public EmanetKitapListele()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        DataSet daset = new DataSet();
        private void EmanetListele()
        {
            baglantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *From tbl_EmanetKitap", baglantı);
            adtr.Fill(daset, "tbl_EmanetKitap");
            dataGridView1.DataSource = daset.Tables["tbl_EmanetKitap"];
            baglantı.Close();
        }

        private void EmanetKitapListele_Load(object sender, EventArgs e)
        {
            EmanetListele();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            daset.Tables["tbl_EmanetKitap"].Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                EmanetListele();
            }
            else if (comboBox1.SelectedIndex==1)
            {
                baglantı.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select *From tbl_EmanetKitap where '" + DateTime.Now.ToShortDateString()+"'>İadeTarihi ", baglantı); ;
                adtr.Fill(daset, "tbl_EmanetKitap");
                dataGridView1.DataSource = daset.Tables["tbl_EmanetKitap"];
                baglantı.Close();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                baglantı.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select *From tbl_EmanetKitap where '" + DateTime.Now.ToShortDateString() + "'<=İadeTarihi ", baglantı); ;
                adtr.Fill(daset, "tbl_EmanetKitap");
                dataGridView1.DataSource = daset.Tables["tbl_EmanetKitap"];
                baglantı.Close();
            }
        }
    }
}
