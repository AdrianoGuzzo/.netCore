using Business;
using Business.Interface;
using DBContextSQLite;
using Microsoft.Extensions.DependencyInjection;
using Repository.IRepository;
using Repository.Repository;
using System;

namespace IoC
{
    public class Bootstrap
    {
        public static ServiceProvider Start()
        => new ServiceCollection()
             .AddDbContext<VeiculoContext>()
             .AddSingleton<IVeiculoRepository, VeiculoRepository>()
             .AddSingleton<IVeiculoBusiness, VeiculoBusiness>()
             .BuildServiceProvider();
    }
}
