$.extend(true, $.fn.dataTable.defaults, {
    "paging": false,
    "lengthChange": false,
    "searching": true,
    "processing": true,
    "scrollX": false,
    "scrollY": false,
    "info": true,
    "ordering": true,
    "dom": '<"html5buttons"B><f<t>i>',
    "buttons": [
        {
            extend: 'collection',
            text: 'Export',
            buttons: [
                { extend: 'copy' },
                { extend: 'csv' },
                { extend: 'excel', title: 'SmartStorage' },
                { extend: 'pdf', title: 'SmartStorage' },
                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body)
                            .find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ]
        }
    ]
});