$(document)
    .ready(function () {
        var table = $("#products")
            .DataTable({
                ajax: {
                    url: "/api/products/getproductsofcategory/" + $('#products').name,
                    dataSrc: ""
                },
                "columnDefs": [
                    { "width": "20%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "20%", "targets": 4 }
                ],
                columns: [
                    {
                        data: "name"
                    },
                    {
                        data: "purchasePrice"
                    },
                    {
                        data: "updated"
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "productId",
                        render: function (data) {
                            return "<center><button class='btn btn-primary pull-left js-details' id='details' data-product-id=" +
                                data +
                                ">Details</button>" +
                                "<button class='btn btn-white js-edit' data-product-id=" +
                                data +
                                ">Edit</button>" +
                                "<button class='btn btn-white pull-right js-delete' data-product-id=" +
                                data +
                                ">Delete</button><center>";
                        }
                    }
                ]
            });
    });
$("#products").on("click", ".js-details", function () {
    var button = $(this);
    var id = button.attr("data-product-id");
    var url = "/Products/Details/" + id;
    window.location.href = url;
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
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
});