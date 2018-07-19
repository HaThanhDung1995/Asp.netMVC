function showMessage(data) {
    if (data == undefined) return;

    var type = "alert-success";
    if (data.type == "Error") {
        type = "alert-danger";
    } else if (data.type == "warning") {
        type = "alert-warning";
    }
    var template =
        '<div class="alert ' +
            type +
            ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button><span><strong>' +
            data.type +
            '!</strong> ' +
            data.message +
            '</span></div>';
    $('#alert-container').removeClass("hidden");
    $('#alert-container').html(template);
    setTimeout(function () {
        $("div.alert").remove();
        $('#alert-container').addClass("hidden");
    }, 5000);
}