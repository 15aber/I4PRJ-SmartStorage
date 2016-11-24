$(document)
    .ready(function() {
        var table = $("#status")
            .DataTable({
                ajax: {
                    url: "/api/status/1",
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
                        data: "quantity"
                    },
                    {
                        render: function() {
                            return "<input type='number' style='width: 100%' class='form-control quantity'/>";
                        }
                    },
                    {
                        data: "quantity"
                    }
                ]
            });

        $('.quantity')
            .on('focusout',
                function() {
                    alert("it worked");
                });
        $('#quantity')
            .focusout(function() {
                alert("it worked");
            });

        $('#quantity')
            .addEventListener("focusout",
                function() {
                    alert("it worked");
                });

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

