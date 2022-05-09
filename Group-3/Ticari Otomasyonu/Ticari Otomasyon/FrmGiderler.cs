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

namespace Ticari_Otomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                      Veri Listeleme

            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Giderler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtDoğalGaz.Text = "";
            txtEkstra.Text = "";
            txtElektrk.Text = "";
            txtID.Text = "";
            txtMaaş.Text = "";
            txtSu.Text = "";
            txtİnternet.Text = "";
            cmbAy.Text = "";
            cmbYıl.Text = "";
            rchNotlar.Text = "";
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //                                                          Veri Ekleme

            SqlCommand ekle = new SqlCommand("Insert into tbl_Giderler (Ay,Yıl,Elektrik,Su,DogalGaz,Internet,Maaslar,Ekstra,Notlar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1", cmbAy.Text);
            ekle.Parameters.AddWithValue("@p2", cmbYıl.Text);
            ekle.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrk.Text));
            ekle.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            ekle.Parameters.AddWithValue("@p5", decimal.Parse(txtDoğalGaz.Text));
            ekle.Parameters.AddWithValue("@p6", decimal.Parse(txtİnternet.Text));
            ekle.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaş.Text));
            ekle.Parameters.AddWithValue("@p8", decimal.Parse(txtElektrk.Text));
            ekle.Parameters.AddWithValue("@p9",rchNotlar.Text);
            ekle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Gider Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From tbl_Giderler Where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtID.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Gider Silindi");
                listele();
                temizle();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //                                                          Veri Güncelleme

            SqlCommand güncelle = new SqlCommand("Update  tbl_Giderler Set Ay=@p1,Yıl=@p2,Elektrik=@p3,Su=@p4,DogalGaz=@p5,Internet=@p6,Maaslar=@p7,Ekstra=@p8,Notlar=@p9 Where ID=@p10",bgl.baglanti());
            güncelle.Parameters.AddWithValue("@p1", cmbAy.Text);
            güncelle.Parameters.AddWithValue("@p2", cmbYıl.Text);
            güncelle.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrk.Text));
            güncelle.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            güncelle.Parameters.AddWithValue("@p5", decimal.Parse(txtDoğalGaz.Text));
            güncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtİnternet.Text));
            güncelle.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaş.Text));
            güncelle.Parameters.AddWithValue("@p8", decimal.Parse(txtElektrk.Text));
            güncelle.Parameters.AddWithValue("@p9", rchNotlar.Text);
            güncelle.Parameters.AddWithValue("@p10",txtID.Text);
            güncelle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Gider Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                  Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                cmbAy.Text = dr["Ay"].ToString();
                cmbYıl.Text = dr["Yıl"].ToString();
                txtDoğalGaz.Text = dr["DogalGaz"].ToString();
                txtEkstra.Text = dr["Ekstra"].ToString();
                txtElektrk.Text = dr["Elektrik"].ToString();
                txtMaaş.Text = dr["Maaslar"].ToString();
                txtSu.Text = dr["Su"].ToString();
                txtİnternet.Text = dr["Internet"].ToString();
                rchNotlar.Text = dr["Notlar"].ToString();
              
            }
        }

    }
}
