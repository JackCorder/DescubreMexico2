// CENTRO HISTÓRICO
const musicCentroButton = document.getElementById("music-centro-btn");
const audioCentro = document.getElementById("bg-centro-audio");

musicCentroButton.addEventListener("click", () => {
    if (audioCentro.paused) {
        audioCentro.play();
        musicCentroButton.classList.add("btn-success");
        musicCentroButton.classList.remove("btn-light");
    } else {
        audioCentro.pause();
        musicCentroButton.classList.remove("btn-success");
        musicCentroButton.classList.add("btn-light");
    }
});