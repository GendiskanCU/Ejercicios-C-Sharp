using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumaDosNumeros
{
    public partial class frmSumador : Form
    {
        public frmSumador()
        {
            InitializeComponent();
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double resultado = Convert.ToDouble(tbNumero1.Text) + Convert.ToDouble(tbNumero2.Text);
                tbResultado.Text = Convert.ToString(resultado);
            }
            catch(Exception error)
            {
                MessageBox.Show("Error. Los datos introducidos no son correctos", "Error de datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbNumero1_TextChanged(object sender, EventArgs e)
        {
            CompruebaDatosIntroducidos();
        }

        private void tbNumero2_TextChanged(object sender, EventArgs e)
        {
            CompruebaDatosIntroducidos();
        }

        private void CompruebaDatosIntroducidos()
        {
            double cadenaEscrita;
            if (!double.TryParse(tbNumero1.Text, out cadenaEscrita) ||
                !double.TryParse(tbNumero2.Text, out cadenaEscrita))
            {
                lbMensajes.Text = "¡Se están introduciendo datos que no son números válidos!";
                    
            }
            else
            {
                lbMensajes.Text = "";
            }
        }
    }
}
