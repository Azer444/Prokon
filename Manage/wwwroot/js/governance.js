$(function () {
    $('.management .owl-carousel').owlCarousel({
        items: 1,
        loop: true,
        autoplay: true,
        autoplayTimeout: 8000,
        autoplayHoverPause: true,
        smartSpeed: 900,
	    mouseDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
        touchDrag: $('.owl-carousel .owl-item').length > 1 ? true : false,
    });
})