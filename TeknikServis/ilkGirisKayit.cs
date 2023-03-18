using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TeknikServis
{
    public partial class ilkGirisKayit : Form
    {
        public ilkGirisKayit()
        {
            InitializeComponent();
        }
      
        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");
      
        private void ilkGirisKayit_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kullaniciAdi.Text != "" && sifre.Text != "")
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "create table kullanici (k_ad nvarchar(50), k_sifre nvarchar(50))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into kullanici (k_ad, k_sifre) values ('" + kullaniciAdi.Text + "', '" + sifre.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connect.Close();
                }
                kullaniciAdi.Text = "";
                sifre.Text = "";
                MessageBox.Show("Kayit Basarili");
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Tam Giriniz.");
            }
        }

        private void ilkGirisKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
