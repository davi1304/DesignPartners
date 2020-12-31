using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Infra.Repository.Detran;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignPatternsSamples.Infra.Repository.Detran.Tests
{
    public class DependencyInjectionFixturePontos
    {
        public readonly IServiceProvider ServiceProvider;

        public DependencyInjectionFixturePontos()
        {
            var services = new ServiceCollection()
                .AddLogging()
                .AddTransient<DetranPEVerificarPontosRepository>()
                .AddTransient<DetranSPVerificarPontosRepository>()
                .AddTransient<DetranRJVerificarPontosRepository>()
                .AddTransient<DetranRSVerificarPontosRepository>()
                .AddSingleton<IDetranVerificarPontosFactory, DetranVerificarPontosFactory>();

            #region IConfiguration
            services.AddTransient<IConfiguration>((services) =>
                new ConfigurationBuilder()

                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build()
            );
            #endregion

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.GetService<IDetranVerificarPontosFactory>()
                .Register("PE", typeof(DetranPEVerificarPontosRepository))
                .Register("RJ", typeof(DetranSPVerificarPontosRepository))
                .Register("SP", typeof(DetranRJVerificarPontosRepository))
                .Register("RS", typeof(DetranRSVerificarPontosRepository));
        }
    }
}