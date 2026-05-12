using CalculadoraVerniz.API.DTOs;
using CalculadoraVerniz.Core.Models;
using CalculadoraVerniz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CalculadoraVerniz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VernizController : ControllerBase
    {
        private readonly CalculoVernizService _calculadora;

        public VernizController(CalculoVernizService service)
        {
            _calculadora = service;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular(CalculoRequestDto request)
        {
            if (!request.Medidas.Any())
            {
                return BadRequest();
            }

            var medidas = new List<Medida>();

            foreach (var medida in request.Medidas)
            {
                medidas.Add(new Medida(medida.Largura, medida.Altura));
            }

            

            var response = _calculadora.CalcularTotais(medidas);

            return Ok(CalculoMapper.Mapper(response));
        }
    }
}
