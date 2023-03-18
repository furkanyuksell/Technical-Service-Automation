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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "select * from kullanici";
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                connect.Close();
                ilkGirisKayit igk = new ilkGirisKayit();
                igk.ShowDialog();
                
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (Sifre.Text == "Şifre"){
                Sifre.Text = "";
                Sifre.ForeColor = Color.Black;
                Sifre.PasswordChar = '*';
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Sifre.Text == ""){
                Sifre.Text = "Şifre";
                Sifre.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (KullaniciAdi.Text == "Kullanıcı Adı")
            {
                KullaniciAdi.Text = "";
                KullaniciAdi.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (KullaniciAdi.Text == "")
            {
                KullaniciAdi.Text = "Kullanıcı Adı";
                KullaniciAdi.ForeColor = Color.Silver;
            }

        }
        public bool login(string user, string password) {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from kullanici where k_ad=@k and k_sifre=@s", connect);
            cmd.Parameters.AddWithValue("@k", user);
            cmd.Parameters.AddWithValue("@s", password);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }

        private void Giris_Click(object sender, EventArgs e)
        {
            bool loginProcess = login(KullaniciAdi.Text, Sifre.Text);
            if (loginProcess == true)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifre yanlis");
            }
        }

    }
}
