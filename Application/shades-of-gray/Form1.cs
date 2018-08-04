using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shades_of_gray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            img1.Load(openFileDialog1.FileName);
        }

        private void btnTransformar_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(openFileDialog1.FileName);
            int coluna = img.Width;
            int linha = img.Height;
            Bitmap imgnova = new Bitmap(coluna, linha);
            Color cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R * 0.30;
                    double g = img.GetPixel(i, j).G * 0.59;
                    double b = img.GetPixel(i, j).B * 0.11;
                    int newColor = (int)(r + g + b) / 3;
                    cor = Color.FromArgb(255, newColor, newColor, newColor);
                    imgnova.SetPixel(i, j, cor);
                }
            }
            imgnova.Save(Application.StartupPath + "\\nova-imagem.bmp");
            img2.Load(Application.StartupPath + "\\nova-imagem.bmp");
        }
    }
}
