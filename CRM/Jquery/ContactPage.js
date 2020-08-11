$(document).ready(function () {
    Get_Deal_owner();
    Get_Deal();
    //Get_Ticketowner();
});

function Get_Ticketowner() {
    $.ajax({
        type: "GET",
        url: "/Contact/Get_Ticketsowner",
        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#User_id").html(s);
        }
    });
}


function Get_Deal_owner() {
    debugger;
    $.ajax({
        type: "GET",
        url: "/Contact/GetDealowner",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#User_id").html(s);
        }
    });
}



function Get_Deal() {
    debugger;
    $.ajax({
        type: "GET",
        url: "/Contact/GetDealName",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].deal_information_id + '">' + data[i].deal_name + '</option>';
            }
            $("#deal_information_id").html(s);
        }
    });
}



function Save() {
    debugger;
    var company_id = $("#company_id").val();
    var deal_owner_id = $("#User_id").val();
    var deal_name = $("#deal_name").val();
    var deal_type_id = $("#deal_type_id").val();
    var amont = $("#amont").val();
    var closing_date = $("#closing_date").val();
    var deal_pipeline_id = $("#deal_pipeline_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    var type_of_dealstage = $("#type_of_dealstage").val();



    $.ajax({
        url: "/Contact/DealCreate",
        type: "Post",
        data: {
            company_id: company_id,
            deal_owner_id: User_id,
            deal_name: deal_name,
            deal_type_id: deal_type_id,
            amont: amont,
            closing_date: closing_date,
            Deals_Pipelines_id: deal_pipeline_id,
            User_id: User_id,
            Create_date: Create_date,
            Deal_Stage_Type_id: type_of_dealstage,
        },
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: function (result) {
            if (result === "Success") {

                $("#Successmsg").text("Data has been saved Successfully");
                $("#Successmsg").css('color', 'green');               
                clear();
                $("#Successmsg").fadeOut(6000);
                $("#deal_name").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#deal_name").focus();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}


function Add() {
    Save();
    $("#myModal2").modal('hide');
}

function clear() {
    $("#deal_name").val("");
    $("#deal_pipeline_id").val("-1");
    $("#type_of_dealstage").val("-1");
    $("#amont").val("");
    $("#closing_date").val("dd/MM/yyyy");
    $("#deal_type_id").val("-1");
    $("#deal_name").focus();
    $("#btnUpdate").hide();
    $("#btnSave").show();
}

function CreateandAnother() {
    Save();
    clear();
    $("#deal_name").focus();

}
function Cancel() {
    clear();
}