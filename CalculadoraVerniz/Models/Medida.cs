using System;

namespace CalculadoraVerniz.Models;

public class Medida
{
    public decimal Largura {get; private set;}
    public decimal Altura {get; private set;}
    public decimal Area {get; private set;}

    public Medida(decimal  largura, decimal altura)
    {
        if (largura <= 0)  throw new ArgumentException("Largura deve ser maior que ZERO!!!");

        if (altura <= 0) throw new ArgumentException("Altura deve ser maior que ZERO!!!");
        
        Largura = largura;
        Altura = altura;
        CalcularArea(largura, altura);
    }

    public void CalcularArea(decimal largura, decimal altura)
    {
        Area = (largura * altura) /10000m;
    }
}
