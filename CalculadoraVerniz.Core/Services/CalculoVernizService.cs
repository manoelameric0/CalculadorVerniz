using System;
using CalculadoraVerniz.Core.Models;

namespace CalculadoraVerniz.Core.Services;

public class CalculoVernizService
{
    public ResultadoCalculo CalcularTotais(List<Medida> medidas)
    {
        var areaTotal = medidas.Sum(m => m.Area);
        decimal mlTotal = areaTotal * 80;
        decimal verniz = mlTotal * 5 / 6;
        decimal catalizador = mlTotal * 1 / 6;

        medidas.Clear();

        return new ResultadoCalculo(areaTotal, mlTotal, verniz, catalizador);

    }
}
