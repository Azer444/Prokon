$(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 58) {
            $('header .header-top').css('visibility', 'hidden');
            $('header').css({
                'position': 'sticky',
                'top': '-58px',
                'box-shadow': '0px 6px 10px -10px gray'
            });
            $('.top-0-btn').addClass('active');
        } else {
            $('header .header-top').css('visibility', 'visible');
            $('header').css({
                'position': 'static',
                'box-shadow': 'none'
            });;
            $('.top-0-btn').removeClass('active');
        }
    });

    $(document).on('click', '.top-0-btn', () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    })

    $(document).on('click', '.bar-icon', function () {
        $('.mobile-menu-section').css({
            'transform': 'translateX(0)',
            'opacity': 1
        })
    })

    $(document).on('click','.close-menu-icon', function () {
        $('.mobile-menu-section').css({
            'transform': 'translateX(100%)',
            'opacity': 0
        })
    })

    $('.mm-bar-item').click( function () {
            $('.mm-bar-item').css('color', 'rgba(255, 255, 255, 0.3)');
            $(this).css('color', 'white');

            var pageId = $(this).attr('page-id');

            $('.mm-bar-item-components').addClass('d-none');
            $(`.mm-bar-item-components[page-id='${pageId}']`).removeClass('d-none');
        }
    );

    $('.select-box').click(function () {
        $('.mm-bar-item-components').addClass('d-none');
        $('.mm-bar-item').css('color', 'rgba(255, 255, 255, 0.3)');
    })
})