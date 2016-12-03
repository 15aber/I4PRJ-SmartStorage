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
                    }
                ]
            });
    });