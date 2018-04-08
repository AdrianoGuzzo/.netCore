using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface IVeiculoRepository : IDisposable
    {
        void Salvar(Veiculo model);
        void AtualizarVeiculo(Veiculo model);
        IEnumerable<Veiculo> Read();
        bool IsExisteVeiculo(string chassi, out Veiculo model);
        bool IsExisteVeiculo(string chassi);
        void ExcluirVeiculo(Guid id);
    }
}
