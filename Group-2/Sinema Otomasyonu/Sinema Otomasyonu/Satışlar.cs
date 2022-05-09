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
    public partial class Satışlar : Form
    {
        public Satışlar()
        {
            InitializeComponent();
        }

        //DataSet Adresi
        SinemaTableAdapters.tbl_SatışBilgiTableAdapter satılisteleme = new SinemaTableAdapters.tbl_SatışBilgiTableAdapter();

        private void ToplamÜcretHesapla()
        {
            int ücrettoplamı = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ücrettoplamı += Convert.ToInt32(dataGridView1.Rows[i].Cells["Ücret"].Value);
            }
            label1.Text = "Toplam Satış = " + ücrettoplamı + "TL";
        }

        private void Satışlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satılisteleme.TariheGöreListele2(dateTimePicker1.Text);
            ToplamÜcretHesapla();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satılisteleme.TariheGöreListele2(dateTimePicker1.Text);
            ToplamÜcretHesapla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Toplam Ücret Hesaplama
            dataGridView1.DataSource = satılisteleme.SatışListesi2();

            ToplamÜcretHesapla();
        }
    }
}
