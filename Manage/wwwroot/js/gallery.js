$(function () {
    $(document).on('click', '.gallery-component', function () {
        var order = $(this).attr('order');
        var bg = $(this).children().eq(0).css('background-image');
        $('.gallery-component-collection').addClass('d-none');
        $(`.gallery-component-collection[order='${order}']`).removeClass('d-none');
        $(`.gallery-active-photo[order='${order}']`).css('background-image', `${bg}`);
        $('.gallery-modal').addClass('active-modal');
        $('body').css('overflow', 'hidden');
        $('header').css('z-index', '1');
    })

    $(window).on('click', function (event) {
        let target = $(event.target);
        if (target.is('.gallery-component-collection') || target.is('.gallery-modal')) {
            $('.gallery-modal').removeClass('active-modal');
            $('body').css('overflow', 'auto');
            $('header').css('z-index','99');
        }
    })

    $(document).on('click','.thumbnail',function () {
        var order = $(this).attr('order');
        var bg = $(this).css('background-image');
        $(`.gallery-active-photo[order='${order}']`).css('background-image', `${bg}`);
    })
})