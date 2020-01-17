
function showlocation() {
    // One-shot position request.
    navigator.geolocation.getCurrentPosition(callback);
}

function callback(position) {
    document.getElementById('latitude').innerHTML = position.coords.latitude;
    document.getElementById('longitude').innerHTML = position.coords.longitude;
}

