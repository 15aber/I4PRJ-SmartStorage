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
                    }
                ]
            });
    });