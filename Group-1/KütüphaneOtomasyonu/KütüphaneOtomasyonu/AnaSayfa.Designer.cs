
namespace KütüphaneOtomasyonu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnÜyeListele = new System.Windows.Forms.Button();
            this.btnÜyeEkle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKitapListele = new System.Windows.Forms.Button();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnemanetkitapiade = new System.Windows.Forms.Button();
            this.btnemanetlistele = new System.Windows.Forms.Button();
            this.btnEmanetver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnÜyeListele);
            this.groupBox1.Controls.Add(this.btnÜyeEkle);
            this.groupBox1.Location = new System.Drawing.Point(63, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üye İşlemleri";
            // 
            // btnÜyeListele
            // 
            this.btnÜyeListele.BackColor = System.Drawing.Color.Purple;
            this.btnÜyeListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnÜyeListele.ForeColor = System.Drawing.Color.White;
            this.btnÜyeListele.Location = new System.Drawing.Point(270, 43);
            this.btnÜyeListele.Name = "btnÜyeListele";
            this.btnÜyeListele.Size = new System.Drawing.Size(163, 57);
            this.btnÜyeListele.TabIndex = 1;
            this.btnÜyeListele.Text = "Üye Listele";
            this.btnÜyeListele.UseVisualStyleBackColor = false;
            this.btnÜyeListele.Click += new System.EventHandler(this.btnÜyeListele_Click);
            // 
            // btnÜyeEkle
            // 
            this.btnÜyeEkle.BackColor = System.Drawing.Color.DarkGreen;
            this.btnÜyeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnÜyeEkle.ForeColor = System.Drawing.Color.White;
            this.btnÜyeEkle.Location = new System.Drawing.Point(50, 43);
            this.btnÜyeEkle.Name = "btnÜyeEkle";
            this.btnÜyeEkle.Size = new System.Drawing.Size(163, 57);
            this.btnÜyeEkle.TabIndex = 0;
            this.btnÜyeEkle.Text = "Üye Ekle";
            this.btnÜyeEkle.UseVisualStyleBackColor = false;
            this.btnÜyeEkle.Click += new System.EventHandler(this.btnÜyeEkle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnKitapListele);
            this.groupBox3.Controls.Add(this.btnKitapEkle);
            this.groupBox3.Location = new System.Drawing.Point(63, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 139);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kitap İşlemşeri";
            // 
            // btnKitapListele
            // 
            this.btnKitapListele.BackColor = System.Drawing.Color.Purple;
            this.btnKitapListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapListele.ForeColor = System.Drawing.Color.White;
            this.btnKitapListele.Location = new System.Drawing.Point(272, 43);
            this.btnKitapListele.Name = "btnKitapListele";
            this.btnKitapListele.Size = new System.Drawing.Size(161, 57);
            this.btnKitapListele.TabIndex = 1;
            this.btnKitapListele.Text = "Kitap Listele";
            this.btnKitapListele.UseVisualStyleBackColor = false;
            this.btnKitapListele.Click += new System.EventHandler(this.btnKitapListele_Click);
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.BackColor = System.Drawing.Color.Green;
            this.btnKitapEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapEkle.ForeColor = System.Drawing.Color.White;
            this.btnKitapEkle.Location = new System.Drawing.Point(50, 43);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(159, 57);
            this.btnKitapEkle.TabIndex = 0;
            this.btnKitapEkle.Text = "Kitap Ekle";
            this.btnKitapEkle.UseVisualStyleBackColor = false;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnemanetkitapiade);
            this.groupBox4.Controls.Add(this.btnemanetlistele);
            this.groupBox4.Controls.Add(this.btnEmanetver);
            this.groupBox4.Location = new System.Drawing.Point(63, 366);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(491, 351);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Emanet Kitap İşlemleri";
            // 
            // btnemanetkitapiade
            // 
            this.btnemanetkitapiade.BackColor = System.Drawing.Color.Crimson;
            this.btnemanetkitapiade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnemanetkitapiade.ForeColor = System.Drawing.Color.White;
            this.btnemanetkitapiade.Location = new System.Drawing.Point(35, 227);
            this.btnemanetkitapiade.Name = "btnemanetkitapiade";
            this.btnemanetkitapiade.Size = new System.Drawing.Size(247, 68);
            this.btnemanetkitapiade.TabIndex = 2;
            this.btnemanetkitapiade.Text = "Emanet Kitap İade";
            this.btnemanetkitapiade.UseVisualStyleBackColor = false;
            this.btnemanetkitapiade.Click += new System.EventHandler(this.btnemanetkitapiade_Click);
            // 
            // btnemanetlistele
            // 
            this.btnemanetlistele.BackColor = System.Drawing.Color.Purple;
            this.btnemanetlistele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnemanetlistele.ForeColor = System.Drawing.Color.White;
            this.btnemanetlistele.Location = new System.Drawing.Point(205, 137);
            this.btnemanetlistele.Name = "btnemanetlistele";
            this.btnemanetlistele.Size = new System.Drawing.Size(247, 65);
            this.btnemanetlistele.TabIndex = 1;
            this.btnemanetlistele.Text = "Emanet Kitap Listele";
            this.btnemanetlistele.UseVisualStyleBackColor = false;
            this.btnemanetlistele.Click += new System.EventHandler(this.btnemanetlistele_Click);
            // 
            // btnEmanetver
            // 
            this.btnEmanetver.BackColor = System.Drawing.Color.Green;
            this.btnEmanetver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmanetver.ForeColor = System.Drawing.Color.White;
            this.btnEmanetver.Location = new System.Drawing.Point(35, 44);
            this.btnEmanetver.Name = "btnEmanetver";
            this.btnEmanetver.Size = new System.Drawing.Size(247, 65);
            this.btnEmanetver.TabIndex = 0;
            this.btnEmanetver.Text = "Emanet Kitap Verme";
            this.btnEmanetver.UseVisualStyleBackColor = false;
            this.btnEmanetver.Click += new System.EventHandler(this.btnEmanetver_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(238, 751);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 10);
            this.panel1.TabIndex = 4;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(604, 799);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnÜyeListele;
        private System.Windows.Forms.Button btnÜyeEkle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKitapListele;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnemanetkitapiade;
        private System.Windows.Forms.Button btnemanetlistele;
        private System.Windows.Forms.Button btnEmanetver;
        private System.Windows.Forms.Panel panel1;
    }
}

