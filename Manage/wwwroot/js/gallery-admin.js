$(function () {
    $('#ShowOnHomePage').change(function () {
        if (this.checked) {
            $('.order-title').removeClass('d-none');
            $('.order-select').removeClass('d-none');
        }
        else {
            $('.order-title').addClass('d-none');
            $('.order-select').addClass('d-none');
        }
    });

    if ($('#ShowOnHomePage').is(':checked')) {
        $('.order-title').removeClass('d-none');
        $('.order-select').removeClass('d-none');
    }
})