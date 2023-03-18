using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace TeknikServis
{
    public partial class ParcaEkle : Form
    {
        public ParcaEkle()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");

        public int ekranKarti, islemci, kasa, monitor;

        private void ParcaEkle_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            label8.Visible = false;
            pictureBox1.Visible = false;
            label10.Visible = false;
            textBox8.Visible = false;
            label10.Text = "Satış No : ";

            Point l1 = new Point(25, 120);
            label1.Location = l1;

            Point l2 = new Point(25, 160);
            label2.Location = l2;

            Point l3 = new Point(25, 200);
            label3.Location = l3;

            Point l4 = new Point(25, 240);
            label4.Location = l4;

            Point l5 = new Point(25, 280);
            label5.Location = l5;

            Point l6 = new Point(25, 320);
            label6.Location = l6;

            Point l7 = new Point(25, 360);
            label7.Location = l7;

            Point l9 = new Point(25, 400);
            label9.Location = l9;
            

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;

            Point t1 = new Point(180,120);
            textBox1.Location = t1;

            Point t2 = new Point(180, 160);
            textBox2.Location = t2;

            Point t3 = new Point(180, 200);
            textBox3.Location = t3;

            Point t4 = new Point(180, 240);
            textBox4.Location = t4;

            Point t5 = new Point(180, 280);
            textBox5.Location = t5;

            Point t6 = new Point(180, 320);
            textBox6.Location = t6;

            Point t7 = new Point(180, 360);
            textBox7.Location = t7;

            Point resimSec = new Point(30, 440);
            button3.Location = resimSec;

            button3.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;

            button1.Visible = false;
            dataGridView1.Visible = false;
        }

        void ekranListe()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from ekranKarti";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "ekranKarti");
            dataGridView1.DataSource = dataset.Tables["ekranKarti"];
            connect.Close();
        }

        void islemciListe()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from islemci";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "islemci");
            dataGridView1.DataSource = dataset.Tables["islemci"];
            connect.Close();
        }

        void kasaListe()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from kasa";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "kasa");
            dataGridView1.DataSource = dataset.Tables["kasa"];
            connect.Close();
        }

        void monitorListe()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from monitor";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "monitor");
            dataGridView1.DataSource = dataset.Tables["monitor"];
            connect.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            dataGridView1.Visible = true;
            label8.Visible = true;
            pictureBox1.Visible = true;
            button3.Visible = true;
            label10.Visible = true;
            textBox8.Visible = true;

            if (comboBox1.SelectedIndex == 0)
            {
                ekranListe();
                ekranKarti = dataGridView1.RowCount;
                label8.Text = "Ekran Karti Adedi : " + ekranKarti;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;

                label1.Text = "Ekran Karti";
                label1.Name = "ekranKarti";

                label2.Text = "Markasi";
                label2.Name = "ekranKartiMarka";

                label3.Text = "Fiyat";
                label3.Name = "ekranKartiFiyat";

                label4.Text = "Chipset";
                label4.Name = "ekranKartiChipset";

                label5.Text = "Ram Kapasitesi";
                label5.Name = "ekranKartiRam";

                label6.Text = "Bellek Tipi";
                label6.Name = "ekranKartiBellek";

                label7.Text = "Bellek Arayüzü";
                label7.Name = "ekranKartiBellek";

                label9.Text = "Ekran Karti Resmi";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                islemciListe();
                islemci = dataGridView1.RowCount;
                label8.Text = "Islemci Adedi : " + islemci;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label9.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;

                label1.Text = "Islemci";
                label1.Name = "islemci";

                label2.Text = "Marka";
                label2.Name = "islemciMarka";

                label3.Text = "Fiyat";
                label3.Name = "islemciFiyat";

                label9.Text = "Islemci Resmi";

                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;

                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                kasaListe();
                kasa = dataGridView1.RowCount;
                label8.Text = "Kasa Adedi : " + kasa;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;

                label1.Text = "Kasa Boyutu";

                label2.Text = "Marka";

                label3.Text = "Fiyat";

                label4.Text = "Cikis";

                label5.Text = "Yapi";

                label6.Text = "Guc Kaynagi";

                label9.Text = "Kasa Resmi";

                label7.Visible = false;

                textBox7.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                monitorListe();
                monitor = dataGridView1.RowCount;
                label8.Text = "Monitor Adedi : " + monitor;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;

                label1.Text = "Monitor";

                label2.Text = "Marka";

                label3.Text = "Fiyat";

                label4.Text = "Monitor Tipi";

                label5.Text = "Yenileme Hizi";

                label6.Text = "Ekran Boyu";

                label7.Text = "Cozunurluk";

                label9.Text = "Monitor Resmi";
            }
            
        }

        private void ParcaEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        public bool satisNoKont(string user)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from tumParcalar where p_id=@p_id", connect);
            cmd.Parameters.AddWithValue("@p_id", user);
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
            bool satisNo = satisNoKont(textBox8.Text);
            if (satisNo == false)
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || pictureBox1.Image != null)
                {
                    FileStream fs = new FileStream(resimYolu, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] resim = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    if (comboBox1.SelectedIndex == 0)
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "insert into ekranKarti (ekran_Ad, ekran_Marka, ekran_Fiyat, ekran_Chipset, ekran_Ram, ekran_Tip, ekran_Arayuz, ekran_Image, p_id) values ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "', '" + textBox7.Text + "', @image, '" + textBox8.Text + "')";
                            cmd.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "insert into tumParcalar(tP_parca, tP_marka, tP_fiyat, tP_Image, p_id) values ('Ekran Karti', '" + textBox2.Text + "','" + textBox3.Text + "', @image, '" + textBox8.Text + "')";
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            connect.Close();
                        }
                        SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from ekranKarti", connect);
                        DataSet dtSet = new DataSet();
                        dtAdapter.Fill(dtSet, "ekranKarti");
                        dataGridView1.DataSource = dtSet.Tables["ekranKarti"];
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        pictureBox1.Image = null;
                        ekranKarti = dataGridView1.RowCount;
                        label8.Text = "Ekran Karti Adedi : " + ekranKarti;
                        MessageBox.Show("Ekran Karti Kayit Basarili");
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "insert into islemci (islemci_Soket, islemci_Marka, islemci_Fiyat, islemci_Image, p_id) values ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "',@image, '" + textBox8.Text + "')";
                            cmd.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "insert into tumParcalar(tP_parca, tP_marka, tP_fiyat, tP_Image, p_id) values ('Islemci', '" + textBox2.Text + "','" + textBox3.Text + "', @image, '" + textBox8.Text + "')";
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            connect.Close();
                        }
                        SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from islemci", connect);
                        DataSet dtSet = new DataSet();
                        dtAdapter.Fill(dtSet, "islemci");
                        dataGridView1.DataSource = dtSet.Tables["islemci"];
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox8.Text = "";
                        pictureBox1.Image = null;
                        islemci = dataGridView1.RowCount;
                        label8.Text = "Islemci Adedi : " + islemci;
                        MessageBox.Show("Islemci Kayit Basarili");
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "insert into kasa (kasa_Boyut, kasa_Marka, kasa_Fiyat, kasa_Cikis, kasa_yapi, kasa_Guc, kasa_Image, p_id) values ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "',@image, '" + textBox8.Text + "')";
                            cmd.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "insert into tumParcalar(tP_parca, tP_marka, tP_fiyat, tP_Image, p_id) values ('Kasa', '" + textBox2.Text + "','" + textBox3.Text + "', @image, '" + textBox8.Text + "')";
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            connect.Close();
                        }
                        SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from kasa", connect);
                        DataSet dtSet = new DataSet();
                        dtAdapter.Fill(dtSet, "kasa");
                        dataGridView1.DataSource = dtSet.Tables["kasa"];
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox8.Text = "";
                        pictureBox1.Image = null;
                        kasa = dataGridView1.RowCount;
                        label8.Text = "Kasa Adedi : " + kasa;
                        MessageBox.Show("Kasa Kayit Basarili");
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "insert into monitor (monitor_Ekran, monitor_Marka, monitor_Fiyat, monitor_Tip, monitor_Yenileme, monitor_Boy, monitor_Cozunurluk, monitor_Image, p_id) values ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "', '" + textBox7.Text + "',@image, '" + textBox8.Text + "')";
                            cmd.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "insert into tumParcalar(tP_parca, tP_marka, tP_fiyat, tP_Image, p_id) values ('Monitor', '" + textBox2.Text + "','" + textBox3.Text + "', @image, '" + textBox8.Text + "')";
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            connect.Close();
                        }
                        SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from monitor", connect);
                        DataSet dtSet = new DataSet();
                        dtAdapter.Fill(dtSet, "monitor");
                        dataGridView1.DataSource = dtSet.Tables["monitor"];
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        pictureBox1.Image = null;
                        monitor = dataGridView1.RowCount;
                        label8.Text = "Monitor Adedi : " + monitor;
                        MessageBox.Show("Monitor Kayit Basarili");
                    }   
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgileri Tam Doldurunuz ve Eklemediyseniz 1 Adet Resim Ekleyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Ayni satis numarasında bir ürün daha var lütfen farklı bir satis no giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            parcaKontrol pF = new parcaKontrol();
            pF.Show();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        string resimYolu;
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title  = "Resim";
            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                resimYolu = openFileDialog1.FileName.ToString();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
