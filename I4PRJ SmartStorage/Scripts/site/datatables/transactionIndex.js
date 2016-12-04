

$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var fromDate = $("#fromdate").datepicker("getDate");
        var toDate = $("#todate").datepicker("getDate");
        console.log(data[4]);
        var updatedDate = new Date(data[4]); // use data for the "updated" column
        
        console.log("updatedDate: " + updatedDate.toLocaleDateString() + " " + updatedDate.getTime());
        console.log("fromdate: " + fromDate.toLocaleDateString() + " " + fromDate.getTime());
        console.log("todate: " + toDate.toLocaleDateString() + " " + toDate.getTime());
        console.log("HEJ");
        console.log(fromDate.getTime() <= updatedDate);

        
        //if ((isNaN(fromDate.getTime()) && isNaN(toDate.getTime())) ||
        //     (isNaN(fromDate.getTime()) &&  updatedDate <= toDate.getTime()) ||
        //     (fromDate.getTime() <= updatedDate && isNaN(toDate.getTime())) ||
        //     (fromDate.getTime() <= updatedDate && updatedDate <= toDate.getTime())) {
        //    return true;
        //}
        //return false;
        return true;
    }
);



$(document).ready(function () {
    $('#fromdate').datepicker({dataFormat: 'dd-mm-yy'});
    $('#todate').datepicker({ dataFormat: 'dd-mm-yy' });
    
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
                    return "0" + date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
                    }
                },
                {
                    data: "byUser"

                }
            ]
        });
    //document.getElementById("filter").addEventListener("click", displayDate);

    //$('fromdate').on('change', function() {
    //    alert(this.val());
    //});
    
    //$('#min, #max').keyup( function() {
    //    table.draw();
    //});
    var table = $('#transactions-table').DataTable();

    $('#filter')
        .click(
            function displayDate() {
                var fromDate = $("#fromdate").datepicker("getDate");
                var toDate = $("#todate").datepicker("getDate");
                //var updatedDate = new Date();
                //updatedDate.setHours(updatedDate.getHours() - 2);
                alert(fromDate.toLocaleDateString() + " --- " + toDate.getTime());
                console.log("I draw now");
                table.draw();
            }); 
});


