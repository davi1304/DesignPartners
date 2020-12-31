using System;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificarPontosFactory
    {
        public IDetranVerificarPontosFactory Register(string UF, Type repository);
        public IDetranVerificarPontosRepository Create(string UF);
    }
}
