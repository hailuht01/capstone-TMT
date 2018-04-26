$("document").ready(function () {
    $.ajax({
        url: "www.google.com/maps/embed/v1/directions?origin=Tate+Modern&destination=Tower+of + London & waypoints=Ministry+of + sound & key=AIzaSyCPzAfumWS9n3IJ-PGos47STA1mp4QuLZQ",
        method: "get",
        dataType: "json",
    }).done(function (results) {

    })
})

function getLandmarks() {
    var baseURL = 
}