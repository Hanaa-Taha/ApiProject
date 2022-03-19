window.addEventListener("load", function () {
    getCoordintes();



})

function getCoordintes() {
    var options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 0
    };

    function success(pos) {
        var crd = pos.coords;
        var lat = crd.latitude.toString();
        var lng = crd.longitude.toString();
        var coordinates = [lat, lng];
        console.log(`Latitude: ${lat}, Longitude: ${lng}`);
        getCity(coordinates);
        return;

    }

    function error(err) {
        console.warn(`ERROR(${err.code}): ${err.message}`);
    }

    navigator.geolocation.getCurrentPosition(success, error, options);
}

// Step 2: Get city name
function getCity(coordinates) {

    var lat = coordinates[0];
    var lng = coordinates[1];
    fetch(`http://api.positionstack.com/v1/reverse?access_key=10fb594a161b7d49b1a373d4ded8ea4c&query=${lat},${lng}`)
        .then(response => response.json())
        .then(data => getLocation(data.data[0].region));

}




function getLocation(city) {
    fetch(`https://api.weatherapi.com/v1/current.json?key=ac1763cd50fd42cd9fe131850210912&q=${city}`)
        .then(response => response.json())
        .then(data => updated(data));
}
function updated(data) {
    document.querySelector(".weather").innerHTML = `
        
        <div style=" display: flex;"> 
        <img src="${data.current.condition.icon}" alt="">
        <div style=" display: flex; flex-direction: column;">
           <p>${data.current.temp_c}ْC</p>
           <p>${data.current.condition.text}</p>
        </div>
        </div>
        <div class="temp">
        <p>% ${data.current.humidity}:رطوبة</p> 
        <p> ${data.current.last_updated}: اخر تحديث</p>
        <p>${data.current.pressure_mb}mb :الضغط</p>
        <p> ${data.current.wind_degree}${data.current.wind_dir}:الرياح</p>
        </div>
        `;
    console.log(true);
}