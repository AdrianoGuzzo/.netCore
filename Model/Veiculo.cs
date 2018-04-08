using Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Veiculo : ModelBase
    {
        public string Chassi { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public byte NPassageiros { get; set; }
        public string Cor { get; set; }
    }
}
