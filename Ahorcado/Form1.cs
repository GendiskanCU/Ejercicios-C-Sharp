using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Ahorcado : Form
    {

        private List<string> listaPalabras;

        private StreamReader ficheroListaPalabras;

        public Ahorcado()
        {
            InitializeComponent();

            try
            {
                if(File.Exists("ListaPalabras.txt"))
                {
                    ficheroListaPalabras = File.OpenText("ListaPalabras.txt");

                    listaPalabras = new List<string>();

                    int finalFichero = 0;

                    finalFichero = ficheroListaPalabras.Read();

                    while(finalFichero != -1)
                    {
                        listaPalabras.Add(ficheroListaPalabras.ReadLine());

                        finalFichero = ficheroListaPalabras.Read();
                    }                   

                    ficheroListaPalabras.Close();

                    lbPalabra.Text = "Número de palabras cargadas: " + listaPalabras.Count;
                }
                else
                {
                    lbPalabra.Text = "Error al abrir el fichero. No se ha encontrado";
                }
            }
            catch (Exception error)
            {
                lbPalabra.Text = "Error al abrir el fichero: " + error.Message;
            }

        }

        private void btComenzar_Click(object sender, EventArgs e)
        {

        }
    }
}
