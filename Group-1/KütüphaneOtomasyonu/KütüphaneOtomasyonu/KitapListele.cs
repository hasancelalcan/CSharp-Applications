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
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");

        private void listele()
        {
            //                          SQL'deki Tabloyu Listeleme
            baglantı.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_KitapBilgi", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            //                  SQL'deki Verileri BarkodNo'yu Baz Alarak Günceller
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_KitapBilgi Set KitapAdı=@p1,Yazarı=@p2,YayınEvi=@p3,SayfaSayısı=@p4,Türü=@p5,StokSayısı=@p6,RafNo=@p7,Açıklama=@p8 Where BarkodNo=@p9 ", baglantı);
            güncelle.Parameters.AddWithValue("@p9", txtBarkodNo.Text);
            güncelle.Parameters.AddWithValue("@p1",txtKitapAdı.Text);
            güncelle.Parameters.AddWithValue("@p2", txtYazarı.Text);
            güncelle.Parameters.AddWithValue("@p3", txtYayınEvi.Text);
            güncelle.Parameters.AddWithValue("@p4", txtSayfaSayısı.Text);
            güncelle.Parameters.AddWithValue("@p5", cmbtürü.Text);
            güncelle.Parameters.AddWithValue("@p6", txtStokSayısı.Text);
            güncelle.Parameters.AddWithValue("@p7", txtRafNo.Text);
            güncelle.Parameters.AddWithValue("@p8", txtAçıklama.Text);
           
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kitap Güncellendi");
            listele();
        }



        private void btnsil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog==DialogResult.Yes)
            {
                //                  SQL'den BarkodNo'yu Baz Alarak Veri Siler 
                baglantı.Open();
                SqlCommand sil = new SqlCommand("Delete From tbl_KitapBilgi Where BarkodNo=@p1", baglantı);
                sil.Parameters.AddWithValue("@p1", txtBarkodNo.Text);
                sil.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Kitap Silindi");
                listele();
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //        *****DataGridView'de üzerine çift tıkladığımız sırayı araçlara aktarma*****

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtBarkodNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKitapAdı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtYazarı.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtYayınEvi.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSayfaSayısı.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbtürü.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtStokSayısı.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtRafNo.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtAçıklama.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //             BarkodNo'yu Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_KitapBilgi Where BarkodNo Like '%" + textBox1.Text + "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            //***BarkodNo Yazıldığında,O BarkodNo ile Veri Tabananındaki Eşleşen Bilgiler,Kendi Araçlarına Dolduruldu*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KitapBilgi where BarkodNo like '" + txtBarkodNo.Text + "'", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtBarkodNo.Text = dr["BarkodNo"].ToString();
                txtYazarı.Text = dr["Yazarı"].ToString();
                txtYayınEvi.Text = dr["YayınEvi"].ToString();
                txtSayfaSayısı.Text = dr["SayfaSayısı"].ToString();
                cmbtürü.Text = dr["Türü"].ToString();
                txtStokSayısı.Text = dr["StokSayısı"].ToString();
                txtRafNo.Text = dr["RafNo"].ToString();
                txtAçıklama.Text = dr["Açıklama"].ToString();
            }
            baglantı.Close();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KitapListele_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAçıklama.Clear();
            txtBarkodNo.Clear();
            txtKitapAdı.Clear();
            txtRafNo.Clear();
            txtSayfaSayısı.Clear();
            txtStokSayısı.Clear();
            txtYayınEvi.Clear();
            txtYazarı.Clear();
            cmbtürü.Text = "";
        }
    }
}
