$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
      var fromDate = $("#fromdate").datepicker("getDate");
      var toDate = $("#todate").datepicker("getDate");
      var updatedDate = data[6]; // use data for the hidden "updated" column
      if (fromDate.getTime() === null || toDate.getTime() === null)
        return true;

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
      $("#wholesalers-table")
          .dataTable({
            "order": [[4, "desc"]],
            ajax: {
              url: "/api/wholesalers/getwholesalertransactions",
              dataSrc: ""
            },
            columns: [
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
                  data: "product.wholesalerId",
                  "visible": false
                },
                {
                  data: "updated",
                  render: function (data) {
                    var date = new Date(data);
                    return date.getTime();
                  },
                  "visible": false
                }
            ]
          });
      var table = $("#wholesalers-table").DataTable();

      $("#Wholesaler_WholesalerId").on("change", function () {
        table.columns(5).search(this.value).draw();
      });


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

      $('#fromIcon').click(function () { $('#fromdate').datepicker('show'); });

      $('#toIcon').click(function () { $('#todate').datepicker('show'); });

      $('#filter')
          .click(
              function displayDate() {
                table.draw();
              });
    });