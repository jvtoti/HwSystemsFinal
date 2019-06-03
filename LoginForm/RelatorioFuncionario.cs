using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class RelatorioFuncionario : MaterialSkin.Controls.MaterialForm
    {
        public RelatorioFuncionario()
        {
            InitializeComponent();
        }

        private void RelatorioFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void ImprimirFuncionarioBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imprimindo...");
        }
    }
}
