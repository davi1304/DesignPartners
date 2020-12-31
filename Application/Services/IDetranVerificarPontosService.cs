using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Services
{
    public interface IDetranVerificarPontosService
    {
        Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo);
    }
}
