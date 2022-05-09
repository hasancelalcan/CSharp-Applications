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
    public partial class ÜyeListele : Form
    {
        public ÜyeListele()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");

        private void listele()
        {
            //                          SQL'deki Tabloyu Listeleme
            baglantı.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From tbl_ÜyeBilgi", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglantı.Close();

        }
        private void ÜyeListele_Load(object sender, EventArgs e)
        {
            listele();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            //                          SQL'deki Verileri TC'yi Baz Alarak Günceller
            baglantı.Open();
            SqlCommand güncelle = new SqlCommand("Update tbl_ÜyeBilgi Set AdSoyad=@p1,Yaş=@p2,Cinsiyet=@p3,Telefon=@p4,Adres=@p5,EMail=@p6,Okukitapsayısı=@p7 where TC=@p8", baglantı);
            güncelle.Parameters.AddWithValue("@p8", txttc.Text);
            güncelle.Parameters.AddWithValue("@p1",tctadsoyad.Text);
            güncelle.Parameters.AddWithValue("@p2", txtyaş.Text);
            güncelle.Parameters.AddWithValue("@p3", cmbcinsiyet.Text);
            güncelle.Parameters.AddWithValue("@p4", txttelefon.Text);
            güncelle.Parameters.AddWithValue("@p5", txtadres.Text);
            güncelle.Parameters.AddWithValue("@p6", txtemail.Text);
            güncelle.Parameters.AddWithValue("@p7", txtkitapsayısı.Text);
            güncelle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Üye Güncellendi");
            listele();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?","Sil",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog==DialogResult.Yes)
            {
                //                      SQL'deki Veriyi TC'yi Baz Alarak Siler
                baglantı.Open();
                SqlCommand sil = new SqlCommand("Delete From tbl_ÜyeBilgi where TC=@p1", baglantı);
                sil.Parameters.AddWithValue("@p1", txttc.Text);
                sil.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Üye Silindi");
                listele();
            }
          
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //        *****DataGridView'de üzerine çift tıkladığımız sırayı araçlara aktarma*****

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txttc.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            tctadsoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtyaş.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbcinsiyet.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txttelefon.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtadres.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtkitapsayısı.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //             TC'yi Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_ÜyeBilgi Where TC Like '%" + textBox1.Text + "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }



        private void txttc_TextChanged(object sender, EventArgs e)
        {
            //***TC Yazıldığında,O TC ile Veri Tabananındaki Eşleşen Bilgiler,Kendi Araçlarına Dolduruldu*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_ÜyeBilgi where TC like '" + txttc.Text + "'", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                tctadsoyad.Text = dr["AdSoyad"].ToString();
                txtyaş.Text = dr["Yaş"].ToString();
                cmbcinsiyet.Text = dr["Cinsiyet"].ToString();
                txttelefon.Text= dr["Telefon"].ToString();
                txtadres.Text = dr["Adres"].ToString();
                txtemail.Text = dr["EMail"].ToString();
                txtkitapsayısı.Text = dr["Okukitapsayısı"].ToString();
            }
            baglantı.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtadres.Clear();
            txtemail.Clear();
            txtkitapsayısı.Clear();
            txttc.Clear();
            txttelefon.Clear();
            txtyaş.Clear();
            tctadsoyad.Clear();
            cmbcinsiyet.Text = "";

        }
    }
}
