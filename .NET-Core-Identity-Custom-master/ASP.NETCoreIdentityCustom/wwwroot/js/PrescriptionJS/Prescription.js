$(document).ready(function () {
    PrescriptionDataTableFill("", "");
});


//Function called after page reload.....
function PrescriptionDataTableFill(orderby, whereclause) {
    //Ajax call for print data dynamically when it call....
    $.ajax({
        type: "GET",
        url: "/PrescriptionView/ViewPrescription",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //debugger
            $("#tblP1 tbody").empty();
            for (var i = 0; i < response.data.length; i++) {
                var tr_str = '';
                tr_str = "<tr class='datatable-row' id=" + response.data[i]["presc_id"] + ">" +
                    "<td class='datetable-cell'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:100px'>" + response.data[i]["prescr_Date"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:70px'>" + response.data[i]["patientId"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["firstname"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["lastname"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["medicineName"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["quantity"] + "</span></td>" +
                    "</tr>";
                $("#tblP1 tbody").append(tr_str);
            }
        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }
    });
}