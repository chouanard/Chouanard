

$(document).ready(function ()
{
    $('.mainContainer').hide();
    $(window).resize(function () {
        $('.mainContainer').css({
            position: 'absolute',
            left: ($(window).width() - $('.mainContainer').outerWidth()) / 2,
            top: ($(window).height() - $('.mainContainer').outerHeight()) / 2
        });
    });

    $(window).resize();

    
});


$(window).load(function () {
    $(window).resize();
    $('.mainContainer').show();
});