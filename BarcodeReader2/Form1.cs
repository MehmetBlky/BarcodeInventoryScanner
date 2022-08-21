using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using USB_Barcode_Scanner;

namespace BarcodeReader2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            BarcodeScanner barcodeScanner = new BarcodeScanner(textBox1);
            barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned;

            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();

            int w = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString())/2;


            panel1.Width = w;
            panel3.Width =w;

            buttonResize(button1, 2);

            labelResize(this.label2, 2);
           

            labelResize(this.label1, 3);

            infoFontSize(2);

            labelResize(this.label4, 1);
            labelResize(this.label5, 1);

            buttonResize(button2, 2);

            alignObjects();


        }
        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            textBox1.Text = e.Barcode;
        }

        private void alignObjects() {
            int h = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height.ToString());
            int w = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString());
            var w_vec = ((int)button1.Width);
            var y = (h / 100) + 25;

            label2.Location = new Point((w/200) + 25,y);
            button1.Location = new Point((w / 2) - (w_vec + 30), y);

            textBox1.Location = new Point(50 + label2.Width,y);
            
            textBox1.Width = (w / 2) - (label2.Width + w_vec + (w / 200) + 25 + (w_vec + 30));
          


            textBox1.Font = new Font(textBox1.Font.FontFamily, 2 * w / 154);


            label1.Location = new Point((w/4) - (label1.Width/2), label2.Location.Y + label2.Height + 75);


            label7.Location = new Point((w / 200) + 25, label1.Location.Y + label1.Height + 75);

            // Left Side
            var pd = 7;
            var x = label7.Location.X;
            y = label7.Location.Y;
            w_vec = ((int)label7.Width);
            var h_vec = ((int)label7.Height);
            label9.Location = new Point(x, y+ h_vec +pd);
            y = label9.Location.Y;
            label10.Location = new Point(x, y + h_vec + pd);
            y = label10.Location.Y;
            label11.Location = new Point(x, y + h_vec + pd);
            y = label11.Location.Y;
            label12.Location = new Point(x, y + h_vec + pd);
            y = label12.Location.Y;
            label13.Location = new Point(x, y + h_vec + pd);
            y = label13.Location.Y;
            label14.Location = new Point(x, y + h_vec + pd);
            y = label14.Location.Y;
            label22.Location = new Point(x, y + h_vec + pd);

            var xArray = new int[] {
                ((int)label7.Width),
                ((int)label9.Width),
                ((int)label10.Width),
                ((int)label11.Width),
                ((int)label12.Width),
                ((int)label13.Width),
                ((int)label14.Width),
                ((int)label22.Width),

             };

            x = xArray.Max() + 50;
            y = label7.Location.Y;
            //// Right Side

            label8.Location = new Point(x, y);
            y = label8.Location.Y;
            label16.Location = new Point(x, y + h_vec + pd);
            y = label16.Location.Y;
            label17.Location = new Point(x, y + h_vec + pd);
            y = label17.Location.Y;
            label18.Location = new Point(x, y + h_vec + pd);
            y = label18.Location.Y;
            label19.Location = new Point(x, y + h_vec + pd);
            y = label19.Location.Y;
            label20.Location = new Point(x, y + h_vec + pd);
            y = label20.Location.Y;
            label21.Location = new Point(x, y + h_vec + pd);
            y = label21.Location.Y;
            label15.Location = new Point(x, y + h_vec + pd);
            y = label15.Location.Y;

            w_vec =  ((int)button2.Width);
           

            button2.Location = new Point((w/2) - (w_vec+30), y + h_vec + 50);
            x = label7.Location.X;

            label6.Location = new Point(x, y + h_vec +50);

            label4.Location = new Point(x, h - label4.Height - 200);
            label5.Location = new Point(x+ 200, label4.Location.Y);
        }



        private void infoFontSize(int sz) {
            labelResize(this.label7, sz);
            labelResize(this.label9, sz);
            labelResize(this.label10, sz);
            labelResize(this.label11,sz);
            labelResize(this.label12, sz);
            labelResize(this.label13, sz);
            labelResize(this.label14, sz);
            labelResize(this.label22, sz);


            labelResize(this.label8, sz);
            labelResize(this.label16, sz);
            labelResize(this.label17, sz);
            labelResize(this.label18, sz);
            labelResize(this.label19, sz);
            labelResize(this.label20, sz);
            labelResize(this.label21, sz);
            labelResize(this.label15, sz);
           

        }
          
        private void labelResize(Label lbl, int sz)
        {
            int w = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString());

            lbl.Font = new Font(this.label1.Font.FontFamily,sz* w / 154);

        }

        private void buttonResize(Button btn, int sz) {
              int w = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width.ToString());
            btn.Font = new Font(btn.Font.FontFamily, sz * w / 154);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {

                var bark = Int64.Parse(textBox1.Text);
                UrundbEntities Urundb = new UrundbEntities();
                var sip = Urundb.Tbl_cikis.Where(c => c.Barkod == bark).First();


                    label8.Text = sip.Siparis_No;
                    label16.Text = sip.Kalem_Sayisi;
                    label17.Text = sip.Toplam_Fiyat;
                    label18.Text = sip.Siparis_Durumu;
                    label19.Text = sip.Kargoya_sonVerme;
                    label21.Text = sip.Musteri_Ad;
                    label20.Text = sip.Kargo_FirmaAdı;
                    label15.Text = sip.Teslimat_Adres;

                var urn = Urundb.Tbl_Urunler.Where(c => c.Urun_Barkod == sip.Barkod).First();
                pictureBox1.Load(urn.Urun_Foto);


                if (sip.Siparis_Durumu == "iptal") 
                {
                    pictureBox1.Image = Image.FromFile(@"..\\..\\Signs\\cancel.png");
                    label18.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                    label6.Text = "İptal Edilmiş Ürün Bulunmaktadır!";
                    pictureBox2.Image = null;
                }
                else
                {
                    
                    label6.BackColor = Color.Green;
                    label6.Text = "Bilgiler Görüntülendi.";
                }

            }
            catch (Exception ex)
            {

                label6.Text = "Ürün Bilgisi Bulunamadı";
                pictureBox1.Image= null;
                label8.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";
                label19.Text = "";
                label20.Text = "";
                label21.Text = "";
                label15.Text = "";

                string message = "Ürün stoklarda yok.!";
                string title = "Farklı  Ürün Denemek ister misin?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    pictureBox2.Image = null;
                    label6.Text = "";
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            label4.Text = DateTime.Now.ToLongDateString();
            label5.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ////  pictureBox2.Image = Image.FromFile(@"..\\..\\Signs\\check-mark.png");
            label6.Text = "İşlem Başarıyla Tamamlandı .!!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}