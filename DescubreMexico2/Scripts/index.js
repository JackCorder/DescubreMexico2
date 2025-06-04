// Principal
const musicButton = document.getElementById("music-index-btn");
const audio = document.getElementById("bg-index-audio");

musicButton.addEventListener("click", () => {
    if (audio.paused) {
        audio.play();
        musicButton.classList.add("btn-success");
        musicButton.classList.remove("btn-light");
    } else {
        audio.pause();
        musicButton.classList.remove("btn-success");
        musicButton.classList.add("btn-light");
    }
});

const parrafo = document.getElementById("escribir-parrafo");
const textoCompleto = "Mexico es un país hermoso y con una cultura muy rica. Descubre nuestro tour de la Ciudad de Mexico.";
let escribiendo = false;

function typeEffect(texto, elemento, delay = 50) {
    elemento.textContent = "";
    let index = 0;
    escribiendo = true;

    const intervaloEscritura = setInterval(() => {
        if (index < texto.length) {
            elemento.textContent += texto.charAt(index);
            index++;
        } else {
            clearInterval(intervaloEscritura);
            escribiendo = false;
        }
    }, delay);
}

// Evento scroll que activa el efecto
window.addEventListener("scroll", () => {
    const scrollPosition = window.scrollY;

    // Solo activa el efecto si no está escribiendo y si ha hecho suficiente scroll
    if (scrollPosition > 100 && !escribiendo) {
        typeEffect(textoCompleto, parrafo);
    }
});