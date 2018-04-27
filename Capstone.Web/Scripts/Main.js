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
  var windowHtml = `<h3>${props.name}</h3>
                        <p>${props.address}</p>
                        <p>${props.description}</p>
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
      var detailQuery = "https://maps.googleapis.com/maps/api/place/details/json?placeid=ChIJi77WfdCzQYgRGbJHVBDHy-g&key=" + APIKey;
      $('#landmark-detail').modal('show');
      console.log(props.placeId);
      var modalHTML = `Description: ${props.description}`;
      $('.modal-title').text(props.name)
      $('.modal-body').text(modalHTML);
    });
}

function addToItin(placeId) {
  itinArr.push(placeId);
  console.log("lana del rey" + placeId);
}

$('#addToItin').addListener('click', function () {
  addToItin(marker.placeId);

});