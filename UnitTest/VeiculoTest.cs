using Business.Interface;
using IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Enum;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass()]
    public class VeiculoTest
    {
        static string[] Cores = new string[] {
            "Preto","Branco","Amarelo","Vermelho","Azul","Laranja","Rosa"
        };
        static string[] Chassis = new string[] {
            "VT004251 ","VT005251","VT104251 ","VT004451","VT014251","VT004255","VT004266"
        };
        static TipoVeiculo[] tipoVeiculos = new TipoVeiculo[] {
            TipoVeiculo.Caminhoes,TipoVeiculo.Onibus
        };

        readonly IVeiculoBusiness _veiculoBusiness;
        List<Veiculo> veiculos = CriarListaAleatoria(100);

        public VeiculoTest()
        {
            var serviceProvider = Bootstrap.Start();
            _veiculoBusiness = serviceProvider.GetService<IVeiculoBusiness>();
        }
        [TestMethod()]
        public void VeiculoPerformanceTeste()
        {
            Veiculo _veiculo;
            foreach (var veiculo in veiculos)
            {
                if (_veiculoBusiness.IsExisteVeiculo(veiculo.Chassi, out _veiculo))
                {
                    _veiculo.Cor = veiculo.Cor;
                    _veiculoBusiness.AtualizarVeiculo(_veiculo);
                }
                else
                    _veiculoBusiness.SalvarVeiculo(veiculo);
            }
        }
        [TestMethod()]
        public void BuscarVeiculoTeste()
        {
            Veiculo _veiculo;
            foreach (var chassi in Chassis)
            {
                if (!_veiculoBusiness.IsExisteVeiculo(chassi, out _veiculo))
                    Assert.Fail("Veiculo não encontrado Chassi: " + chassi);
            }
        }
        [TestMethod()]
        public void ExcluirVeiculoTeste()
        {
            Veiculo _veiculo;
            foreach (var chassi in Chassis)
            {
                if (_veiculoBusiness.IsExisteVeiculo(chassi, out _veiculo))
                {
                    _veiculoBusiness.ExcluirVeiculo(_veiculo.Id);
                }
                else
                    Assert.Fail("Veiculo não encontrado Chassi: " + chassi);
            }
        }
       



        internal static List<Veiculo> CriarListaAleatoria(int quantidade)
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            for (int i = 0; i < quantidade; i++)
            {
                Random random = new Random();
                int corIndex = random.Next(0, Cores.Length);
                string cor = Cores[corIndex];

                int chassiIndex = random.Next(0, Chassis.Length);
                string chassi = Chassis[chassiIndex];

                int tipoVeiculoIndex = random.Next(0, tipoVeiculos.Length);
                TipoVeiculo tipoVeiculo = tipoVeiculos[tipoVeiculoIndex];
                veiculos.Add(new Veiculo
                {
                    Chassi = chassi,
                    Cor = cor,
                    TipoVeiculo = tipoVeiculo
                });
            }
            return veiculos;

        }
    }
}
