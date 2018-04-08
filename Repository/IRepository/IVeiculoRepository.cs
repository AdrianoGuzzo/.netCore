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
        bool IsExisteVericulo(string chassi, out Veiculo model);
        bool IsExisteVericulo(string chassi);
        void ExcluirVeiculo(Guid id);
    }
}
