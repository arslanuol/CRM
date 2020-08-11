$(document).ready(function () {

    GetList();
    clear();
    $("#myModal2").on('hidden.bs.modal', function (e) {
        $("#Lead_Status_name").val("");
        $("#btnUpdate").hide();
        $("#btnSave").show();

    });

});

function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/TypesofLeadStatus/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td>' + result1[i].Lead_Status_name + '</td> <td>' + result1[i].full_name + '</td> <td>' + result1[i].Create_date + '</td><td style="text-align:center">' + '<button id="loading" class="btn btn-sm" style="font-size:18px;color:red;" onclick=' + ' Delete' + '(' + result1[i].Lead_status_id + ')><i class="las la-trash"></i></button> | <button id="Edit" class="btn btn-sm" style="font-size:18px;color:#ffa31a;" onclick=' + 'GetId' + '(' + result1[i].Lead_status_id + ')>' + " " + '<i class="las la-edit"></i></button></td> </tr>';
                $('#tbllist').append(AddOption);
            }



        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}






function Add() {
    Save();
    $("#myModal2").modal('hide');
}

function Save() {
    debugger;
    var Lead_Status_name = $("#Lead_Status_name").val();
    var Company_id = $("#Company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();


    $.ajax({
        url: "/TypesofLeadStatus/CreateTypeofLeadStatus",
        type: "Post",
        data: {
            Lead_Status_name: Lead_Status_name,
            Company_id: Company_id,
            User_id: User_id,
            Create_date: Create_date

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
                $("#Lead_Status_name").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#Lead_Status_name").focus();

                clear();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}




function GetId(id) {
    debugger;
    $.ajax({
        url: "/TypesofLeadStatus/GetByID/" + id,
        type: "Get",
        dataType: "json",
        success: function (result) {
            $("#Lead_status_id").val(result.Lead_status_id);
            $("#Lead_Status_name").val(result.Lead_Status_name);
            $("#Company_id").val(result.Company_id);
            $("#User_id").val(result.User_id);
            $("#myModal2").modal('show');
            $("#btnUpdate").show();
            $("#btnSave").hide();
            $("#btnAnother").prop('disabled', true);
        },
        error: function (error) {

        }
    });

}




function clear() {
    $("#Lead_status_id").val("");
    $("#Lead_Status_name").val("");
    $("#btnUpdate").hide();
    $("#btnSave").show();
}


function CreateandAnother() {
    Save();
    clear();
    $("#Lead_Status_name").focus();
}



function Update() {
    debugger;
    var Lead_status_id = $("#Lead_status_id").val();
    var Lead_Status_name = $("#Lead_Status_name").val();
    var Company_id = $("#Company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    if (Lead_Status_name == "") {
        $("#Errormsg").text("Life Cycle Required");
        $("#Errormsg").css('color', 'red');
        $("#Lead_Status_name").focus();
        return;
    }
    $.ajax({
        url: "/TypesofLeadStatus/Update",
        type: "Post",
        data: {
            Lead_status_id: Lead_status_id,
            Lead_Status_name: Lead_Status_name,
            Company_id: Company_id,
            User_id: User_id,
            Create_date: Create_date
        },
        dataType: "json",
        success: function (res) {
            if (res === "Success") {
                $("#Successmsg").text("Update Successfully");
                $("#Successmsg").css('color', 'green');
                $("#Successmsg").fadeOut(3000);
                $("#Lead_Status_name").focus();
                GetList();
                $("#btnUpdate").hide();
                $("#btnSave").show();
                clear();
                $("#myModal2").modal('hidde', true);


            }
            else {
                $("#Successmsg").text("Already Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(3000);
                $("#Lead_Status_name").focus();
                clear();
            }
        }
    });
}




function Delete(id) {
    debugger;
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/TypesofLeadStatus/Delete/" + id,
            type: "Get",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            datatype: "json",
            success: function (result) {
                debugger;
                $("#Successmsg").text("This Record Exist In Another Table");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(2000);
                GetList();

            },
            error: function (error) {
                //ShowError("Branch is Save in Sub Branch!!");
            }
        });
    }
}