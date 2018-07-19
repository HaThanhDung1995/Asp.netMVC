var demo = {
    init: function() {
        $("#Create").click(function() {
            var url = $(this).data("url");
            $("#modalContent").load(url, function() {
                $("#modal").modal("show");
            });
        });
        $(".update").click(function() {
            var url = $(this).data("url");
            $("#modalContent").load(url, function () {
                $("#modal").modal("show");
            });
        });
    },
    loadcate: function() {
        $("#dvlistcate").submit();
    },
    onsuccess: function(data) {
        $("#modal").modal("hide");
        demo.loadcate();
        alert(data.message);
    }
}
$(function() {
    demo.init();
});