using CalculadoraVerniz.Core.Models;
namespace CalculadoraVerniz.API.DTOs
{
    public class CalculoMapper
    {  
        public static CalculoResponseDto Mapper(ResultadoCalculo resultado)
        {
            return  new CalculoResponseDto
            {
                AreaTotal = resultado.AreaTotal,
                MlTotal = resultado.MlTotal,
                Verniz = resultado.Verniz,
                Catalizador =  resultado.Catalizador
            };
        }
    }
}
