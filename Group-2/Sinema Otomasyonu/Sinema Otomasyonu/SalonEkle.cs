using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Otomasyonu
{
    public partial class SalonEkle : Form
    {
        public SalonEkle()
        {
            InitializeComponent();
        }
        //DataSet Adresi
        SinemaTableAdapters.tbl_SalonBilgiTableAdapter salon = new SinemaTableAdapters.tbl_SalonBilgiTableAdapter();
        private void btnekle_Click(object sender, EventArgs e)
        {
            //DataSet Kısmında Oluşturulan INSERT Sorgusu(SalonEkle) İle Ekleme

            try
            {
                salon.SalonEkle(textBox1.Text.ToString());
                MessageBox.Show("Salon Eklendi", "Kayıt");
            }
            catch (Exception)
            {

                MessageBox.Show("Aynı Salonu Daha Önce Eklediniz !!!");
            }
            textBox1.Text = "";
        }

        private void SalonEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
