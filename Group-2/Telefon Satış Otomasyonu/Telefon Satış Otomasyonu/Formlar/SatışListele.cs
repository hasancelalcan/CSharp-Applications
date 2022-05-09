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
    public partial class SatışListele : Form
    {
        public SatışListele()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        private void SatışListele_Load(object sender, EventArgs e)
        {
            baglantı.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_Satıs", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }

        private void txtürünıd_TextChanged(object sender, EventArgs e)
        {
            //ID ye Göre Arama
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where UrunID Like '%"+txtürünıd.Text+"%' ",baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();

        }

        private void txtmarkaara_TextChanged(object sender, EventArgs e)
        {
            //Markaya Göre Arama
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where Marka Like '%"+txtmarkaara.Text +"%' ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void dtgünlük_ValueChanged(object sender, EventArgs e)
        {
            //Tarihe Göre Arama
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where Tarih=convert(date,'"+dtgünlük.Text+"',104)", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void btnikitariharası_Click(object sender, EventArgs e)
        {
            //İki Tarih Arası Göre Arama
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where Tarih between convert(date,'"+dtbaşlangıç.Text+ "',104) and convert(date,'" + dtson.Text + "',104)", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void btnayyılgetir_Click(object sender, EventArgs e)
        {
            // ay ve yıla göre ara
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where month(Tarih)='"+txtay.Text+"' and year(Tarih)='"+txtyıl2.Text+"' ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void btnyılgetir_Click(object sender, EventArgs e)
        {
            //yıla göre ara
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select * From tbl_Satıs Where year(Tarih)='" + txtyıl2.Text + "' ", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

       
    }
}
