using CalculadoraVerniz.Core.Models;
namespace CalculadoraVerniz.API.DTOs
{
    public class MedidasMapper
    {  
        public static MedidaResponse Mapper(Medida m)
        {
            return new MedidaResponse
            {
                Largura = m.Largura,
                Altura = m.Altura,
                Area = m.Area
            };
        }
    }
}
