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
    public partial class EmanetKitapVer : Form
    {
        public EmanetKitapVer()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VRK3DH1\\SQLEXPRESS; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        DataSet daset = new DataSet();
        private void temizle()
        {
            txtadsoyad.Clear();
            txtbarkodno.Clear();
            txtkitapadı.Clear();
            txtkitapsayısı.Clear();
            txtsayfasayısı.Clear();
            txttcara.Clear();
            txttelefon.Clear();
            txtyayınevi.Clear();
            txtyazarı.Clear();
            txtyaş.Clear();
        }
        private void lislete()
        {
           
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from tbl_Sepet",baglantı);
            adtr.Fill(daset,"tbl_Sepet");
            dataGridView1.DataSource = daset.Tables["tbl_Sepet"];
            baglantı.Close();
        }
        private void kitapsayısı()
        {
            //SQL'deki Sepette Kayıtlı Olan KitapSayısını Label'a Yazdırma
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select Sum(KitapSayısı) from tbl_Sepet",baglantı);
            lblsepetkitap.Text = komut.ExecuteScalar().ToString();
            baglantı.Close();
        }

        private void EmanetKitapVer_Load(object sender, EventArgs e)
        {
            lislete();
        }


        private void btnekle_Click(object sender, EventArgs e)
        {
            //                                  SQL'deki Tabloya Ekleme Yapar
            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_Sepet(BarkodNo,KitapAdı,Yazarı,Yayınevi,SayfaSayısı,KitapSayısı,TeslimTarihi,İadeTarihi)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",baglantı);
            ekle.Parameters.AddWithValue("@p1",txtbarkodno.Text);
            ekle.Parameters.AddWithValue("@p2",txtkitapadı.Text);
            ekle.Parameters.AddWithValue("@p3",txtyazarı.Text);
            ekle.Parameters.AddWithValue("@p4",txtyayınevi.Text);
            ekle.Parameters.AddWithValue("@p5",txtsayfasayısı.Text);
            ekle.Parameters.AddWithValue("@p6",int.Parse(txtkitapsayısı.Text));
            ekle.Parameters.AddWithValue("@p7",dtteslimtarihi.Text);
            ekle.Parameters.AddWithValue("@p8",dtiadetarihi.Text);
            ekle.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Kitap Eklendi");
            temizle();

            daset.Tables["tbl_Sepet"].Clear();
            lislete();

            lblkayıtlıkitap.Text = "";
            kitapsayısı();
        }


        private void btnsil_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                //                  DataGrid de Seçilen BarkodNo'su Sütünü SQL'Den Siler  
                baglantı.Open();
                SqlCommand sil = new SqlCommand("Delete From tbl_Sepet where BarkodNo=@p1 ", baglantı);
                sil.Parameters.AddWithValue("@p1",txtbarkodno.Text);
                sil.ExecuteNonQuery();
                baglantı.Close();
                MessageBox.Show("Kitap Silindi");

                daset.Tables["tbl_Sepet"].Clear();
                lislete();

                lblkayıtlıkitap.Text = "";
                kitapsayısı();
            }
        }

        private void btnteslimet_Click(object sender, EventArgs e)
        {//Stoktaki Kitap Ve Emanet Kitap Sayısı
            if (lblsepetkitap.Text != "")
            {
                if (lblkayıtlıkitap.Text == "" && int.Parse(lblsepetkitap.Text) <= 3 || lblkayıtlıkitap.Text!="" && int.Parse(lblkayıtlıkitap.Text)+int.Parse(lblsepetkitap.Text)<=3)
                {
                    if (txttcara.Text!="" && txtadsoyad.Text!="" && txtyaş.Text!="" && txttelefon.Text!="")
                    {
                        for (int i = 0; i <dataGridView1.Rows.Count-1; i++)
                        {
                            baglantı.Open();
                            SqlCommand komut = new SqlCommand("Insert into tbl_EmanetKitap(TC,AdSoyad,Yaş,Telefon,BarkodNo,KitapAdı,Yazarı,Yayınevi,SayfaSayısı,KitapSayısı,TeslimTarihi,İadeTarihi)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",baglantı);
                            komut.Parameters.AddWithValue("@p1",txttcara.Text);
                            komut.Parameters.AddWithValue("@p2",txtadsoyad.Text);
                            komut.Parameters.AddWithValue("@p3",txtyaş.Text);
                            komut.Parameters.AddWithValue("@p4",txttelefon.Text);
                            komut.Parameters.AddWithValue("@p5", dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString());
                            komut.Parameters.AddWithValue("@p6", dataGridView1.Rows[i].Cells["KitapAdı"].Value.ToString());
                            komut.Parameters.AddWithValue("@p7", dataGridView1.Rows[i].Cells["Yazarı"].Value.ToString());
                            komut.Parameters.AddWithValue("@p8", dataGridView1.Rows[i].Cells["Yayınevi"].Value.ToString());
                            komut.Parameters.AddWithValue("@p9", dataGridView1.Rows[i].Cells["SayfaSayısı"].Value.ToString());
                            komut.Parameters.AddWithValue("@p10",int.Parse(dataGridView1.Rows[i].Cells["KitapSayısı"].Value.ToString()));
                            komut.Parameters.AddWithValue("@p11", dataGridView1.Rows[i].Cells["TeslimTarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("@p12", dataGridView1.Rows[i].Cells["İadeTarihi"].Value.ToString());
                            komut.ExecuteNonQuery();

                            SqlCommand komut2 = new SqlCommand("Update tbl_ÜyeBilgi set Okukitapsayısı=Okukitapsayısı+'" + int.Parse(dataGridView1.Rows[i].Cells["KitapSayısı"].Value.ToString()) + "'where TC ='"+txttcara.Text+"'", baglantı);
                            komut2.ExecuteNonQuery();

                            SqlCommand komut3 = new SqlCommand("Update tbl_KitapBilgi set StokSayısı=StokSayısı-'" + int.Parse(dataGridView1.Rows[i].Cells["KitapSayısı"].Value.ToString()) + "'where BarkodNo ='" + dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString() + "'", baglantı);
                            komut3.ExecuteNonQuery();
                            baglantı.Close();
                        }
                        baglantı.Open();
                        SqlCommand komut4 = new SqlCommand("Delete From tbl_Sepet",baglantı);
                        komut4.ExecuteNonQuery();
                        baglantı.Close();
                        MessageBox.Show("Kitap Emanet Edilid");

                        daset.Tables["tbl_Sepet"].Clear();
                        lislete();

                        lblsepetkitap.Text = "";
                        kitapsayısı();
                        lblkayıtlıkitap.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Önce Üye İsmi Seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3 ten Fazla Olamaz!!!");
                }
            }
            else
            {
                MessageBox.Show("Önce Sepete Kitap Ekleyiniz");
            }
        }


        private void txttcara_TextChanged(object sender, EventArgs e)
        {
            //***TC Yazıldığında,O TC ile Veri Tabananındaki Eşleşen Bilgiler,Kendi Araçlarına Dolduruldu*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_ÜyeBilgi where TC like '" + txttcara.Text + "'", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtadsoyad.Text = dr["AdSoyad"].ToString();
                txtyaş.Text = dr["Yaş"].ToString();
                txttelefon.Text = dr["Telefon"].ToString();
            }
            baglantı.Close();

            //SQL'deki Kişiye Kayıtlı Olan KitapSayısını Label'a Yazdırma
            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Select Sum(KitapSayısı) from tbl_EmanetKitap where TC='"+txttcara.Text+"'",baglantı);
            lblkayıtlıkitap.Text = komut2.ExecuteScalar().ToString();
            baglantı.Close();

            if (txttcara.Text=="")
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        
                    }
                }
                lblkayıtlıkitap.Text = "";
            }
        }



        private void txtbarkodno_TextChanged(object sender, EventArgs e)
        {
            //***BarkodNo Yazıldığında,O BarkodNo ile Veri Tabananındaki Eşleşen Bilgiler,Kendi Araçlarına Dolduruldu*******

            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_KitapBilgi where BarkodNo like '" + txtbarkodno.Text + "'", baglantı);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtyazarı.Text = dr["Yazarı"].ToString();
                txtyayınevi.Text = dr["Yayınevi"].ToString();
                txtsayfasayısı.Text = dr["SayfaSayısı"].ToString();
                txtkitapadı.Text = dr["KitapAdı"].ToString();        
            }
            baglantı.Close();
            //Araç Temizlik
            if (txtbarkodno.Text=="")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtkitapsayısı)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //        *****DataGridView'de üzerine çift tıkladığımız sırayı araçlara aktarma*****

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtbarkodno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkitapadı.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtyazarı.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtyayınevi.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsayfasayısı.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtkitapsayısı.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
