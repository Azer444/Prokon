$(function () {
    $(document).on('click','.completed-access', function () {
        $('.current-access').removeClass('active-access');
        $(this).addClass('active-access');
        $('.current-project-components').addClass('d-none');
        $('.completed-project-components').removeClass('d-none');
    })

    $(document).on('click','.current-access', function () {
        $('.completed-access').removeClass('active-access');
        $(this).addClass('active-access');
        $('.completed-project-components').addClass('d-none');
        $('.current-project-components').removeClass('d-none');
    })
})