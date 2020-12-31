using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Infra.Repository.Detran;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DesignPatternsSamples.Infra.Repository.Detran.Tests
{
    public class DetranVerificarPontosFactoryTests : IClassFixture<DependencyInjectionFixturePontos>
    {
        private readonly IDetranVerificarPontosFactory _Factory;

        public DetranVerificarPontosFactoryTests(DependencyInjectionFixturePontos dependencyInjectionFixturePontos)
        {
            var serviceProvider = dependencyInjectionFixturePontos.ServiceProvider;
            _Factory = serviceProvider.GetService<IDetranVerificarPontosFactory>();
        }

        [Theory(DisplayName = "Dado um UF que está devidamente registrado no Factory devemos receber a sua implementação correspondente")]
        [InlineData("PE", typeof(DetranPEVerificarPontosRepository))]
        [InlineData("SP", typeof(DetranSPVerificarPontosRepository))]
        [InlineData("RJ", typeof(DetranRJVerificarPontosRepository))]
        [InlineData("RS", typeof(DetranRSVerificarPontosRepository))]
        public void InstanciarServicoPorUFRegistrado(string uf, Type implementacao)
        {
            var resultado = _Factory.Create(uf);

            Assert.NotNull(resultado);
            Assert.IsType(implementacao, resultado);
        }

        [Fact(DisplayName = "Dado um UF que não está registrado no Factory devemos receber NULL")]
        public void InstanciarServicoPorUFNaoRegistrado()
        {
            IDetranVerificarPontosRepository implementacao = _Factory.Create("CE");

            Assert.Null(implementacao);
        }
    }
}
