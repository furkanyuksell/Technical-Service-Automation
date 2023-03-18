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
    public partial class parcaKontrol : Form
    {
        public parcaKontrol()
        {
            InitializeComponent();
        }

        private void parcaFiyat_Load(object sender, EventArgs e)
        {
            
        }

        private void arizaEkle_Click(object sender, EventArgs e)
        {
            ParcaEkle pE = new ParcaEkle();
            pE.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new TeknikServis.Menu();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TumParcalar tparcalar = new TumParcalar();
            tparcalar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            raporForm rform = new raporForm();
            rform.Show();
        }
    }
}
