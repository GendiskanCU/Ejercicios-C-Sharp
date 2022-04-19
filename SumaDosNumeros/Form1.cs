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
            int resultado = Convert.ToInt32(tbNumero1.Text) + Convert.ToInt32(tbNumero2.Text);
            tbResultado.Text = Convert.ToString(resultado);
        }
    }
}
