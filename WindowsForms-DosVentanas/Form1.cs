using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_DosVentanas
{
    public partial class Form1 : Form
    {
        //Para poder abrir la ventana/formulario de introducción de datos
        private Introduccion ventanaIntroduccion;

        public Form1()
        {
            InitializeComponent();

            //Inicializa la ventana/formulario de introducción de dtos
            ventanaIntroduccion = new Introduccion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Abre la ventana/formulario de introducción de datos en modo diálogo
            ventanaIntroduccion.ShowDialog();
            //Cuando se cierre ésta ventana, leemos la información introducida en ella
            tbNombreYApellido.Text = ventanaIntroduccion.GetNombreYApellido();
        }


        
    }


}
