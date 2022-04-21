using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms_DosVentanas
{
    public partial class Introduccion : Form
    {
        public Introduccion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string GetNombreYApellido()
        {
            return tbNombre.Text + " " + tbApellido.Text;
        }
    }
}
