$(document)
    .ready(function () {
        $("#suppliers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/supplier/",
                    dataSrc: ""
                },
                dom: '<"html5buttons"B>lTfgitp',
                "buttons": [
                    {
                        extend: 'collection',
                        text: 'Export',
                        buttons: [
                            { extend: 'copy' },
                            { extend: 'csv' },
                            { extend: 'excel', title: 'Leverandørsrapport' },
                            { extend: 'pdf', title: 'Leverandørsrapport' },
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
                columns: [
                    {
                        data: "product.supplier.name"
                    },
                    {
                        data: "transactionId"
                    },
                    {
                        data: "product.name"
                    },
                    {
                        data: "quantity"
                    },
                    {
                        data: "updated",
                        render: function (data) {
                            var date = new Date(data).toLocaleDateString();
                            return date;
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "product.supplier.supplierId",
                        "visible": false
                    }
                ]
            });
        var table = $("#suppliers-table").DataTable();

        $("#Supplier_SupplierId").on("change", function () {
            table.columns(6).search(this.value).draw();
        });
    });