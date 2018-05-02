var WEBAPI_BASE_URL = "http://localhost:55601/api/";

// This example adds a search box to a map, using the Google Place Autocomplete
// feature. People can enter geographical searches. The search box will return a
// pick list containing a mix of places and predicted search terms.

// This example requires the Places library. Include the libraries=places
// parameter when you first load the API. For example:
// <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">
var map;

function initAutocomplete() {
    map = new google.maps.Map(document.getElementById('map'),
        {
            zoom: 13,
            center: { lat: 39.103118, lng: -84.512020 },
            clickableIcons: true,
            gestureHandling: 'auto',
            mapTypeId: 'roadmap'
        });

    // Create the search box and link it to the UI element.
    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    var markers = [];
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }

        // Clear out the old markers.
        markers.forEach(function (marker) {
            marker.setMap(null);
        });
        markers = [];

        // For each place, get the icon, name and location.
        var bounds = new google.maps.LatLngBounds();
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }
            
            service = new google.maps.places.PlacesService(map);

            markers.forEach(function (marker) {
                marker.addListener('click', function (event) {
                    var request = { placeId: place.place_id };
                    service.getDetails(request, function (result, status) {
                        if (status !== google.maps.places.PlacesServiceStatus.OK) {
                            console.error(status);
                            return;
                        }
                        $("#LandmarkCreate input").val("");
                        $('#Latitude').val(event.latLng.lat);
                        $('#Longitude').val(event.latLng.lng);
                        $('#PlaceId').val(result.place_id);
                        $('#Address').val(result.formatted_address);
                        $('#Name').val(result.name);
                        $('#Type').val(result.types.toString());
                    });


                    
                });
            });

            // Create a marker for each place.
            markers.push(new google.maps.Marker({
                map: map,
                title: place.name,
                position: place.geometry.location
            }));

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });
        map.fitBounds(bounds);
    });
}
