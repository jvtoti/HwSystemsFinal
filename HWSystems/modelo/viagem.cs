using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSystems.modelo
{
    public class viagem
    {
        public int idViagem { get; set; }
        public int id_veiculo { get; set; }
        public String destino { get; set; }
        public String data_saida { get; set; }
        public String data_chegada { get; set; }
        public int quilometragem_atual { get; set; }
        public String status_viagem { get; set; }
    }
}
