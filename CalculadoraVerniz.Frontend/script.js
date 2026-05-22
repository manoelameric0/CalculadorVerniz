import { VernizService } from "./calculators/verniz-service.js";

const service = new VernizService();

const medidas = [];

const resultContent = document.getElementById("resultContent");
const resultTitle = document.getElementById("resultTitle");


const inputLargura = document.getElementById("inputLargura");
const inputAltura = document.getElementById("inputAltura");

const btnCalcular = document.getElementById("btnCalcular");
const btnAdicionar = document.getElementById("btnAdicionar");
btnAdicionar.addEventListener("click", function()
{
    //  console.log("clicou"),
    //  console.log(inputLargura.value),
    //  console.log(inputAltura.value)
    

     const largura = Number(inputLargura.value);
     const altura = Number(inputAltura.value);
    if (largura <= 0 || altura <= 0){
         alert("Informe valores válidos.");
         return;
    }

    if (resultTitle.textContent !== "Adicionados") {
        resultTitle.textContent = "Adicionados";
    }

     const medida = {
        largura: largura,
        altura: altura
     }

     medidas.push(medida);
    //  console.log(medidas);
     renderizarMedidas();
     inputAltura.value = "";
     inputLargura.value = "";
     inputLargura.focus();
    
});

btnCalcular.addEventListener("click", async function() {
    if (medidas.length === 0) {
        alert("Adicione ao menos uma medida.");
        return;
    }

    const data = await service.CalcularTotais(medidas);

    resultTitle.textContent = "Resultado";
    resultContent.innerHTML = `
        <p>Área Total: ${
            data.areaTotal >= 1
            ? `${+(data.areaTotal).toFixed(1)}m²`: `${+(data.areaTotal * 100).toFixed(1)}cm`
            
        }</p>

        <p>ML total: ${
            data.mlTotal >= 1000
            ? `${+(data.mlTotal / 1000).toFixed(1)}L` : `${+(data.mlTotal).toFixed(1)}ML`
        }</p>

        <p>Verniz: ${
            data.verniz >= 1000
            ? `${+(data.verniz / 1000).toFixed(1)}L` : `${+(data.verniz).toFixed(1)}ML`
        }</p>

        <p>Catalizador: ${
            data.catalizador >= 1000
            ? `${+(data.catalizador / 1000).toFixed(1)}L` : `${+(data.catalizador).toFixed(1)}ML`
        }</p>
    `
    medidas.length = 0;
});

function renderizarMedidas(){
    resultContent.innerHTML = "";

    medidas.forEach(function (medida, index){
        resultContent.innerHTML += ` 
        <div class="medida-item" data-index="${index}">

            <span>
                ${+(medida.largura).toFixed(3)} x ${+(medida.altura.toFixed(3))}  ${
                    medida.largura * medida.altura /10000 >= 1 ? `
                    ${+(medida.largura * medida.altura / 10000).toFixed(3)}m²` : `${+(medida.largura * medida.altura / 10000).toFixed(3)}cm`
                    
                } 
            </span>

            <button class="btn-remover" data-index="${index}">
                X
            </button>

        </div>
        `;
    });

    const itensMedida = document.querySelectorAll(".medida-item");

    itensMedida.forEach(function (item){
        item.addEventListener("click", function(){
            item.classList.toggle("ativo");
        })
    });

    const botoesRemover = document.querySelectorAll(".btn-remover");

    botoesRemover.forEach(function (botao){
        botao.addEventListener("click", function(event){
            event.stopPropagation();
            const index = botao.dataset.index;
            medidas.splice(index, 1);
            renderizarMedidas();
        });
    });
}

if ("serviceWorker" in navigator){
    navigator.serviceWorker.register("service-worker.js");
}