namespace bulanık_mantik
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hesapla = new System.Windows.Forms.Button();
            this.sicaklik = new System.Windows.Forms.TextBox();
            this.nem = new System.Windows.Forms.TextBox();
            this.sicaklikLabel = new System.Windows.Forms.Label();
            this.nemLabel = new System.Windows.Forms.Label();
            this.maksimum = new System.Windows.Forms.RadioButton();
            this.agirlikliOrtalama = new System.Windows.Forms.RadioButton();
            this.om = new System.Windows.Forms.ComboBox();
            this.ve = new System.Windows.Forms.RadioButton();
            this.veya = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hesapla
            // 
            this.hesapla.Location = new System.Drawing.Point(210, 138);
            this.hesapla.Name = "hesapla";
            this.hesapla.Size = new System.Drawing.Size(81, 27);
            this.hesapla.TabIndex = 0;
            this.hesapla.Text = "Hesapla";
            this.hesapla.UseVisualStyleBackColor = true;
            this.hesapla.Click += new System.EventHandler(this.hesapla_Click);
            // 
            // sicaklik
            // 
            this.sicaklik.Location = new System.Drawing.Point(12, 39);
            this.sicaklik.Name = "sicaklik";
            this.sicaklik.Size = new System.Drawing.Size(81, 20);
            this.sicaklik.TabIndex = 1;
            this.sicaklik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sicaklik_KeyPress);
            // 
            // nem
            // 
            this.nem.Location = new System.Drawing.Point(210, 39);
            this.nem.Name = "nem";
            this.nem.Size = new System.Drawing.Size(81, 20);
            this.nem.TabIndex = 2;
            this.nem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nem_KeyPress);
            // 
            // sicaklikLabel
            // 
            this.sicaklikLabel.AutoSize = true;
            this.sicaklikLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sicaklikLabel.Location = new System.Drawing.Point(9, 9);
            this.sicaklikLabel.Name = "sicaklikLabel";
            this.sicaklikLabel.Size = new System.Drawing.Size(78, 13);
            this.sicaklikLabel.TabIndex = 3;
            this.sicaklikLabel.Text = "Sıcaklık Değeri";
            // 
            // nemLabel
            // 
            this.nemLabel.AutoSize = true;
            this.nemLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nemLabel.Location = new System.Drawing.Point(207, 9);
            this.nemLabel.Name = "nemLabel";
            this.nemLabel.Size = new System.Drawing.Size(63, 13);
            this.nemLabel.TabIndex = 4;
            this.nemLabel.Text = "Nem Değeri";
            // 
            // maksimum
            // 
            this.maksimum.AutoSize = true;
            this.maksimum.Location = new System.Drawing.Point(4, 24);
            this.maksimum.Name = "maksimum";
            this.maksimum.Size = new System.Drawing.Size(107, 17);
            this.maksimum.TabIndex = 7;
            this.maksimum.TabStop = true;
            this.maksimum.Text = "Maksimum Üyelik";
            this.maksimum.UseVisualStyleBackColor = true;
            this.maksimum.CheckedChanged += new System.EventHandler(this.maksimum_CheckedChanged);
            // 
            // agirlikliOrtalama
            // 
            this.agirlikliOrtalama.AutoSize = true;
            this.agirlikliOrtalama.Location = new System.Drawing.Point(4, 7);
            this.agirlikliOrtalama.Name = "agirlikliOrtalama";
            this.agirlikliOrtalama.Size = new System.Drawing.Size(102, 17);
            this.agirlikliOrtalama.TabIndex = 8;
            this.agirlikliOrtalama.TabStop = true;
            this.agirlikliOrtalama.Text = "Ağırlıklı Ortalama";
            this.agirlikliOrtalama.UseVisualStyleBackColor = true;
            this.agirlikliOrtalama.CheckedChanged += new System.EventHandler(this.agirlikliOrtalama_CheckedChanged);
            // 
            // om
            // 
            this.om.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.om.Enabled = false;
            this.om.FormattingEnabled = true;
            this.om.Location = new System.Drawing.Point(12, 111);
            this.om.Name = "om";
            this.om.Size = new System.Drawing.Size(102, 21);
            this.om.TabIndex = 9;
            // 
            // ve
            // 
            this.ve.AutoSize = true;
            this.ve.Enabled = false;
            this.ve.Location = new System.Drawing.Point(6, 7);
            this.ve.Name = "ve";
            this.ve.Size = new System.Drawing.Size(39, 17);
            this.ve.TabIndex = 5;
            this.ve.TabStop = true;
            this.ve.Text = "VE";
            this.ve.UseVisualStyleBackColor = true;
            // 
            // veya
            // 
            this.veya.AutoSize = true;
            this.veya.Enabled = false;
            this.veya.Location = new System.Drawing.Point(6, 24);
            this.veya.Name = "veya";
            this.veya.Size = new System.Drawing.Size(53, 17);
            this.veya.TabIndex = 6;
            this.veya.TabStop = true;
            this.veya.Text = "VEYA";
            this.veya.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.veya);
            this.groupBox1.Controls.Add(this.ve);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(210, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(60, 47);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.agirlikliOrtalama);
            this.groupBox2.Controls.Add(this.maksimum);
            this.groupBox2.Location = new System.Drawing.Point(12, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 47);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(303, 177);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.om);
            this.Controls.Add(this.nemLabel);
            this.Controls.Add(this.sicaklikLabel);
            this.Controls.Add(this.nem);
            this.Controls.Add(this.sicaklik);
            this.Controls.Add(this.hesapla);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(319, 216);
            this.MinimumSize = new System.Drawing.Size(319, 216);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sera Otomasyon";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hesapla;
        private System.Windows.Forms.TextBox sicaklik;
        private System.Windows.Forms.TextBox nem;
        private System.Windows.Forms.Label sicaklikLabel;
        private System.Windows.Forms.Label nemLabel;
        private System.Windows.Forms.RadioButton maksimum;
        private System.Windows.Forms.RadioButton agirlikliOrtalama;
        private System.Windows.Forms.ComboBox om;
        private System.Windows.Forms.RadioButton ve;
        private System.Windows.Forms.RadioButton veya;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

