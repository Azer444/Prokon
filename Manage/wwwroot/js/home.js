$(function () {
    $('.banner .owl-carousel').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        autoplayTimeout: 8000,
        autoplayHoverPause: true,
        smartSpeed: 900,
        mouseDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
        touchDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
    });

    $('.licence-section-center .owl-carousel').owlCarousel({
        loop: false,
        nav: true,
        autoplay: true,
        autoplayTimeout: 8000,
        smartSpeed: 900,
        autoplayHoverPause: true,
        dots: false,
        mouseDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
        touchDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
        navText: ["<img style='transform:rotate(180deg)' src='/img/Vector (6).svg'>", "<img src='/img/Vector (6).svg'>"],
        responsive: {
            0: {
                items: 1
            },
            772: {
                items: 2
            },
            1200: {
                items: 3
            }
        }
    });

    $('.our-project-bottom .owl-carousel').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        autoplayTimeout: 8000,
        autoplayHoverPause: true,
        smartSpeed: 900,
    });

    $(document).on('click', '.gallery-section-center .gallery-component', function () {
        var order = $(this).attr('order');
        var photo = $(this).attr('src');
        $('.gallery-component-collection').addClass('d-none');
        $(`.gallery-component-collection[order='${order}']`).removeClass('d-none');
        $(`.gallery-active-photo[order='${order}'] img`).attr('src', `${photo}`);
        $('.gallery-modal').addClass('active-modal');
        $('body').css('overflow', 'hidden');
        $('header').css('z-index', '1');

        if ($(this).prop('naturalHeight') > $(this).prop('naturalWidth')) {
            $(`.gallery-active-photo[order='${order}'] img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo[order='${order}'] img`).css('width', '100%');
        }
    })


    $(window).on('click', function (event) {
        let target = $(event.target);
        if (target.is('.gallery-component-collection') || target.is('.gallery-modal')) {
            $('.gallery-modal').removeClass('active-modal');
            $('body').css('overflow', 'auto');
            $('header').css('z-index', '99');
        }
    })

    $(document).on('click', '.thumbnail', function () {
        var order = $(this).attr('order');
        var photo = $(this).attr('src');
        $(`.gallery-active-photo[order='${order}'] img`).attr('src', `${photo}`);

        console.log($(this).prop('naturalHeight'))
        console.log($(this).prop('naturalWidth'))

        if ($(this).prop('naturalHeight') > $(this).prop('naturalWidth')) {
            $(`.gallery-active-photo[order='${order}'] img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo[order='${order}'] img`).css('width', '100%');
        }
    })

    $(".news-component .news-component-bottom-content-text").each(function () {
        var text = $(this).children().eq(0).text();
        if (text.length > 200) {
            $(this).text(text.substr(0, text.lastIndexOf(' ', 197)) + '...');
        }
        else {
            $(this).text(text + '...');
        }
    });
})

