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
    public partial class TumParcalar : Form
    {
        public TumParcalar()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=.\\FURKAN;Initial Catalog=teknikServis;Integrated Security=True");


        int adet, ekranKartiSay = 0, islemciSay = 0, kasaSay = 0, monitorSay = 0;

        void tumParcalar()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "select * from tumParcalar";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "tumParcalar");
            dataGridView1.DataSource = dataset.Tables["tumParcalar"];
            adet = dataGridView1.RowCount;
            adet = adet - 1; 
            label5.Text = "Toplam Parça : " + adet;
            connect.Close();
        }

        void pEkranKartiSay() {
            SqlCommand cmd = new SqlCommand("select count(*) from ekranKarti");
            connect.Open();
            cmd.Connection = connect;
            ekranKartiSay = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
        }

        void pIslemciSay()
        {
            SqlCommand cmd = new SqlCommand("select count(*) from islemci");
            connect.Open();
            cmd.Connection = connect;
            islemciSay = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
        }

        void pKasaSay()
        {
            SqlCommand cmd = new SqlCommand("select count(*) from kasa");
            connect.Open();
            cmd.Connection = connect;
            kasaSay = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
        }

        void pMonitorSay()
        {
            SqlCommand cmd = new SqlCommand("select count(*) from monitor");
            connect.Open();
            cmd.Connection = connect;
            monitorSay = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
        }

        void chartKontrol() {

            pEkranKartiSay();
            pIslemciSay();
            pMonitorSay();
            pKasaSay();
        
        }

        private void TumParcalar_Load(object sender, EventArgs e)
        {
            chartKontrol();
            chart1.Series["Parcalar"].Points.Add(ekranKartiSay);
            chart1.Series["Parcalar"].Points.Add(islemciSay);
            chart1.Series["Parcalar"].Points.Add(kasaSay);
            chart1.Series["Parcalar"].Points.Add(monitorSay);

            chart1.Series["Parcalar"].Points[0].AxisLabel = "Ekran Karti";
            chart1.Series["Parcalar"].Points[1].AxisLabel = "Islemci";
            chart1.Series["Parcalar"].Points[2].AxisLabel = "Kasa";
            chart1.Series["Parcalar"].Points[3].AxisLabel = "Monitor";

            chart1.Series["Parcalar"].Points[0].Color = Color.Black;
            chart1.Series["Parcalar"].Points[1].Color = Color.Red;
            chart1.Series["Parcalar"].Points[2].Color = Color.Yellow;
            chart1.Series["Parcalar"].Points[3].Color = Color.Blue;
            
            tumParcalar();
            dataGridView1.AllowUserToAddRows = false;
            chartKontrol();
            
        }

        private void TumParcalar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen       = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text     = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text     = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text     = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text     = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MemoryStream ms   = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[4].Value);
            pictureBox1.Image = Image.FromStream(ms);
            textBox5.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            parcaKontrol pK = new parcaKontrol();
            pK.Show();
        }

        void ekranSil() {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from ekranKarti where p_id = @p_id";
                cmd.Parameters.AddWithValue("@p_id", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.Image = null;
            }
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from ekranKarti", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "ekranKarti");
            dataGridView1.DataSource = dtSet.Tables["ekranKarti"];
        }

        void islemciSil()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from islemci where p_id = @p_id";
                cmd.Parameters.AddWithValue("@p_id", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.Image = null;
            }
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from islemci", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "islemci");
            dataGridView1.DataSource = dtSet.Tables["islemci"];
        }

        void monitorSil()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from monitor where p_id = @p_id";
                cmd.Parameters.AddWithValue("@p_id", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.Image = null;
            }
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from monitor", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "monitor");
            dataGridView1.DataSource = dtSet.Tables["monitor"];
        }

        void kasaSil()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from kasa where p_id = @p_id";
                cmd.Parameters.AddWithValue("@p_id", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.Image = null;
            }
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from kasa", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "kasa");
            dataGridView1.DataSource = dtSet.Tables["kasa"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "delete from tumParcalar where p_id=@p_id";
                cmd.Parameters.AddWithValue("@p_id", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
            }
            if (textBox2.Text == "Ekran Karti")
            {
                ekranSil();
            }
            else if (textBox2.Text == "Islemci")
            {
                islemciSil();
            }
            else if (textBox2.Text == "Monitor")
            {
                monitorSil();
            }
            else
            {
                kasaSil();
            }

            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from tumParcalar", connect);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "tumParcalar");
            dataGridView1.DataSource = dtSet.Tables["tumParcalar"];
            MessageBox.Show("Parça Silinmiştir");
            chartKontrol();
        }
    }
}
