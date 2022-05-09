
namespace Sinema_Otomasyonu
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
            this.btnsalonekle = new System.Windows.Forms.Button();
            this.btnfilmekle = new System.Windows.Forms.Button();
            this.btnseansekle = new System.Windows.Forms.Button();
            this.btnseanslistele = new System.Windows.Forms.Button();
            this.btnçıkış = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtsoyad = new System.Windows.Forms.TextBox();
            this.txtad = new System.Windows.Forms.TextBox();
            this.txtkoltukadı = new System.Windows.Forms.TextBox();
            this.cmbücret = new System.Windows.Forms.ComboBox();
            this.cmbfilmseansı = new System.Windows.Forms.ComboBox();
            this.cmbfilmtarihi = new System.Windows.Forms.ComboBox();
            this.cmbsalonadı = new System.Windows.Forms.ComboBox();
            this.cmbfilmadı = new System.Windows.Forms.ComboBox();
            this.btnbiletsat = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnbiletiptal = new System.Windows.Forms.Button();
            this.cmbkoltuknıiptal = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsalonekle
            // 
            this.btnsalonekle.BackColor = System.Drawing.Color.Crimson;
            this.btnsalonekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalonekle.ForeColor = System.Drawing.Color.White;
            this.btnsalonekle.Location = new System.Drawing.Point(20, 48);
            this.btnsalonekle.Name = "btnsalonekle";
            this.btnsalonekle.Size = new System.Drawing.Size(119, 93);
            this.btnsalonekle.TabIndex = 0;
            this.btnsalonekle.Text = "Salon Ekle";
            this.btnsalonekle.UseVisualStyleBackColor = false;
            this.btnsalonekle.Click += new System.EventHandler(this.btnsalonekle_Click);
            // 
            // btnfilmekle
            // 
            this.btnfilmekle.BackColor = System.Drawing.Color.Crimson;
            this.btnfilmekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfilmekle.ForeColor = System.Drawing.Color.White;
            this.btnfilmekle.Location = new System.Drawing.Point(176, 48);
            this.btnfilmekle.Name = "btnfilmekle";
            this.btnfilmekle.Size = new System.Drawing.Size(121, 93);
            this.btnfilmekle.TabIndex = 1;
            this.btnfilmekle.Text = "Film Ekle";
            this.btnfilmekle.UseVisualStyleBackColor = false;
            this.btnfilmekle.Click += new System.EventHandler(this.btnfilmekle_Click);
            // 
            // btnseansekle
            // 
            this.btnseansekle.BackColor = System.Drawing.Color.Crimson;
            this.btnseansekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseansekle.ForeColor = System.Drawing.Color.White;
            this.btnseansekle.Location = new System.Drawing.Point(339, 48);
            this.btnseansekle.Name = "btnseansekle";
            this.btnseansekle.Size = new System.Drawing.Size(122, 93);
            this.btnseansekle.TabIndex = 2;
            this.btnseansekle.Text = "Seans Ekle";
            this.btnseansekle.UseVisualStyleBackColor = false;
            this.btnseansekle.Click += new System.EventHandler(this.btnseansekle_Click);
            // 
            // btnseanslistele
            // 
            this.btnseanslistele.BackColor = System.Drawing.Color.Crimson;
            this.btnseanslistele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseanslistele.ForeColor = System.Drawing.Color.White;
            this.btnseanslistele.Location = new System.Drawing.Point(517, 48);
            this.btnseanslistele.Name = "btnseanslistele";
            this.btnseanslistele.Size = new System.Drawing.Size(126, 93);
            this.btnseanslistele.TabIndex = 3;
            this.btnseanslistele.Text = "Seans Listele";
            this.btnseanslistele.UseVisualStyleBackColor = false;
            this.btnseanslistele.Click += new System.EventHandler(this.btnseanslistele_Click);
            // 
            // btnçıkış
            // 
            this.btnçıkış.BackColor = System.Drawing.Color.Crimson;
            this.btnçıkış.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnçıkış.ForeColor = System.Drawing.Color.White;
            this.btnçıkış.Location = new System.Drawing.Point(865, 44);
            this.btnçıkış.Name = "btnçıkış";
            this.btnçıkış.Size = new System.Drawing.Size(122, 93);
            this.btnçıkış.TabIndex = 4;
            this.btnçıkış.Text = "Çıkış";
            this.btnçıkış.UseVisualStyleBackColor = false;
            this.btnçıkış.Click += new System.EventHandler(this.btnçıkış_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnçıkış);
            this.groupBox1.Controls.Add(this.btnsalonekle);
            this.groupBox1.Controls.Add(this.btnseanslistele);
            this.groupBox1.Controls.Add(this.btnfilmekle);
            this.groupBox1.Controls.Add(this.btnseansekle);
            this.groupBox1.Location = new System.Drawing.Point(57, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 179);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(692, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 93);
            this.button1.TabIndex = 5;
            this.button1.Text = "Satışlar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtsoyad);
            this.groupBox4.Controls.Add(this.txtad);
            this.groupBox4.Controls.Add(this.txtkoltukadı);
            this.groupBox4.Controls.Add(this.cmbücret);
            this.groupBox4.Controls.Add(this.cmbfilmseansı);
            this.groupBox4.Controls.Add(this.cmbfilmtarihi);
            this.groupBox4.Controls.Add(this.cmbsalonadı);
            this.groupBox4.Controls.Add(this.cmbfilmadı);
            this.groupBox4.Controls.Add(this.btnbiletsat);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(1153, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(414, 556);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // txtsoyad
            // 
            this.txtsoyad.Location = new System.Drawing.Point(152, 343);
            this.txtsoyad.Name = "txtsoyad";
            this.txtsoyad.Size = new System.Drawing.Size(240, 31);
            this.txtsoyad.TabIndex = 16;
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(150, 295);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(240, 31);
            this.txtad.TabIndex = 15;
            // 
            // txtkoltukadı
            // 
            this.txtkoltukadı.Enabled = false;
            this.txtkoltukadı.Location = new System.Drawing.Point(151, 243);
            this.txtkoltukadı.Name = "txtkoltukadı";
            this.txtkoltukadı.Size = new System.Drawing.Size(240, 31);
            this.txtkoltukadı.TabIndex = 14;
            // 
            // cmbücret
            // 
            this.cmbücret.FormattingEnabled = true;
            this.cmbücret.Location = new System.Drawing.Point(151, 397);
            this.cmbücret.Name = "cmbücret";
            this.cmbücret.Size = new System.Drawing.Size(241, 33);
            this.cmbücret.TabIndex = 17;
            // 
            // cmbfilmseansı
            // 
            this.cmbfilmseansı.FormattingEnabled = true;
            this.cmbfilmseansı.Location = new System.Drawing.Point(150, 189);
            this.cmbfilmseansı.Name = "cmbfilmseansı";
            this.cmbfilmseansı.Size = new System.Drawing.Size(241, 33);
            this.cmbfilmseansı.Sorted = true;
            this.cmbfilmseansı.TabIndex = 12;
            this.cmbfilmseansı.SelectedIndexChanged += new System.EventHandler(this.cmbfilmseansı_SelectedIndexChanged);
            // 
            // cmbfilmtarihi
            // 
            this.cmbfilmtarihi.FormattingEnabled = true;
            this.cmbfilmtarihi.Location = new System.Drawing.Point(150, 133);
            this.cmbfilmtarihi.Name = "cmbfilmtarihi";
            this.cmbfilmtarihi.Size = new System.Drawing.Size(241, 33);
            this.cmbfilmtarihi.Sorted = true;
            this.cmbfilmtarihi.TabIndex = 11;
            this.cmbfilmtarihi.SelectedIndexChanged += new System.EventHandler(this.cmbfilmtarihi_SelectedIndexChanged);
            // 
            // cmbsalonadı
            // 
            this.cmbsalonadı.FormattingEnabled = true;
            this.cmbsalonadı.Location = new System.Drawing.Point(151, 79);
            this.cmbsalonadı.Name = "cmbsalonadı";
            this.cmbsalonadı.Size = new System.Drawing.Size(241, 33);
            this.cmbsalonadı.Sorted = true;
            this.cmbsalonadı.TabIndex = 10;
            this.cmbsalonadı.SelectedIndexChanged += new System.EventHandler(this.cmbsalonadı_SelectedIndexChanged);
            // 
            // cmbfilmadı
            // 
            this.cmbfilmadı.FormattingEnabled = true;
            this.cmbfilmadı.Location = new System.Drawing.Point(151, 27);
            this.cmbfilmadı.Name = "cmbfilmadı";
            this.cmbfilmadı.Size = new System.Drawing.Size(241, 33);
            this.cmbfilmadı.Sorted = true;
            this.cmbfilmadı.TabIndex = 9;
            this.cmbfilmadı.SelectedIndexChanged += new System.EventHandler(this.cmbfilmadı_SelectedIndexChanged);
            // 
            // btnbiletsat
            // 
            this.btnbiletsat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnbiletsat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbiletsat.Location = new System.Drawing.Point(150, 455);
            this.btnbiletsat.Name = "btnbiletsat";
            this.btnbiletsat.Size = new System.Drawing.Size(240, 61);
            this.btnbiletsat.TabIndex = 8;
            this.btnbiletsat.Text = "Bilet Sat";
            this.btnbiletsat.UseVisualStyleBackColor = false;
            this.btnbiletsat.Click += new System.EventHandler(this.btnbiletsat_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(75, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 25);
            this.label12.TabIndex = 7;
            this.label12.Text = "Ücret:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(65, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 25);
            this.label13.TabIndex = 6;
            this.label13.Text = "Soyad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(100, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(33, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Koltuk No:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(14, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "Film Seansı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(26, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Film Tarihi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(34, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Salon Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(55, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Film Adı";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnbiletiptal);
            this.groupBox5.Controls.Add(this.cmbkoltuknıiptal);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(1153, 592);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 190);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // btnbiletiptal
            // 
            this.btnbiletiptal.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnbiletiptal.ForeColor = System.Drawing.Color.White;
            this.btnbiletiptal.Location = new System.Drawing.Point(152, 97);
            this.btnbiletiptal.Name = "btnbiletiptal";
            this.btnbiletiptal.Size = new System.Drawing.Size(238, 66);
            this.btnbiletiptal.TabIndex = 12;
            this.btnbiletiptal.Text = "Bilet İptal";
            this.btnbiletiptal.UseVisualStyleBackColor = false;
            this.btnbiletiptal.Click += new System.EventHandler(this.btnbiletiptal_Click);
            // 
            // cmbkoltuknıiptal
            // 
            this.cmbkoltuknıiptal.FormattingEnabled = true;
            this.cmbkoltuknıiptal.Location = new System.Drawing.Point(152, 42);
            this.cmbkoltuknıiptal.Name = "cmbkoltuknıiptal";
            this.cmbkoltuknıiptal.Size = new System.Drawing.Size(241, 33);
            this.cmbkoltuknıiptal.Sorted = true;
            this.cmbkoltuknıiptal.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(35, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Koltuk No:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Location = new System.Drawing.Point(57, 846);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1510, 89);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1243, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "BOŞ KOLTUKLAR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "DOLU KOLTUKLAR";
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(1158, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 53);
            this.button7.TabIndex = 1;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Maroon;
            this.button6.Location = new System.Drawing.Point(98, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 64);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(808, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "F İ L M       A F İ Ş İ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 550);
            this.label2.TabIndex = 0;
            this.label2.Text = "P\r\n\r\n\r\n\r\n\r\nE\r\n\r\n\r\n\r\n\r\nR\r\n\r\n\r\n\r\n\r\nD\r\n\r\n\r\n\r\n\r\nE\r\n\r\n";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(57, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 538);
            this.panel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1618, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 163);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(512, 1034);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(618, 10);
            this.panel4.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(680, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 538);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Location = new System.Drawing.Point(1016, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1640, 1065);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsalonekle;
        private System.Windows.Forms.Button btnfilmekle;
        private System.Windows.Forms.Button btnseansekle;
        private System.Windows.Forms.Button btnseanslistele;
        private System.Windows.Forms.Button btnçıkış;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsoyad;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtkoltukadı;
        private System.Windows.Forms.ComboBox cmbücret;
        private System.Windows.Forms.ComboBox cmbfilmseansı;
        private System.Windows.Forms.ComboBox cmbfilmtarihi;
        private System.Windows.Forms.ComboBox cmbsalonadı;
        private System.Windows.Forms.ComboBox cmbfilmadı;
        private System.Windows.Forms.Button btnbiletsat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnbiletiptal;
        private System.Windows.Forms.ComboBox cmbkoltuknıiptal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}

