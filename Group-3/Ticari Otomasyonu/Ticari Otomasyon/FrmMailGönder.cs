using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Mail Gönderme Kütüphaneleri
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMailGönder : Form
    {
        public FrmMailGönder()
        {
            InitializeComponent();
        }

        MailMessage eposta = new MailMessage();
        void MailGönder()
        {
            //                                    Mail Gönderme 

            eposta.From = new MailAddress("hasancelalcn@outlook.com");          // Gönderen
            eposta.To.Add(txtMail.Text.ToString());                             // Alıcının Yazılı Olduğu araç
            eposta.Subject = txtKonu.Text.ToString();                           // Konunun Yazılı Olduğu Araç
            eposta.Body = rchMesaj.Text.ToString();                             // Mesajın Yazılı Olduğu Araç

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("hasancelalcn@outlook.com","hasan.celal01");    // Gönderen Mailin Bilgileri
            smtp.Host = "smtp.live.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;

            smtp.Send(eposta);

            MessageBox.Show("Mail Gönderildi");

        }

        public String Mail;
        private void FrmMailGönder_Load(object sender, EventArgs e)
        {
            txtMail.Text = Mail;    // Rehber Formundan Mail Adresi Çekme
        }
            
        private void btnGönder_Click(object sender, EventArgs e)
        {
            //                                    Mail Gönderme 
            MailGönder();
        }


        
        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
          
        }
    }
}
