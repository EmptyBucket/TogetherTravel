require("./map.css");
var MarkerClusterer = require("exports-loader?MarkerClusterer!markerclusterer");
var ClusterMarkerImageUrl = require("./content/m1.png");
ClusterMarkerImageUrl = ClusterMarkerImageUrl.slice(0, ClusterMarkerImageUrl.length - 5);
var RequireContext = require.context("./content", false, /m[2-5]\.png$/);
RequireContext.keys().map(RequireContext);

export default function Map(options) {
    const mapElem = options.elem;
    const googleApiKey = options.googleApiKey;
    const usersUrl = options.usersUrl;
    const markerClick = options.markerClick;
    const markers = [];

    function initMap() {
        var map = new google.maps.Map(mapElem, {
            zoom: 2,
            MapTypeId: google.maps.MapTypeId.SATELLITE,
            maxZoom: 10,
            minZoom: 2,
            center: { lat: 0, lng: 0}
        });

        navigator.geolocation.getCurrentPosition(function(e) {
            const center = { lat: e.coords.latitude, lng: e.coords.longitude };
            map.setCenter(center);
            const marker = new google.maps.Marker({
                position: center,
                map: map,
                draggable: false,
                label: "Вы"
            });
            markers.push(marker);
        });

        $.post(usersUrl,
            function(e) {
                const usersMarkers = e.map(user => new google.maps.Marker({
                    position: { lat: user.LatitudeCoord, lng: user.LongitudeCoord },
                    label: user.FirstName + " " + user.SecondName,
                    draggable: false
                }));
                Array.prototype.push.apply(markers, usersMarkers);
                const clustererMarker = new MarkerClusterer(map, usersMarkers,
                    {
                        imagePath: ClusterMarkerImageUrl
                    });
                markers.forEach(item => {
                    item.addListener("click", markerClick);
                });
            });
    }

    function render() {
        mapElem.classList.add("map");

        const src = "https://maps.googleapis.com/maps/api/js?key=" + googleApiKey + "&callback=initMap";

        const googleApiScript = document.createElement("script");
        googleApiScript.src = src;
        googleApiScript.defer = true;
        googleApiScript.async = true;

        window.initMap = initMap;
        document.body.append(googleApiScript);
    }

    render();
}