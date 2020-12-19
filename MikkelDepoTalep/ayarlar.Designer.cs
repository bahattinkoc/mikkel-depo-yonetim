namespace MikkelDepoTalep
{
    partial class ayarlar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numTalepMiktar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numTeslimTarihGun = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numAltSinir = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTalepMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeslimTarihGun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltSinir)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numTalepMiktar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numTeslimTarihGun);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numAltSinir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Talep İşlemleri";
            // 
            // numTalepMiktar
            // 
            this.numTalepMiktar.Location = new System.Drawing.Point(10, 106);
            this.numTalepMiktar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numTalepMiktar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTalepMiktar.Name = "numTalepMiktar";
            this.numTalepMiktar.Size = new System.Drawing.Size(130, 26);
            this.numTalepMiktar.TabIndex = 5;
            this.numTalepMiktar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTalepMiktar.ValueChanged += new System.EventHandler(this.numAltSinir_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Talep edilen ürün miktarı";
            // 
            // numTeslimTarihGun
            // 
            this.numTeslimTarihGun.Location = new System.Drawing.Point(10, 158);
            this.numTeslimTarihGun.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numTeslimTarihGun.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTeslimTarihGun.Name = "numTeslimTarihGun";
            this.numTeslimTarihGun.Size = new System.Drawing.Size(130, 26);
            this.numTeslimTarihGun.TabIndex = 3;
            this.numTeslimTarihGun.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTeslimTarihGun.ValueChanged += new System.EventHandler(this.numAltSinir_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Talep teslim tarihi süresi (gün)";
            // 
            // numAltSinir
            // 
            this.numAltSinir.Location = new System.Drawing.Point(10, 54);
            this.numAltSinir.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numAltSinir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAltSinir.Name = "numAltSinir";
            this.numAltSinir.Size = new System.Drawing.Size(130, 26);
            this.numAltSinir.TabIndex = 1;
            this.numAltSinir.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAltSinir.ValueChanged += new System.EventHandler(this.numAltSinir_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Talep oluşturmak için gereken ürün adet alt sınırı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 225);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(359, 37);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSifirla
            // 
            this.btnSifirla.Location = new System.Drawing.Point(12, 268);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(359, 37);
            this.btnSifirla.TabIndex = 2;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = true;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.BackColor = System.Drawing.SystemColors.Control;
            this.lblDurum.ForeColor = System.Drawing.Color.Green;
            this.lblDurum.Location = new System.Drawing.Point(18, 308);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 20);
            this.lblDurum.TabIndex = 6;
            // 
            // ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 337);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.btnSifirla);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ayarlar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.ayarlar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTalepMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeslimTarihGun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltSinir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAltSinir;
        private System.Windows.Forms.NumericUpDown numTeslimTarihGun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.NumericUpDown numTalepMiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDurum;
    }
}