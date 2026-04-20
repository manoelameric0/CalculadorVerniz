using System;

namespace CalculadoraVerniz.Models;

public class Medida
{
    public int Largura {get; private set;}
    public int Altura {get; private set;}
    public int Area {get; private set;}

    public Medida(int  largura, int altura)
    {
        if (largura <= 0)  throw new ArgumentException("Largura deve ser maior que ZERO!!!");

        if (altura <= 0) throw new ArgumentException("Altura deve ser maior que ZERO!!!");
        
        Largura = largura;
        Altura = altura;
        CalcularArea(largura, altura);
    }

    public void CalcularArea(int largura, int altura)
    {
        Area = (largura * altura) /10000;
    }
}
