using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraVerniz.Core.Models
{
    public class Calculo
    {
        private readonly List<Medida> _medidas = new();

        public async Task<decimal> AreaTotal()
        {
            return _medidas.Sum(c => c.Area);
        }

        public async Task Clear()
        {
            _medidas.Clear();
        }
        public async Task Add(decimal largura, decimal altura)
        {
            _medidas.Add(new Medida(largura, altura));
        }
    }
}
