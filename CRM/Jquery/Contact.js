$(document).ready(function () {
    GetList();
    GetLifeCycleStage();
    GetLeadStatus();
    Get_Contact();

});







function GetLifeCycleStage() {
    $.ajax({
        type: "GET",
        url: "/Contact/Get_LifeCycle",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].life_cycle_id + '">' + data[i].life_cycle_name + '</option>';
            }
            $("#life_cycle_id").html(s);
        }
    });
}


function Get_Contact() {
    $.ajax({
        type: "GET",
        url: "/Contact/Get_ContactOwner",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#User_id").html(s);
        }
    });
}



function GetLeadStatus() {
    $.ajax({
        type: "GET",
        url: "/Contact/Get_LeadStatus",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Lead_status_id + '">' + data[i].Lead_Status_name + '</option>';
            }
            $("#Lead_status_id").html(s);
        }
    });
}



function Add() {
    Save();
    $("#myModal2").modal('hide');
}

function CreateandAnother() {
    Save();
    clear();
}
function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/Contact/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td><a href="/Contact/Get_Contact_Information">' + result1[i].email + '</a></td><td>' + result1[i].full_names + '</td><td>' + result1[i].phone_Number + '</td><td>' + result1[i].full_name + '</td><td>' + result1[i].Lead_Status_name + '</td><td>' + result1[i].life_cycle_name + '</td><td>' + result1[i].Create_date + '</td> <td style="text-align:center">' + '</td><td style="text-align:center">' + '<a href="/Contact/Get_Contact_Information"><button id="Edit" class="btn btn-sm" style="font-size:18px;color:#ffa31a;" onclick=' + 'GetId' + '(' + result1[i].Contact_id + ')>' + " " + '<i class="fa fa-eye-slash"></i></button></a></td></tr>';
                $('#tbllist').append(AddOption);
            }



        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}








function Save() {
    debugger;
    var email = $("#email").val();
    var full_name = $("#full_name").val();
    var last_name = $("#last_name").val();
    var User_id = $("#User_id").val();
    var Job_Title = $("#Job_Title").val();
    var phone_Number = $("#phone_Number").val();
    var life_cycle_id = $("#life_cycle_id").val();
    var Lead_status_id = $("#Lead_status_id").val();
    var Company_id = $("#Company_id").val();
    var Create_date = $("#Create_date").val();
    var Created_by = $("#Created_by").val();
    $.ajax({
        url: "/Contact/Create",
        type: "Post",
        data: {
            email: email,
            Company_id: Company_id,
            full_names: full_name,
            last_name: last_name,
            Contact_owner: User_id,
            Job_Title: Job_Title,
            phone_Number: phone_Number,
            LifeCycle_Stage: life_cycle_id,
            Lead_Status: Lead_status_id,
            Create_date: Create_date,
            Created_by: Created_by

        },
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: function (result) {
            if (result === "Success") {

                $("#Successmsg").text("Data has been saved Successfully");
                $("#Successmsg").css('color', 'green');

                GetList();
                clear();
                $("#Successmsg").fadeOut(6000);
                $("#email").focus();
               
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);               
                clear();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}



function clear() {
    $("#email").val("");
    $("#full_name").val("");
    $("#last_name").val();
    $("#Contact_owner").val("-1");
    $("#Job_Title").val("");
    $("#phone_Number").val("");
    $("#LifeCycle_Stage").val("-1");
    $("#Lead_Status").val("-1");
}

function Cancel() {
    clear();
}

function GetId(id) {
    debugger;
    $.ajax({
        url: "/Contact/GetByID/" + id,
        type: "Get",
        dataType: "json",
        success: function (result) {
           
        },
        error: function (error) {

        }
    });

}