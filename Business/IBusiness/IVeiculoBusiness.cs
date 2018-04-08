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
        bool IsExisteVeiculo(string chassi, out Veiculo model);
        bool IsExisteVeiculo(string chassi);
        void ExcluirVeiculo(Guid id);
    }
}
