var map;
var APIKey = "AIzaSyCPzAfumWS9n3IJ-PGos47STA1mp4QuLZQ";
var itinArr = [];

$("document").ready(function () {
    initMap();
})

function initMap() {
    //Map Options
    var options = {
        zoom: 10,
        center: {lat: 39.103118, lng: -84.512020},
        clickableIcons: true,
        gestureHandling: 'auto',
    }

    map = new google.maps.Map(document.getElementById('map'), options);
}

function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

function AddMarker(props) {
    var windowHtml = `<h3>${props.name}</h3>
                        <p>${props.address}</p>
                        <p>${props.description}</p>
                        <p>${props.placeId}</p>
                        <input id="markerPlaceId" type="hidden" value="${props.placeId}"/>
`;
    //Add Marker
    var marker = new google.maps.Marker({
        map: map,
        draggable: false,
        animation: google.maps.Animation.DROP,
        position: props.coords,
    });

    //Add InfoWindow
    var infoWindow = new google.maps.InfoWindow({
        content: windowHtml
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
        console.log(props.placeId);
        var modalHTML = `Description: ${props.description}`;
        $('.modal-title').text(props.name);

        var modalHTML = genLandmarkModalHTML(props.placeId);
        $('.modal-body').text(modalHTML);
    });
}

function addToItin() {
    $("#markerPlaceId").value();
    itinArr.push();
    console.log("add to itin");
}

$('#addToItin').addListener('click', function () {
    addToItin(marker.placeId);

});

function genLandmarkModalHTML(placeId) {
    var detailRequest = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + placeId + "&key=" + APIKey;
    //var photoQuery = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference="+photoReference+"&key=" + APIKey;
    var modalHTML = "not assigned";
    $.ajax({
        url: detailRequest,
        type: "GET",
        dataType: "text"
    })
        .done(function (data) {
            console.log("ajax Detail placeID: " + placeId);
            json = JSON.parse(data);
            console.log(json["result"].name);
        })

        .fail(function (data) {
            console.error("ajax fail" + error);
        });


    return modalHTML;
}





























