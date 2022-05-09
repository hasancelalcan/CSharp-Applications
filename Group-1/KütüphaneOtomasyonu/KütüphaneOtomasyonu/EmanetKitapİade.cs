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
    public partial class EmanetKitapİade : Form
    {
        public EmanetKitapİade()
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

        private void EmanetKitapİade_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbarkodara_TextChanged(object sender, EventArgs e)
        {
            //             BarkodNo'yu Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_EmanetKitap Where BarkodNo Like '%" + txtbarkodara.Text + "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
            if (txtbarkodara.Text == "")
            {
                daset.Tables["tbl_EmanetKitap"].Clear();
                EmanetListele();
            }
        }

        private void txttcara_TextChanged(object sender, EventArgs e)
        {
            //             TC'yi Araçlardan Alıp SQL'de Arayıp Eşleşenleri Tabloda Listeledi
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter ara = new SqlDataAdapter("Select *From tbl_EmanetKitap Where TC Like '%" + txttcara.Text + "%'", baglantı);
            ara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
            if (txttcara.Text=="")
            {
                daset.Tables["tbl_EmanetKitap"].Clear();
                EmanetListele();
            }
        }

        private void btnteslimal_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Delete From tbl_EmanetKitap where TC=@TC And BarkodNo=@BarkodNo",baglantı);
            komut.Parameters.AddWithValue("@TC",dataGridView1.CurrentRow.Cells["TC"].Value.ToString());
            komut.Parameters.AddWithValue("@BarkodNo", dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString());
            komut.ExecuteNonQuery();
            baglantı.Close();

            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Update tbl_KitapBilgi Set StokSayısı=StokSayısı+'"+dataGridView1.CurrentRow.Cells["KitapSayısı"].Value.ToString()+"'where BarkodNo=@BarkodNo ",baglantı);
            komut2.Parameters.AddWithValue("@BarkodNo", dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString());
            komut2.ExecuteNonQuery();
            baglantı.Close();

            MessageBox.Show("Kitap İade Alındı");
            daset.Tables["tbl_EmanetKitap"].Clear();
            EmanetListele();
        }
    }
}
