using CalculadoraVerniz.Core.Models;

namespace CalculadoraVerniz.API.DTOs
{
    public class CalculoRequestDto
    {
       List<MedidaRequestDto> Medidas { get; set; }
    }
}
