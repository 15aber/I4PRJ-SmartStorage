$(document)
    .ready(function () {
        var vm = {
            quantities: [],
            differences: [],
            productIds: []
        };

        var table = $("#status")
            .DataTable({
                ajax: {
                    url: "/api/status/GetStatus/" + document.location.pathname.split('/')[3],
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
                                customize: function(win) {
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
                        render: function(data) {
                            return "<label id='expected'>" + data + "</label>";
                        }
                    },
                    {
                        data: null,
                        render: function() {
                            return "<input type='number' min='0' step='0.25' style='width: 100%' id='curQuantity' class='form-control quantity'/>";
                        }
                    },
                    {
                        data: null,
                        "sDefaultContent": ""
                    },
                    {
                        data: "product.productId",
                        "visible": false,
                        render: function(data) {
                            return "<label id='productIdLabel' value='data'>" + data + "</label>";
                        }
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

        $('.js-submit').on('click', function () {

            var rows = $('#status').dataTable().fnGetNodes();

            for (var i = 0; i < rows.length; i++) {
                var expected = document.getElementById("expected").textContent;
                var current = $(rows[i]).find("td:eq(3)").find('input').val();
                var diff = Math.abs(new Number(expected) - new Number(current));
                var productId = table.cell(i, 5).data();

                alert(productId);
                
                vm.quantities.push(current);
                vm.differences.push(diff);
                vm.productIds.push(productId);
            }


            vm.InventoryId = document.location.pathname.split('/')[3];





            //var cells = $(this).closest('tr').children('td');
            //var quantity = cells.eq(3).find('input').val();
            //vm.quantities.push(quantity);

            $.ajax({
                url: "/api/status/CreateNewStatus/",
                method: "post",
                data: vm
            })
                .done(function () {
                    window.location.href = url;
                })
                .fail(function () {
                    toastr.error("Something unexpected happened!");
                });
        });

    });