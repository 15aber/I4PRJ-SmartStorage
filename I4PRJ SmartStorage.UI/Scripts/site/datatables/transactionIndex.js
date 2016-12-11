$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var fromDate = $("#fromdate").datepicker("getDate");
        var toDate = $("#todate").datepicker("getDate");
        var updatedDate = data[6]; // use data for the hidden "updated" column
        if (fromDate.getTime() === null || toDate.getTime() === null)
            return true;
        console.log("from: " + fromDate);
        console.log("to: " + toDate);
        
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
    
    $("#transactions")
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
                    return date.toLocaleDateString('da-DK');
                    //return "0" + date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
                    }
                },
                {
                    data: "byUser"

                },
                {
                    data: "updated",
                    render: function(data) {
                        var date = new Date(data);
                        return date.getTime();
                    },
                    "visible": false
                }
            ]
        });

    var table = $('#transactions').DataTable();

    
    $('#fromdate').datepicker({
      dateFormat: "dd-mm-yy",
        defaultDate: -30,
        changeMonth: true,  
        changeYear: true,
        showOtherMonths: true,
        selectOtherMonths: true
    });
    $('#todate').datepicker({
      dateFormat: "dd-mm-yy",
      defaultDate: +1,
        maxDate: +1,
        changeMonth: true,
        changeYear: true,
        showOtherMonths: true,
        selectOtherMonths: true
    });

    $('#fromIcon').click(function() { $('#fromdate').datepicker('show'); });
 
    $('#toIcon').click(function () { $('#todate').datepicker('show'); });

    $('#filter')
        .click(
            function displayDate() {
                table.draw();
            }); 
});


