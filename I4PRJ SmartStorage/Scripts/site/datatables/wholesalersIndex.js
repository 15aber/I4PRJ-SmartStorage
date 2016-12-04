$(document)
    .ready(function () {

        var table = $("#wholesalers")
            .DataTable({
                ajax: {
                    url: "/api/wholesalers/",
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
                        data: "wholesalerId",
                        "orderable": false,
                        "searchable": false,
                        render: function (data) {
                            return "<button class='btn btn-info js-edit' data-wholesaler-id=" + data + ">Edit</button> " +
                                "<button class='btn btn-danger js-delete' data-wholesaler-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            });
    });

$("#wholesalers").on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-wholesaler-id");
    var url = "/Wholesaler/Edit/" + id;
    window.location.href = url;
});

$("#wholesalers").on("click", ".js-delete", function () {
    var button = $(this);

    bootbox.confirm("Are you sure you want to delete this wholesaler?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/wholesaler/deletewholesaler/" + button.attr("data-wholesaler-id"),
                    method: "DELETE",
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        });
});