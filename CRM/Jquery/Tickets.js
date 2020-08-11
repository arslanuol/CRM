$(document).ready(function () {
    GetList();
    Get_contactowner("/Tickets/Get_contactowner");
    Get_pipeline("/Tickets/Get_ticketpipeline");
    Get_ticketstatus("/Tickets/Get_ticketstatus");
    Get_ticketsource("/Tickets/Get_tickesource");
    Get_priority("/Tickets/Get_priority");


    //Get_Ticketiwner();
    Get_pipeline("/Contact/Get_ticketpipeline");
    Get_ticketstatus("/Contact/Get_ticketstatus");
    Get_ticketsource("/Contact/Get_tickesource");
    Get_priority("/Contact/Get_priority");



    $("#myModal2").on('hidden.bs.modal', function (e) {
        clear();
    });

});

//function Get_Ticketowner() {
//    $.ajax({
//        type: "GET",
//        url: "/Contact/Get_Ticketsowner",
//        success: function (data) {
//            var s = '<option value="-1">Choose</option>';
//            for (var i = 0; i < data.length; i++) {
//                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
//            }
//            $("#User_id").html(s);
//        }
//    });
//}




function Get_contactowner(controller) {
    debugger;
    $.ajax({
        type: "GET",
        url: controller,
        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#User_id").html(s);
        }
    });
}



function Get_pipeline(controller) {
    $.ajax({
        type: "GET",
        url: controller,

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].tickets_pipeline_id + '">' + data[i].tickets_pipeline_name + '</option>';
            }
            $("#Ticket_pipeline_id").html(s);
        }
    });
}


function Get_ticketstatus(controller) {
    $.ajax({
        type: "GET",
        url: controller,

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Ticket_status_id + '">' + data[i].Ticket_status_name + '</option>';
            }
            $("#Ticket_status_id").html(s);
        }
    });
}


function Get_ticketsource(controller) {
    $.ajax({
        type: "GET",
        url: controller,

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Ticket_Source_id + '">' + data[i].Ticket_source_name + '</option>';
            }
            $("#Ticket_Source_id").html(s);
        }
    });
}



function Get_priority(controller) {
    $.ajax({
        type: "GET",
        url: controller,

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].priority_type_id + '">' + data[i].priority_name + '</option>';
            }
            $("#priority_type_id").html(s);
        }
    });
}

function Add() {
    Save("/Tickets/Create");
    $("#myModal2").modal('hide');
}

function AddTickets() {
    Save("/Contact/CreateTickets");
}
function CreateandAnotherTickets() {
    Save("/Contact/CreateTickets");
}
function Save(controller) {
    debugger;
    var Ticket_name = $("#Ticket_name").val();
    var Ticket_status_id = $("#Ticket_status_id").val();
    var Ticket_Source_id = $("#Ticket_Source_id").val();
    var User_id = $("#User_id").val();
    var priority_type_id = $("#priority_type_id").val();
    var Created_date = $("#Created_date").val();
    var Ticket_pipeline_id = $("#Ticket_pipeline_id").val();
    var Description = $("#Description").val();
    var Created_by = $("#Created_by").val();
    var Date_of_creation = $("#Date_of_creation").val();
    var Company_id = $("#Company_id").val();
    $.ajax({
        url: controller,
        type: "Post",
        data: {
            Ticket_name: Ticket_name,
            Ticket_status_id: Ticket_status_id,
            Ticket_Source_id: Ticket_Source_id,
            User_id: User_id,
            priority_type_id: priority_type_id,
            Created_date: Created_date,
            Ticket_pipeline_id: Ticket_pipeline_id,
            Description: Description,
            Created_by: Created_by,
            Date_of_creation: Date_of_creation,
            Company_id: Company_id

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
                $("#Ticket_name").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#Ticket_name").focus();

                clear();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}




function clear() {
    $("#Ticket_name").val("");
    $("#Ticket_status_id").val("-1");
    $("#Ticket_Source_id").val("-1");
    $("#User_id").val("-1");
    $("#priority_type_id").val("-1");
    $("#Created_date").val("dd/MM/yyyy");
    $("#Ticket_pipeline_id").val("-1");
    $("#Description").val("");    
}


function CreateandAnother() {
    Save("/Tickets/Create");
    clear();
    $("#Ticket_name").focus();

}

function Cancel() {
    clear();
}

function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/Tickets/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td>' + result1[i].Ticket_name + '</td><td>' + result1[i].Ticket_status_name + '</td><td>' + result1[i].Ticket_source_name + '</td><td>' + result1[i].tickets_pipeline_name + '</td><td>' + result1[i].priority_name + '</td><td>' + result1[i].Created_date + '</td><td>' + result1[i].full_name + '</td><td style="text-align:center">' + '</td> </tr>';
                $('#tbllist').append(AddOption);
            }
        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}