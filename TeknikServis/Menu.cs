using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YetkiliPaneli yetkiliEkle = new YetkiliPaneli();
            yetkiliEkle.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArizaKayit kayit = new ArizaKayit();
            kayit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArizaListe aListe = new ArizaListe();
            this.Hide();
            aListe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parcaKontrol pf = new parcaKontrol();
            pf.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Menu_KeyDown);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            mail.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PDF pdf = new PDF();
            pdf.Show();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Help.ShowHelp(this, "file://C:\\Users\\Furkan YÜKSEL\\Desktop\\TeknikServis\\Yardım.chm");
            }
        }
    }
}
