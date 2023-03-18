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
    public partial class ArizaKayit : Form
    {
        public ArizaKayit()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");
        
        private void ArizaKayit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ad.Text != "" || soyad.Text != "")
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "insert into arizaKayit (ak_Ad, ak_Soyad, ak_Telefon, ak_Adres, ak_Cihaz, ak_ArizaSikayet, ak_Tarih, ak_Aciklama, ak_fiyat) values ('" + ad.Text + "', '" + soyad.Text + "' , '" + telefon.Text + "', '" + adres.Text + "', '" + cihaz.Text + "','" + ariza.Text + "','" + tarih.Value.ToString("M/d/yyyy") + "','" + aciklama.Text + "','" + ucret.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connect.Close();
                }
                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from arizaKayit", connect);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "arizaKayit");
                ad.Text = "";
                soyad.Text = "";
                adres.Text = "";
                telefon.Text = "";
                cihaz.Text = "";
                ariza.Text = "";
                tarih.Text = "";
                aciklama.Text = "";
                ucret.Text = "";
                MessageBox.Show("Kayit Basarili");   
            }
            else
            {
                MessageBox.Show("Lütfen Musteri Bilgilerini Tam Doldurunuz.");
            }
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
