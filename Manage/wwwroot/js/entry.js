$(function () {
    $('.entry-slider .owl-carousel').owlCarousel({
        center: true,
        items: 2,
        loop: false,
        margin: 50,
        dots: false,
        autoWidth: true,
        smartSpeed: 900,
    });

    $(".entry-bar-item").hover(
        function () {
            $('.entry-bar-item').css('color', 'rgba(255, 255, 255, 0.3)');
            $(this).css('color', 'white');
        },
        function () {
            $('.entry-bar-item').css('color', 'white');
        }
    );
})