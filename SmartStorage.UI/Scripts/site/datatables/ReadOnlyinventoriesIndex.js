$(document)
    .ready(function () {

        var table = $("#inventories")
            .DataTable({
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
                    }
                ]
            });
    });