$(document)
    .ready(function () {

        var table = $("#stocks")
            .DataTable({
                ajax: {
                    url: "/api/stocks/" + document.location.pathname.split('/')[3],
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "product.name"
                    },
                    {
                        data: "quantity"
                    }
                ]
            });
    });