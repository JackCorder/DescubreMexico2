const formulario = document.getElementById("formulario-tour")
formulario.addEventListener("submit", function (e) {
    if (!formulario.checkValidity()) {
        e.preventDefault();
        e.stopPropagation();
    }
    formulario.classList.add('was-validated');

    let valid = true;

    const nombre = document.getElementById("nombre");
    const nombreRegex = /^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$/;
    if (!nombreRegex.test(nombre.value.trim())) {
        nombre.classList.add("is-invalid");
        valid = false;
    } else {
        nombre.classList.remove("is-invalid");
    }

    const emailInput = document.getElementById("email");

    emailInput.addEventListener("input", function () {
        if (this.value.includes("@")) {
            this.classList.remove("is-invalid");
        } else {
            this.classList.add("is-invalid");
        }
    });

    const fecha = document.getElementById("fecha");
    const inputDate = new Date(fecha.value);
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    const minDate = new Date(today);
    minDate.setDate(minDate.getDate() + 5);
    if (inputDate <= minDate) {
        fecha.classList.add("is-invalid");
        valid = false;
    } else {
        fecha.classList.remove("is-invalid");
    }

    const personas = document.getElementById("personas");
    const num = parseInt(personas.value);
    if (isNaN(num) || num < 1 || num > 50) {
        personas.classList.add("is-invalid");
        valid = false;
    } else {
        personas.classList.remove("is-invalid");
    }

    if (valid) {
        alert("Formulario enviado correctamente.");
        this.reset(); // Opcional: limpia el formulario
    }
});