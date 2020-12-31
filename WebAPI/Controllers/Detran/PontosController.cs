using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificarPontosService _DetranVerificarPontosServices;

        public PontosController(IMapper mapper, IDetranVerificarPontosService detranVerificarPontosServices)
        {
            _Mapper = mapper;
            _DetranVerificarPontosServices = detranVerificarPontosServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<PontoVeiculoModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]VeiculoModel model)
        {
            var pontos = await _DetranVerificarPontosServices.ConsultarPontos(_Mapper.Map<Veiculo>(model));

            var result = new SuccessResultModel<IEnumerable<PontoVeiculoModel>>(_Mapper.Map<IEnumerable<PontoVeiculoModel>>(pontos));

            return Ok(result);
        }
    }
}