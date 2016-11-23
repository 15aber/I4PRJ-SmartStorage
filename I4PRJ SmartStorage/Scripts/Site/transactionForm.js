$(document)
    .ready(function () {

    // add eventlistener for 
    $('#Transaction_FromInventoryId')
        .on('change',
            function () {

                // ajax get products of inventory

                $.get('/api/Products/GetProductsOfInventory/' + this.value,
                    function (data) {
                        // populate with options
                        var productsOfInveorySelect = $('#Transaction_ProductId');
                        // remove selected from select

                        productsOfInveorySelect.empty();

                        if (!data || data.length === 0) {
                            productsOfInveorySelect.append(new Option('Please choose', undefined));
                            return;
                        }

                        for (var i = 0; i < data.length; i++) {
                            productsOfInveorySelect.append(new Option(data[i].Name, data[i].ProductId));
                        }

                    });
            });

});