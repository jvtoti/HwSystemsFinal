using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWSystems.modelo
{
    public class Aluguel
    {
        public int idAluguel { get; set; }
        public int id_veiculo { get; set; }
        public String nome { get; set; }
        public String dataSaida { get; set; }
        public String dataChegada { get; set; }
        public decimal preco { get; set; }
    }
}
