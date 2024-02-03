$(function () {
    $(document).on('click', '.az-access', function () {
        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');

        $('.licence-components').addClass('d-none');
        $('.az-licences').removeClass('d-none');
    })

    $(document).on('click', '.ru-access', function () {
        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');

        $('.licence-components').addClass('d-none');
        $('.ru-licences').removeClass('d-none');
    })

    $(document).on('click', '.tr-access', function () {
        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');

        $('.licence-components').addClass('d-none');
        $('.tr-licences').removeClass('d-none');
    })
})