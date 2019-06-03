using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWSystems.modelo
{
    public class Veiculo : viagem
    {
        public int idVeiculo;
        public String placa { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public int ano_fabricacao { get; set; }
        public int ano_modelo { get; set; }
        public String Cor { get; set; }
        public Decimal quilometragem { get; set; }
        public String status { get; set; }

    }
}
