using System;
using CalculadoraVerniz.Models;

namespace CalculadoraVerniz.Services;

public class CalculoVernizService
{
    List<Medida> medidas = new List<Medida>();

    public void AdicionarMedida(int largura, int altura)
    {
        var medida = new Medida(largura, altura);
        medidas.Add(medida);
    }

    public ResultadoCalculo CalcularTotais(List<Medida> medidas)
    {
        decimal areaTotal = 0;
        foreach (var medida in medidas)
        {
            areaTotal += medida.Area;
        }
        decimal mlTotal = areaTotal * 80;
        decimal verniz = mlTotal * 5/6;
        decimal catalizador = mlTotal * 1/6;

        medidas.Clear();

        return new ResultadoCalculo(areaTotal, mlTotal, verniz, catalizador);

    }
}
