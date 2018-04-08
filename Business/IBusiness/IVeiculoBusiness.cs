using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IVeiculoBusiness : IDisposable
    {
        void SalvarVeiculo(Veiculo model);
        void AtualizarVeiculo(Veiculo model);
        IEnumerable<Veiculo> GetVeiculos();
        bool IsExisteVericulo(string chassi, out Veiculo model);
        bool IsExisteVericulo(string chassi);
        void ExcluirVeiculo(Guid id);
    }
}
