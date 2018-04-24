//$(document).ready(function () {

<<<<<<< HEAD
//    $("#registerform").validate({
        
//        rules: {
//            UserName: {
//                required: true
//            },
//            FirstName: {
//                required: true
//            },
//            LastName: {
//                required: true,
//                minlength: 2,
//                lettersonly: true
//            },
//            Email: {
//                email: true,
//                required: true
//            },
//            Password: {
//                required: true,
//                minlength: 8,
//                strongPassword: true
//            },
//            VerifyPassword: {
//                equalTo: "#password"
//            }
//        },
//        messages: {
//            fName: "First Name is required",
//            lName: {
//                required: "Last Name is required",
//                minlength: "Last Name must be at least 2 charactors long."
//            }
//        },
//        errorClass: "error",
//        validClass: "valid"
//    });
=======
    $("#registerform").validate({
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
>>>>>>> e3f9e29046041002b5bef2a4cff8a06efe08bb58

//    $.validator.addMethod("strongPassword", function(value, element, params) {
//        return value.match(/[A-Z]/) && value.match(/[a-z]/) && value.match(/\d/);
//    }, "Must enter a strong password (one upper and one lower case letter plus a number)");
//})
