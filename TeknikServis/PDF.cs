using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TeknikServis
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document rapor = new iTextSharp.text.Document();
            PdfWriter.GetInstance(rapor, new FileStream("C:\\Users\\Furkan YÜKSEL\\Desktop\\" + textBox2.Text + ".pdf", FileMode.Create));
            rapor.AddAuthor(textBox1.Text);
            rapor.AddCreationDate();
            rapor.AddCreator(textBox2.Text);
            rapor.AddSubject(textBox3.Text);
            rapor.AddKeywords(textBox4.Text);
            if (rapor.IsOpen() == false)
                rapor.Open();
            rapor.Add(new Paragraph(richTextBox1.Text));
            rapor.Close();
            MessageBox.Show(textBox2.Text + " İsimli PDF Oluşturuldu");
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog pdfac = new OpenFileDialog();
            pdfac.Title = "PDF Aç";
            pdfac.Filter = "PDF Dosyaları (*.Pdf)|*.Pdf";
            if (pdfac.ShowDialog() == DialogResult.OK) {
                PDFGoruntule pdfgoruntule = new PDFGoruntule();
                pdfgoruntule.axAcroPDF1.LoadFile(pdfac.FileName);

                pdfgoruntule.Show();
            }
            
        }
    }
}
