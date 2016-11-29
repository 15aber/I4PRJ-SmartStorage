

//$.fn.dataTable.ext.search.push(
//    function (settings, data, dataIndex) {
//        var min = Date($('#fromdate').val(), 10);
//        var max = parseInt($('#todate').val(), 10);
//        var updatedDate = parseFloat(data[4]) || 0; // use data for the age column

//        if ((isNaN(min) && isNaN(max)) ||
//             (isNaN(min) &&  <= max) ||
//             (min <= updatedDate && isNaN(max)) ||
//             (min <= updatedDate && updatedDate <= max)) {
//            return true;
//        }
//        return false;
//    }
//);



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
    document.getElementById("filter").addEventListener("click", displayDate);

    //$('fromdate').on('change', function() {
    //    alert(this.val());
    //});
    
    //$('#min, #max').keyup( function() {
    //    table.draw();
    //});
});

function displayDate() {
    //dataFormat df = new Sim 
    //DateFormat df = new SimpleDateFormat("MM/dd/yyyy");
    var minimum = document.getElementById("fromdate");
    var fromDate = new Date(minimum);
    alert(minimum.value);
    //alert(fromDate.toLocaleString());
    //var maximum = document.getElementById("todate");
    //var min = new Date(String(minimum));
    //var max = new Date(String(maximum));
    //alert(min.toLocaleDateString("en-US") + " --- " + max.value);
}

