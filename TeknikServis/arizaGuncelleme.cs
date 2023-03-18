using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis
{
    public partial class arizaGuncelleme : Form
    {
        public arizaGuncelleme()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");

        ArizaListe aListe = new ArizaListe();

        private void arizaGuncelleme_Load(object sender, EventArgs e)
        {
            ad.Text = ArizaListe.gonderAd;
            soyad.Text = ArizaListe.gonderSoyad;
            telefon.Text = ArizaListe.gonderTelefon;
            adres.Text = ArizaListe.gonderAdres;
            cihaz.Text = ArizaListe.gonderCihaz;
            ariza.Text = ArizaListe.gonderSikayet;
            tarih.Text = ArizaListe.gonderTarih;
            aciklama.Text = ArizaListe.gonderAciklama;
            ucret.Text = ArizaListe.gonderFiyat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            string kayitGuncelle = "update arizaKayit set ak_Ad=@ak_Ad, ak_Soyad=@ak_Soyad, ak_Telefon=@ak_Telefon, ak_Adres=@ak_Adres, ak_Cihaz=@ak_Cihaz , ak_ArizaSikayet=@ak_ArizaSikayet, ak_Tarih=@ak_Tarih, ak_Aciklama=@ak_Aciklama, ak_fiyat=@ak_fiyat where ak_Id=@ak_Id";
            SqlCommand cmd = new SqlCommand(kayitGuncelle, connect);

            cmd.Parameters.AddWithValue("@ak_Id", ArizaListe.gonderId); 
            cmd.Parameters.AddWithValue("@ak_Ad", ad.Text);
            cmd.Parameters.AddWithValue("@ak_Soyad", soyad.Text);
            cmd.Parameters.AddWithValue("@ak_Telefon", telefon.Text);
            cmd.Parameters.AddWithValue("@ak_Adres", adres.Text);
            cmd.Parameters.AddWithValue("@ak_Cihaz", cihaz.Text);
            cmd.Parameters.AddWithValue("@ak_ArizaSikayet", ariza.Text);
            cmd.Parameters.AddWithValue("@ak_Tarih", tarih.Value.ToString("M/d/yyyy"));
            cmd.Parameters.AddWithValue("@ak_Aciklama", aciklama.Text);
            cmd.Parameters.AddWithValue("@ak_fiyat", ucret.Text);

            cmd.ExecuteNonQuery();
            connect.Close();
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from arizaKayit", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "arizaKayit");
            aListe.dataGridView1.DataSource = dtSet.Tables["arizaKayit"];
            ad.Text = "";
            soyad.Text = "";
            telefon.Text = "";
            adres.Text = "";
            cihaz.Text = "";
            ariza.Text = "";
            aciklama.Text = "";
            tarih.Text = "";
            ucret.Text = "";
            MessageBox.Show("Bilgiler Guncellendi");
            this.Close();
            aListe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            aListe.Show();
        }

        private void ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ucret_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
