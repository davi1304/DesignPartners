using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificarPontosRepository
    {
        Task<IEnumerable<PontosVeiculo>> ConsultarPontos(Veiculo veiculo);
    }
}
