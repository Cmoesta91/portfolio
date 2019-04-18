$(document).ready(function () {
    LoadProducts();
});

var money = 0.00;
var price = 0.00;
var id = 0;
var moneyQuarter = 0;
var moneyDime = 0;
var moneyNickel = 0;

function LoadProducts() {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function (data, status) {
            $('#candy1').text('').append(data[0].id);
            $('#cN1').text('').append(data[0].name);
            $('#cP1').text('').append('$' + data[0].price);
            $('#qN1').text('').append(data[0].quantity);

            $('#candy2').text('').append(data[1].id);
            $('#cN2').text('').append(data[1].name);
            $('#cP2').text('').append('$' + data[1].price);
            $('#qN2').text('').append(data[1].quantity);

            $('#candy3').text('').append(data[2].id);
            $('#cN3').text('').append(data[2].name);
            $('#cP3').text('').append('$' + data[2].price);
            $('#qN3').text('').append(data[2].quantity);

            $('#candy4').text('').append(data[3].id);
            $('#cN4').text('').append(data[3].name);
            $('#cP4').text('').append('$' + data[3].price);
            $('#qN4').text('').append(data[3].quantity);

            $('#candy5').text('').append(data[4].id);
            $('#cN5').text('').append(data[4].name);
            $('#cP5').text('').append('$' + data[4].price);
            $('#qN5').text('').append(data[4].quantity);

            $('#candy6').text('').append(data[5].id);
            $('#cN6').text('').append(data[5].name);
            $('#cP6').text('').append('$' + data[5].price);
            $('#qN6').text('').append(data[5].quantity);

            $('#candy7').text('').append(data[6].id);
            $('#cN7').text('').append(data[6].name);
            $('#cP7').text('').append('$' + data[6].price);
            $('#qN7').text('').append(data[6].quantity);

            $('#candy8').text('').append(data[7].id);
            $('#cN8').text('').append(data[7].name);
            $('#cP8').text('').append('$' + data[7].price);
            $('#qN8').text('').append(data[7].quantity);

            $('#candy9').text('').append(data[8].id);
            $('#cN9').text('').append(data[8].name);
            $('#cP9').text('').append('$' + data[8].price);
            $('#qN9').text('').append(data[8].quantity);
        },
        error: function () {
            alert("FAILURE");
        }
    })
};

$('.candyButton').on('click', function () {
    id = this.value;
    price = $('#cP' + id).text().substring(1);
    var itemInfo = this.value + ': ' + $('#cN' + id).text();
    $('#itemBox').text('').append(itemInfo);

});

$('#dollar').on('click', function () {
    money += 1;
    $('#totalBox').text('').append(money.toFixed(2));
    moneyQuarter += 4;
});

$('#quarter').on('click', function () {
    money += .25;
    $('#totalBox').text('').append(money.toFixed(2));
    moneyQuarter += 1;
});

$('#dime').on('click', function () {
    money += .10;
    $('#totalBox').text('').append(money.toFixed(2));
    moneyDime += 1;
});

$('#nickel').on('click', function () {
    money += .05;
    $('#totalBox').text('').append(money.toFixed(2));
    moneyNickel += 1;
});


$('#purchase').on('click', function () {

    $.ajax({
        type: "GET",
        url: "http://localhost:8080/money/" + money + "/item/" + id,
        success: function (data, status) {
            $('#messageBox').text('Thank you!!!');
            $('#changeBox').text(' ' + data.quarters + ' quarters ' + data.dimes + ' dimes ' + data.nickels + ' nickel ' + data.pennies + ' pennies ');
            LoadProducts();
            $('#totalBox').text('').append('&nbsp;');
            money = 0;
            moneyQuarter = 0;
            moneyDime = 0;
            moneyNickel = 0;
        },
        statusCode: {
            422: function (xhr) {
                $('#messageBox').text($.parseJSON(xhr.responseText).message);
            }
        }

    });
});

$('#changeButton').on('click', function () {
    $('#totalBox').text('').append('&nbsp;');
    money = 0;
    $('#messageBox').text('').append('&nbsp;');
    $('#itemBox').text('').append('&nbsp;');
    $('#changeBox').text(''+ moneyQuarter + ' quarters ' + moneyDime + ' dimes ' + moneyNickel + ' nickels ');
    moneyQuarter = 0;
    moneyDime = 0;
    moneyNickel = 0;
});