
namespace Telefon_Satış_Otomasyonu
{
    partial class TelefonEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbmarka = new System.Windows.Forms.ComboBox();
            this.tblMarkaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telefonSatışOtomasyouDataSet = new Telefon_Satış_Otomasyonu.TelefonSatışOtomasyouDataSet();
            this.cmbmodel = new System.Windows.Forms.ComboBox();
            this.fKtblModeltblMarkaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtserino = new System.Windows.Forms.TextBox();
            this.txtimei = new System.Windows.Forms.TextBox();
            this.dtüretim = new System.Windows.Forms.DateTimePicker();
            this.dtgeliş = new System.Windows.Forms.DateTimePicker();
            this.txtalışfiyatı = new System.Windows.Forms.TextBox();
            this.txtKDV = new System.Windows.Forms.TextBox();
            this.txtİşlemci = new System.Windows.Forms.TextBox();
            this.txtişletimsist = new System.Windows.Forms.TextBox();
            this.txthafıza = new System.Windows.Forms.TextBox();
            this.txtçözünürlük = new System.Windows.Forms.TextBox();
            this.txtrenk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnekle = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnresimseç = new System.Windows.Forms.Button();
            this.tbl_MarkaTableAdapter = new Telefon_Satış_Otomasyonu.TelefonSatışOtomasyouDataSetTableAdapters.tbl_MarkaTableAdapter();
            this.tbl_ModelTableAdapter = new Telefon_Satış_Otomasyonu.TelefonSatışOtomasyouDataSetTableAdapters.tbl_ModelTableAdapter();
            this.label13 = new System.Windows.Forms.Label();
            this.txtsatış = new System.Windows.Forms.TextBox();
            this.Temizle = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtmiktar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tblMarkaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonSatışOtomasyouDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKtblModeltblMarkaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbmarka
            // 
            this.cmbmarka.DataSource = this.tblMarkaBindingSource;
            this.cmbmarka.DisplayMember = "Marka";
            this.cmbmarka.FormattingEnabled = true;
            this.cmbmarka.Location = new System.Drawing.Point(187, 95);
            this.cmbmarka.Name = "cmbmarka";
            this.cmbmarka.Size = new System.Drawing.Size(211, 33);
            this.cmbmarka.TabIndex = 1;
            // 
            // tblMarkaBindingSource
            // 
            this.tblMarkaBindingSource.DataMember = "tbl_Marka";
            this.tblMarkaBindingSource.DataSource = this.telefonSatışOtomasyouDataSet;
            // 
            // telefonSatışOtomasyouDataSet
            // 
            this.telefonSatışOtomasyouDataSet.DataSetName = "TelefonSatışOtomasyouDataSet";
            this.telefonSatışOtomasyouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbmodel
            // 
            this.cmbmodel.DataSource = this.fKtblModeltblMarkaBindingSource;
            this.cmbmodel.DisplayMember = "Model";
            this.cmbmodel.FormattingEnabled = true;
            this.cmbmodel.Location = new System.Drawing.Point(187, 147);
            this.cmbmodel.Name = "cmbmodel";
            this.cmbmodel.Size = new System.Drawing.Size(211, 33);
            this.cmbmodel.TabIndex = 2;
            // 
            // fKtblModeltblMarkaBindingSource
            // 
            this.fKtblModeltblMarkaBindingSource.DataMember = "FK_tbl_Model_tbl_Marka";
            this.fKtblModeltblMarkaBindingSource.DataSource = this.tblMarkaBindingSource;
            // 
            // txtserino
            // 
            this.txtserino.Location = new System.Drawing.Point(187, 199);
            this.txtserino.Name = "txtserino";
            this.txtserino.Size = new System.Drawing.Size(211, 31);
            this.txtserino.TabIndex = 3;
            // 
            // txtimei
            // 
            this.txtimei.Location = new System.Drawing.Point(187, 249);
            this.txtimei.Name = "txtimei";
            this.txtimei.Size = new System.Drawing.Size(211, 31);
            this.txtimei.TabIndex = 4;
            // 
            // dtüretim
            // 
            this.dtüretim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtüretim.Location = new System.Drawing.Point(187, 299);
            this.dtüretim.Name = "dtüretim";
            this.dtüretim.Size = new System.Drawing.Size(211, 31);
            this.dtüretim.TabIndex = 5;
            // 
            // dtgeliş
            // 
            this.dtgeliş.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtgeliş.Location = new System.Drawing.Point(187, 349);
            this.dtgeliş.Name = "dtgeliş";
            this.dtgeliş.Size = new System.Drawing.Size(211, 31);
            this.dtgeliş.TabIndex = 6;
            // 
            // txtalışfiyatı
            // 
            this.txtalışfiyatı.Location = new System.Drawing.Point(187, 399);
            this.txtalışfiyatı.Name = "txtalışfiyatı";
            this.txtalışfiyatı.Size = new System.Drawing.Size(211, 31);
            this.txtalışfiyatı.TabIndex = 7;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(187, 499);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Size = new System.Drawing.Size(211, 31);
            this.txtKDV.TabIndex = 9;
            // 
            // txtİşlemci
            // 
            this.txtİşlemci.Location = new System.Drawing.Point(633, 144);
            this.txtİşlemci.Name = "txtİşlemci";
            this.txtİşlemci.Size = new System.Drawing.Size(211, 31);
            this.txtİşlemci.TabIndex = 10;
            // 
            // txtişletimsist
            // 
            this.txtişletimsist.Location = new System.Drawing.Point(633, 198);
            this.txtişletimsist.Name = "txtişletimsist";
            this.txtişletimsist.Size = new System.Drawing.Size(211, 31);
            this.txtişletimsist.TabIndex = 11;
            // 
            // txthafıza
            // 
            this.txthafıza.Location = new System.Drawing.Point(633, 252);
            this.txthafıza.Name = "txthafıza";
            this.txthafıza.Size = new System.Drawing.Size(211, 31);
            this.txthafıza.TabIndex = 12;
            // 
            // txtçözünürlük
            // 
            this.txtçözünürlük.Location = new System.Drawing.Point(633, 306);
            this.txtçözünürlük.Name = "txtçözünürlük";
            this.txtçözünürlük.Size = new System.Drawing.Size(211, 31);
            this.txtçözünürlük.TabIndex = 13;
            // 
            // txtrenk
            // 
            this.txtrenk.Location = new System.Drawing.Point(633, 360);
            this.txtrenk.Name = "txtrenk";
            this.txtrenk.Size = new System.Drawing.Size(211, 31);
            this.txtrenk.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(95, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(90, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(84, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "SeriNo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(83, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "İmeiNo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(106, 499);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "KDV:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(56, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Alış Fiyatı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(40, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Geliş Tarihi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(33, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Üretim Tarihi:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(486, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Çözünürlük:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(534, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Hafıza:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(458, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "İşletim Sistemi:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(529, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 25);
            this.label12.TabIndex = 18;
            this.label12.Text = "İşlemci:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(545, 362);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 25);
            this.label16.TabIndex = 22;
            this.label16.Text = "Renk:";
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Location = new System.Drawing.Point(621, 418);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(223, 46);
            this.btnekle.TabIndex = 14;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btniptal
            // 
            this.btniptal.BackColor = System.Drawing.Color.Crimson;
            this.btniptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniptal.ForeColor = System.Drawing.Color.White;
            this.btniptal.Location = new System.Drawing.Point(994, 490);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(137, 48);
            this.btniptal.TabIndex = 25;
            this.btniptal.Text = "İptal";
            this.btniptal.UseVisualStyleBackColor = false;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(929, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnresimseç
            // 
            this.btnresimseç.BackColor = System.Drawing.Color.Indigo;
            this.btnresimseç.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnresimseç.ForeColor = System.Drawing.Color.White;
            this.btnresimseç.Location = new System.Drawing.Point(969, 416);
            this.btnresimseç.Name = "btnresimseç";
            this.btnresimseç.Size = new System.Drawing.Size(178, 50);
            this.btnresimseç.TabIndex = 25;
            this.btnresimseç.Text = "Resim Seç";
            this.btnresimseç.UseVisualStyleBackColor = false;
            this.btnresimseç.Click += new System.EventHandler(this.btnresimseç_Click);
            // 
            // tbl_MarkaTableAdapter
            // 
            this.tbl_MarkaTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_ModelTableAdapter
            // 
            this.tbl_ModelTableAdapter.ClearBeforeFill = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(40, 449);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 25);
            this.label13.TabIndex = 28;
            this.label13.Text = "Satış Fiyatı:";
            // 
            // txtsatış
            // 
            this.txtsatış.Location = new System.Drawing.Point(187, 449);
            this.txtsatış.Name = "txtsatış";
            this.txtsatış.Size = new System.Drawing.Size(211, 31);
            this.txtsatış.TabIndex = 8;
            // 
            // Temizle
            // 
            this.Temizle.BackColor = System.Drawing.Color.Purple;
            this.Temizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Temizle.ForeColor = System.Drawing.Color.White;
            this.Temizle.Location = new System.Drawing.Point(641, 487);
            this.Temizle.Name = "Temizle";
            this.Temizle.Size = new System.Drawing.Size(182, 48);
            this.Temizle.TabIndex = 29;
            this.Temizle.Text = "Temizle";
            this.Temizle.UseVisualStyleBackColor = false;
            this.Temizle.Click += new System.EventHandler(this.Temizle_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(536, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 25);
            this.label14.TabIndex = 31;
            this.label14.Text = "Miktar:";
            // 
            // txtmiktar
            // 
            this.txtmiktar.Location = new System.Drawing.Point(633, 97);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(211, 31);
            this.txtmiktar.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btniptal);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbmarka);
            this.panel1.Controls.Add(this.txtmiktar);
            this.panel1.Controls.Add(this.cmbmodel);
            this.panel1.Controls.Add(this.Temizle);
            this.panel1.Controls.Add(this.txtserino);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtimei);
            this.panel1.Controls.Add(this.txtsatış);
            this.panel1.Controls.Add(this.dtüretim);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dtgeliş);
            this.panel1.Controls.Add(this.btnresimseç);
            this.panel1.Controls.Add(this.txtalışfiyatı);
            this.panel1.Controls.Add(this.txtKDV);
            this.panel1.Controls.Add(this.btnekle);
            this.panel1.Controls.Add(this.txtişletimsist);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtİşlemci);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtrenk);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txthafıza);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtçözünürlük);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 669);
            this.panel1.TabIndex = 32;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TelefonEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1264, 669);
            this.Controls.Add(this.panel1);
            this.Name = "TelefonEkle";
            this.Text = "TelefonEkle";
            this.Load += new System.EventHandler(this.TelefonEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblMarkaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonSatışOtomasyouDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKtblModeltblMarkaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbmarka;
        private System.Windows.Forms.ComboBox cmbmodel;
        private System.Windows.Forms.TextBox txtserino;
        private System.Windows.Forms.TextBox txtimei;
        private System.Windows.Forms.DateTimePicker dtüretim;
        private System.Windows.Forms.DateTimePicker dtgeliş;
        private System.Windows.Forms.TextBox txtalışfiyatı;
        private System.Windows.Forms.TextBox txtKDV;
        private System.Windows.Forms.TextBox txtİşlemci;
        private System.Windows.Forms.TextBox txtişletimsist;
        private System.Windows.Forms.TextBox txthafıza;
        private System.Windows.Forms.TextBox txtçözünürlük;
        private System.Windows.Forms.TextBox txtrenk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Button btniptal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnresimseç;
        private TelefonSatışOtomasyouDataSet telefonSatışOtomasyouDataSet;
        private System.Windows.Forms.BindingSource tblMarkaBindingSource;
        private TelefonSatışOtomasyouDataSetTableAdapters.tbl_MarkaTableAdapter tbl_MarkaTableAdapter;
        private System.Windows.Forms.BindingSource fKtblModeltblMarkaBindingSource;
        private TelefonSatışOtomasyouDataSetTableAdapters.tbl_ModelTableAdapter tbl_ModelTableAdapter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtsatış;
        private System.Windows.Forms.Button Temizle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtmiktar;
        private System.Windows.Forms.Panel panel1;
    }
}