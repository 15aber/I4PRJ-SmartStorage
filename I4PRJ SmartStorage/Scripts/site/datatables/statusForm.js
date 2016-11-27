$(document)
    .ready(function() {
        var table = $("#status")
            .DataTable({
                ajax: {
                    url: "/api/status/GetStatus/1",
                    dataSrc: ""
                },
                dom: '<"html5buttons"B>lTfgitp',
                "buttons": [
                {
                    extend: 'collection',
                    text: 'Export',
                    buttons: [
                    { extend: 'copy' },
                    { extend: 'csv' },
                    { extend: 'excel', title: 'Optællingsrapport' },
                    { extend: 'pdf', title: 'Optællingsrapport' },
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
                ],
                "columnDefs": [
                    { "width": "20%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "20%", "targets": 4 }
                ],
                columns: [
                    {
                        data: "product.name"
                    },
                    {
                        data: "product.category.name"
                    },
                    {
                        data: "quantity",
                        render: function (data) {
                            return "<label id='expected'>" + data + "</label>";
                        }
                    },
                    {
                        data: null,
                        render: function () {
                            return "<input type='number' min='0' style='width: 100%' id='tast' class='form-control quantity'/>";
                        }
                    },
                    {
                        data: null,
                        "sDefaultContent": ""
                    }
                ]
            });

        $('#status').on('change', '.quantity', function (eventArg) {
            var cells = $(this).closest('tr').children('td');
            var value1 = document.getElementById("expected").textContent;
            var value2 = cells.eq(3).find('input').val();
            var diff = Math.abs(new Number(value1) - new Number(value2));
            cells.eq(4).text(diff);
        });

        
    });

