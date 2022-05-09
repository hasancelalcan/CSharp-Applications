using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TeknikServis_Otomasyonu.Iletisim
{
    public partial class FrmMailGönder : Form
    {
        public FrmMailGönder()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            txtAlici.Text = "";
            txtKonu.Text = "";
            richIcerik.Text = "";
        }

        private void btnGönder_Click(object sender, EventArgs e)
        {
            //Mail Gönderme

            MailMessage mail = new MailMessage();

            string Gönderici = "hasancllcn@gmail.com";
            string Sifre = "hasan.celal01";
            string Alici = txtAlici.Text;
            string Konu = txtKonu.Text;
            string Icerik = richIcerik.Text;

            mail.From=(new MailAddress(Gönderici));
            mail.To.Add(Alici);
            mail.Subject = Konu;
            mail.Body = Icerik;
            mail.IsBodyHtml = true;

            // Hata Vericek Düzeltmek İçin Google Hesabınızı Yönetin > Güvenlik > Daha Az Güvenli Uyg. Erişimi > Aç
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials = new NetworkCredential(Gönderici, Sifre);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            MessageBox.Show("Mail Gönderildi");

        }
    }
}
