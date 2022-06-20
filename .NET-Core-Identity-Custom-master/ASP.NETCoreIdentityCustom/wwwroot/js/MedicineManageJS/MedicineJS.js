$(document).ready(function () {
    //This method pass WhereClause And OrderBy to get Data
    UserDataTableFill("", "");
    
    $("#TxtMedicineSearch").keyup(function () {
        UserDataTableFill("", "Where M_Name like '%" + $(this).val().trim() + "%'");
    });

    //Flag declaration
    var TxtMedicineNameFlag = false, TxtManufacturerFlag = false, TxtPriceFlag = false, TxtStockFlag = false;

    var specialKeys = new Array();
    specialKeys.push(8);
    specialKeys.push(9);
    specialKeys.push(46);

    specialKeys.push(16);
    specialKeys.push(20);

    specialKeys.push(37);
    specialKeys.push(39);

    // This is Edit method declaration for update record
    $(document).on('click', '.EditMedicine', function () {
        UserDataTableFill($(this).attr('data-UserMedicineEdit').trim(), "Where m_Id=");
    });

    // This is Delete Method Declaration.....
    $(document).on('click', '.DeleteCLS', function () {
        if (confirm("Are You Sure To Delete Record..??")) {
            DeleteMedicine(parseInt($(this).attr('data-DeleteMedicineId')));
        }
        else {
            
        }
    })



    //Validation For Medicine Name
    $("#TxtMedicineName").bind("blur", function (e) {
        if ($("#TxtMedicineName").val() == "") {
            TxtMedicineNameFlag = false;
            $("#TxtMedicineNameValidate").empty();
            $("#TxtMedicineNameValidate").html('*Please Enter Medicine Name..!!');
        }
        else {

            $("#TxtFNameValidate").empty();
            TxtMedicineNameFlag = true;
        }
    });

    //Validation For Manufacturer Name
    $("#TxtManufacturerName").bind("blur", function (e) {
        if ($("#TxtManufacturerName").val() == "") {
            TxtManufacturerFlag = false;
            $("TxtManufacturerNameValidate").empty();
            $("#TxtManufacturerNameValidate").html('*Please Enter Manufacturer Name..!!');
        }
        else {

            $("#TxtManufacturerNameValidate").empty();
            TxtManufacturerFlag = true;
        }
    });


    //Validation For Price 
    $("#TxtPrice").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtPriceValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtPrice").bind("blur", function (e) {
        $("#TxtPriceValidate").empty();
        if ($("#TxtPrice").val() == '') {
            TxtPriceFlag = false;
            $("#TxtPrice").html('(*) Price Required..!!');
        }
        else {

            $("#TxtPriceValidate").empty();
            TxtPriceFlag = true;
        }

        return TxtPriceFlag;
    });

    //Validation For Price
    $("#TxtStock").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtStockValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtStock").bind("blur", function (e) {
        $("#TxtStockValidate").empty();
        if ($("#TxtStock").val() == '') {
            TxtStockFlag = false;
            $("#TxtStockValidate").html('(*) Price Required..!!');
        }
        else {

            $("#TxtStockValidate").empty();
            TxtStockFlag = true;
        }

        return TxtStockFlag;
    });


    //Click Event Validation....
    $("#BtnUpdateRecord").click(function () {
        if ($("#TxtMedicineName").val() == "") {
            TxtMedicineNameFlag = false;
            $("#TxtMedicineNameValidate").empty();
            $("#TxtMedicineNameValidate").html('*Please Enter Medicine Name..!!');
        }
        else {

            $("#TxtFNameValidate").empty();
            TxtMedicineNameFlag = true;
        }

        if ($("#TxtManufacturerName").val() == "") {
            TxtManufacturerFlag = false;
            $("TxtManufacturerNameValidate").empty();
            $("#TxtManufacturerNameValidate").html('*Please Enter Manufacturer Name..!!');
        }
        else {

            $("#TxtManufacturerNameValidate").empty();
            TxtManufacturerFlag = true;
        }

        if ($("#TxtPrice").val() == '') {
            TxtPriceFlag = false;
            $("#TxtPriceValidate").html('(*) Price Required..!!');
        }
        else {

            $("#TxtPriceValidate").empty();
            TxtPriceFlag = true;
        }

        if ($("#TxtStock").val() == '') {
            TxtStockFlag = false;
            $("#TxtStockValidate").html('(*) Stock Required..!!');
        }
        else {

            $("#TxtStockValidate").empty();
            TxtStockFlag = true;
        }

        //All condition will true then it will execute
        if (TxtMedicineNameFlag == true && TxtManufacturerFlag == true && TxtPriceFlag == true && TxtStockFlag == true) {
            //Calling Update Record Fucntion
            UpdateRecord();

        }
        else {
            
        }
    });

});


