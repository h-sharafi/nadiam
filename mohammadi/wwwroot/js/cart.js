$(document).on('click', '.addtoBasket', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.post("/Cart/AdToCart", {id: id},
        function (data, textStatus, jqXHR) {
            if (data.result) {
                alert('ثبت شد');
            }
            else{
                alert('خطا');
            }
        },
        "json"
    );
})