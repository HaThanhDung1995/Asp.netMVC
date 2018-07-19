var demo = {
    init: function() {
        $("#createcate").click(function() {
            var url = $(this).data("url");
            $("#modalContent").load(url,
                function() {
                    $("#modal").modal("show");
                });
        });
        $(".updatecate").click(function() {
            var url = $(this).data("url");
            $("#modalContent").load(url,
                function () {
                    $("#modal").modal("show");
                });
        });
    },
    loadproduct: function() {
        $("#loadlistcate").submit();
    },
    onsuccess: function(data) {
        $("#modal").modal("hide");
        demo.loadproduct();
        alert(data.message);
    }
}
$(function() {
    demo.init();
});