const medidas = [];

const resultContent = document.getElementById("resultContent");

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

const inputLargura = document.getElementById("inputLargura");
const inputAltura = document.getElementById("inputAltura");

function renderizarMedidas(){
    resultContent.innerHTML = "";

    medidas.forEach(function (medida){
        resultContent.innerHTML += ` 
        <p>${medida.largura} x ${medida.altura} </p>
        `;
    });
}