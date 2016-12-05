$(document)
    .ready(function () {

        var table = $("#suppliers")
            .DataTable({
                ajax: {
                    url: "/api/suppliers/",
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
                        data: "supplierId",
                        "orderable": false,
                        "searchable": false,
                        render: function (data) {
                          return "<button class='btn btn-primary btn-sm js-edit' data-supplier-id=" + data + ">Edit</button> " +
                                "<button class='btn btn-danger btn-sm js-delete' data-supplier-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            });
    });

$("#suppliers").on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-supplier-id");
    var url = "/Suppliers/Edit/" + id;
    window.location.href = url;
});

$("#suppliers").on("click", ".js-delete", function () {
    var button = $(this);

    bootbox.confirm("Are you sure you want to delete this supplier?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/supplier/deletesupplier/" + button.attr("data-supplier-id"),
                    method: "DELETE",
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        });
});