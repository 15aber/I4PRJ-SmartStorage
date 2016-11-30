function calcDiff(id) {
  var expected = document.getElementById('expected' + id).textContent;
  var curQuantity = document.getElementById('curQuantity' + id).value;
  var result = curQuantity - expected;
  document.getElementById('diff' + id).innerHTML = result;
}

$(document)
    .ready(function () {
        var vm = {
            expQuantities: [],
            curQuantities: [],
            differences: [],
            productIds: []
        };

        var table = $("#status")
            .DataTable({
                ajax: {
                    url: "/api/status/GetStatusOfInventory/" + document.location.pathname.split('/')[3],
                    dataSrc: ""
                },
                rowId: "product.productId",
                "columnDefs": [
                    { "width": "20%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "20%", "targets": 4 }
                ],
                columns: [
                    {
                        data: "product.name"
                    },
                    {
                        data: "product.category.name"
                    },
                    {
                      data: "quantity",
                        render: function(data, type, row, meta) {
                          return "<div id='expected" + meta.row + "' value='" + data + "'>" + data + "</div>";
                        }
                    },
                    {
                      data: "product.productId",
                      render: function (data, type, row, meta) {
                        return "<input type='number' min='0' step='0.25' style='width: 100%' id='curQuantity" + meta.row + "' class='form-control quantity' onChange='calcDiff("+ meta.row +");'/>";
                        }
                    },
                    {
                        data: null,
                        "sDefaultContent": "",
                        render: function (data, type, row, meta) {
                          return "<label id='diff" + meta.row + "'></label>";
                        }
                    },
                    {
                        data: "product.productId",
                        "visible": false,
                        render: function(data) {
                            return "<label id='productIdLabel' value='data'>" + data + "</label>";
                        }
                    }
                ]
            });

       $('.js-submit').on('click', function () {

            var rows = $('#status').dataTable().fnGetNodes();

            for (var i = 0; i < rows.length; i++) {
                var expected = document.getElementById('expected' + i).textContent;
                var current = $(rows[i]).find("td:eq(3)").find('input').val();
                var diff = new Number(expected) - new Number(current);
                var productId = table.cell(i, 5).data();

                if ($("#IsStarted").val() === "True") {
                    vm.IsStarted = false;
                }
                else {
                    vm.IsStarted = true;
                }

                vm.expQuantities.push(expected);
                vm.curQuantities.push(current);
                vm.differences.push(diff);
                vm.productIds.push(productId);
            }

            vm.InventoryId = document.location.pathname.split('/')[3];

            $.ajax({
                url: "/api/status/CreateStatus/",
                method: "post",
                data: vm
            })
                .done(function () {
                    var indexUrl = "/status/index/1";
                    window.location.href = indexUrl;
                })
                .fail(function () {
                    toastr.error("Something unexpected happened!");
                });
        });        
    });