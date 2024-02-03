$(function () {

    $(document).on('click', '.job-access', function () {
        $('.careerr').addClass('d-none');
        $('.job-career').removeClass('d-none');

        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');
    })

    $(document).on('click', '.intern-access', function () {
        $('.careerr').addClass('d-none');
        $('.intern-career').removeClass('d-none');

        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');
    })

    $(document).on('click', '.general-access', function () {
        $('.careerr').addClass('d-none');
        $('.general-career').removeClass('d-none');

        $('.c-access').removeClass('active-access');
        $(this).addClass('active-access');
    })

    $(document).on('click', '.accordion-button', function () {
        if (!$(this).hasClass('collapsed')) {
            $('.accordion-item').css('box-shadow', 'none');
            $(this).parents().eq(1).css('box-shadow', '0px 1px 7px rgba(191, 191, 191, 0.25)');
        } else {
            $(this).parents().eq(1).css('box-shadow', 'none');
        }
    })

    $(document).on('click', '.accordion-item .apply-btn', function () {
        $('.career-modal').addClass('active-career-modal');
        $('header').css('z-index', '1');
        $('body').css('overflow', 'hidden');
    })

    $(window).on('click', function (event) {
        let target = $(event.target);
        if (target.is('.container') || target.is('.career-modal')) {
            $('.career-modal').removeClass('active-career-modal');
            $('header').css('z-index', '99');
            $('body').css('overflow', 'auto');
        }
    })

    $(document).on('click', '.apply-form-close-icon', function () {
        $('.career-modal').removeClass('active-career-modal');
        $('header').css('z-index', '99');
        $('body').css('overflow', 'auto');
    })

    $(document).on('click', '.apply-btn', function () {
        if ($(this).attr('opportunityid')) {
            $('#fullName').val('');
            $('#email').val('');
            $('#cv-form-file').val('');
            $('#cv-form-file').siblings().eq(0).children().eq(0).removeClass('d-none');
            $('#cv-form-file').siblings().eq(0).children().eq(1).html('');
            $('#supportingFiles-form-file').val('');
            $('#supportingFiles-form-file').siblings().eq(0).children().eq(0).removeClass('d-none');
            $('#supportingFiles-form-file').siblings().eq(0).children().eq(1).html('');
            var opportunityId = $(this).attr('opportunityid');
            $('.apply-form #opportunityId').attr('value', opportunityId);
            var positionText = $(this).parents().eq(1).siblings().eq(0).children().eq(0).text();
            $('.apply-form #position').attr('value', positionText);
        }
    })

    var allowedExtension = [".docx", ".doc", ".pdf"];

    $('.form-file').change(function (e) {

        var hasCorrectFile = false;
        for (var i = 0; i < this.files.length; i++) {
            var file = this.files[i];
            for (var i = 0; i < allowedExtension.length; i++) {
                if (file.name.endsWith(allowedExtension[i])) {
                    hasCorrectFile = true;
                }
            }
        }

        if (hasCorrectFile) {
            var files = [];
            for (var i = 0; i < $(this)[0].files.length; i++) {
                files.push($(this)[0].files[i].name);
            }
            $(this).siblings().eq(0).children().eq(0).addClass('d-none');
            $(this).siblings().eq(0).children().eq(1).html(files.join(', '));
        }
        else {
            $(this).value = "";
            alert("Unsupported file selected.");
        }

    });
})