var map;
var APIKey = "AIzaSyCPzAfumWS9n3IJ-PGos47STA1mp4QuLZQ";
var itinArr = [];
var activeItinId;
var prevItinId;


$("document").ready(function () {
    initMap();
    $('#createItinForm').hide();
    $("element[id$='Itin-']>#activeItin")
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
        genLandmarkModalHTML(props.placeId, props.description);

    });
}

function toggleActiveItin(itinId){
    activeItinId = itinId;
    console.log("prev itin: " + prevItinId);
    console.log("active itin: " + activeItinId);
    $('#Itin-'+activeItinId+'>#activeItin').show();
    if(activeItinId != prevItinId) {
        $('#Itin-' + prevItinId + '>#activeItin').hide();
    }

    prevItinId = activeItinId;

}

function addToItin(placeIdStr, activeItinId) {
    //$("#markerPlaceId").value();
    {
        itinArr.push(placeIdStr);
        console.log("add to itin: " + placeIdStr);
        console.warn(itinArr);
    }
}

function createItin()
{
    console.log("create itin");
    $('#createItinForm').show();
}

function saveItin(activeItinId, itinArr)
{

}

function removeLandmark(i)
{
    if(itinArr.length >= i-1) {
        itinArr.splice(i, 1);
        console.log("removed landmark index= "+ i);
    }
}

function genLandmarkModalHTML(Id, description) {
    var detailRequest = "https://maps.googleapis.com/maps/api/place/details/json?placeid="+Id+"&key=" + APIKey;

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
            var days = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'];
            var day = days[ now.getDay() ];

            var todaysHours; // html var
            try   {
                todaysHours = j.opening_hours['weekday_text'][days.indexOf(day)];
            }catch(Exception){console.warn("no open time for this place")}


            var photoReference = j['photos'][0].photo_reference;

            var photoQuery = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference="+photoReference+"&key=" + APIKey;


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






























