$(document).ready(function () {

    
    clear();
   
});





function Add() {
    debugger;
    var L_source = $("#leadsource_name").val();
    var Comp_id = $("#company_id").val();
       
    $.ajax({
        url: "/CreateTypeofLeadSource/Create",
        type: "Post",
        data: {
            leadsource_name: L_source,
            company_id: Comp_id
            
        },
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        datatype: "json",
        success: function (result) {
            if (result === "Success") {

                $("#Successmsg").text("Data has been saved Successfully");
                $("#Successmsg").css('color', 'green');

                
                clear();
                $("#Successmsg").fadeOut(7000);
                $("#leadsource_name").focus();
                debugger;
            }
            else   {
                $("#Successmsg").text("Alread Exist Please Try Again");
                $("#Successmsg").css('color', 'red');
                $("#Successmsg").fadeOut(8000);
                $("#leadsource_name").focus();

                clear();
            }
        },
        error: function (error) {
            ShowError("internal Server Error!!");
        }
    });
}


function clear() {
    $("#leadsource_name").val("");
    $("#leadsource_name").focus();
}