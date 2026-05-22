export class ResultadoCalculo {
  constructor(areaTotal, mlTotal, verniz, catalizador) {
    this.areaTotal = areaTotal;
    this.mlTotal = mlTotal;
    this.verniz = verniz;
    this.catalizador = catalizador;
  }
}

export class VernizService {
  async CalcularTotais(medidas) {

    if (!navigator.onLine) {
      return Calcular();
    }

    try {
    const controller = new AbortController();
    const idDoTimer = setTimeout(function(){
      controller.abort();
    }, 8000);

    const response = await fetch("https://calculadora-verniz-api.onrender.com/api/Verniz/calcular", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            medidas: medidas
        }),
        signal: controller.signal
    });

    clearTimeout(idDoTimer);

    // console.log(response);
    // console.log(response.status);

    // if (!response.ok) {
    //     alert("não funfou");
    //     return;
    // }
    console.log("Calculo-API");
    //console.log(response.json());
    return await response.json();
    
    } catch (error) {
      return Calcular();
    }

    function Calcular(){
      let areaTotal = medidas.reduce((acc, m) => acc + (m.largura * m.altura), 0);
      areaTotal = areaTotal / 10000;

      let mlTotal = areaTotal * 80;
      let verniz = mlTotal * 5 / 6;
      let catalizador = mlTotal * 1 / 6;

      medidas.length = 0;

      console.log("Calculo-Local");
      return new ResultadoCalculo(areaTotal, mlTotal, verniz, catalizador);
    }
    
  }
}
