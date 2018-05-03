var map;
var APIKey = "AIzaSyB6eN6z5EglebAQuE7RNTeid-SM2cvdIOM";

var landmarkArr = [];
var activeItinIdIndex;
var prevItinIdIndex;
var mapToggle=true;






if(!localStorage.getItem('genRoute') == true || localStorage.getItem('genRoute') == null) {

    $("document").ready(function () {
        $('#createItinForm').hide();
        $('#landmark-list').hide();
        initMap();



    });

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







}else{ // gen route
    $("document").ready(function () {
        $('#createItinForm').hide();
        $('#landmark-list').hide();
        initMap();


        calculateAndDisplayRoute(directionsService, directionsDisplay);
        localStorage.setItem('genRoute', false)

    });



    function initMap() {
         directionsService = new google.maps.DirectionsService;
         directionsDisplay = new google.maps.DirectionsRenderer;
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 13,
            center: {lat: 39.103118, lng: -84.512020},
        });
        directionsDisplay.setMap(map);
        calculateAndDisplayRoute(directionsService,directionsDisplay);

    }

    function calculateAndDisplayRoute(directionsService, directionsDisplay) {
        var waypts = [];
        var checkboxArray = localStorage.getItem('placeIds').replace('  ', ' ').split(' ');

        for (var i = 0; i < checkboxArray.length; i++) {
            if (checkboxArray[i].length < 5) {
                checkboxArray.splice(i, 1);
            }
        }
        for (var i = 0; i < checkboxArray.length; i++) {

                if(i == 0){
                   var origin = checkboxArray[i]
                }
                waypts.push({
                    stopover: true,
                    location:{'placeId': checkboxArray[i]}

                });
                if(i == checkboxArray.length-1){
                    var destination = checkboxArray[i]
                }

           // console.log(waypts[i].location);
        }
        waypts.shift();
        waypts.pop();

        directionsService.route({
         //   origin: {
         //       'placeId': 'ChIJb4LYpVCxQYgRO54lkCeetLY'},
         //   destination: {
         //       'placeId': 'ChIJV0h_FdyzQYgR2CacE0p1ai8'},
         //   waypoints:[{
         //       stopover: true,
         //       location: {
         //           'placeId':"ChIJkV51b2exQYgRLmkA6uJ5Hpo"
         //       }
         //   }],

            origin: {
                'placeId': origin},
            destination: {
                'placeId': destination},
            waypoints:waypts,
            optimizeWaypoints: true,
            travelMode: 'DRIVING'
        }, function(response, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(response);
                var route = response.routes[0];
                var summaryPanel = document.getElementById('directions-panel');
                summaryPanel.innerHTML = '';
                // For each route, display summary information.
                for (var i = 0; i < route.legs.length; i++) {
                    var routeSegment = i + 1;
                    summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment +
                        '</b><br>';
                    summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                    summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                    summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
                }
            } else {
                window.alert('Directions request failed due to ' + status);
            }
        });
    }
    //genRoute=false;
    localStorage.setItem("genRoute", false);
}
function generateRoute(placeIdStr)
{

    localStorage.setItem("placeIds", placeIdStr);
    console.log(localStorage.getItem('placeIds'));
    localStorage.setItem("genRoute", true);
    location.reload();

}

function AddMarker(props) {
    var windowHtml = `<h3>${props.name}</h3>
                        <p>${props.address}</p>
                        <p>${props.description}</p>
                        <input id="markerId" type="hidden" value="${props.placeId}"/>
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
        $('#landmark-detail-' + props.id).modal('show');


        $('.modal-title').text(props.name);

        genLandmarkModalHTML(props);

    });
}
















function ShowModal(props) {

    $(`#landmark-detail-${props.id}`).modal('show');
    $('#landmark-detail').modal('show');
    console.log(props.placeId);

    $("#modal-title-" + props.id).text(props.name);
    genLandmarkModalHTML(props);

}

function genLandmarkModalHTML(props) {
    var detailRequest = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + props.placeId + "&key=" + APIKey;

    $.ajax({
        url: detailRequest,
        type: "GET",
        dataType: "text"
    })
        .done(function (data) {
            console.log("ajax Detail placeID: " + props.placeId);
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
            } catch (Exception) {
                console.warn("no open time for this place")
            }


            var photoReference = j['photos'][0].photo_reference;

            var photoQuery = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" + photoReference + "&key=" + APIKey;


            $("#modal-body-" + props.id).html(`
<div class="row">
<div class='col-sm-12 col-6'><img src='${photoQuery}'/></div><div class='col-sm-12 col-6'><b></b></div>

<div class='col-sm-6 col-6'><b>${phone}</b></div> <div class='col-sm-6 col-3'><h5><a href='${website}' target="_blank">Website</a></h5></div>



</div>
<h5>Description:</h5><p>${props.description}</p>
`);
        })

        .fail(function (data) {
            console.error("ajax fail" + error);
            ("#modal-body-" + props.id).html("Offline Error");
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

function toggleMap() {
    var hide = '';
    var show = '';

    if (mapToggle) {
        hide = '#map-container';
        show = '#landmark-list';
        mapToggle = false;
    }
    else {
        hide = '#landmark-list';
        show = '#map-container';
        mapToggle = true;
    }

    $(hide).hide();
    $(show).show();
}

function addToItin(idStr, name) {
    //$("#markerPlaceId").value();
    {

        if (!landmarkArr.includes(idStr)) {
            landmarkArr.push(idStr);
            console.log("add to itin: " + idStr + "  itin: " + activeItinIdIndex);
            console.warn(landmarkArr);

            $('#itin-landmark-array-' + activeItinIdIndex).val(function () {
                return this.value + " " + idStr
            })

            var landmarkHTML = `<div class=' col-8 btn-success round border' id='itin-landitem-id-${idStr}' data-value='${idStr}' onclick="removeLandmark(${idStr})">${name}</div>`;

            $('#activeItin').append(landmarkHTML);

        } else {
            console.log("already in itin land:" + idStr + "  itin: " + activeItinIdIndex)
        }
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

function removeLandmark(idStr) { // remove from value and hide div
//var val = document.getElementById('demo').getAttribute('data-value');
    $('#itin-landmark-array-' + activeItinIdIndex).val(function () {
        console.log("old " + this.value + "new" + this.value.replace(idStr, ''));
        return this.value.replace(idStr, '');
    });

    $('#itin-landitem-id-' + idStr).hide()

}

function removeItinerary(i) {
    if (landmarkArr.length >= i - 1) {
        confirm("Permanately Delete this Itinerary?");
        landmarkArr.splice(i, 1);
        console.log("removed Itin index= " + i);
    }
}


































