$(document)
    .ready(function() {
        var table = $("#status")
            .DataTable({
                buttons: [
                    { extend: 'copy' },
                    { extend: 'csv' },
                    { extend: 'excel' },
                    { extend: 'pdf' }],
                ajax: {
                    url: "/api/status/1",
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
                        data: "product.name"
                    },
                    {
                        data: "product.category.name"
                    },
                    {
                        data: "quantity"
                    },
                    {
                        render: function() {
                            return "<div id='quantity'><input type='number' style='width: 100%' class='form-control'/></div>";
                        }
                    },
                    {
                        data: "quantity"
                    }
                ]
            });

        $("#product").append(table.row(2).data() - table.row(3).data());

        $('#quantity')
            .focusout(function() {
                console.log("it worked");
            });

        $("#newStatus").on("click",
                ".js-submit",
                function() {
                    var url = "/Transactions/";
                    window.location.href = url;
                    toastr.success("Status successfully recorded.");
                });
    });

