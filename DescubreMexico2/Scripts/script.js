let map = L.map('map').setView([19.432858860223014, -99.1333541753921], 13);

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

let marker = L.marker([19.432858860223014, -99.1333541753921]).addTo(map);


