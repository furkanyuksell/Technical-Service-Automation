namespace TeknikServis
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.KullaniciAdi = new System.Windows.Forms.TextBox();
            this.Sifre = new System.Windows.Forms.TextBox();
            this.Giris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KullaniciAdi
            // 
            this.KullaniciAdi.BackColor = System.Drawing.SystemColors.Menu;
            this.KullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KullaniciAdi.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.KullaniciAdi.Location = new System.Drawing.Point(517, 78);
            this.KullaniciAdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KullaniciAdi.Multiline = true;
            this.KullaniciAdi.Name = "KullaniciAdi";
            this.KullaniciAdi.Size = new System.Drawing.Size(337, 36);
            this.KullaniciAdi.TabIndex = 1;
            this.KullaniciAdi.Text = "Kullanıcı Adı";
            this.KullaniciAdi.Enter += new System.EventHandler(this.textBox2_Enter);
            this.KullaniciAdi.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // Sifre
            // 
            this.Sifre.BackColor = System.Drawing.SystemColors.Menu;
            this.Sifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Sifre.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Sifre.Location = new System.Drawing.Point(517, 138);
            this.Sifre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Sifre.Multiline = true;
            this.Sifre.Name = "Sifre";
            this.Sifre.Size = new System.Drawing.Size(337, 36);
            this.Sifre.TabIndex = 2;
            this.Sifre.Text = "Şifre";
            this.Sifre.Enter += new System.EventHandler(this.textBox1_Enter);
            this.Sifre.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Giris
            // 
            this.Giris.BackColor = System.Drawing.Color.Transparent;
            this.Giris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Giris.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Giris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Giris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Giris.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Giris.Image = ((System.Drawing.Image)(resources.GetObject("Giris.Image")));
            this.Giris.Location = new System.Drawing.Point(588, 198);
            this.Giris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Giris.Name = "Giris";
            this.Giris.Size = new System.Drawing.Size(191, 47);
            this.Giris.TabIndex = 3;
            this.Giris.Text = "Giriş Yap";
            this.Giris.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Giris.UseVisualStyleBackColor = false;
            this.Giris.Click += new System.EventHandler(this.Giris_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1283, 679);
            this.Controls.Add(this.Giris);
            this.Controls.Add(this.Sifre);
            this.Controls.Add(this.KullaniciAdi);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1000, 1000);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Teknik Servis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KullaniciAdi;
        private System.Windows.Forms.Button Giris;
        private System.Windows.Forms.TextBox Sifre;
    }
}

