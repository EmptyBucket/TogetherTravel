require("./map.css");
var MarkerClusterer = require("exports-loader?MarkerClusterer!markerclusterer");
var ClusterMarkerImageUrl = require("./content/m1.png");
ClusterMarkerImageUrl = ClusterMarkerImageUrl.slice(0, ClusterMarkerImageUrl.length - 5);
var RequireContext = require.context("./content", false, /m[2-5]\.png$/);
RequireContext.keys().map(RequireContext);

export default function(options) {
    const elem = options.elem;
    const usersMarkers = [];

    function initMap() {
        var map = new window.google.maps.Map(elem, {
            zoom: 5,
            MapTypeId: window.google.maps.MapTypeId.SATELLITE,
            minZoom: 3,
            center: { lat: 0, lng: 0}
        });

        navigator.geolocation.getCurrentPosition(function(e) {
            const center = { lat: e.coords.latitude, lng: e.coords.longitude };
            map.setCenter(center);
            const marker = new window.google.maps.Marker({
                position: center,
                map: map,
                draggable: false,
                label: "Вы"
            });
            usersMarkers.push(marker);
        });

        fetch(options.usersUrl, { method: "POST" })
            .then(response => response.json())
            .then(array => {
                return array.map(user => {
                var marker = new window.google.maps.Marker({
                    position: {
                        lat: user.LatitudeCoord,
                        lng: user.LongitudeCoord
                    },
                    label: user.FirstName + " " + user.SecondName,
                    draggable: false
                });
                marker.set("userId", user.Id);
                return marker;
            }); })
            .then(function (e) {
                usersMarkers.push(...e);
                const markerClusterer = new MarkerClusterer(map, usersMarkers,
                    {
                        imagePath: ClusterMarkerImageUrl
                    });
                usersMarkers.forEach(item => item.addListener("click", options.markerClick));
            });
    }

    function render() {
        elem.classList.add("map");

        const src = `https://maps.googleapis.com/maps/api/js
?key=${options.googleApiKey}&callback=initMap`;

        const googleApiScript = document.createElement("script");
        googleApiScript.src = src;
        googleApiScript.defer = true;
        googleApiScript.async = true;

        window.initMap = initMap;
        document.body.append(googleApiScript);
    }

    render();
}