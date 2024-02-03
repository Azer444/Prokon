$(function () {
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