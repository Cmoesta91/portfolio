$(document).ready(function () {

});

$('#submitButton').on('click', function () {
    $('#errorList').empty();
    //alert('help');

    var searchType = $('#submitButton').val();

    var isError = false;
    var term = $('#searchBar').val();
    var minPrice = $('#minPriceBar').val();
    var maxPrice = $('#maxPriceBar').val();
    var minYear = $('#minYearBar').val();
    var maxYear = $('#maxYearBar').val();

    if (minYear == "") { minYear = 2000; }
    if (maxYear == "") { maxYear = 2020; }

    if (term == "") {
        term = 'hamster';
    } if (minPrice == "") {
        minPrice = 0;
    } if (maxPrice == "") {
        maxPrice = 999999999;
    } if (minPrice < 0 || maxPrice < 0) {
        $('#errorList').append("<li>Prices must be positive.</li>");
        isError = true;
    } if (minPrice >= maxPrice) {
        $('#errorList').append("<li>Min Price must be lower than Max Price.</li>");
        isError = true;
    } if (minYear > maxYear) {
        $('#errorList').append("<li>Min Year must be lower than Max Year.</li>");
        isError = true;
    } if (isError == false) {
        $('#searchResults').empty();
        //alert(term + minPrice + maxPrice + minYear + maxYear)
        //alert(searchType);
        $.ajax({
            type: 'GET',
            url: 'http://localhost:61818/api/inventory/search/' + searchType + '/' + term + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear,
            success: function (data) {
                //alert(JSON.stringify(data));
                $.each(data, function (index, item) {
                    var id = item.VehicleId;
                    var year = item.CarYear;
                    var make = item.Make.MakeName;
                    var model = item.Model.ModelName;
                    var body = item.BodyStyle;
                    var trans = item.Trans;
                    var color = item.Color;
                    var interior = item.Interior;
                    var mileage = item.Mileage;
                    var vin = item.Vin;
                    var price = item.SalePrice;
                    var msrp = item.MSRP;

                    $('#searchResults').append('<div class="row detailBox" style="border-style: solid"><div class= "col-md-3"><p>' + year + '  ' + make + '  ' + model + '</p><img src="\\Images\\CarSymbolInverted.png"></div><div class="col-md-3"><br/><p>' + '<span>Body Type: </span>' + body + '</p><p>' + trans + '</p><p>' + color + '</p></div><div class="col-md-3"><br/><p>' + interior + '</p><p>' + mileage + '</p><p>' + vin + '</p></div><div class="col-md-3"><br/><p>' + price + '</p><p>' + msrp + '</p><p><a href=/Inventory/Details/' + id + '>Details</a></p></div></div><br/>')
                })
                if (data.length == 0) {
                    alert("No Results Found With Selected Parameters.");
                }


            },
            error: function (xHR) {
                alert(JSON.stringify(xHR.responseJSON));
            }
        });
    }
});

$('#makeDropDown').on('change', function () {
    $('#modelDropDown').empty();
    var make = $('#makeDropDown').val();
    if (make != "") {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:61818/api/admin/modellist/' + make,
            success: function (data) {
            //alert(JSON.stringify(data));

                $.each(data, function (index, item) {

                    var modelName = item.ModelName;
                    var modelId = item.ModelID;

                    $('#modelDropDown').append('<option value="' + modelId + '">' + modelName + '</option>');


                });
            },

            error: function () {
                alert("NO");
            }
        })
    }
})