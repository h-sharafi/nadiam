
$.post("/Home/ProductsPartial", null,
    function (data, textStatus, jqXHR) {
        $('#ca_plc').html(data);
    },
    "html"
);