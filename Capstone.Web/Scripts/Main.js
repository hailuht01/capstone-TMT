var map;
var APIKey = "AIzaSyCPzAfumWS9n3IJ-PGos47STA1mp4QuLZQ";

var landmarkArr = [];
var activeItinIdIndex;
var prevItinIdIndex;


$("document").ready(function () {
    initMap();
    $('#createItinForm').hide();
    $('#landmark-list').hide();

});

function initMap() {
    //Map Options
    var options = {
        zoom: 13,
        center: { lat: 39.103118, lng: -84.512020 },
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
        $('.landmark-detail').modal('show');
        console.log(props.placeId);

        $('.modal-title').text(props.name);
        genLandmarkModalHTML(props.placeId, props.description);

    });
}



function toggleActiveItin(itinId) {
    activeItinIdIndex = itinId;
    console.log("prev itin: " + prevItinIdIndex);
    console.log("active itin: " + activeItinIdIndex);
    $('#Itin-' + activeItinIdIndex + '>#activeItin').show();
    if (activeItinIdIndex != prevItinIdIndex) {
        $('#Itin-' + prevItinIdIndex + '>#activeItin').hide();
    }

    prevItinIdIndex = activeItinIdIndex;

    $('#map-container').hide();
    $('#landmark-list').show();

}

function addToItin(idStr) {
    //$("#markerPlaceId").value();
    {

        if (!landmarkArr.includes(idStr)) {
            landmarkArr.push(idStr);
            console.log("add to itin: " + idStr + "  itin: " + activeItinIdIndex);
            console.warn(landmarkArr);
        } else { console.log("already in itin land:" + idStr + "  itin: " + activeItinIdIndex) }
        $('.landmark-detail').modal('hide');

    }

}

function createItin(newIndex) {
    $('#Itin-' + activeItinIdIndex + '>#activeItin').hide();
    $('#Itin-' + prevItinIdIndex + '>#activeItin').hide();
    activeItinIdIndex = newIndex;
    console.log("create itin new index" + activeItinIdIndex);
    $('#createItinForm').show();
}

function saveItin(activeItinId, itinArr) {

}

function removeLandmark(i) {
    if (landmarkArr.length >= i - 1) {
        landmarkArr.splice(i, 1);
        console.log("removed landmark index= " + i);
    }
}

function removeItinerary(i) {
    if (landmarkArr.length >= i - 1) {
        confirm("Permanately Delete this Itinerary?");
        landmarkArr.splice(i, 1);
        console.log("removed Itin index= " + i);
    }
}


function ShowModal(props) {

    //Add Modal Detail

    //$('.landmark-item>').addListener('click', function () {
    // $('#landmark-detail').modal('show');

    $('.landmark-detail').modal('show');
    console.log(props.placeId);

    $('.modal-title').text(props.name);
    genLandmarkModalHTML(props.placeId, props.description);

    //});
}

function genLandmarkModalHTML(Id, description) {
    var detailRequest = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + Id + "&key=" + APIKey;

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
            //phone = (phone == "undefined") ? "No Phone Number" : phone;
            var now = new Date();
            var days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
            var day = days[now.getDay()];

            var todaysHours; // html var
            try {
                todaysHours = j.opening_hours['weekday_text'][days.indexOf(day)];
            } catch (Exception) { console.warn("no open time for this place") }


            var photoReference = j['photos'][0].photo_reference;

            var photoQuery = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" + photoReference + "&key=" + APIKey;


            $('.modal-body').html(`
<div class="row">
<div class='col-sm-12 col-6'><img src='${photoQuery}'/></div><div class='col-sm-12 col-6'><b>Departure Date ${todaysHours}</b></div>

<div class='col-sm-6 col-6'><b>${phone}</b></div> <div class='col-sm-6 col-3'><h5><a href='${website}' target="_blank">Website</a></h5></div>



</div>
<h5>Description:</h5><p>${description}</p>
`);
        })

        .fail(function (data) {
            console.error("ajax fail" + error);
            ('.modal-body').html("Offline Error");
        });
}





























