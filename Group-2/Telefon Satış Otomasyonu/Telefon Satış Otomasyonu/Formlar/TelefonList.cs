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

namespace Telefon_Satış_Otomasyonu
{
    public partial class TelefonList : Form
    {
        public TelefonList()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");
        private void TelefonList_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'telefonSatışOtomasyouDataSet.tbl_Model' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_ModelTableAdapter.Fill(this.telefonSatışOtomasyouDataSet.tbl_Model);
            // TODO: Bu kod satırı 'telefonSatışOtomasyouDataSet.tbl_Marka' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_MarkaTableAdapter.Fill(this.telefonSatışOtomasyouDataSet.tbl_Marka);

            TelefonListele();
            hesapla();
        }

        void hesapla()
        {
            //Telefon Fiyatlarıyla Telefon Adetlerini Çarpıp Hesapladı
            double geneltutar = 0;
            for (int i = 0; i <dataGridView1.Rows.Count-1; i++)
            {
                double miktarı = double.Parse(dataGridView1.Rows[i].Cells["Miktar"].Value.ToString());
                double alışfiyatı = double.Parse(dataGridView1.Rows[i].Cells["AlışFiyatı"].Value.ToString());
                double tutar = miktarı * alışfiyatı;
                geneltutar += tutar;
            }
            lbltoplammaliyet.Text = "Toplam Maliyet="+" "+geneltutar.ToString("C2");
            lbltoplamkayıt.Text = (dataGridView1.Rows.Count - 1) +" "+ "Kayıt Listelendi";
        }
        private void TelefonListele()
        {
            baglantı.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_Urun", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();
        }
        private void temizle()
        {
            txtalışfiyatı.Clear();
            txthafıza.Clear();
            txtimei.Clear();
            txtişletimsist.Clear();
            txtKDV.Clear();
            txtrenk.Clear();
            txtsatış.Clear();
            txtserino.Clear();
            txtçözünürlük.Clear();
            txtİşlemci.Clear();
            cmbmarka.Text = "";
            cmbmodel.Text = "";
            txtID.Clear();
            txtmiktar.Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Araçlara Taşıma
            txtID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblyenimarka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblyenimodel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtserino.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtimei.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtalışfiyatı.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtsatış.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtKDV.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtmiktar.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtİşlemci.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtişletimsist.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txthafıza.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtçözünürlük.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txtrenk.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            
        }

        private void btnmarkamodel_Click(object sender, EventArgs e)
        {
            
            lblyenimarka.Text = cmbmarka.Text;
            lblyenimodel.Text = cmbmodel.Text;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //Telefon Ekleme
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_Urun Set Marka=@p1,Model=@p2,SeriNo=@p3,İmeiNo=@p4,AlışFiyatı=@p5,SatışFiyatı=@p6,KDV=@p7,Miktar=@p8,İşlemci=@p9,İşletimSistemi=@p10,Hafıza=@p11,Cozunurluk=@p12,Renk=@p13 Where ID=@p14",baglantı);
            güncelle.Parameters.AddWithValue("@p1",lblyenimarka.Text);
            güncelle.Parameters.AddWithValue("@p2",lblyenimodel.Text);
            güncelle.Parameters.AddWithValue("@p3",txtserino.Text);
            güncelle.Parameters.AddWithValue("@p4",txtimei.Text);
            güncelle.Parameters.AddWithValue("@p5",double.Parse(txtalışfiyatı.Text));
            güncelle.Parameters.AddWithValue("@p6",double.Parse(txtsatış.Text));
            güncelle.Parameters.AddWithValue("@p7",int.Parse(txtKDV.Text));
            güncelle.Parameters.AddWithValue("@p8",int.Parse(txtmiktar.Text));
            güncelle.Parameters.AddWithValue("@p9", txtİşlemci.Text);
            güncelle.Parameters.AddWithValue("@p10",txtişletimsist.Text);
            güncelle.Parameters.AddWithValue("@p11",txthafıza.Text);
            güncelle.Parameters.AddWithValue("@p12",txtçözünürlük.Text);
            güncelle.Parameters.AddWithValue("@p13",txtrenk.Text);
            güncelle.Parameters.AddWithValue("@p14",txtID.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Telefon Bilgileri Güncellendi");
            TelefonListele();
            temizle();
            hesapla();
        }

        private void TXTARA_TextChanged(object sender, EventArgs e)
        {
            //SeriNo ya Göre Arayıp Lisleler
            baglantı.Open();
            SqlCommand ara = new SqlCommand("Select *From tbl_Urun where SeriNo like '%" + TXTARA.Text + "%'", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Telefon Silme
            baglantı.Open();
            SqlCommand sil = new SqlCommand("Delete From tbl_Urun Where ID=@p1",baglantı);
            sil.Parameters.AddWithValue("@p1",txtID.Text);
            sil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Telefon Bilgileri Silindi");
            TelefonListele();
            temizle();
            hesapla();
        }

        private void TXTARA_Click(object sender, EventArgs e)
        {
            TXTARA.Text = "";
        }

        
    }
}
