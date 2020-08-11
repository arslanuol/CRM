$(document).ready(function () {
    GetList();
    GetIndustry("/Companies");
    Get_contact_owner("/Companies");
    Get_Type("/Companies");

    GetIndustry("/Contact");
    Get_contact_owner("/Contact");
    Get_Type("/Contact");
    Get_CompanyName();
    $("#myModal2").on('hidden.bs.modal', function (e) {
        clear();

    });

});











function GetIndustry(controller) {
    $.ajax({
        type: "GET",
        url: controller+"/Get_indutry",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].industry_id + '">' + data[i].industry_name + '</option>';
            }
            $("#Industry_id").html(s);
        }
    });
}


function Get_Type(controller) {
    $.ajax({
        type: "GET",
        url: controller+"/Get_Type",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Type_of_comp_id + '">' + data[i].type_name + '</option>';
            }
            $("#Type_of_comp_id").html(s);
        }
    });
}

function Get_contact_owner(controller) {
    $.ajax({
        type: "GET",
        url: controller + "/Get_Contact_owner",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].User_id + '">' + data[i].full_name + '</option>';
            }
            $("#company_owner").html(s);
        }
    });
}


function Get_CompanyName() {
    $.ajax({
        type: "GET",
        url:  "/Contact/GetCompanyName",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].company_User_ID + '">' + data[i].company_u_name + '</option>';
            }
            $("#company_User_ID").html(s);
        }
    });
}
















function AddCompany() {
    Save("/Contact/CreateCompany");
    $("#myModal2").modal('hide');

}

function CreateandAnothercomp() {
    Save("/Contact/CreateCompany");
    clear();
    $("#company_u_domain").focus();

}
function Add() {
    Save("/Companies/Create");    
    $("#myModal2").modal('hide');
}

function Save(controller) {
    debugger;
    var company_u_domain = $("#company_u_domain").val();
    var company_u_name = $("#company_u_name").val();
    var company_owner = $("#company_owner").val();
    var Industry_id = $("#Industry_id").val();
    var phone_number = $("#phone_number").val();
    var Type_of_comp_id = $("#Type_of_comp_id").val();
    var city = $("#city").val();
    var state = $("#state").val();
    var postal_code = $("#postal_code").val();
    var no_emp = $("#no_emp").val();
    var Annual_revenue = $("#Annual_revenue").val();
    var Description = $("#Description").val();
    var linkedin_page = $("#linkedin_page").val();
    var company_User_ID = $("#company_User_ID").val();
    var Create_date = $("#Create_date").val();
    var User_id = $("#User_id").val();
    var Company_id = $("#Company_id").val();

   
    $.ajax({
        url: controller,
        type: "Post",
        data: {
            company_u_name: company_u_name,
            company_u_domain: company_u_domain,
            company_owner: company_owner,
            Industry_id: Industry_id,
            Type_of_comp_id: Type_of_comp_id,
            User_id: User_id,
            Annual_revenue: Annual_revenue,
            Description: Description,
            linkedin_page: linkedin_page,
            Company_id: Company_id,
            Create_date: Create_date,
            company_User_ID: company_User_ID,
            city: city,
            state: state,
            phone_number: phone_number,
            postal_code: postal_code,
            no_emp: no_emp,
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
                $("#company_u_domain").focus();
                debugger;
            }
            else {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#company_u_domain").focus();

               
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}




function CreateandAnother() {
    Save("/Companies/Create");
    clear();
    $("#company_u_domain").focus();

}
    function Cancel() {
        clear();
    }

    function clear() {
        $("#company_u_name").val("");
        $("#company_u_domain").val("");
        $("#company_owner").val("-1");
        $("#Industry_id").val("-1");
        $("#phone_number").val("");
        $("#Type_of_comp_id").val("-1");
        $("#city").val("");
        $("#state").val("");
        $("#postal_code").val("");
        $("#no_emp").val("");
        $("#Description").val("");
        $("#linkedin_page").val("");
        $("#Annual_revenue").val("");
        $("#company_u_domain").focus();
        $("#btnUpdate").hide();
        $("#btnSave").show();
    }


function GetList() {

    $('#tbllist').html('');
    $.ajax({
        url: '/Companies/GetDetail',
        type: 'GET',
        dataType: 'html',
        //dataType: 'application/json',

        success: function (result) {
            debugger;
            var result1 = JSON.parse(result);
            for (var i = 0; i < result1.length; i++) {
                AddOption = '<tr> <td>' + result1[i].company_u_name + '</td><td>' + result1[i].full_name + '</td><td>' + result1[i].phone_number + '</td><td>' + result1[i].city + '</td><td>' + result1[i].state + '</td><td>' + result1[i].industry_name + '</td><td>' + result1[i].Create_date + '</td><td style="text-align:center">' +'</td> </tr>';
                $('#tbllist').append(AddOption);
            }



        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}
