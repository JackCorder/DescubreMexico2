// ÁNGEL DE LA INDEPENDENCIA
const musicAngelButton = document.getElementById("music-angel-btn");
const audioAngel = document.getElementById("bg-angel-audio");

musicAngelButton.addEventListener("click", () => {
    if (audioAngel.paused) {
        audioAngel.play();
        musicAngelButton.classList.add("btn-success");
        musicAngelButton.classList.remove("btn-light");
    } else {
        audioAngel.pause();
        musicAngelButton.classList.remove("btn-success");
        musicAngelButton.classList.add("btn-light");
    }
});