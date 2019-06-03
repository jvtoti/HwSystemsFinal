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
    public partial class Orcamento : MaterialSkin.Controls.MaterialForm
    {
        public Orcamento()
        {
            InitializeComponent();
        }

        private void Orcamento_Load(object sender, EventArgs e)
        {

        }

        private void ImprimirOrcamentoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imprimindo...");
        }
    }
}
