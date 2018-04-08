using IoC;
using System;
using Microsoft.Extensions.DependencyInjection;
using Business.Interface;
using Model.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using Model;
using System.Linq;

namespace View
{
    class Program
    {
        static IVeiculoBusiness _veiculoBusiness;
        static void Main(string[] args)
        {
            var serviceProvider = Bootstrap.Start();
            _veiculoBusiness = serviceProvider.GetService<IVeiculoBusiness>();
            string opcao = "";
            while (opcao != "0")
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1 - Adicionar veículo.");
                Console.WriteLine("2 - Editar veículo existente.");
                Console.WriteLine("3 - Excluir veículo existente.");
                Console.WriteLine("4 - Listar todos os veículos.");
                Console.WriteLine("5 - Encontrar veículo por Chassi.");
                Console.WriteLine("0 - Sair.");

                opcao = Console.ReadLine();
                try
                {
                    switch (opcao)
                    {
                        case "1":
                            AdicionarVeiculo();
                            break;
                        case "2":
                            EditarVeiculo();
                            break;
                        case "3":
                            ExcluirVeiculo();
                            break;
                        case "4":
                            ListarVeiculo();
                            break;
                        case "5":
                            EncontrarVeiculo();
                            break;
                        default:
                            Console.WriteLine("------------------");
                            Console.WriteLine("Opção incorreta!!!");
                            Console.WriteLine("------------------");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    TratarException(ex);
                }
            }
            _veiculoBusiness.Dispose();
        }
        static void AdicionarVeiculo()
        {
            Console.Write("Chassi: ");
            var chassi = Console.ReadLine();

            TipoVeiculo tipoVeiculo;
            SetVeiculo(out tipoVeiculo);

            Console.Write("Cor: ");
            var cor = Console.ReadLine();
            if (!_veiculoBusiness.IsExisteVeiculo(chassi))
                _veiculoBusiness.SalvarVeiculo(new Veiculo
                {
                    Chassi = chassi,
                    Cor = cor,
                    TipoVeiculo = tipoVeiculo
                });
            else
                Console.WriteLine("Veículo já cadastrado!!!");
        }
        static void EditarVeiculo()
        {
            Console.Write("Digite o Chassi do veículo a ser editado: ");
            string chassi = Console.ReadLine();
            Veiculo veiculo;
            if (_veiculoBusiness.IsExisteVeiculo(chassi, out veiculo))
            {
                PrintVeiculo(veiculo);
                Console.WriteLine("Editar: ");
                Console.Write("Cor: ");
                var cor = Console.ReadLine();
                veiculo.Cor = cor;
                _veiculoBusiness.AtualizarVeiculo(veiculo);
            }
            else
                Console.WriteLine("Veiculo não existe!!!");
        }
        static void ExcluirVeiculo()
        {
            Console.Write("Digite o Chassi do veículo a ser excluido: ");
            string chassi = Console.ReadLine();
            Veiculo veiculo;
            if (_veiculoBusiness.IsExisteVeiculo(chassi, out veiculo))
            {
                PrintVeiculo(veiculo);
                Console.WriteLine("Deseja realmente excluir esse veículo? ");
                Console.WriteLine("SIM(S)");
                bool sim = Console.ReadLine() == "S" ? true : false;
                if (sim)
                    _veiculoBusiness.ExcluirVeiculo(veiculo.Id);
            }
            else
                Console.WriteLine("Veiculo não existe!!!");


        }
        static void ListarVeiculo()
        {
            IEnumerable<Veiculo> lista = _veiculoBusiness.GetVeiculos();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Lista de veículos cadastrados");
            Console.WriteLine("-------------------------------");
            foreach (Veiculo veiculo in lista)
                PrintVeiculo(veiculo);
        }
        static void EncontrarVeiculo()
        {
            Console.Write("Digite o Chassi do veículo a ser editado: ");
            string chassi = Console.ReadLine();
            Veiculo veiculo;
            if (_veiculoBusiness.IsExisteVeiculo(chassi, out veiculo))
                PrintVeiculo(veiculo);
            else
                Console.WriteLine("Veiculo não existe!!!");
        }
        private static void PrintVeiculo(Veiculo veiculo)
        {
            Console.Write("Chassi: ");
            Console.WriteLine(veiculo.Chassi);
            Console.Write("Cor: ");
            Console.WriteLine(veiculo.Cor);
            Console.Write("Numero passageiros: ");
            Console.WriteLine(veiculo.NPassageiros);
            Console.Write("Tipo automóvel: ");
            Console.WriteLine(veiculo.TipoVeiculo.GetDescription());
            Console.WriteLine("-------------------------------");
        }
        private static void SetVeiculo(out TipoVeiculo tipoVeiculo)
        {
            Console.WriteLine((byte)TipoVeiculo.Caminhoes + " - " + TipoVeiculo.Caminhoes.GetDescription());
            Console.WriteLine((byte)TipoVeiculo.Onibus + " - " + TipoVeiculo.Onibus.GetDescription());
            Console.Write("Tipo Veículo: ");
            string tipo = Console.ReadLine();
            if (!Enum.TryParse<TipoVeiculo>(tipo, out tipoVeiculo) ||
                !Enum.IsDefined(typeof(TipoVeiculo), tipoVeiculo))
            {
                Console.WriteLine("Valor incorreto!! ");
                SetVeiculo(out tipoVeiculo);
            }

        }
        private static void TratarException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            if (ex.InnerException != null)
                TratarException(ex.InnerException);
        }




    }
}
