using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public abstract class DetranVerificarPontosRepositoryCrawlerBase : IDetranVerificarPontosRepository
    {
        public async Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo)
        {
            var html = await RealizarAcesso(veiculo);
            return await PadronizarResultado(html);
        }

        protected abstract Task<string> RealizarAcesso(Veiculo veiculo);
        protected abstract Task<IEnumerable<PontosVeiculo>> PadronizarResultado(string html);
    }
}
