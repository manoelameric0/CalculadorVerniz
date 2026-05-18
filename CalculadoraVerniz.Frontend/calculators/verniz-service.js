export class ResultadoCalculo {
  constructor(areaTotal, mlTotal, verniz, catalizador) {
    this.areaTotal = areaTotal;
    this.mlTotal = mlTotal;
    this.verniz = verniz;
    this.catalizador = catalizador;
  }
}

export class VernizService {
  CalcularTotais(medidas) {
    let areaTotal = medidas.reduce((acc, m) => acc + (m.largura * m.altura), 0);


    let mlTotal = areaTotal * 80;
    let verniz = mlTotal * 5 / 6;
    let catalizador = mlTotal * 1 / 6;

    medidas.length = 0;

    return new ResultadoCalculo(areaTotal, mlTotal, verniz, catalizador);
  }
}
