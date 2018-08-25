var ProductsControllerFunction = function () {

    var renderPartial = function (data) {
        $("#productsContent").empty().append(data);
    };

    var ajaxObject = {
        CurrentPage: 0
    };

    var requestUrl = 'Home/GetPaginatedProducts';

    var that = {
        setRequestUrl: function (url) {
            if (url) {
                requestUrl = url;
            }
        },
        setPage: function (pageNumber) {
            if (!isNaN(pageNumber)) {
                ajaxObject.CurrentPage = pageNumber;
            }
        },
        getProducts: function () {
            $.ajax({
                url: requestUrl,
                data: ajaxObject,
                dataType: 'html',
                method: 'POST',
                success: function (data) {
                    renderPartial(data);
                },
                error: function (err) {
                    console.error(err);
                }
            });
        }
    };
    return that;
};

var productsController = new ProductsControllerFunction();


