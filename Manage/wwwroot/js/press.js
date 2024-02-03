$(function () {
    $(document).on('click','.community-access',function () {
        $('.news-access').removeClass('active-access');
        $(this).addClass('active-access');
        
        $('.p-news-components').addClass('d-none');
        $('.community-components').removeClass('d-none');
    })

    $(document).on('click','.news-access',function () {
        $('.community-access').removeClass('active-access');
        $(this).addClass('active-access');
        
        $('.community-components').addClass('d-none');
        $('.p-news-components').removeClass('d-none');
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