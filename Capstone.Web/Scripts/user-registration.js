$(document).ready(function () {

    $("#registerform").validate({
        debug: true,
        rules: {
            fName: {
                required: true
            },
            lName: {
                required: true,
                minlength: 2,
                lettersonly: true
            },
            email: {
                email: true,

            },
            password: {
                required: true,
                minlength: 8,
                strongPassword: true
            },
            verifyPassword: {
                equalTo: "#password"
            }
        },
        messages: {
            fName: "First Name is required",
            lName: {
                required: "Last Name is required",
                minlength: "Last Name must be at least 2 charactors long."
            }
        },
        errorClass: "error",
        validClass: "valid"
    });

    $.validator.addMethod("strongPassword", function(value, element, params) {
        return value.match(/[A-Z]/) && value.match(/[a-z]/) && value.match(/\d/);
    }, "Must enter a strong password (one upper and one lower case letter plus a number)");
})
