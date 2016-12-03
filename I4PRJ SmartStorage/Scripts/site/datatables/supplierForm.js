$(document)
    .ready(function () {
        $("#suppliers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/supplier/",
                    dataSrc: ""
                },
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