using System;

namespace CalculadoraVerniz.Models;

public class ResultadoCalculo
{
    public int AreaTotal {get; private set;}
    public int MlTotal {get; private set;}
    public int Verniz {get; private set;}
    public int Catalizador {get; private set;}

    public ResultadoCalculo(int areaTotal, int mlTotal, int verniz, int catalizador)
    {
        AreaTotal = areaTotal;
        MlTotal = mlTotal;
        Verniz = verniz;
        Catalizador = catalizador;
    }
}
