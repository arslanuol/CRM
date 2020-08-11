$(document).ready(function () {

    GetList();
    clear();
    $("#myModal2").on('hidden.bs.modal', function (e) {
        $("#deal_type_name").val("");
        $("#btnUpdate").hide();
        $("#btnSave").show();

    });

});

function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/TypesofDeals/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td>' + result1[i].deal_type_name + '</td><td>' + result1[i].full_name + '</td><td>' + result1[i].Create_date + '</td><td style="text-align:center">' + '<button id="loading" class="btn btn-sm" style="font-size:18px;color:red" onclick=' + ' Delete' + '(' + result1[i].deal_type_id + ')><i class="las la-trash"></i></button> | <button id="Edit" class="btn btn-sm" style="font-size:18px;color:#ffa31a;" onclick=' + 'GetId' + '(' + result1[i].deal_type_id + ')>' + " " + '<i class="las la-edit"></i> </button></td> </tr>';
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
    var deal_type_name = $("#deal_type_name").val();
    var company_id = $("#company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    $.ajax({
        url: "/TypesofDeals/Create",
        type: "Post",
        data: {
            deal_type_name: deal_type_name,
            company_id: company_id,
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
                $("#deal_type_name").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#deal_type_name").focus();

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
        url: "/TypesofDeals/GetByID/" + id,
        type: "Get",
        dataType: "json",
        success: function (result) {
            $("#deal_type_id").val(result.deal_type_id);
            $("#deal_type_name").val(result.deal_type_name);
            $("#company_id").val(result.company_id);

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
    $("#industry_id").val("");
    $("#deal_type_name").val("");
    $("#btnUpdate").hide();
    $("#btnSave").show();
}

function Cancel() {
    clear();
}

function CreateandAnother() {
    Save();
    clear();
    $("#deal_type_name").focus();
}
function Update() {
    debugger;
    var deal_type_id = $("#deal_type_id").val();
    var deal_type_name = $("#deal_type_name").val();
    var company_id = $("#company_id").val();
    var User_id = $("#User_id").val();
    var Create_date = $("#Create_date").val();
    if (deal_type_name == "") {
        $("#Errormsg").text("Deal Type Required");
        $("#Errormsg").css('color', 'red');
        $("#deal_type_name").focus();
        return;
    }
    $.ajax({
        url: "/TypesofDeals/Update",
        type: "Post",
        data: {
            deal_type_id: deal_type_id,
            deal_type_name: deal_type_name,
            company_id: company_id,
            User_id: User_id,
            Create_date: Create_date
        },
        dataType: "json",
        success: function (res) {
            if (res === "Success") {
                $("#Successmsg").text("Update Successfully");
                $("#Successmsg").css('color', 'green');
                $("#Successmsg").fadeOut(3000);
                $("#deal_type_name").focus();
                GetList();
                $("#modal12").modal('hide');
                $("#btnUpdate").hide();
                $("#btnSave").show();
                clear();


            }
            else {
                $("#Successmsg").text("Already Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(3000);
                $("#deal_type_name").focus();
                $("#btnUpdate").show();
                $("#btnSave").hide();


            }
        }
    });
}


function Delete(id) {
    debugger;
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/TypesofDeals/Delete/" + id,
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