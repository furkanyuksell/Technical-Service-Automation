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
    public partial class YetkiliPaneli : Form
    {
        public YetkiliPaneli()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");
        
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            sifre.PasswordChar = '*';
            yetkiliListe();
            dataGridView1.Columns[0].HeaderText = "Kullanici Adi";
            dataGridView1.Columns[1].HeaderText = "Sifre";
        }

        void yetkiliListe() {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from kullanici";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "kullanici");
            dataGridView1.DataSource = dataset.Tables["kullanici"];
            connect.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
        }

        public bool kayitKont(string user)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from kullanici where k_ad=@k", connect);
            cmd.Parameters.AddWithValue("@k", user);
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool kayitEslesme = kayitKont(kullaniciAdi.Text);
            if (kullaniciAdi.Text != "" || sifre.Text != "")
            {
                if (kayitEslesme == false)
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "insert into kullanici (k_ad, k_sifre) values ('" + kullaniciAdi.Text + "', '" + sifre.Text + "')";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        connect.Close();
                    }
                    SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from kullanici", connect);
                    DataSet dtSet = new DataSet();
                    dtAdapter.Fill(dtSet, "kullanici");
                    dataGridView1.DataSource = dtSet.Tables["kullanici"];
                    kullaniciAdi.Text = "";
                    sifre.Text = "";
                    MessageBox.Show("Kayit Basarili");
                }
                else
                {
                    MessageBox.Show("Kullanici adi mevcut, lütfen farkli bir kullanici adi belirleyiniz.");
                }   
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Tam Giriniz.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "delete from kullanici where k_ad=@k_ad";
                    cmd.Parameters.AddWithValue("@k_ad", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connect.Close();
                }
                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from kullanici", connect);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "kullanici");
                dataGridView1.DataSource = dtSet.Tables["kullanici"];
                textBox1.Text = "";
                MessageBox.Show("Kayit Silinmiştir");
            }
        }

    }
}
