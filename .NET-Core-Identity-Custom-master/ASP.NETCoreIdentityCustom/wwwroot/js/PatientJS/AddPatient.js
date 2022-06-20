$(document).ready(function () {
    //alert("ready");

    var $FNameLNameRegEx = /^([a-zA-Z]{2,20})$/;
    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
    var $ConNoRegEx = /^([0-9]{10})$/;

    var TxtFNameFlag = false, TxtLNameFlag = false, TxtEmailIdFlag = false, TxtAddressFlag = false, TxtContactNoFlag = false, TxtSymtomsFlag = false;

    $("#TxtFName").bind("keypress", function (e) {
        var keyCode = e.which;
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122));
        $("#TxtFNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    })

    $("#TxtFName").bind("blur", function (e) {
        if ($("#TxtFName").val() == "") {
            TxtFNameFlag = false;
            $("#TxtFNameValidate").empty();
            $("#TxtFNameValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#TxtFNameValidate").empty();
            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
                $("#TxtFNameValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#TxtFNameValidate").empty();
                TxtFNameFlag = true;
            }
        }
    });


    $("#TxtLName").bind("keypress", function (e) {
        var keyCode = e.which;
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122));
        $("#TxtLNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtLName").bind("blur", function (e) {
        if ($("#TxtLName").val() == "") {
            TxtLNameFlag = false;
            $("#TxtLNameValidate").empty();
            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#TxtLNameValidate").empty();
            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
                $("#TxtLNameValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#TxtLNameValidate").empty();
                TxtLNameFlag = true;
            }
        }
    });

    $("#TxtEmailId").bind("blur", function (e) {
        $("#TxtEmailIdValidate").empty();
        if ($("#TxtEmailId").val() == "") {
            $("#TxtEmailIdValidate").empty();
            TxtEmailIdFlag = false;
            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
        }
        else {
            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#TxtEmailIdValidate").empty();
                TxtEmailIdFlag = true;
            }
        }
        return TxtEmailIdFlag;
    });

    $("#TxtAddress").bind("blur", function (e) {
        $("#TxtAddressValidate").empty();
        if ($("#TxtAddress").val() == "") {
            $("#TxtAddressValidate").empty();
            TxtAddressFlag = false;
            $("#TxtAddressValidate").html('(*) Address Required..!!');
        }
        else {
            if (!$("#TxtAddress").val().match()) {
                TxtAddressFlag = false;
                $("#TxtAddressValidate").html('Invalid Address..!!');
            }
            else {
                $("#TxtAddressValidate").empty();
                TxtAddressFlag = true;
            }
        }
        return TxtAddressFlag;
    });


    $("#TxtContactNo").bind("keypress", function (e) {
        var keyCode = e.which;
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtContactNoValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtContactNo").bind("blur", function (e) {
        $("#TxtContactNoValidate").empty();
        if ($("#TxtContactNo").val() == '') {
            TxtContactNoFlag = false;
            $("#TxtContactNoValidate").html('(*) Contact No Required..!!');
        }
        else {
            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
                TxtContactNoFlag = false;
                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
            }
            else {
                $("#TxtContactNoValidate").empty();
                TxtContactNoFlag = true;
            }
        }
        return TxtContactNoFlag;
    });

    $("#TxtSymptoms").bind("blur", function (e) {
        $("#TxtSymptomsValidate").empty();
        if ($("#TxtContactNo").val() == '') {
            TxtSymtomsFlag = false;
            $("#TxtSymptomsValidate").html('(*) Symtoms Required..!!');
        }
        else {
                $("#TxtSymptomsValidate").empty();
                TxtSymtomsFlag = true;
        }
        return TxtSymtomsFlag;
    });



    $("#BtnSignUp").click(function () {
        if ($("#TxtFName").val() == "") {
            $("#TxtFNameValidate").empty();
            $("#TxtFNameValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#TxtFNameValidate").empty();
            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
                $("#TxtFNameValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#TxtFNameValidate").empty();
                TxtFNameFlag = true;
            }
        }


        if ($("#TxtLName").val() == "") {
            $("#TxtLNameValidate").empty();
            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#TxtLNameValidate").empty();
            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
                $("#TxtLNameValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#TxtLNameValidate").empty();
                TxtLNameFlag = true;
            }
        }


        if ($("#TxtEmailId").val() == "") {
            $("#TxtEmailIdValidate").empty();
            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
        }
        else {
            $("#TxtEmailIdValidate").empty();
            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#TxtEmailIdValidate").empty();
                TxtEmailIdFlag = true;
            }
        }

        if ($("#TxtAddress").val() == "") {
            $("#TxtAddressValidate").empty();
            $("#TxtAddressValidate").html('(*) Address Required..!!');
        }
        else {

            $("#TxtAddressValidate").empty();
            TxtAddressFlag = true;
        }


        if ($("#TxtContactNo").val() == "") {
            $("#TxtContactNoValidate").empty();
            $("#TxtContactNoValidate").html('(*) Contact No. Required..!!');
        }
        else {
            $("#TxtContactNoValidate").empty();
            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
                TxtContactNoFlag = false;
            }
            else {
                $("#TxtContactNoValidate").empty();
                TxtContactNoFlag = true;
            }
        }

        if (TxtFNameFlag == true && TxtLNameFlag == true && TxtEmailIdFlag == true && TxtContactNoFlag == true) {
            AddPatient();
        }
        else {
            alert("Invalid Inputs..!!")
        }
    });

});


//Calling AJAX for Adding New Patient
function AddPatient() {
    var user = new Object();
    user.PatientId = 0;
    user.FirstName = $("#TxtFName").val().trim();
    user.LastName = $("#TxtLName").val().trim();
    user.EmailId = $("#TxtEmailId").val().trim();
    user.Symptoms = $("#TxtSymptoms").val().trim();
    user.Address = $("#TxtAddress").val().trim();
    user.ContactNo = $("#TxtContactNo").val().trim();
    user.IsFollowUp = $("#DDL_IsFollowUp").val().trim();
    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Patient/AddPatient",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(user),
        success: function (response) {
            if (response.success = "success") {
                alert("data Inserted Successfully");
                $("input").val("");
                $("#DDL_IsFollowUp").val("N");
                UserDataTableFill("", "");
                $("#EditPatientRecord .close").click();
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};


