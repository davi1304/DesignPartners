using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificarPontosDecoratorLogger : IDetranVerificarPontosService
    {
        private readonly IDetranVerificarPontosService _Inner;
        private readonly ILogger<DetranVerificarPontosDecoratorLogger> _Logger;

        public DetranVerificarPontosDecoratorLogger(
            IDetranVerificarPontosService inner,
            ILogger<DetranVerificarPontosDecoratorLogger> logger)
        {
            _Inner = inner;
            _Logger = logger;
        }

        public async Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo)
        {
            Stopwatch watch = Stopwatch.StartNew();
            _Logger.LogInformation($"Iniciando a execução do método ConsultarPontos({veiculo})");
            var result = await _Inner.ConsultarPontos(veiculo);
            watch.Stop(); 
            _Logger.LogInformation($"Encerrando a execução do método ConsultarPontos({veiculo}) {watch.ElapsedMilliseconds}ms");
            return result;
        }
    }
}