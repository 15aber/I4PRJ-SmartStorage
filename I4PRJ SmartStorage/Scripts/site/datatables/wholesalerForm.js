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