
$(window).on('beforeunload', function () {
    displayBusyIndicator();
});

$(window).on('load', function () {
    $('.loading').hide();
})

//$(document).on('submit', 'form', function () {
//    displayBusyIndicator();
//});

function displayBusyIndicator() {
    $('.loading').show();
}