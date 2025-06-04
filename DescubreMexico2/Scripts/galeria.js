// GALERIA
const musicGalleryButton = document.getElementById("music-galeria-btn");
const audioGallery = document.getElementById("bg-galeria-audio");

musicGalleryButton.addEventListener("click", () => {
    if (audioGallery.paused) {
        audioGallery.play();
        musicGalleryButton.classList.add("btn-success");
        musicGalleryButton.classList.remove("btn-light");
    } else {
        audioGallery.pause();
        musicGalleryButton.classList.remove("btn-success");
        musicGalleryButton.classList.add("btn-light");
    }
});

const myCarouselElement = document.querySelector('#myCarousel')

const carousel = new bootstrap.Carousel(myCarouselElement, {
    interval: 2000,
    touch: false
})

