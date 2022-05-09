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
    public partial class ModelEkle : Form
    {
        public ModelEkle()
        {
            InitializeComponent();
        }
        //SQL Bağlantısı
        SqlConnection baglantı = new SqlConnection("Data Source = DESKTOP-VRK3DH1\\SQLEXPRESS;Initial Catalog=TelefonSatışOtomasyou; Integrated Security = True");

        private void ModelEkle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'telefonSatışOtomasyouDataSet.tbl_Marka' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_MarkaTableAdapter.Fill(this.telefonSatışOtomasyouDataSet.tbl_Marka);

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //Model Ekleme
            baglantı.Open();
            SqlCommand ekle = new SqlCommand("Insert into tbl_Model values ('"+cmbmarka.SelectedValue+"','"+txtmodel.Text+"')", baglantı);
            ekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show(" İlgili Markaya Model Eklendi");
        }
    }
}
