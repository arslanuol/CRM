$(document).ready(function () {
    GetList();
    Get_dealpipline("/Deals");
    Get_Type("/Deals");
    Get_contact_owner();
    Get_dealstage("/Deals");
   


    Get_dealpipline("/Contact");
    Get_Type("/Contact");
   
    Get_dealstage("/Contact");

    $("#myModal2").on('hidden.bs.modal', function (e) {
        clear();

    });
});











function Get_dealpipline(controller) {
    $.ajax({
        type: "GET",
        url: controller + "/Get_Pipeline",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Deals_Pipelines_id + '">' + data[i].Deals_piplines_name + '</option>';
            }
            $("#deal_pipeline_id").html(s);
        }
    });
}


function Get_Type(controller) {
   
     $.ajax({
        type: "GET",
        url: controller+"/Get_dealType",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].deal_type_id + '">' + data[i].deal_type_name + '</option>';
            }
            $("#deal_type_id").html(s);
        }
    });
}

function Get_contact_owner() {
    debugger;
    $.ajax({
        type: "GET",
        url: "/Deals/Get_Contact_owner",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#deal_owner_id").html(s);
        }
    });
}



function Get_dealstage(controller) {
    $.ajax({
        type: "GET",
        url: controller + "/Get_dealstage",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Deal_Stage_Type_id + '">' + data[i].Deal_Stage_name + '</option>';
            }
            $("#type_of_dealstage").html(s);
        }
    });
}

function Add() {
    Save();   
    $("#myModal2").modal('hide');
}






function Save() {
    debugger;
    var company_id = $("#company_id").val();
    var deal_owner_id = $("#deal_owner_id").val();
    var deal_name = $("#deal_name").val();
    var deal_type_id = $("#deal_type_id").val();
    var amont = $("#amont").val();
    var closing_date = $("#closing_date").val();
    var deal_pipeline_id = $("#deal_pipeline_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    var type_of_dealstage = $("#type_of_dealstage").val();
    


    $.ajax({
        url: "/Deals/Create",
        type: "Post",
        data: {
            company_id: company_id,
            deal_owner_id: deal_owner_id,
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

                GetList();
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




function CreateandAnother() {
    Save();
   
    clear();
    $("#deal_name").focus();

}
function Cancel() {
    clear();
}

function clear() {
    $("#deal_name").val("");
    $("#deal_pipeline_id").val("-1");
    $("#type_of_dealstage").val("-1");
    $("#amont").val("");
    $("#closing_date").val("dd/MM/yyyy");
    $("#deal_owner_id").val("-1");
    $("#deal_type_id").val("-1");
    $("#deal_name").focus();
    $("#btnUpdate").hide();
    $("#btnSave").show();
}


function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/Deals/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td>' + result1[i].deal_name + '</td><td>' + result1[i].Deal_Stage_name + '</td><td>' + result1[i].full_name + '</td><td>' + result1[i].closing_date + '</td><td>' + result1[i].Create_date + '</td><td>' + result1[i].full_name + '</td><td style="text-align:center">' + '</td> </tr>';
                $('#tbllist').append(AddOption);
            }



        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}
