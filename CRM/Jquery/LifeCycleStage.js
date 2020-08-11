$(document).ready(function () {
   
    GetList();
    clear();
    $("#myModal2").on('hidden.bs.modal', function (e) {
        clear();
    });
});

function GetList() {
   
    $('#tbllist').html('');
        $.ajax({
            url: '/LifeCycleStage/GetDetail',
            type: 'GET',
            dataType: 'html',
            //dataType: 'application/json',

            success: function (result) {
                debugger;
                var result1 = JSON.parse(result);
                for (var i = 0; i < result1.length; i++) {
                    AddOption = '<tr> <td>' + result1[i].life_cycle_name + '</td><td>' + result1[i].full_name + '</td><td>' + result1[i].Create_date + '</td><td style="text-align:center">' + '<button id="loading" class="btn btn-sm" style="font-size:18px;color:red" onclick=' + ' Delete' + '(' + result1[i].life_cycle_id + ')><i class="las la-trash"></i></button> | <button id="Edit" class="btn btn-sm" style="font-size:18px;color:#ffa31a;" onclick=' + 'GetId' + '(' + result1[i].life_cycle_id + ')>' + " " + '<i class="las la-edit"></i> </button></td> </tr>';
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
    var life_cycle_name = $("#life_cycle_name").val();
    var Company_id = $("#Company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();

    $.ajax({
        url: "/LifeCycleStage/Create",
        type: "Post",
        data: {
            life_cycle_name: life_cycle_name,
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
                $("#life_cycle_name").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#life_cycle_name").focus();

                clear();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });


}

function GetId(id)
{
    debugger;
    $.ajax({
        url: "/LifeCycleStage/GetByID/" + id,
        type: "Get",
        dataType: "json",
        success: function (result)
        {           
            $("#life_cycle_id").val(result.life_cycle_id);
            $("#life_cycle_name").val(result.life_cycle_name);
            $("#Company_id").val(result.Company_id);
            $("#User_id").val(result.User_id);
            $("#myModal2").modal('show');
            $("#btnUpdate").show();
            $("#btnSave").hide();
            $("#btnAnother").prop('disabled', true);
        },
        error: function (error)
        {

        }
    });

}


function clear() {
    $("#life_cycle_id").val("");
    $("#life_cycle_name").val("");
    $("#btnUpdate").hide();
    $("#btnSave").show();
}

function Cancel() {
      clear();
}

function CreateandAnother() {
    Save();
    clear();
    $("#life_cycle_name").focus();
}
function Update() {
    debugger;
    var life_cycle_id = $("#life_cycle_id").val();
    var life_cycle_name = $("#life_cycle_name").val();
    var Company_id = $("#Company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    if (life_cycle_name == "") {
        $("#Errormsg").text("Life Cycle Required");
        $("#Errormsg").css('color', 'red');
        $("#life_cycle_name").focus();
        return;
    }
    $.ajax({
        url: "/LifeCycleStage/Update",
        type: "Post",
        data: {
            life_cycle_id: life_cycle_id,
            life_cycle_name: life_cycle_name,
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
                $("#life_cycle_name").focus();
                GetList();
                $("#btnUpdate").hide();
                $("#btnSave").show();
                clear();


            }
            else {
                $("#Successmsg").text("Already Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(3000);
                $("#life_cycle_name").focus();
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
            url: "/LifeCycleStage/Delete/" + id,
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