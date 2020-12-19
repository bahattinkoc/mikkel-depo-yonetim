namespace MikkelDepoTalep
{
    partial class talepEkleSilGuncelleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTedarikciTel = new System.Windows.Forms.TextBox();
            this.txtTedarikciShow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarkodShow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrunBarkod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numAdet = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTeslimTarih = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGüncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Talep İşlemleri Formu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tedarikçi Telefon";
            // 
            // txtTedarikciTel
            // 
            this.txtTedarikciTel.Location = new System.Drawing.Point(12, 78);
            this.txtTedarikciTel.MaxLength = 11;
            this.txtTedarikciTel.Name = "txtTedarikciTel";
            this.txtTedarikciTel.Size = new System.Drawing.Size(155, 26);
            this.txtTedarikciTel.TabIndex = 2;
            this.txtTedarikciTel.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtTedarikciShow
            // 
            this.txtTedarikciShow.Enabled = false;
            this.txtTedarikciShow.Location = new System.Drawing.Point(173, 78);
            this.txtTedarikciShow.Name = "txtTedarikciShow";
            this.txtTedarikciShow.Size = new System.Drawing.Size(155, 26);
            this.txtTedarikciShow.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tedarikçi İsim";
            // 
            // txtBarkodShow
            // 
            this.txtBarkodShow.Enabled = false;
            this.txtBarkodShow.Location = new System.Drawing.Point(173, 130);
            this.txtBarkodShow.Name = "txtBarkodShow";
            this.txtBarkodShow.Size = new System.Drawing.Size(155, 26);
            this.txtBarkodShow.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ürün Adı";
            // 
            // txtUrunBarkod
            // 
            this.txtUrunBarkod.Location = new System.Drawing.Point(12, 130);
            this.txtUrunBarkod.MaxLength = 20;
            this.txtUrunBarkod.Name = "txtUrunBarkod";
            this.txtUrunBarkod.Size = new System.Drawing.Size(155, 26);
            this.txtUrunBarkod.TabIndex = 6;
            this.txtUrunBarkod.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ürün Barkod";
            // 
            // numAdet
            // 
            this.numAdet.Location = new System.Drawing.Point(12, 182);
            this.numAdet.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numAdet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAdet.Name = "numAdet";
            this.numAdet.Size = new System.Drawing.Size(99, 26);
            this.numAdet.TabIndex = 9;
            this.numAdet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Adet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Teslim Tarihi";
            // 
            // dateTeslimTarih
            // 
            this.dateTeslimTarih.Location = new System.Drawing.Point(12, 234);
            this.dateTeslimTarih.Name = "dateTeslimTarih";
            this.dateTeslimTarih.Size = new System.Drawing.Size(316, 26);
            this.dateTeslimTarih.TabIndex = 12;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 266);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(316, 38);
            this.btnKaydet.TabIndex = 13;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Location = new System.Drawing.Point(12, 310);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(316, 38);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.Enabled = false;
            this.btnGüncelle.Location = new System.Drawing.Point(12, 354);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.Size = new System.Drawing.Size(316, 38);
            this.btnGüncelle.TabIndex = 15;
            this.btnGüncelle.Text = "Güncelle";
            this.btnGüncelle.UseVisualStyleBackColor = true;
            this.btnGüncelle.Click += new System.EventHandler(this.btnGüncelle_Click);
            // 
            // talepEkleSilGuncelleForm
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 401);
            this.Controls.Add(this.btnGüncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dateTeslimTarih);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numAdet);
            this.Controls.Add(this.txtBarkodShow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUrunBarkod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTedarikciShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTedarikciTel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "talepEkleSilGuncelleForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talep İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTedarikciTel;
        private System.Windows.Forms.TextBox txtTedarikciShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarkodShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrunBarkod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAdet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTeslimTarih;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGüncelle;
    }
}