using Business.Interface;
using Model;
using Model.Enum;
using Repository.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business
{
    public class VeiculoBusiness : IVeiculoBusiness
    {
        private IVeiculoRepository _veiculoRepository { get; set; }
        public VeiculoBusiness(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;

        }
        public void AtualizarVeiculo(Veiculo model)
            => _veiculoRepository.AtualizarVeiculo(model);
        public void ExcluirVeiculo(Guid id)
            => _veiculoRepository.ExcluirVeiculo(id);

        public bool IsExisteVeiculo(string chassi, out Veiculo model)
            => _veiculoRepository.IsExisteVeiculo(chassi, out model);
        public bool IsExisteVeiculo(string chassi)
           => _veiculoRepository.IsExisteVeiculo(chassi);

        public void SalvarVeiculo(Veiculo model)
        {
            model.NPassageiros = SetNumeroPassageiros(model.TipoVeiculo);
            _veiculoRepository.Salvar(model);
        }

        public IEnumerable<Veiculo> GetVeiculos()
           => _veiculoRepository.Read();

        private byte SetNumeroPassageiros(TipoVeiculo tipo)
        {
            switch (tipo)
            {
                case TipoVeiculo.Caminhoes:
                    return 2;
                case TipoVeiculo.Onibus:
                    return 42;
                default:
                    throw new Exception("Tipo Veículo não definido");
            }
        }
        public void Dispose()
        {
            if (_veiculoRepository != null)
                _veiculoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
