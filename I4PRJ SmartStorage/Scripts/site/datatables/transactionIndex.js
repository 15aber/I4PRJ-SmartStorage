$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var fromDate = $("#fromdate").datepicker("getDate");
        var toDate = $("#todate").datepicker("getDate");
        console.log(data[4]);
        var updatedDate = new Date(data[4]); // use data for the "updated" column
        if (fromDate === null || toDate === null)
            return true;

        console.log(fromDate);
        console.log("updatedDate: " + updatedDate.toLocaleDateString() + " " + updatedDate.getTime());
        console.log("fromdate: " + fromDate.toLocaleDateString() + " " + fromDate.getTime());
        console.log("todate: " + toDate.toLocaleDateString() + " " + toDate.getTime());

        
        if (isNaN(fromDate.getTime()) && isNaN(toDate.getTime()) ||
             isNaN(fromDate.getTime()) &&  updatedDate <= toDate.getTime() ||
             fromDate.getTime() <= updatedDate && isNaN(toDate.getTime()) ||
             fromDate.getTime() <= updatedDate && updatedDate <= toDate.getTime()) {
            return true;
        }
        return false;
    }
);



$(document).ready(function () {
    
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
                    data: "fromInventory.name",
                    "sDefaultContent": ""
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
                    return date.toLocaleDateString();
                    //return "0" + date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
                    }
                },
                {
                    data: "byUser"

                }
            ]
        });

    var table = $('#transactions-table').DataTable();

    
    $('#fromdate').datepicker({
        dataFormat: "dd-mm-yy",
        defaultDate: '01/01/2010',
        changeMonth: true,
        changeYear: true,
        onSelect: function(selectedDate) {
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

    $('#fromIcon').click(function() { $('#fromdate').datepicker('show'); });
 
    $('#toIcon').click(function () { $('#todate').datepicker('show'); });

    $('#filter')
        .click(
            function displayDate() {
                table.draw();
            }); 
});


