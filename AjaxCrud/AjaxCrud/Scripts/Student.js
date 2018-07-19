$(document).ready(function() {
    getAll();
    $("#btn-submit").click(function () {
        Add();
    });
    $("#btn-update").click(function () {
        _edit();
    });
});
function getAll() {
    $.ajax({
        url: "/Student/Json",
        type: "Get",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            var html = '';
            $.each(response, function(key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Status + '</td>';
                html += '<td><button class="btn-get" data-id=' + item.Id + '>Edit</button></td>';
                html += '<td><button class="btn-delete" data-id=' + item.Id + '>Delete</button></td>';
                html += '</tr>';
            });
            $("#list tbody").html(html);
            $(".btn-get").click(function () {
                var id = $(this).attr("data-id");
                Get(id);
            });
            $(".btn-delete").click(function() {
                var id = $(this).attr("data-id");
                Delete(id);
            });


        }
    });
   
}
function Add() {
    $("#btn-update").hide();
    var obj = {
       
        Name: $("#Name").val()
        
}
    $.ajax({
        url: "/Student/Create",
        data:JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.message);
            getAll();
            $("#send-dialog").modal('hide');
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Get(id) {
    $("#btn-submit").hide();
    $("#btn-update").show();
    $.ajax({
        url: '/Student/Get/' + id,
        // data: JSON.stringify(dto),
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.fasdfasdsId);
            $('#Name').val(result.Name);
            $('#Status').val(result.Status);
            $('#btn-submit').hide();
            $('#btn-update').show();
            $('#send-dialog').modal('show');
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delete(id) {
    $.ajax({
        url: '/Student/Delete/' + id,
        // data: JSON.stringify(dto),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result.message);
            getAll();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function _edit() {
    
    var obj = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
        Status: $("#Status").val()
    }
    $.ajax({
        url: '/Student/Update',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (result) {
            getAll();
            $('#send-dialog').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}