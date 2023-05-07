'use strict';

const mapEl = document.getElementById('map');

const lat = mapEl.dataset.lat;
const lng = mapEl.dataset.lng;
const companyName = mapEl.dataset.companyName;

var map = L.map('map').setView([lat, lng], 13);

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

L.marker([lat, lng]).addTo(map)
    .bindPopup(companyName)
    .openPopup();