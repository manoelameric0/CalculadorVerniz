using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraVerniz.Core.Models
{
    public class Calculo
    {
        private readonly List<Medida> _medidas = new();

        public async Task<decimal> AreaTotal() => _medidas.Sum(c => c.Area);

        public async Task Limpar() => _medidas.Clear();

        public async Task Adicionar(Medida medida) => _medidas.Add(medida);

        public async Task<bool> TemMedidas() => _medidas.Any();

        public async Task Remover(int index) => _medidas.RemoveAt(index);

        public async Task<IEnumerable<Medida>> Medidas() => _medidas ?? Enumerable.Empty<Medida>();
    }
}
