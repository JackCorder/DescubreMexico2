// BELLAS ARTES
const musicBellasButton = document.getElementById("music-bellas-btn");
const audioBellas = document.getElementById("bg-bellas-audio");

musicBellasButton.addEventListener("click", () => {
    try {
        if (audioBellas.paused) {
            audioBellas.play();
            musicBellasButton.classList.add("btn-success");
            musicBellasButton.classList.remove("btn-light");
        } else {
            audioBellas.pause(); // ✅ CORREGIDO
            musicBellasButton.classList.remove("btn-success");
            musicBellasButton.classList.add("btn-light");
        }
    } catch (ex) {
        console.error(ex);
    }
});