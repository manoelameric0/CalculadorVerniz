using System.ComponentModel.DataAnnotations;

namespace CalculadoraVerniz.API.DTOs
{
    public class MedidaRequestDto
    {
        [Range(0.1, 100000)]
        public decimal Largura { get; set; }

        [Range(0.1, 100000)]
        public decimal Altura { get; set; }
    }
}
