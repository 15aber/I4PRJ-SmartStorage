$("#from").datepicker({dateFormat: "dd-mm-yyyy",
    defaultDate: new Date(),
    maxDate: new Date(),
    onSelect: function (dateStr) {
        $("#to").val(dateStr);
        $("#to").datepicker("option", { minDate: new Date(dateStr), maxDate: 0 })
    }
});

$('#to').datepicker({
    defaultDate: new Date(),
    onSelect: function (dateStr) {
        var toDate;
        toDate = new Date(dateStr);

        // Converts date objects to appropriate strings
        var fromDate = window.ConvertDateToShortDateString(fromDate);
        toDate = window.ConvertDateToShortDateString(toDate);
    }
});