﻿$(document)
    .ready(function () {

        var table = $("#status")
            .DataTable({
                ajax: {
                    url: "/api/status/GetStatus/1",
                    dataSrc: ""
                },
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
                        render: function() {
                            return "<input type='number' min='0' style='width: 100%' id='tast' class='form-control quantity'/>";
                        }
                    },
                    {


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

        //cells.eq(4).text(new Number(value1) - new Number(value2));

        //$('.quantity')
        //    .on('focusout',
        //        function() {
        //            alert("it worked");
        //        });
        //$('#quantity')
        //    .focusout(function() {
        //        alert("it worked");
        //    });

        //$('#quantity')
        //    .addEventListener("focusout",
        //        function() {
        //            alert("it worked");
        //        });

        $('#newStatus').validate({
            submitHandler: function () {
                $.ajax({
                    url: "/api/status",
                    method: "post",
                    dataSrc: ""
                })
                .done(function () {
                    toastr.success("Status successfully recorded.");
                })
                .fail(function () {
                    toastr.error("Something unexpected happened.");
                });

                return false;
            }

        });
    });

