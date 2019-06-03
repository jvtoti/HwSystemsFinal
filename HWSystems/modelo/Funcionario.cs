using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWSystems.modelo
{
    public class Funcionario
    {
        public int idFuncionario { get; set; }
        public String nome { get; set; }
        public String CPF { get; set; }
        public String email { get; set; }
        public String telefone { get; set; }
        public String cargo { get; set; }
        public Decimal salario { get; set; }

        

        public void GerarRelatorioSalario()
        {

        }

        public void GerarRelatorioDosAlugueisfeitos()
        {

        }

        public void GerarRelatorioGeral()
        {

        }
    }
}
