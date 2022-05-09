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
    public partial class FiyatGör : Form
    {
        public FiyatGör()
        {
            InitializeComponent();
        }

        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        public void fiyatgör()
        {
            //SeriNo ya Göre Telefon Bilgileri Araçlara Çekme
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Urun where SeriNo like'" + txtserinoara.Text + "'", baglantı);
            SqlDataReader dr = ara.ExecuteReader();
            while (dr.Read())
            {
                txtürünıd.Text = dr["ID"].ToString();
                txtmarka.Text = dr["Marka"].ToString();
                //txtmiktar.Text = dr["Miktar"].ToString();
                txtimeino.Text = dr["İmeiNo"].ToString();
                txtbirimfiyat.Text = dr["SatışFiyatı"].ToString();
            }
            baglantı.Close();
        }
        private void FiyatGör_Load(object sender, EventArgs e)
        {
            
        }

        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtbirimfiyat.Text) * double.Parse(txtmiktar.Text)).ToString("0.00");
            }
            catch 
            {
            }
        }

        private void txtserinoara_TextChanged(object sender, EventArgs e)
        {
            fiyatgör();
        }
    }
}
