using DBContextSQLite;
using Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(VeiculoContext context) : base(context)
        {
        }

        public bool IsExisteVeiculo(string chassi)
            => base.IsExist(m => m.Chassi == chassi);

        public bool IsExisteVeiculo(string chassi, out Veiculo model)
            => base.IsExist(m => m.Chassi == chassi, out model);

        public void ExcluirVeiculo(Guid id)
            => base.Delete(id);
        public void AtualizarVeiculo(Veiculo model)
            => base.Update(model);

        public void Salvar(Veiculo model)
        {
            if (IsExist(m => m.Chassi == model.Chassi))
                throw new Exception("Veículo já cadastrado!!");
            Save(model);
        }
        
        public IEnumerable<Veiculo> Read()
            => base.Read();
    }
}
