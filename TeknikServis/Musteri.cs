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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");

        private void Musteri_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();   
        }

        void musteriListe() {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from musteri";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "musteri");
            dataGridView1.DataSource = dataset.Tables["musteri"];
            connect.Close();
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
                    cmd.CommandText = "insert into musteri (m_ad, m_soyad, m_adres, m_telefon, m_parca, m_siparistarihi, m_tahminisure) values ('" + ad.Text + "', '" + soyad.Text + "' , '" + adres.Text + "', '" + telefon.Text + "', '" + parca.Text + "','"+ tarih.Value.ToString("M/d/yyyy") + "','" + tahminiSure.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connect.Close();
                }
                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from musteri", connect);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "musteri");
                dataGridView1.DataSource = dtSet.Tables["musteri"];
                ad.Text = "";
                soyad.Text = "";
                adres.Text = "";
                telefon.Text = "";
                parca.Text = "";
                tahminiSure.Text = "";
                MessageBox.Show("Kayit Basarili");
            }
            else
            {
                MessageBox.Show("Lütfen Müsteri Bilgilerini Tam doldurunuz.");
            }
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            musteriListe();
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Adi";
            dataGridView1.Columns[2].HeaderText = "Soyadi";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Telefon";
            dataGridView1.Columns[5].HeaderText = "Parca Adi";
            dataGridView1.Columns[6].HeaderText = "Siparis Tarihi";
            dataGridView1.Columns[7].HeaderText = "Tahmini Sure";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "delete from musteri where m_id=@m_id";
                    cmd.Parameters.AddWithValue("@m_id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connect.Close();
                }
                textBox1.Text = "";
                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from musteri", connect);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "musteri");
                dataGridView1.DataSource = dtSet.Tables["musteri"];
                MessageBox.Show("Kayit Silinmiştir");   
            }
            else
            {
                MessageBox.Show("Lütfen Bir ID Giriniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            this.Close();
            musteri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void telefon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void button3_Click_2(object sender, EventArgs e)
        {
            connect.Open();
            string kayitBul = "select * from musteri where m_id=@m_id";
            SqlCommand cmd = new SqlCommand(kayitBul, connect);
            cmd.Parameters.AddWithValue("@m_id", textBox2.Text);
            SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
            SqlDataReader dRead = cmd.ExecuteReader();
            if (dRead.Read())
            {
                textBox3.Text = dRead["m_ad"].ToString();
                textBox4.Text = dRead["m_soyad"].ToString();
                textBox5.Text = dRead["m_telefon"].ToString();
                textBox6.Text = dRead["m_parca"].ToString();
                textBox7.Text = dRead["m_tahminisure"].ToString();
                dateTimePicker1.Text = dRead["m_siparistarihi"].ToString();
                textBox9.Text = dRead["m_adres"].ToString();
            }
            else
            {
                MessageBox.Show("Musteri Bulunamadi");
            }
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connect.Open();
            string kayitGuncelle = "update musteri set m_ad=@m_ad, m_soyad=@m_soyad, m_adres=@m_adres, m_telefon=@m_telefon, m_parca=@m_parca , m_siparistarihi=@m_siparistarihi, m_tahminisure=@m_tahminisure where m_id=@m_id";
            SqlCommand cmd = new SqlCommand(kayitGuncelle, connect);

            cmd.Parameters.AddWithValue("@m_id", textBox2.Text); 
            cmd.Parameters.AddWithValue("@m_ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@m_soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("@m_telefon", textBox5.Text);
            cmd.Parameters.AddWithValue("@m_parca", textBox6.Text);
            cmd.Parameters.AddWithValue("@m_tahminisure", textBox7.Text);
            cmd.Parameters.AddWithValue("@m_siparistarihi", dateTimePicker1.Value.ToString("M/d/yyyy"));
            cmd.Parameters.AddWithValue("@m_adres", textBox9.Text);

            cmd.ExecuteNonQuery();
            connect.Close();
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from musteri", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "musteri");
            dataGridView1.DataSource = dtSet.Tables["musteri"];

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            dateTimePicker1.Text = "";
            MessageBox.Show("Bilgiler Guncellendi");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
