$(document)
    .ready(function () {

        var table = $("#products")
            .DataTable({
                ajax: {
                    url: "/api/products/getproductsofcategory/" + document.location.pathname.split('/')[3],
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "name"
                    },
                    {
                        data: "purchasePrice",
                        render: function (data) {
                            var price = data;
                            return price.toFixed(2);
                        }
                    },
                    {
                        data: "updated",
                        render: function (data) {
                            var date = new Date(data);
                            return date.toLocaleString('da-DK');
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "productId",
                        render: function (data) {
                          return "<button class='btn btn-info btn-sm js-edit' data-product-id=" + data + ">Edit</button> " +
                                "<button class='btn btn-danger btn-sm js-delete' data-product-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            });
    });

$("#products").on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-product-id");
    var url = "/Products/Edit/" + id;
    window.location.href = url;
});

$("#products").on("click", ".js-delete", function () {
    var button = $(this);

    bootbox.confirm("Are you sure you want to delete this product?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/products/deleteproduct/" + button.attr("data-product-id"),
                    method: "DELETE",
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        });
});