$(document)
    .ready(function () {

        var table = $("#inventories")
            .DataTable({
                paging: false,
                searching: true,
                "info": false,
                "ordering": true,
                dom: '<"html5buttons"B>lTfgitp',
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
                ],
                ajax: {
                    url: "/api/inventories/",
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "name"
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
                    },
                    {
                        data: "inventoryId",
                        render: function (data) {
                            return "<button class='btn btn-primary btn-xs js-edit' data-inventory-id=" + data + ">Edit</button>" +
                                "<button class='btn btn-white btn-xs js-delete' data-inventory-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            });
    });

$("#inventories").on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-inventory-id");
    var url = "/Inventories/Edit/" + id;
    window.location.href = url;
});

$("#inventories").on("click", ".js-delete", function () {
    var button = $(this);

    bootbox.confirm("Are you sure you want to delete this inventory?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/inventories/deleteinventory/" + button.attr("data-inventory-id"),
                    method: "DELETE",
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        });
});