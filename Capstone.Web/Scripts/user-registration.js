$(document).ready(function () {

    $("#registerform").validate({
        debug: false,
        rules: {
            UserName: {
                required: true
            },
            FirstName: {
                required: true
            },
            LastName: {
                required: true,
                minlength: 2,
                lettersonly: true
            },
            Email: {
                email: true,
                required: true
            },
            Password: {
                required: true,
                minlength: 8,
                strongPassword: true
            },
            VerifyPassword: {
                equalTo: "#Password"
            }
        },
        messages: {
            UserName: {
                required: "Please Enter User Name"
            },
            FirstName: {
                required: "First Name is required."
            },
            LastName: {
                required: "Last Name is required",
                minlength: "Last Name must be at least 2 characters long."
            },
            Email: {
                email: "Please enter valid email address",
                required: "Email address required"
            },
            Password: {
                required: "Please enter valid password"
            },
            VerifyPassword: {
                equalTo: "Passwords must match"
            }
        },
        errorClass: "error",
        validClass: "valid"
    });

    $("#loginform").validate({
        debug: false,
        rules: {
            Email: {
                email: true,
                required: true
            },
            Password: {
                required: true,
            },
        },
        messages: {
            Email: {
                email: "Please enter valid email address",
                required: "Email address required"
            },
            Password: {
                required: "Please enter valid password"
            },
        },
        errorClass: "error",
        validClass: "valid"
    });



    $.validator.addMethod("strongPassword", function(value, element, params) {
        return value.match(/[A-Z]/) && value.match(/[a-z]/) && value.match(/\d/);
    }, "Must enter a strong password (one upper and one lower case letter plus a number)");
})
