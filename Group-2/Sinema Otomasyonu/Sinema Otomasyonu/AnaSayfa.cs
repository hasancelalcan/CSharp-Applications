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
namespace Sinema_Otomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = Sinema Otomasyonu; Integrated Security = True");


        private void BoşKoltuklar()
        {
            //Buton Oluşturma
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.ForeColor = Color.Blue;
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }

        private void ComboBoxaFilmVeSalonÇek(ComboBox combo,string sql1,string sql2)
        {
            //ComboBox'a Eleman Çekme
            baglantı.Open();
            SqlCommand komut = new SqlCommand(sql1, baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglantı.Close();
        }
       
        private void FilmAfişiGöster()
        {
            //Film Seçildiğinde SQL'den Film Afişini Çeker
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_FilmBilgi where FilmAdı='" + cmbfilmadı.SelectedItem + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                pictureBox1.ImageLocation = read["Resim"].ToString();
            }
            baglantı.Close();
        }

        private void YenidenRenklendirme()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void DoluKoltuklar()
        {
            //VeriTabanındaki Dolu Koltukların Butonunu Kırmızı Yapar
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_SatışBilgi where FilmAdı='"+cmbfilmadı.SelectedItem+"' and SalonAdı='"+cmbsalonadı.SelectedItem+"' and Tarih='"+cmbfilmtarihi.SelectedItem+"' and Saat='"+cmbfilmseansı.SelectedItem+"'",baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["KoltukNo"].ToString()==item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                    }
                }
            }
            baglantı.Close();



        }

        private void ComboBoxaDoluKoltukÇek()
        {
            cmbkoltuknıiptal.Items.Clear();
            cmbkoltuknıiptal.Text = "";

            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor==Color.Red)
                    {
                        cmbkoltuknıiptal.Items.Add(item.Text);
                    }
                }
            }
        }

        private void ComboBoxaFilmTarihiGetir()
        {
            //Film Adı Ve Salona Göre Film Tarihi Getirme
            cmbfilmtarihi.Text = "";
            cmbfilmseansı.Text = "";
            cmbfilmtarihi.Items.Clear();
            cmbfilmseansı.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_SeansBilgi where FilmAdı='" + cmbfilmadı.SelectedItem + "' and SalonAdı='" + cmbsalonadı.SelectedItem + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!cmbfilmtarihi.Items.Contains(read["Tarih"].ToString()))
                    {
                        cmbfilmtarihi.Items.Add(read["Tarih"].ToString());
                    }
                    
                }
                
            }
            baglantı.Close();
        }

        private void ComboBoxaFilmSeansıGetir()
        {
            //Film Adı,Salon Ve Tarihine Göre Seans Getirme
            cmbfilmseansı.Text = "";
            cmbfilmseansı.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select *From tbl_SeansBilgi where FilmAdı='" + cmbfilmadı.SelectedItem + "' and SalonAdı='" + cmbsalonadı.SelectedItem + "' and Tarih='"+cmbfilmtarihi.SelectedItem+"' ", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(read["Seans"].ToString()) > DateTime.Parse(DateTime.Now.ToLongTimeString()))
                    {
                        cmbfilmseansı.Items.Add(read["Seans"].ToString());
                    }            

                }
                else if (DateTime.Parse(read["Tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {                   
                        cmbfilmseansı.Items.Add(read["Seans"].ToString());                 
                }

            }
            baglantı.Close();
        }

        private void Temizle()
        {
            cmbfilmadı.Text = "";
            cmbfilmseansı.Text = "";
            cmbfilmtarihi.Text = "";
            cmbkoltuknıiptal.Text = "";
            cmbsalonadı.Text = "";
            cmbücret.Text = "";
            txtad.Clear();
            txtkoltukadı.Clear();
            txtsoyad.Clear();
        }


        int sayac = 0;
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            BoşKoltuklar();
            //ComboBox Doldurma
            ComboBoxaFilmVeSalonÇek(cmbfilmadı,"Select *From tbl_FilmBilgi ","FilmAdı");

            ComboBoxaFilmVeSalonÇek(cmbsalonadı, "Select *From tbl_SalonBilgi", "SalonAdı");
        }
       
        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor==Color.White)
            {
                txtkoltukadı.Text = b.Text;
            }
        }
        private void cmbfilmadı_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            FilmAfişiGöster();
            YenidenRenklendirme();
            ComboBoxaDoluKoltukÇek();
 
        }

        //Dataset Adresi
        SinemaTableAdapters.tbl_SatışBilgiTableAdapter satis = new SinemaTableAdapters.tbl_SatışBilgiTableAdapter();

        private void btnbiletsat_Click(object sender, EventArgs e)
        {
            //Yapılan Satışları SQL'e Ekleme ---(DataSet Insert Sorgusu(SatışYap))

            if (txtkoltukadı.Text!="")
            {
                try
                {   //DataSet    
                    satis.SatışYap(txtkoltukadı.Text, cmbsalonadı.Text, cmbfilmadı.Text, cmbfilmtarihi.Text, cmbfilmseansı.Text, txtad.Text, txtsoyad.Text, cmbücret.Text, DateTime.Now.ToString());

                    YenidenRenklendirme();
                    DoluKoltuklar();
                    ComboBoxaDoluKoltukÇek();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu !!!"+hata.Message);
                } 
            }
            else if (true)
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız !!");
            }
            Temizle();
          
        }

        private void cmbsalonadı_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxaFilmTarihiGetir();
        }

        private void cmbfilmtarihi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxaFilmSeansıGetir();
        }

        private void cmbfilmseansı_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendirme();
            DoluKoltuklar();
            ComboBoxaDoluKoltukÇek();

        }

        private void btnbiletiptal_Click(object sender, EventArgs e)
        {
            //KoltukNo'ya Göre Bilet İptali

            if (cmbkoltuknıiptal.Text!="")
            {
                try
                {
                    satis.Satışİptal(cmbfilmadı.Text,cmbsalonadı.Text, cmbfilmtarihi.Text, cmbfilmseansı.Text, cmbkoltuknıiptal.Text);
                    YenidenRenklendirme();
                    DoluKoltuklar();
                    ComboBoxaDoluKoltukÇek();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata Oluştu"+hata.Message,"Uyarı");
                }
            }
            else
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız");
            }
            
        }


        private void btnsalonekle_Click(object sender, EventArgs e)
        {
            SalonEkle fr = new SalonEkle();
            fr.ShowDialog();
        }
        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            Filmekle fr = new Filmekle();
            fr.ShowDialog();
        }
        private void btnseansekle_Click(object sender, EventArgs e)
        {
            SeansEkle fr = new SeansEkle();
            fr.ShowDialog();
        }
        private void btnseanslistele_Click(object sender, EventArgs e)
        {
            SeansListele fr = new SeansListele();
            fr.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Satışlar fr = new Satışlar();
            fr.ShowDialog();
        }
        private void btnçıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa fr = new AnaSayfa();
            fr.Show();
            this.Hide();
           
        }

       
    }
}
