using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranPEVerificarPontosRepository : DetranVerificarPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPEVerificarPontosRepository(ILogger<DetranPEVerificarPontosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<PontosVeiculo>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<PontosVeiculo>>(new List<PontosVeiculo>() { new PontosVeiculo() { DataOcorrencia = DateTime.UtcNow } });
        }

        protected override Task<string> RealizarAcesso(Veiculo veiculo)
        {
            Task.Delay(5000).Wait();
            _Logger.LogDebug($"Consultando os Pontos do veículo de placa {veiculo.Placa} do estado de PE.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/PE");
        }
    }
}
