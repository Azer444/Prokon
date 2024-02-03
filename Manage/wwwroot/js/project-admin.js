
$(function () {

        var conceptName = $('#Type :selected').text().toLowerCase();

        if (conceptName == 'current') {
            $('#CompletedDate').addClass('d-none');
            $('#CompletedDate').parents().eq(1).addClass('d-none');

            $('#PlannedCompletionDate').removeClass('d-none');
            $('#PlannedCompletionDate').parents().eq(1).removeClass('d-none');
        }
        else if (conceptName == 'completed') {
            $('#CurrentOrder').val('');
            $('#CurrentOrder').parents().eq(1).addClass('d-none');
            $('#OrderTitle').addClass('d-none');

            $('#PlannedCompletionDate').addClass('d-none');
            $('#PlannedCompletionDate').parents().eq(1).addClass('d-none');

            $('#CompletedDate').removeClass('d-none');
            $('#CompletedDate').parents().eq(1).removeClass('d-none');
        }


        $('#Type').on('change', function () {
            if (this.value == 'current') {
                $('#CurrentOrder').parents().eq(1).removeClass('d-none');
                $('#OrderTitle').removeClass('d-none');

                $('#CompletedDate').addClass('d-none');
                $('#CompletedDate').parents().eq(1).addClass('d-none');

                $('#PlannedCompletionDate').removeClass('d-none');
                $('#PlannedCompletionDate').parents().eq(1).removeClass('d-none');
            }
            else if (this.value == 'completed') {
                $('#CurrentOrder').val('');
                $('#CurrentOrder').parents().eq(1).addClass('d-none');
                $('#OrderTitle').addClass('d-none');

                $('#PlannedCompletionDate').addClass('d-none');
                $('#PlannedCompletionDate').parents().eq(1).addClass('d-none');

                $('#CompletedDate').removeClass('d-none');
                $('#CompletedDate').parents().eq(1).removeClass('d-none');
            }
        });

        $('#Name_EN').on('input', function () {
            $('#Slug').val(slug($(this).val()));
        });

        $('#ShowOnHomePageAsGallery').change(function () {
            if ($(this).is(':checked')) {
                $('#gallery-order').removeClass('d-none');
            }
            else {
                $('#gallery-order').addClass('d-none');
            }
        });

        $('#ShowAsGallery').change(function () {
            if ($(this).is(':checked')) {
                $('#home-page-as-gallery').removeClass('d-none');
            }
            else {
                $('#home-page-as-gallery').addClass('d-none');
                $('#gallery-order').addClass('d-none');
                $('#ShowOnHomePageAsGallery').prop('checked', false);
                $('#ShowOnHomePageAsGallery').prop('value', false);
            }
        });

        if ($('#ShowOnHomePageAsGallery').is(':checked')) {
            $('#gallery-order').removeClass('d-none');
        }
        else {
            $('#gallery-order').addClass('d-none');
        }
    })