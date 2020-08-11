function imgvalid() {

    var val = $("#img").val();
    if (!val.match(/(?:JPG|PNG|BMP|JPEG|jpeg|jpg|png|bmp)$/)) {
        // inputted file path is not an image of one of the above types
        $("#SuccessMSg").text("Please Select Image Extension Should be('JPG,PNG,BMP,JPEG,jpeg,jpg,png,bmp')");
        $("#SuccessMSg").css('color', 'red');
        $("#img").focus();
        $("#SuccessMSg").fadeOut(3000);
        $("#img").val("");
        return;
    }
    $('#img').css('border-color', '#8bb9df');
}