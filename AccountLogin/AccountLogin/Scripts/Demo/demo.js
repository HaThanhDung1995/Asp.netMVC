var demo = {
    init: function() {
        //bắt sự kiện click btn Create
        $('#createProduct').click(function() {
            var url = $(this).data("url"); //lấy url tới controller - Action create data-url="@Url.Action("CreateProduct")"
            $("#modalContent").load(url, //load url vào modal
                function() {
                    $("#modal").modal("show"); // show modal
                });
        });
    },
    loadListProduct: function() {
        $("#frmGetListProduct").submit();  /*hàm gọi submit form update lại dữ liệu*/
    },
    saveSuccess: function (data) {
        $("#modal").modal("hide"); /*ẩn pop up*/
        
        demo.loadListProduct();
        alert(data.message); /*Xuất message*/
    }
}
$(function() {
    demo.init();
})