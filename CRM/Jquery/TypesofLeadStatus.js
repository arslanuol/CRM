$(document).ready(function () {

    GetList();
   
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
                AddOption = '<tr> <td>' + result1[i].Lead_Status_name + '</td> <td>' + result1[i].full_name + '</td> <td>' + result1[i].Create_date + '</td> <td style="text-align:center">' + '<button id="loading" class="btn btn-sm" style="font-size:18px;color:red" onclick=' + ' Delete' + '(' + result1[i].Lead_status_id + ')><i class="fa fa-close" style="font-size:18px"></i></button> | <button id="Edit" class="btn btn-sm" style="font-size:18px;color:#ffa31a;" onclick=' + 'GetId' + '(' + result1[i].Lead_status_id + ')>' + " " + '<i class="fa fa-pencil" style="font-size:18px"></i></button></td> </tr>';
                $('#tbllist').append(AddOption);
            }
        },
        error: function (error) {
            debugger;
            ShowError(error.statusText);
        }
    });
}