using CalculadoraVerniz.Core.Models;

namespace CalculadoraVerniz.API.DTOs
{
    public class CalculoRequestDto
    {
       public List<MedidaRequestDto> Medidas { get; set; }
    }
}
