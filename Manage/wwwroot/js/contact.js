$(function () {
    $(document).on('click', '.contact-map-location', function () {
        var order = $(this).attr('order');
        if ($(window).width() < 768) {
            var mapInfoHeight = $(`.contact-map-info[order=${order}]`).height();
            $('.contact-component').css('height', mapInfoHeight);
        }
        $(`.contact-map-info[order=${order}]`).css('z-index', '1');
        $(`.contact-map-info[order=${order}] .contact-map-info-content`).css({
            'transform': 'translateX(0)',
            'opacity': '1'
        });
        $(` .contact-map-info[order=${order}] .contact-map-info-image`).css({
            'transform': 'translateX(0)',
            'opacity': '1'
        });
    })

    $(document).on('click', '.contact-info-close-icon', function () {
        var order = $(this).attr('order');

        if ($(window).width() < 768) {
            $('.contact-component').css('height', '100%');
        }
        $(`.contact-map-info[order=${order}] .contact-map-info-content`).css({
            'transform': 'translateX(-200%)',
            'opacity': '0'
        });
        $(`.contact-map-info[order=${order}] .contact-map-info-image`).css({
            'transform': 'translateX(200%)',
            'opacity': '0'
        });
        $(`.contact-map-info[order=${order}]`).css('z-index', '-1');
    })

    $('.contact-map-info-image').height($('.contact-map-image').height())

    $(window).on('resize', function () {
        $('.contact-map-info-image').height($('.contact-map-image').height())
    });
})