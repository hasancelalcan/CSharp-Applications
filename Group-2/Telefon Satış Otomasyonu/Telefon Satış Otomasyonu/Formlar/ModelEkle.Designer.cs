
namespace Telefon_Satış_Otomasyonu.Formlar
{
    partial class ModelEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtmodel = new System.Windows.Forms.TextBox();
            this.btnekle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbmarka = new System.Windows.Forms.ComboBox();
            this.tblMarkaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telefonSatışOtomasyouDataSet = new Telefon_Satış_Otomasyonu.TelefonSatışOtomasyouDataSet();
            this.tbl_MarkaTableAdapter = new Telefon_Satış_Otomasyonu.TelefonSatışOtomasyouDataSetTableAdapters.tbl_MarkaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblMarkaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonSatışOtomasyouDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(88, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Model:";
            // 
            // txtmodel
            // 
            this.txtmodel.Location = new System.Drawing.Point(184, 172);
            this.txtmodel.Name = "txtmodel";
            this.txtmodel.Size = new System.Drawing.Size(213, 31);
            this.txtmodel.TabIndex = 4;
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.Crimson;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Location = new System.Drawing.Point(194, 247);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(188, 49);
            this.btnekle.TabIndex = 3;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(88, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Marka:";
            // 
            // cmbmarka
            // 
            this.cmbmarka.DataSource = this.tblMarkaBindingSource;
            this.cmbmarka.DisplayMember = "Marka";
            this.cmbmarka.FormattingEnabled = true;
            this.cmbmarka.Location = new System.Drawing.Point(184, 106);
            this.cmbmarka.Name = "cmbmarka";
            this.cmbmarka.Size = new System.Drawing.Size(213, 33);
            this.cmbmarka.TabIndex = 8;
            this.cmbmarka.ValueMember = "ID";
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
            // tbl_MarkaTableAdapter
            // 
            this.tbl_MarkaTableAdapter.ClearBeforeFill = true;
            // 
            // ModelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(527, 418);
            this.Controls.Add(this.cmbmarka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmodel);
            this.Controls.Add(this.btnekle);
            this.Name = "ModelEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModelEkle";
            this.Load += new System.EventHandler(this.ModelEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblMarkaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telefonSatışOtomasyouDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmodel;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbmarka;
        private TelefonSatışOtomasyouDataSet telefonSatışOtomasyouDataSet;
        private System.Windows.Forms.BindingSource tblMarkaBindingSource;
        private TelefonSatışOtomasyouDataSetTableAdapters.tbl_MarkaTableAdapter tbl_MarkaTableAdapter;
    }
}