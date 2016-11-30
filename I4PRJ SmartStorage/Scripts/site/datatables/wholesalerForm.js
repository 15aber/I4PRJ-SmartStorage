$(function () {
    $("#from").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        maxDate: '0',
        onSelect: function (selectedDate) {
            $("#to").datepicker("option", "minDate", selectedDate);
        }
    });
    $("#to").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        maxDate: '0',
        onSelect: function (selectedDate) {
            $("#from").datepicker("option", "maxDate", selectedDate);
        }
    });
});
$(document)
    .ready(function() {
        $("#wholesalers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/wholesaler/",
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
                            var date = new Date(data);
                            return date.toLocaleString();
                        }
                    },
                    {
                        data: "byUser"

                    }
                ]
            });
    });