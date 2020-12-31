using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificarPontosDecoratorCache : IDetranVerificarPontosService
    {
        private readonly IDetranVerificarPontosService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificarPontosDecoratorCache(
            IDetranVerificarPontosService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo)
        {
            return Task.FromResult(_Cache.GetOrCreate($"{veiculo.UF}_{veiculo.Placa}", () => _Inner.ConsultarPontos(veiculo).Result));
        }
    }
}