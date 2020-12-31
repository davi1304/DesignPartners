using System;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class PontosVeiculo
    {
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public double QuantidadePontos { get; set; }
    }
}