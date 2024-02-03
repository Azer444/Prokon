$(function () {
    $('#Title_EN').on('input', function () {
        $('#Slug').val(slug($(this).val()));
    });
})