$(function () {
    if ($("#collapsePages a").hasClass("active")) {
        $("#collapsePages").parent().addClass("active");
        $("#collapsePages").siblings().eq(0).removeClass("collapsed");
        $("#collapsePages").addClass("show");
    }
    else if ($("#collapseTwo a").hasClass("active")) {
        $("#collapseTwo").parent().addClass("active");
        $("#collapseTwo").siblings().eq(0).removeClass("collapsed");
        $("#collapseTwo").addClass("show");
    }
})