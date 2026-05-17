const medidas = [];

const resultContent = document.getElementById("resultContent");
const resultTitle = document.getElementById("resultTitle");


const inputLargura = document.getElementById("inputLargura");
const inputAltura = document.getElementById("inputAltura");

const btnCalcular = document.getElementById("btnCalcular");
const btnAdicionar = document.getElementById("btnAdicionar");
btnAdicionar.addEventListener("click", function()
{
     console.log("clicou"),
     console.log(inputLargura.value),
     console.log(inputAltura.value)
    
     const largura = Number(inputLargura.value);
     const altura = Number(inputAltura.value);
    if (largura <= 0 || altura <= 0){
         alert("Informe valores válidos.");
         return;
    }

     const medida = {
        largura: largura,
        altura: altura
     }

     medidas.push(medida);
     console.log(medidas);
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

    const response = await fetch("http://localhost:5056/api/Verniz/calcular", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            medidas: medidas
        })
    });

    console.log(response);
    console.log(response.status);

    if (!response.ok) {
        alert("não funfou");
        return;
    }

    const data = await response.json();
    console.log(data);

    resultTitle.textContent = "Resultado";
    resultContent.innerHTML = `
        <p>Área Total: ${data.areaTotal} m²</p>
        <p>ML total: ${data.mlTotal} ML</p>
        <p>Verniz: ${data.verniz} ML</p>
        <p>Catalizador: ${data.catalizador} ML</p>
    `
});

function renderizarMedidas(){
    resultContent.innerHTML = "";

    medidas.forEach(function (medida){
        resultContent.innerHTML += ` 
        <p>${medida.largura} x ${medida.altura} </p>
        `;
    });
}