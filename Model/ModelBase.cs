using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
