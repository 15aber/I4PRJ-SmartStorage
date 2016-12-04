$(document)
    .ready(function () {

        var table = $("#categories")
            .DataTable({
                ajax: {
                    url: "/api/categories/",
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
                        data: "categoryId",
                        "orderable": false,
                        "searchable": false,
                        render: function (data) {
                            return "<button class='btn btn-info js-edit' data-category-id=" + data + ">Edit</button> " +
                                "<button class='btn btn-danger js-delete' data-category-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            });
    });

$("#categories").on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-category-id");
    var url = "/Categories/Edit/" + id;
    window.location.href = url;
});

$("#categories").on("click", ".js-delete", function () {
    var button = $(this);

    bootbox.confirm("Are you sure you want to delete this category?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/categories/deletecategory/" + button.attr("data-category-id"),
                    method: "DELETE",
                    success: function () {
                        window.location.reload(true);
                    }
                });
            }
        });
});