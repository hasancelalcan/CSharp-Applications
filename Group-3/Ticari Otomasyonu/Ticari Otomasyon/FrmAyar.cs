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
    public partial class FrmAyar : Form
    {
        public FrmAyar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //                                  Veri Listeleme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Admin", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtKullanıcıAdı.Text = "";
            txtSifre.Text = "";
            txtSifre.Properties.UseSystemPasswordChar=false;
        }

        private void FrmAyar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (btnGüncelle.Text=="Kaydet")
            {
                //                                      Veri Ekleme

                SqlCommand komut = new SqlCommand("Insert into tbl_Admin values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanıcıAdı.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Eklendi");
                listele();
                temizle();
            }

            if (btnGüncelle.Text=="Güncelle")
            {
                //                                      Veri Güncelleme

                SqlCommand komut1 = new SqlCommand("Update  tbl_Admin Set  Sifre=@p1 Where KullanıcıAdı=@p2", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut1.Parameters.AddWithValue("@p2", txtKullanıcıAdı.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Güncellendi");
                listele();
                temizle();
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //                                   Grid'den Araçlara Taşıma

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtKullanıcıAdı.Text = dr["KullanıcıAdı"].ToString();
                txtSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Silmek İstiyor Musunuz MesajKutusu
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kayıdı Silmek İstiyor Musunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                                              Veri Silme
            if (dialog == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From tbl_Admin Where KullanıcıAdı=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", txtKullanıcıAdı.Text);
                sil.ExecuteNonQuery();

                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Silindi");
                listele();
                temizle();
            }
        }

        private void txtKullanıcıAdı_EditValueChanged(object sender, EventArgs e)
        {
            if (txtKullanıcıAdı.Text !="")
            {
                btnGüncelle.Text = "Güncelle";
            }
            else
            {
                btnGüncelle.Text = "Kaydet";
            }
        }
    }
}