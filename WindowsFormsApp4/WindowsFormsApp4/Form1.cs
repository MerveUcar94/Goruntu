using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grey = Average(image);
            pictureBox2.Image = grey;

            Bitmap image2 = new Bitmap(pictureBox1.Image);
            Bitmap grey2 = BT(image2);
            pictureBox3.Image = grey2;

            Bitmap image3 = new Bitmap(pictureBox1.Image);
            Bitmap grey3 = Luma(image3);
            pictureBox4.Image = grey3;

            Bitmap image4 = new Bitmap(pictureBox1.Image);
            Bitmap gri4 = Aciklik(image4);
            pictureBox5.Image = gri4;

            Bitmap image5 = new Bitmap(pictureBox1.Image);
            Bitmap gri5 = Kanal(image5);
            pictureBox6.Image = gri5;
        }

        private Bitmap Average(Bitmap orta)
        {
            for (int i = 0; i < orta.Width; i++)
            {
                for (int j = 0; j < orta.Height; j++)
                {
                    int deger = (orta.GetPixel(i, j).R + orta.GetPixel(i, j).G + orta.GetPixel(i, j).B) / 3;

                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);

                    orta.SetPixel(i, j, renk);

                }
            }
            return orta;
        }

        private Bitmap BT(Bitmap bt)
        {
            Bitmap greyscale = new Bitmap(bt.Width, bt.Height);
            for (int x = 0; x < bt.Width; x++)
            {
                for (int y = 0; y < bt.Height; y++)
                {
                    Color pixelColor = bt.GetPixel(x, y);
                    int grey = (int)(pixelColor.R * 0.2125 + pixelColor.G * 0.7154 + pixelColor.B * 0.072);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private Bitmap Luma(Bitmap input)
        {
            Bitmap greyscale = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixelColor = input.GetPixel(x, y);
                    int grey = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private Bitmap Aciklik(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    int grey = (int)(pixelColor.R | pixelColor.G | pixelColor.B);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private Bitmap Kanal(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int a = 0;
                    if (pixelColor.R > pixelColor.G & pixelColor.R > pixelColor.B)
                        a = pixelColor.R;
                    if (pixelColor.G > pixelColor.R & pixelColor.G > pixelColor.B)
                        a = pixelColor.G;
                    if (pixelColor.B > pixelColor.R & pixelColor.B > pixelColor.G)
                        a = pixelColor.B;
                    int b = 0;
                    if (pixelColor.R < pixelColor.G & pixelColor.R < pixelColor.B)
                        b = pixelColor.R;
                    if (pixelColor.G < pixelColor.R & pixelColor.G < pixelColor.B)
                        b = pixelColor.G;
                    if (pixelColor.B < pixelColor.R & pixelColor.B < pixelColor.G)
                        b = pixelColor.B;

                    int grey = (int)((a + b) / 2);

                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }
    }
}
