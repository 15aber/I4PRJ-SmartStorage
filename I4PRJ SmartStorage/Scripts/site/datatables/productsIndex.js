$(document)
    .ready(function () {

        var table = $("#products")
            .DataTable({
                paging: false,
                searching: true,
                "info": false,
                "ordering": true,
                dom: '<"html5buttons"B>lTfgitp',
                "buttons": [
                    {
                        extend: 'collection',
                        text: 'Export',
                        buttons: [
                            { extend: 'copy' },
                            { extend: 'csv' },
                            { extend: 'excel', title: 'SmartStorage - Produkt' },
                            { extend: 'pdf', title: 'SmartStorage - Produkt' },
                            {
                                extend: 'print',
                                customize: function (win) {
                                    $(win.document.body).addClass('white-bg');
                                    $(win.document.body).css('font-size', '10px');

                                    $(win.document.body)
                                        .find('table')
                                        .addClass('compact')
                                        .css('font-size', 'inherit');
                                }
                            }
                        ]
                    }
                ],
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
                            return date.toLocaleString();
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "productId",
                        render: function (data) {
                            return "<button class='btn btn-primary btn-xs js-edit' data-product-id=" + data + ">Edit</button>" +
                                "<button class='btn btn-white btn-xs js-delete' data-product-id=" + data + ">Delete</button>";
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