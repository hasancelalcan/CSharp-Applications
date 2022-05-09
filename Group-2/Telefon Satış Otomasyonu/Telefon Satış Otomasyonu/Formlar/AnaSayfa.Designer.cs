
namespace Telefon_Satış_Otomasyonu
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModelEkle = new System.Windows.Forms.Button();
            this.btnSatışlar = new System.Windows.Forms.Button();
            this.btnMarkaEkle = new System.Windows.Forms.Button();
            this.btnKullanıcıListele = new System.Windows.Forms.Button();
            this.btnSatış = new System.Windows.Forms.Button();
            this.btnKullanıcıEkle = new System.Windows.Forms.Button();
            this.btnMüşteriListele = new System.Windows.Forms.Button();
            this.btnTelefonEkle = new System.Windows.Forms.Button();
            this.btnTelefonListele = new System.Windows.Forms.Button();
            this.btnMüşteriEkle = new System.Windows.Forms.Button();
            this.panelsayfalar = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnModelEkle);
            this.panel1.Controls.Add(this.btnSatışlar);
            this.panel1.Controls.Add(this.btnMarkaEkle);
            this.panel1.Controls.Add(this.btnKullanıcıListele);
            this.panel1.Controls.Add(this.btnSatış);
            this.panel1.Controls.Add(this.btnKullanıcıEkle);
            this.panel1.Controls.Add(this.btnMüşteriListele);
            this.panel1.Controls.Add(this.btnTelefonEkle);
            this.panel1.Controls.Add(this.btnTelefonListele);
            this.panel1.Controls.Add(this.btnMüşteriEkle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1771, 156);
            this.panel1.TabIndex = 0;
            // 
            // btnModelEkle
            // 
            this.btnModelEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnModelEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnModelEkle.Location = new System.Drawing.Point(1198, 31);
            this.btnModelEkle.Name = "btnModelEkle";
            this.btnModelEkle.Size = new System.Drawing.Size(148, 89);
            this.btnModelEkle.TabIndex = 9;
            this.btnModelEkle.Text = "Model Ekle";
            this.btnModelEkle.UseVisualStyleBackColor = false;
            this.btnModelEkle.Click += new System.EventHandler(this.btnModelEkle_Click);
            // 
            // btnSatışlar
            // 
            this.btnSatışlar.BackColor = System.Drawing.Color.Transparent;
            this.btnSatışlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatışlar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSatışlar.Location = new System.Drawing.Point(1549, 31);
            this.btnSatışlar.Name = "btnSatışlar";
            this.btnSatışlar.Size = new System.Drawing.Size(152, 89);
            this.btnSatışlar.TabIndex = 7;
            this.btnSatışlar.Text = "Satışlar";
            this.btnSatışlar.UseVisualStyleBackColor = false;
            this.btnSatışlar.Click += new System.EventHandler(this.btnSatışlar_Click);
            // 
            // btnMarkaEkle
            // 
            this.btnMarkaEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnMarkaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkaEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMarkaEkle.Location = new System.Drawing.Point(1036, 31);
            this.btnMarkaEkle.Name = "btnMarkaEkle";
            this.btnMarkaEkle.Size = new System.Drawing.Size(140, 89);
            this.btnMarkaEkle.TabIndex = 8;
            this.btnMarkaEkle.Text = "Marka Ekle";
            this.btnMarkaEkle.UseVisualStyleBackColor = false;
            this.btnMarkaEkle.Click += new System.EventHandler(this.btnMarkaEkle_Click);
            // 
            // btnKullanıcıListele
            // 
            this.btnKullanıcıListele.BackColor = System.Drawing.Color.Transparent;
            this.btnKullanıcıListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanıcıListele.ForeColor = System.Drawing.Color.DarkRed;
            this.btnKullanıcıListele.Location = new System.Drawing.Point(532, 33);
            this.btnKullanıcıListele.Name = "btnKullanıcıListele";
            this.btnKullanıcıListele.Size = new System.Drawing.Size(146, 91);
            this.btnKullanıcıListele.TabIndex = 3;
            this.btnKullanıcıListele.Text = "Kullanıcı Listele";
            this.btnKullanıcıListele.UseVisualStyleBackColor = false;
            this.btnKullanıcıListele.Click += new System.EventHandler(this.btnKullanıcıListele_Click);
            // 
            // btnSatış
            // 
            this.btnSatış.BackColor = System.Drawing.Color.Transparent;
            this.btnSatış.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatış.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSatış.Location = new System.Drawing.Point(1368, 31);
            this.btnSatış.Name = "btnSatış";
            this.btnSatış.Size = new System.Drawing.Size(143, 89);
            this.btnSatış.TabIndex = 6;
            this.btnSatış.Text = "Satış Yap";
            this.btnSatış.UseVisualStyleBackColor = false;
            this.btnSatış.Click += new System.EventHandler(this.btnSatış_Click);
            // 
            // btnKullanıcıEkle
            // 
            this.btnKullanıcıEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnKullanıcıEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanıcıEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnKullanıcıEkle.Location = new System.Drawing.Point(364, 33);
            this.btnKullanıcıEkle.Name = "btnKullanıcıEkle";
            this.btnKullanıcıEkle.Size = new System.Drawing.Size(146, 91);
            this.btnKullanıcıEkle.TabIndex = 2;
            this.btnKullanıcıEkle.Text = "Kullanıcı Ekle";
            this.btnKullanıcıEkle.UseVisualStyleBackColor = false;
            this.btnKullanıcıEkle.Click += new System.EventHandler(this.btnKullanıcıEkle_Click);
            // 
            // btnMüşteriListele
            // 
            this.btnMüşteriListele.BackColor = System.Drawing.Color.Transparent;
            this.btnMüşteriListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMüşteriListele.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMüşteriListele.Location = new System.Drawing.Point(868, 31);
            this.btnMüşteriListele.Name = "btnMüşteriListele";
            this.btnMüşteriListele.Size = new System.Drawing.Size(146, 91);
            this.btnMüşteriListele.TabIndex = 5;
            this.btnMüşteriListele.Text = "Müşteri Listele";
            this.btnMüşteriListele.UseVisualStyleBackColor = false;
            this.btnMüşteriListele.Click += new System.EventHandler(this.btnMüşteriListele_Click);
            // 
            // btnTelefonEkle
            // 
            this.btnTelefonEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnTelefonEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefonEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnTelefonEkle.Location = new System.Drawing.Point(23, 33);
            this.btnTelefonEkle.Name = "btnTelefonEkle";
            this.btnTelefonEkle.Size = new System.Drawing.Size(146, 91);
            this.btnTelefonEkle.TabIndex = 1;
            this.btnTelefonEkle.Text = "Telefon Ekle";
            this.btnTelefonEkle.UseVisualStyleBackColor = false;
            this.btnTelefonEkle.Click += new System.EventHandler(this.btnTelefonListele_Click);
            // 
            // btnTelefonListele
            // 
            this.btnTelefonListele.BackColor = System.Drawing.Color.Transparent;
            this.btnTelefonListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefonListele.ForeColor = System.Drawing.Color.DarkRed;
            this.btnTelefonListele.Location = new System.Drawing.Point(196, 34);
            this.btnTelefonListele.Name = "btnTelefonListele";
            this.btnTelefonListele.Size = new System.Drawing.Size(146, 91);
            this.btnTelefonListele.TabIndex = 1;
            this.btnTelefonListele.Text = "Telefon Listele";
            this.btnTelefonListele.UseVisualStyleBackColor = false;
            this.btnTelefonListele.Click += new System.EventHandler(this.btnTelefonListele_Click);
            // 
            // btnMüşteriEkle
            // 
            this.btnMüşteriEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnMüşteriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMüşteriEkle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMüşteriEkle.Location = new System.Drawing.Point(700, 31);
            this.btnMüşteriEkle.Name = "btnMüşteriEkle";
            this.btnMüşteriEkle.Size = new System.Drawing.Size(146, 91);
            this.btnMüşteriEkle.TabIndex = 4;
            this.btnMüşteriEkle.Text = "Müşteri Ekle";
            this.btnMüşteriEkle.UseVisualStyleBackColor = false;
            this.btnMüşteriEkle.Click += new System.EventHandler(this.btnMüşteriEkle_Click);
            // 
            // panelsayfalar
            // 
            this.panelsayfalar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelsayfalar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelsayfalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelsayfalar.Location = new System.Drawing.Point(0, 156);
            this.panelsayfalar.Name = "panelsayfalar";
            this.panelsayfalar.Size = new System.Drawing.Size(1771, 905);
            this.panelsayfalar.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1771, 1061);
            this.Controls.Add(this.panelsayfalar);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSatışlar;
        private System.Windows.Forms.Button btnKullanıcıListele;
        private System.Windows.Forms.Button btnSatış;
        private System.Windows.Forms.Button btnKullanıcıEkle;
        private System.Windows.Forms.Button btnMüşteriListele;
        private System.Windows.Forms.Button btnTelefonListele;
        private System.Windows.Forms.Button btnMüşteriEkle;
        private System.Windows.Forms.Panel panelsayfalar;
        private System.Windows.Forms.Button btnModelEkle;
        private System.Windows.Forms.Button btnMarkaEkle;
        private System.Windows.Forms.Button btnTelefonEkle;
    }
}

