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
    public partial class Filmekle : Form
    {
        public Filmekle()
        {
            InitializeComponent();
        }

        //Dataset Adresi
        // SinemaTableAdapters.tbl_FilmBilgiTableAdapter film = new SinemaTableAdapters.tbl_FilmBilgiTableAdapter();
        SinemaTableAdapters.tbl_FilmBilgiTableAdapter film = new SinemaTableAdapters.tbl_FilmBilgiTableAdapter();

        private void temizle()
        {
            txtfilmadı.Clear();
            txtsüre.Clear();
            txtyapımyılı.Clear();
            txtyönetmen.Clear();
            cmbfilmtürü.Text = "";
           
        }
        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            //DataSet Kısmında Oluşturulan INSERT Sorgusu(FilmEkle) İle Ekleme
            try
            {
                //film.FilmEkle(txtfilmadı.Text, txtyönetmen.Text, cmbfilmtürü.Text, txtsüre.Text, dateTimePicker1.Text, txtyapımyılı.Text, pictureBox1.ImageLocation);

                film.FilmEkle(txtfilmadı.Text, txtyönetmen.Text, cmbfilmtürü.Text, txtsüre.Text, dateTimePicker1.Text, txtyapımyılı.Text, pictureBox1.ImageLocation);
                MessageBox.Show("Film Bilgileri Eklendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Bu Film Daha Önce Eklendi","Uyarı");
            }
            temizle();

        }

        private void btnafişseç_Click(object sender, EventArgs e)
        {
            //PC'den PictureBox'a Görsel Seçmek İçin
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

       
    }
}
