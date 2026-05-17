const medidas = [];

const btnAdicionar = document.getElementById("btnAdicionar");
btnAdicionar.addEventListener("click", function()
{
     console.log("clicou"),
     console.log(inputLargura.value),
     console.log(inputAltura.value)

     const medida = {
        largura: inputLargura.value,
        altura: inputAltura.value
     }

     medidas.push(medida);
     console.log(medidas);
    
});

const inputLargura = document.getElementById("inputLargura");
const inputAltura = document.getElementById("inputAltura");