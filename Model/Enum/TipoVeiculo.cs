using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.Enum
{
    public enum TipoVeiculo
    {
        [Description("Ônibus")]
        Onibus = 0,
        [Description("Caminhões")]
        Caminhoes = 1
    }
}
