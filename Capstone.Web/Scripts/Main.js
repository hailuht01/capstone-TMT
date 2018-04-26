var map;

$("document").ready(function () {
    initMap()
})

function initMap() {
    //Map Options
    var options = {
        zoom: 10,
        center: { lat: 39.103118, lng: -84.512020 },
        clickableIcons: true,
        gestureHandling: 'auto',
    }

    map = new google.maps.Map(document.getElementById('map'), options);
}

function toggleBounce() {
    if (marker.getAnimation() != null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

function AddMarker(props) {

    //Add Marker
    var marker = new google.maps.Marker({
        map: map,
        draggable: false,
        animation: google.maps.Animation.DROP,
        position: { lat: 39.1100, lng: 84.5378 },
    });

    //Add InfoWindow
    var infoWindow = new google.maps.InfoWindow({
        content: '<h3>Cincinnati Museum</h3>'
    });
    marker.addListener('mouseover', function () {
        infoWindow.open(map, marker);
    });
    marker.addListener('mouseout', function () {
        infoWindow.close();
    });

    //Add Modal Detail
    marker.addListener('click', function () {
        $('#landmark-detail').modal('show');
    });
}