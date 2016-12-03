//$(function () {
//    $("#from").datepicker({
//        dateFormat: "dd.mm.yy",
//        changeMonth: true,
//        changeYear: true,
//        maxDate: "0",
//        onSelect: function (selectedDate) {
//            $("#to").datepicker("option", "minDate", selectedDate);
//        }
//    });
//    $("#to").datepicker({
//        dateFormat: "dd.mm.yy",
//        changeMonth: true,
//        changeYear: true,
//        maxDate: "0",
//        onSelect: function (selectedDate) {
//            $("#from").datepicker("option", "maxDate", selectedDate);
//        }
//    });
//});
$(document)
    .ready(function () {
        $("#wholesalers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/wholesaler/",
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
                            { extend: 'excel', title: 'Grossistsrapport' },
                            { extend: 'pdf', title: 'Grossistsrapport' },
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
                            var date = new Date(data).toLocaleDateString();
                            return date;
                        }
                    },
                    {
                        data: "byUser"
                    },
                    {
                        data: "product.wholesaler.wholesalerId",
                        "visible": false
                    }
                ]
            });
        var table = $("#wholesalers-table").DataTable();

        $("#Wholesaler_WholesalerId").on("change", function () {
            table.columns(6).search(this.value).draw();
        });
    });

