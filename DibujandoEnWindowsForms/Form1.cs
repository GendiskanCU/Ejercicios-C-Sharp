using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DibujandoEnWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Crea la "pluma", el "relleno" y la ventana gráfica
            System.Drawing.Pen contornoRojo = new System.Drawing.Pen(
                System.Drawing.Color.Red);

            System.Drawing.SolidBrush rellenoAzul = new System.Drawing.SolidBrush(
                System.Drawing.Color.Blue);

            System.Drawing.Graphics ventanaGrafica;
            ventanaGrafica = this.CreateGraphics();

            //Muestra una imagen predefinida
            Image imagenCara = new Bitmap("cara.png");
            ventanaGrafica.DrawImage(imagenCara, 220, 120, 178, 100);

            //Dibuja una línea y una elipse
            ventanaGrafica.DrawLine(contornoRojo, 200, 100, 300, 400);
            ventanaGrafica.FillEllipse(rellenoAzul, new Rectangle(0, 0, 200, 300));
                        

            //Libera la memoria reservada
            contornoRojo.Dispose();
            rellenoAzul.Dispose();
            ventanaGrafica.Dispose();
        }
    }
}
