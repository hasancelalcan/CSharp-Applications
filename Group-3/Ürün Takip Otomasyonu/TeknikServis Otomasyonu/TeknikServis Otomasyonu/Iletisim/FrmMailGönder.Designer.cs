
namespace TeknikServis_Otomasyonu.Iletisim
{
    partial class FrmMailGönder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMailGönder));
            this.btnGönder = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlici = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKonu = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richIcerik = new System.Windows.Forms.RichTextBox();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGönder
            // 
            this.btnGönder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnGönder.Location = new System.Drawing.Point(285, 627);
            this.btnGönder.Name = "btnGönder";
            this.btnGönder.Size = new System.Drawing.Size(218, 56);
            this.btnGönder.TabIndex = 3;
            this.btnGönder.Text = "Gönder";
            this.btnGönder.Click += new System.EventHandler(this.btnGönder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(131, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mail Gönderme Paneli";
            // 
            // txtAlici
            // 
            this.txtAlici.Location = new System.Drawing.Point(201, 207);
            this.txtAlici.Name = "txtAlici";
            this.txtAlici.Size = new System.Drawing.Size(404, 40);
            this.txtAlici.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alıcı:";
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(201, 274);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(404, 40);
            this.txtKonu.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Konu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "İçerik";
            // 
            // richIcerik
            // 
            this.richIcerik.Location = new System.Drawing.Point(201, 363);
            this.richIcerik.Name = "richIcerik";
            this.richIcerik.Size = new System.Drawing.Size(404, 212);
            this.richIcerik.TabIndex = 10;
            this.richIcerik.Text = "";
            // 
            // btnSil
            // 
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(303, 727);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(180, 50);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Temizle";
            this.btnSil.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(303, 880);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 10);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(303, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 10);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(752, 372);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 56);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(12, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 38);
            this.panel4.TabIndex = 15;
            // 
            // FrmMailGönder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(774, 902);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.richIcerik);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKonu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlici);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGönder);
            this.Controls.Add(this.label2);
            this.Name = "FrmMailGönder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMailGönder";
            ((System.ComponentModel.ISupportInitialize)(this.txtAlici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGönder;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtAlici;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtKonu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richIcerik;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}