$(document)
    .ready(function () {

        var table = $("#categories")
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
                        render: function (data) {
                            return "<button class='btn btn-primary btn-xs js-edit' data-category-id=" + data + ">Edit</button>" +
                                "<button class='btn btn-white btn-xs js-delete' data-category-id=" + data + ">Delete</button>";
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