//This is Get Data Method to print data
function UserDataTableFill(orderby, whereclause) {
    debugger
    $.ajax({
        type: "GET",
        url: "/Medicine/MedicineManage1",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //debugger
            if (whereclause == 'Where m_Id=') {
                $("#TxtMedicineName").val(response.data[0].m_Name);
                $("#TxtManufacturerName").val(response.data[0].m_Manufacturer);
                $("#TxtPrice").val(response.data[0].m_Price);
                $("#TxtDate").val(response.data[0].m_Date);
                $("#TxtStock").val(response.data[0].stock);
                $("#BtnUpdateRecord").attr('EditMedicineId', response.data[0]["m_Id"]);
            }
            else {
                $("#table14 tbody").empty();
                for (var i = 0; i < response.data.length; i++) {
                    var tr_str = '';

                    tr_str = "<tr class='datatable-row' id=" + response.data[i]["m_Id"] + ">" +
                        "<td class='datetable-cell'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:100px'>" + response.data[i]["m_Name"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:70px'>" + response.data[i]["m_Manufacturer"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["m_Price"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["m_Date"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["stock"] + "</span></td>" +
                        "<td class='datetable-cell'><a data-UserMedicineEdit=" + response.data[i]["m_Id"] + " class='EditMedicine' data-toggle='modal' data-target='#EditMedicineRecord'><i class='fa fa-2x fa-edit'></i></a></td > " +
                        "<td class='datetable-cell'><a data-DeleteMedicineId=" + response.data[i]["m_Id"] + " class='DeleteCLS'><i class='fa fa-2x fa-times-circle'></i></a></td > " +
                        "</tr>";

                    $("#table14 tbody").append(tr_str);
                }
            }
        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }
    });
}

// Method to Update Record Get
function UpdateRecord() {
    debugger
    var medicine = new Object();
    medicine.M_Id = ($("#BtnUpdateRecord").attr('EditMedicineId'));
    medicine.M_Name = $("#TxtMedicineName").val().trim();
    medicine.M_Manufacturer = $("#TxtManufacturerName").val().trim();
    medicine.M_Price = $("#TxtPrice").val().trim();
    medicine.M_Date = $("#TxtDate").val().trim();
    medicine.Stock = $("#TxtStock").val().trim();
    debugger
    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Medicine/AddMedicine",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(medicine),
        success: function (response) {
            if (response.success = "success") {
                alert("data Updated Successfully");
                $("input").val("");
                UserDataTableFill("", "");
                $("#EditMedicineRecord .close").click();
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};

// Method to Delete Record
function DeleteMedicine(id) {
    debugger
    var obj = new Object();
    obj.M_Id = id;
    $.ajax({
        url: "/Medicine/DeleteMedicine",
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify(obj),
        success: function () {
            alert("Data Deleted....");
            UserDataTableFill("", "");
        },
        error: function (jqXHR, textStatus, err) {
            alert('text status ' + textStatus + ', err ' + err)
        }
    });

    return true;
}