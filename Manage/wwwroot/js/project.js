$(function () {
    $('.project-mobile-slider .owl-carousel').owlCarousel({
        items: 1,
        nav: true,
        navText: ["<img style='transform:rotate(180deg)' src='/img/Vector (6).svg'>", "<img src='/img/Vector (6).svg'>"],
        dots: false,
        smartSpeed: 900,
    });

    $(document).on('click', '.project-photos .project-detail-main-photo', function () {
        var photo = $(this).attr('src');
        $('.gallery-active-photo img').attr('src', `${photo}`);
        $('.gallery-modal').addClass('active-modal');
        $('body').css('overflow', 'hidden');
        $('header').css('z-index', '1');

        if ($(this).prop('naturalHeight') > $(this).prop('naturalWidth')) {
            $(`.gallery-active-photo img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo img`).css('width', '100%');
        }
    })

    $(document).on('click', '.project-photos .project-thumbnail', function () {
        var photo = $(this).attr('src');
        $('.gallery-active-photo img').attr('src', `${photo}`);
        $('.gallery-modal').addClass('active-modal');
        $('body').css('overflow', 'hidden');
        $('header').css('z-index', '1');

        if ($(this).prop('naturalHeight') > $(this).prop('naturalWidth')) {
            $(`.gallery-active-photo img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo img`).css('width', '100%');
        }
    })

    $(document).on('click', '.project-photos .cover', function () {
        var photo = $('.project-photos .project-detail-main-photo').attr('src');
        $('.gallery-active-photo img').attr('src', `${photo}`);
        $('.gallery-modal').addClass('active-modal');
        $('body').css('overflow', 'hidden');
        $('header').css('z-index', '1');

        if ($('.project-photos .project-detail-main-photo').prop('naturalHeight') > $('.project-photos .project-detail-main-photo').prop('naturalWidth')) {
            $(`.gallery-active-photo img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo img`).css('width', '100%');
        }
    })

    $(document).on('click', '.thumbnail', function () {
        var photo = $(this).attr('src');
        $('.gallery-active-photo img').attr('src', `${photo}`);

        if ($(this).prop('naturalHeight') > $(this).prop('naturalWidth')) {
            $(`.gallery-active-photo img`).css('width', 'auto');
        }
        else {
            $(`.gallery-active-photo img`).css('width', '100%');
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
})