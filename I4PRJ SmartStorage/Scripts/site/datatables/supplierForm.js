$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var fromDate = $("#fromdate").datepicker("getDate");
        var toDate = $("#todate").datepicker("getDate");
        //console.log(data[8]);
        var updatedDate = (data[8]); // use data for the "updated" column
        if (fromDate.getTime() === null || toDate.getTime() === null)
            return true;

        //console.log(fromDate);
        //console.log("updatedDate: " + updatedDate.toLocaleDateString() + " " + updatedDate.getTime());
        //console.log("fromdate: " + fromDate.toLocaleDateString() + " " + fromDate.getTime());
        //console.log("todate: " + toDate.toLocaleDateString() + " " + toDate.getTime());


        if (isNaN(fromDate.getTime()) && isNaN(toDate.getTime()) ||
             isNaN(fromDate.getTime()) && updatedDate <= toDate.getTime() ||
             fromDate.getTime() <= updatedDate && isNaN(toDate.getTime()) ||
             fromDate.getTime() <= updatedDate && updatedDate <= toDate.getTime()) {
            return true;
        }
        return false;
    }
);


$(document)
    .ready(function () {
        $("#suppliers-table")
            .dataTable({
                "order": [[4, "desc"]],
                ajax: {
                    url: "/api/suppliers/getsuppliertransactions",
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
                    },
                    {
                        data: "updated",
                        render: function (data) {
                            var date = new Date(data).getTime();
                            return date;
                        },
                        "visible": false
                    }
                ]
            });
        var table = $("#suppliers-table").DataTable();

        $("#Supplier_SupplierId").on("change", function () {
            table.columns(6).search(this.value).draw();
        });


        $('#fromdate').datepicker({
            dataFormat: "dd-mm-yy",
            defaultDate: '-1m',
            changeMonth: true,
            changeYear: true,
            onSelect: function (selectedDate) {
                $("#todate").datepicker("option", "minDate", selectedDate);
            }
        });
        $('#todate').datepicker({
            dataFormat: "dd-mm-yy",
            maxDate: 0, changeMonth: true,
            changeYear: true,
            onSelect: function (selectedDate) {
                $("#fromdate").datepicker("option", "maxDate", selectedDate);
            }
        });

        $('#fromIcon').click(function () { $('#fromdate').datepicker('show'); });

        $('#toIcon').click(function () { $('#todate').datepicker('show'); });

        $('#filter')
            .click(
                function displayDate() {
                    table.draw();
                });

    });

