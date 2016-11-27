$(document).ready(function () {
    $('#date').datepicker({ dataFormat: 'dd/mm/yyyy' });
    $("#transactions-table")
        .dataTable({
            "order": [[4, "desc"]],
            ajax: {
                url: "/api/transactions/",
                dataSrc: ""
            },
            columns: [
                {
                    data: "product.name"
                },
                {
                    data: "fromInventory.name"
                },
                {
                    data: "toInventory.name"
                },
                {
                    data: "quantity"
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

                }
            ]
        });
});