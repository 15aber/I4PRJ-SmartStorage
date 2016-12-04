$(document)
    .ready(function () {
        $("#wholesalers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/wholesalers/getwholesalertransactions",
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "product.wholesaler.name"
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
                        render: function(data) {
                            var date = new Date(data).toLocaleDateString('da-DK');
                            return date;
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "product.wholesaler.wholesalerId",
                        "visible": false
                    },
                    {
                        data: "updated",
                        render: function(data) {
                            var date = new Date(data).getTime();
                            return date;
                        },
                        "visible": false
                    }
                ]
            });
        var table = $("#wholesalers-table").DataTable();

        $("#Wholesaler_WholesalerId").on("change", function () {
            table.columns(6).search(this.value).draw();
        });
    });

