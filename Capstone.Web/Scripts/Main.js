var map;
var APIKey = "AIzaSyCPzAfumWS9n3IJ-PGos47STA1mp4QuLZQ";
var itinArr = [];
var modalHTML;

$("document").ready(function () {
    initMap();
})

function initMap() {
    //Map Options
    var options = {
        zoom: 13,
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

        $('.modal-title').text(props.name);

        modalHTML = genLandmarkModalHTML(props.placeId, props.description);
        $('.modal-body').html(modalHTML);
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

function genLandmarkModalHTML(Id, description) {
    var detailRequest = "https://maps.googleapis.com/maps/api/place/details/json?placeid="+Id+"&key=" + APIKey;
    //var photoQuery = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference="+photoReference+"&key=" + APIKey;

    $.ajax({
        url: detailRequest,
        type: "GET",
        dataType: "text"
    })
        .done(function (data) {
            console.log("ajax Detail placeID: " + Id);
            json = JSON.parse(data);
            var j = json['result'];

            var website = j.website;  // html var
            var phone = j.formatted_phone_number;
            var now = new Date();
            var days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
            var day = days[ now.getDay() ];

            var todaysHours; // html var
            try   {
                todaysHours = j.opening_hours['weekday_text'][days.indexOf(day)];
            }catch(Exception){console.warn("no open time for this place")}

            console.log(todaysHours + "hrs" + phone);


             modalHTML = `
<div class="row">
<div class='col-4'><img src=''</div><div class='col-3'><b>Hours: ${todaysHours}</b></div><div class='col-3'><b>${phone}</b></div> <div class='col-2'><h5><a href='${website}' target="_blank">Landmark Website</a></h5></div>



</div>
<h5>Description:</h5><p>${description}</p>
`
        })

        .fail(function (data) {
            console.error("ajax fail" + error);
        });


    return modalHTML;
}






























