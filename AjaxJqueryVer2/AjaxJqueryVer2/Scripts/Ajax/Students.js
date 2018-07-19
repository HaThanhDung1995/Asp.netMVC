$(document).ready(function() {
    getall();
    $("#btn-update").click(function() {
        update();
    });
    $("#btn-create").click(function() {
        add();
    });
});
function getall() {
    $.ajax({
        url: "/Home/Index",
        type: "GET",
        contentType:"application/json; charset-utf-8",
        dataType: "json",
        success: function(response) {
            var html = '';
            $.each(response, function(key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Number + '</td>';
                html += '<td>' + item.Sta + '</td>';
                html += '<td><a href="#" class="btn-edit" data-id="'+item.Id+'">Edit</a></td>';
                html += '</tr>';
            });
            $("#list tbody").html(html);

            $(".btn-edit").click(function() {
                var id = $(this).attr("data-id");
                get(id);
            });
        }
    });
}
function get(id) {
    $.ajax({
        url: "/Home/Get/" + id,
        contentType: "application/json; charsetutf-8",
        dataType: "json",
        success: function (response) {
            $("#btn-update").show();
            $("#Id").val(response.Id);
            $("#Name").val(response.Name);
            $("#Number").val(response.Number);
            $("#Sta").val(response.Sta);
            $("#exampleModal").modal("show");
            $("#btn-create").hide();
        }
    });
}
function update() {
    
    var obj = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
        Number: $("#Number").val(),
        Sta: $("#Sta").val()
}
    $.ajax({
        url: "/Home/Update",
        contentType: "application/json; charsetutf-8",
        data:JSON.stringify(obj),
        dataType: "json",
        type:"POST",
        success: function (response) {
            alert(response.message);
            getall();
            $("#exampleModal").modal("hide");
        }
    });
}
function add() {
    
    $("#btn-submit-2").show();
    var obj = {
        
        Name: $("#Name").val(),
        Number: $("#Number").val()
        
}
    $.ajax({
        url: "/Home/Create",
        data: JSON.stringify(obj),
        
        dataType: "json",
        type: "POST",
        success: function (respond) {
            alert(respond.message);
            getall();
        }
    });
}