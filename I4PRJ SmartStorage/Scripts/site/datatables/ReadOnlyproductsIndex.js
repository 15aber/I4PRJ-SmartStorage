$(document)
    .ready(function () {

        var table = $("#products")
            .DataTable({
                ajax: {
                    url: "/api/products/getproductsofcategory/" + document.location.pathname.split('/')[3],
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "name"
                    },
                    {
                        data: "purchasePrice",
                        render: function (data) {
                            var price = data;
                            return price.toFixed(2);
                        }
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