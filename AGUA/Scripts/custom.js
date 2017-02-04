jQuery.noConflict();

(function ($) {
    $('html').removeClass('no-js').addClass('js');

    $(".Search").submit(function (e) {
        if ($("#contact").valid()) {
            $.post($(this).attr("action"),
                    $(this).serialize(),
                    function (data) {
                        "~/Views/Sublayouts/propertyResult.cshtml"
                        $("#yourContainer").load('/forms/searchcomponent_presult');
                    });
        }
        e.preventDefault();
    });
})(jQuery);
