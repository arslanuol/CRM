$(document).ready(function () {

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');
    Erorrmsg = $("#CheckNo_Emp");
    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });
    Erorrmsg.click(function () {
        if ($('#Num_of_Emp') == null) {
            $("#ErrorNoEmp").text('Please Select No of Employee');
            $("#ErrorNoEmp").css('color', 'red');
            $("#ErrorNoEmp").fadeOut(5000);
            isValid = true;
        }
    });
    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url'], input[type='password'], input[type='file'],input[type='hidden']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').trigger('click');
});



function btn20() {
    document.getElementById("Num_of_Emp").value = '20';
}

function btn40() {
    document.getElementById("Num_of_Emp").value = '40';
}

function btn60() {
    document.getElementById("Num_of_Emp").value = '60';
}

function btn80() {
    document.getElementById("Num_of_Emp").value = '80';
}

function btn100() {
    document.getElementById("Num_of_Emp").value = '100';
}

function btn200() {
    document.getElementById("Num_of_Emp").value = '200';
}

function btn300() {
    document.getElementById("Num_of_Emp").value = '300';
}

function btn400() {
    document.getElementById("Num_of_Emp").value = '400';
}

function btn500() {
    document.getElementById("Num_of_Emp").value = '500';
}

function btn600() {
    document.getElementById("Num_of_Emp").value = '600';
}

function CheckNo_Emp() {
    
    
}

function CheckValid() {
    if ($('#password').val() !== $('#confirm_password').val()) {
        $("#ErrorPswd").text("Password Don't Match Please Enter Correct Password");
        $("#ErrorPswd").css('color', 'red');
        $("#password").val("");
        $("#confirm_password").val("");
        $("#password").focus();
        // Prevent form submission
        event.preventDefault();
        return;
    }
    else {
        $("#successmsg").text("Successfully");
        $("#successmsg").css('color', 'green');
    }
}




function Uservalid() {
    debugger;

    var email = $("#email").val();
    $.ajax({
        url: "/Signup/uservalid",
        type: "post",
        dataType: "json",
        data: {
            usr: usr
        },
        success: function (res) {
            if (res == "OK") {

                $('#email').css('border-color', '#8bb9df');
            }
            else if (res == "Already") {


                $("#errormsg").text("Please Enter Another Email");
                $("#errormsg").css('color', 'red');
                $("#email").val("");
                $("#email").focus();

            }
        },
        error: function (error) {
            ShowError("Internal Server Error");
        }
    });
}



function imgvalid() {

    var val = $("#img").val();
    if (!val.match(/(?:JPG|PNG|BMP|JPEG|jpeg|jpg|png|bmp)$/)) {
        // inputted file path is not an image of one of the above types
        $("#errorimg").text("Please Select Image Extension Should be('JPG,PNG,BMP,JPEG,jpeg,jpg,png,bmp')");
        $("#errorimg").css('color', 'red');
        $("#img").focus();
        $("#errorimg").fadeOut(3000);
        $("#img").val("");
        return;
    }
    $('#imagee').css('border-color', '#8bb9df');
}


function GetCountry() {
    $.ajax({
        type: "GET",
        url: "/Signup/GetCountry",

        success: function (data) {
            var s = '<option value="-1">Choose</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Country_id + '">' + data[i].country_name1 + '</option>';
            }
            $("#Country_id").html(s);
        }
    });

}