$(document).ready(function () {
    $("input.datepicker").datepicker({
        dateFormat:"mm/dd/yy"
    });

    $(".nn-add-to-cart").click(function () {
        var id = $(this).parents("div").attr("data-id");
        $.ajax({
            url: "/Cart/Add/" + id,
            dataType:"json",
            success: function (response) {
                $("#cart-cnt").html(response.Count);
                $("#cart-amt").html(response.Amount);
            }
        });
        /*
         * Hiệu ứng giỏ hàng
         */
        var img = $(this).parents(".panel").find(".panel-body img");

        var src = img.attr("src");
        var css = ".cart-effect {background-image: url('"+src+"');background-size:100% 100%;}";
        $("#cart-effect").html(css);

        var options = { to: ".nn-cart-img", className:"cart-effect" };
        img.effect("transfer", options, 1500);
    });

    $(".nn-remove-from-cart").click(function () {
        var id = $(this).attr("data-id");
        $.ajax({
            url: "/Cart/Remove/" + id,
            dataType: "json",
            success: function (response) {
                $("#cart-cnt").html(response.Count);
                $("#cart-amt").html(response.Amount);
            }
        });
        $(this).parents("tr").hide(500);
    });

    $(".nn-update-cart").click(function () {
        var id = $(this).attr("data-id");
        var qty = $(this).val();
        var price = $(this).attr("data-price");
        var discount = $(this).attr("data-discount");
        var amount = qty * price * (1 - discount);

        amount = Math.round(amount * 100) / 100;

        var td = $(this).parents("tr").find(".nn-amount");
        $.ajax({
            url: "/Cart/Update",
            data: { id: id, qty: qty },
            dataType: "json",
            success: function (response) {
                $("#cart-cnt").html(response.Count);
                $("#cart-amt").html(response.Amount);
                td.html("$"+amount);
            }
        });
    });

    $(".nn-add-to-favorite").click(function () {
        var id = $(this).parents("div").attr("data-id");
        $.ajax({
            url: "/Product/AddToFavorite/" + id,
            success: function (response) {
                alert();
                load();
            }
        });
    });
    function load() {
        $.ajax({
            url: "/Home/_Favorite",
            success: function (response) {
                alert();
                var html = '';
                $.each(response, function (key, item) {
                    html += '<a href="/Product/Detail/@' + item.Id + '" class="list-group-item">' + item.Name + '</a>';
                });
                $("#favorite").html(html);
            }
        });
    }

    $(".nn-send-mail").click(function () {
        var id = $(this).parents("div").attr("data-id");
        $("#item-id").val(id);
        $(".nn-btn-send img").hide();
    });

    $(".nn-btn-send").click(function () {
        var id = $("#item-id").val();
        var from = $("#from").val();
        var to = $("#to").val();
        var subject = $("#subject").val();
        var body = $("#body").val();
        
        $(".nn-btn-send img").show();
        $.ajax({
            url: "/Product/Send",
            data: { id: id, from: from, to: to, subject: subject, body: body },
            type:"POST",
            success: function (response) {
                alert("Đã gửi mail thành công!");
                $("button.close").click();
                $(".nn-btn-send img").hide();
            }
        });
    });

    $("a[data-lang]").click(function () {
        var lang = $(this).attr("data-lang");
        var expiry = new Date();
        expiry.setDate(expiry.getDate() + 30);
        document.cookie = "lang=" + lang + "; expires=" + expiry.toGMTString() + ";path=/";
        location.reload();
        return false;
    });
});