using System;

namespace CalculadoraVerniz.Models;

public class ResultadoCalculo
{
    public decimal AreaTotal {get; private set;}
    public decimal MlTotal {get; private set;}
    public decimal Verniz {get; private set;}
    public decimal Catalizador {get; private set;}

    public ResultadoCalculo(decimal areaTotal, decimal mlTotal, decimal verniz, decimal catalizador)
    {
        AreaTotal = areaTotal;
        MlTotal = mlTotal;
        Verniz = verniz;
        Catalizador = catalizador;
    }
}
