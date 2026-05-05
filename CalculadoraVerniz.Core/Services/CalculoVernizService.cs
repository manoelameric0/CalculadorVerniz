using System;
using CalculadoraVerniz.Core.Models;

namespace CalculadoraVerniz.Core.Services;

public class CalculoVernizService
{
    private readonly Calculo _calc;

    public CalculoVernizService(Calculo calc)
    {
        _calc = calc;
    }

    public async Task AdicionarMedida(int largura, int altura)
    {
        await _calc.Add(largura, altura);
    }

    public async Task<ResultadoCalculo> CalcularTotais()
    {
        var areaTotal = _calc.AreaTotal().Result;
        decimal mlTotal = areaTotal * 80;
        decimal verniz = mlTotal * 5/6;
        decimal catalizador = mlTotal * 1/6;

        await _calc.Clear();

        return new ResultadoCalculo(areaTotal, mlTotal, verniz, catalizador);

    }
}
