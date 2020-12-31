using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranRSVerificarPontosRepository : DetranVerificarPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranRSVerificarPontosRepository(ILogger<DetranRSVerificarPontosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<PontosVeiculo>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<PontosVeiculo>>(new List<PontosVeiculo>() { new PontosVeiculo() });
        }

        protected override Task<string> RealizarAcesso(Veiculo veiculo)
        {
            _Logger.LogDebug($"Consultando os Pontos do veículo de placa {veiculo.Placa} do estado de RS.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/RS");
        }
    }
}
