using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public class DetranVerificarPontosServices : IDetranVerificarPontosService
    {
        private readonly IDetranVerificarPontosFactory _Factory;

        public DetranVerificarPontosServices(IDetranVerificarPontosFactory factory)
        {
            _Factory = factory;
        }

        public Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo)
        {
            IDetranVerificarPontosRepository repository = _Factory.Create(veiculo.UF);
            return repository.ConsultarPontos(veiculo);
        }
    }
}
