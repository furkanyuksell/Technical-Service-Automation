using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TeknikServis
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void Mail_Load(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mesaj = new MailMessage();
                SmtpClient islemci = new SmtpClient("smtp.gmail.com");
                islemci.Credentials = new NetworkCredential(textBox2.Text.ToString(), textBox3.Text.ToString());
                islemci.Port = 587;
                islemci.EnableSsl = true;
                mesaj.To.Add(textBox4.Text);
                mesaj.From = new MailAddress(textBox2.Text.ToString(), textBox1.Text.ToString());
                mesaj.Subject = textBox5.Text;
                mesaj.Body = textBox6.Text;
                islemci.Send(mesaj);
                MessageBox.Show("Mail Gönderildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Mail Gönderme Başarısız.");   
            }
        }
    }
}
