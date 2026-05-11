using CalculadoraVerniz.API.DTOs;
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

        [HttpPost("medida")]
        public async Task<IActionResult> Add(MedidaRequestDto medida)
        {
            await _calculadora.AdicionarMedida(medida.Largura, medida.Altura);

            return Created("", medida);
        }
    }
}
