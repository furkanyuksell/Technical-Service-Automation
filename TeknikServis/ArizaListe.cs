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
    public partial class ArizaListe : Form
    {
        public ArizaListe()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");

        public static string gonderId, gonderAd, gonderSoyad, gonderAdres, gonderCihaz, gonderSikayet, gonderTarih, gonderAciklama, gonderTelefon, gonderFiyat;

        void arizaListe()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from arizaKayit";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "arizaKayit");
            dataGridView1.DataSource = dataset.Tables["arizaKayit"];
            connect.Close();
        }

        private void ArizaListe_Load(object sender, EventArgs e)
        {
            arizaListe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from arizaKayit where ak_Id=@ak_Id";
                cmd.Parameters.AddWithValue("@ak_Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
            }
            textBox1.Text = "";
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from arizaKayit", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "arizaKayit");
            dataGridView1.DataSource = dtSet.Tables["arizaKayit"];
            MessageBox.Show("Kayit Silinmiştir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            string kayitBul = "select * from arizaKayit where ak_Id=@ak_Id";
            SqlCommand cmd = new SqlCommand(kayitBul, connect);
            cmd.Parameters.AddWithValue("@ak_Id", textBox2.Text);
            SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
            SqlDataReader dRead = cmd.ExecuteReader();
            if (dRead.Read())
            {
                gonderId = dRead["ak_Id"].ToString();
                gonderAd = dRead["ak_Ad"].ToString();
                gonderSoyad = dRead["ak_Soyad"].ToString();
                gonderTelefon = dRead["ak_Telefon"].ToString();
                gonderAdres = dRead["ak_Adres"].ToString();
                gonderCihaz = dRead["ak_Cihaz"].ToString();
                gonderSikayet = dRead["ak_ArizaSikayet"].ToString();
                gonderTarih = dRead["ak_Tarih"].ToString();
                gonderAciklama = dRead["ak_Aciklama"].ToString();
                gonderFiyat = dRead["ak_fiyat"].ToString();
                arizaGuncelleme aGuncelle = new arizaGuncelleme();
                aGuncelle.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Musteri Bulunamadi");
            }
            connect.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arizaListe();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from arizaKayit where ak_Tarih between @tarih1 and @tarih2";
            cmd.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@tarih2", dateTimePicker2.Value.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "arizaKayit");
            dataGridView1.DataSource = dataset.Tables["arizaKayit"];
            connect.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from arizaKayit where ak_Tarih between @tarih1 and @tarih2";
            cmd.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@tarih2", dateTimePicker2.Value.Date);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "arizaKayit");
            dataGridView1.DataSource = dataset.Tables["arizaKayit"];
            connect.Close();
        }

    }
}
